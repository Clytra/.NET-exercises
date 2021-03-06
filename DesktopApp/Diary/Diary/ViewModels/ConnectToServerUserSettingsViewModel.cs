﻿using Diary.Commands;
using Diary.Models.Domains;
using Diary.Models.Wrappers;
using Diary.Properties;
using Diary.Views;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Diary.ViewModels
{
    public class ConnectToServerUserSettingsViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        public ConnectToServerUserSettingsViewModel(Server server = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);
            SettingsCommand = new RelayCommand(SetServerConnection);

            if (server == null)
            {
                Server = new Server();
            }
            else
            {
                Server = server;
            }
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public static string ConnectionString { get; set; }
        public bool IsConnected { get; set; }

        private void Confirm(object obj)
        {
            IsConnected = CheckConnection();
            if (IsConnected)
            {
                var result = MessageBox
                    .Show("Udało się nawiązać połączenie." +
                    " Aplikacja zostanie uruchomiona ponownie.",
                    "Sukces",
                    MessageBoxButton.OK);

                SaveSettings();
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else
            {
                CloseWindow(obj as Window);
                var result = MessageBox
                    .Show("Nie udało się nawiązać połączenia." +
                    " Czy chcesz zmienić ustawienia?",
                    "Błąd połączenia",
                    MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    SetServerConnection(obj as Server);
                }
                else
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private Server _server;

        public Server Server
        {
            get { return _server; }
            set
            {
                _server = value;
                OnPropertyChanged();
            }
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }

        private void SetServerConnection(object obj)
        {
            var connectToServerUserSettingsWindow = new ConnectToServerUserSettingsView(obj as Server);
            connectToServerUserSettingsWindow.ShowDialog();
        }

        private bool CheckConnection()
        {
            var connectionString = ServerWrapper.GetConnectionString();

            try
            {
                SqlConnection testConnection = new SqlConnection(connectionString);
                testConnection.Open();
                testConnection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SaveSettings()
        {
            Settings.Default.ServerAddress = Server.ServerAddress;
            Settings.Default.ServerName = Server.ServerName;
            Settings.Default.DbName = Server.DbName;
            Settings.Default.UserName = Server.UserName;
            Settings.Default.Password = Server.Password;
            Settings.Default.Save();
        }
    }
}
