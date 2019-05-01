using LangDriverApi.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LangDriverApi.DataAccess
{
    public sealed class LangDriverContext : DbContext
    {
        //Creating DataBase if not exist
        public LangDriverContext(DbContextOptions<LangDriverContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        //Db tables description
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(i => i.Id);
            modelBuilder.Entity<User>().Property(i => i.Id).IsRequired().HasColumnType("uniqueidentifier");
            modelBuilder.Entity<User>().Property(i => i.Login).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(i => i.Password).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<User>()
                .HasMany(w => w.WordsDictionary)
                //.WithOne(u => u.)
                ;


            modelBuilder.Entity<Word>().ToTable("Words");
            modelBuilder.Entity<Word>().HasKey(i => i.Id);
            modelBuilder.Entity<Word>().Property(i => i.Id).IsRequired().HasColumnType("uniqueidentifier");
            modelBuilder.Entity<Word>().Property(i => i.WordOrigin).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Word>().Property(i => i.Translate).IsRequired().HasMaxLength(100);
            //modelBuilder.Entity<Word>().HasOne(i => i.User).WithMany(i => i.WordsDictionary);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Word> Words { get; set; }
    }
}
