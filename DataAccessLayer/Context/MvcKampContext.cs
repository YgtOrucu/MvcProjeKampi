using DataAccessLayer.Configurations;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class MvcKampContext:DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImagesFile> ImagesFiles  { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AboutConfig());

            #region Category
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryID);
            modelBuilder.Entity<Category>().Property(x => x.CategoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Category>().Property(x => x.CategoryName).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Category>().Property(x => x.CategoryDescription).HasColumnType("varchar").HasMaxLength(200);
            #endregion

            #region Contact
            modelBuilder.Entity<Contact>().HasKey(x => x.ContactID);
            modelBuilder.Entity<Contact>().Property(x => x.ContactID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Contact>().Property(x => x.UserName).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Contact>().Property(x => x.UserMail).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Contact>().Property(x => x.Subject).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Contact>().Property(x => x.Message).HasColumnType("varchar").HasMaxLength(1000);
            modelBuilder.Entity<Contact>().Property(x => x.ContactDate).HasColumnType("date");
            #endregion

            #region Content
            modelBuilder.Entity<Content>().HasKey(x => x.ContentID);
            modelBuilder.Entity<Content>().Property(x => x.ContentID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Content>().Property(x => x.ContentValue).HasColumnType("varchar").HasMaxLength(1000);
            modelBuilder.Entity<Content>().Property(x => x.ContentDate).HasColumnType("date");
            #endregion

            #region Heading
            modelBuilder.Entity<Heading>().HasKey(x => x.HeadingID);
            modelBuilder.Entity<Heading>().Property(x => x.HeadingID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Heading>().Property(x => x.HeadingName).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Heading>().Property(x => x.HeadingDate).HasColumnType("date");
            #endregion

            #region Writer
            modelBuilder.Entity<Writer>().HasKey(x => x.WriterID);
            modelBuilder.Entity<Writer>().Property(x => x.WriterID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Writer>().Property(x => x.WriterName).HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Writer>().Property(x => x.WriterSurname).HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Writer>().Property(x => x.WriterImage).HasColumnType("varchar").HasMaxLength(250);
            modelBuilder.Entity<Writer>().Property(x => x.WriterAbout).HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<Writer>().Property(x => x.WriterMail).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Writer>().Property(x => x.WriterPassword).HasColumnType("varchar").HasMaxLength(200);
            #endregion

            #region Message
            modelBuilder.Entity<Message>().HasKey(x => x.MessageID);
            modelBuilder.Entity<Message>().Property(x => x.MessageID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Message>().Property(x => x.SenderMail).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Message>().Property(x => x.ReceiverMail).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Message>().Property(x => x.MessageSubject).HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<Message>().Property(x => x.MessageContent).HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<Message>().Property(x => x.MessageDate).HasColumnType("date");
            #endregion

            #region ImagesFile
            modelBuilder.Entity<ImagesFile>().HasKey(x => x.ImagesID);
            modelBuilder.Entity<ImagesFile>().Property(x => x.ImagesID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ImagesFile>().Property(x => x.Name).HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<ImagesFile>().Property(x => x.Path).HasColumnType("varchar").HasMaxLength(1000);
            #endregion
        }
    }
}
