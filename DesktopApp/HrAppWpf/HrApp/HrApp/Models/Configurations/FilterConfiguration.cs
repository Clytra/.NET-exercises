using HrApp.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Models.Configurations
{
    class FilterConfiguration : EntityTypeConfiguration<Filter>
    {
        public FilterConfiguration()
        {
            ToTable("dbo.Filters");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption
                (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
