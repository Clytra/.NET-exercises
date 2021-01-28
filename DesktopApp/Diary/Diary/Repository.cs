using Diary.Models.Domains;
using Diary.Models.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Diary.Models.Converters;
using Diary.Models;
using System;
using Diary.Properties;
using System.Data.SqlClient;
using System.Windows;

namespace Diary
{
    public class Repository
    {
        public List<Group> GetGroups()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Groups.ToList();
            }
        }

        public List<StudentWrapper> GetStudents(int groupId)
        {
            using (var context = new ApplicationDbContext())
            {
                var students = context
                    .Students
                    .Include(x => x.Group)
                    .Include(x => x.Ratings)
                    .AsQueryable();

                if (groupId != 0)
                    students = students.Where(x => x.GroupId == groupId);

                return students.ToList().Select(x => x.ToWrapper()).ToList();
            }
        }

        public void DeleteStudent(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var studentToDelete = context.Students.Find(id);
                context.Students.Remove(studentToDelete);
                context.SaveChanges();
            }
        }

        public void UpdateStudent(StudentWrapper studentWrapper)
        {
            var student = studentWrapper.ToDao();
            var ratings = studentWrapper.ToRatingDao();

            using (var context = new ApplicationDbContext())
            {
                UpdateStudentProperties(context, student);

                var studentsRatings = GetStudentsRatings(context, student);

                UpdateRate(student, ratings, context, studentsRatings, 
                    Subject.Math);
                UpdateRate(student, ratings, context, studentsRatings, 
                    Subject.ForeignLang);
                UpdateRate(student, ratings, context, studentsRatings, 
                    Subject.Physics);
                UpdateRate(student, ratings, context, studentsRatings, 
                    Subject.PolishLang);
                UpdateRate(student, ratings, context, studentsRatings, 
                    Subject.Technology);

                context.SaveChanges();
            }
        }

        private void UpdateStudentProperties(ApplicationDbContext context, Student student)
        {
            var studentToUpdate = context.Students.Find(student.Id);
            studentToUpdate.Activities = student.Activities;
            studentToUpdate.Comments = student.Comments;
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.GroupId = student.GroupId;
        }

        private static List<Rating> GetStudentsRatings(ApplicationDbContext context, Student student)
        {
            return context.Ratings
                    .Where(x => x.StudentId == student.Id)
                    .ToList();
        }

        private static void UpdateRate(Student student, List<Rating> newRatings,
            ApplicationDbContext context, List<Rating> studentsRatings, Subject subject) 
        {
            var subRatings = studentsRatings
                    .Where(x => x.SubjectId == (int)subject)
                    .Select(x => x.Rate);

            var newSubRatings = newRatings
                .Where(x => x.SubjectId == (int)subject)
                .Select(x => x.Rate);

            var subRatingsToDelete = subRatings.Except(newSubRatings).ToList();
            var subRatingsToAdd = newSubRatings.Except(subRatings).ToList();

            subRatingsToDelete.ForEach(x =>
            {
                var ratingsToDelete = context
                .Ratings
                .First(
                    y => y.Rate == x &&
                    y.StudentId == student.Id &&
                    y.SubjectId == (int)subject);

                context.Ratings.Remove(ratingsToDelete);
            });

            subRatingsToAdd.ForEach(x =>
            {
                var ratingToAdd = new Rating
                {
                    Rate = x,
                    StudentId = student.Id,
                    SubjectId = (int)subject
                };
                context.Ratings.Add(ratingToAdd);
            });
        }

        public void AddStudent(StudentWrapper studentWrapper)
        {
            var student = studentWrapper.ToDao();
            var ratings = studentWrapper.ToRatingDao();

            using (var context = new ApplicationDbContext())
            {
                var dbStudent = context.Students.Add(student);

                ratings.ForEach(x =>
                {
                    x.StudentId = dbStudent.Id;
                    context.Ratings.Add(x);
                });

                context.SaveChanges();
            }
        }

        public int ConnectToDb()
        {
            ServerWrapper settings = new ServerWrapper
            {
                ServerAddress = Settings.Default.ServerAddress,
                ServerName = Settings.Default.ServerName,
                DbName = Settings.Default.DbName,
                UserName = Settings.Default.UserName,
                Password = Settings.Default.Password
            };

            if (settings.IsValid)
            {
                try
                {
                    SqlConnection thisConnection = new SqlConnection
                        ($@"Server=({settings.ServerAddress})\{settings.ServerName};Database={settings.DbName};User Id={settings.UserName};Password={settings.Password};App=EntityFramework");
                    thisConnection.Open();
                    return 1;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                var window = MessageBox
                    .Show("Nie ustanowiono połączenia z bazą danych. Czy chcesz nawiązań nowe połączenie?", 
                    "Brak połączenia", 
                    MessageBoxButton.YesNo);

                if (window.Equals("No"))
                {
                    return (int)ConnectionStatus.CONNECTION_CANCELLED_BY_USER;
                }
                else
                {
                    return (int)ConnectionStatus.USER_ATTEMPTING_TO_CONNECT;
                }
            }
        }
    }
}
