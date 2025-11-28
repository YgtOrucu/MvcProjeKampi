using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class AboutConfig : EntityTypeConfiguration<About>
    {
        public AboutConfig()
        {
            HasKey(x => x.AboutID);
            Property(x => x.AboutID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AboutDetails1).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.AboutDetails2).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.AboutImage1).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.AboutImage2).HasColumnType("varchar").HasMaxLength(100);
        }
    }
}
