
using LibraryWithWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWithWebApiConsole.Store
{
    public  class LibraryContext:DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public LibraryContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(_connectionString,m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IssueBook>()
                .HasKey(ib => new { ib.StudentId, ib.bookId });

            builder.Entity<IssueBook>()
                .HasOne(ib => ib.Student)
                .WithMany(i => i.BookIssues)
                .HasForeignKey(ib => ib.StudentId);

            builder.Entity<ReturnBook>()
               .HasKey(rb => new { rb.StudentId, rb.bookId });

            builder.Entity<ReturnBook>()
                .HasOne(rb => rb.Student)
                .WithMany(rb => rb.BookReturns);

            base.OnModelCreating(builder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<IssueBook> IssueBooks { get; set; }
        public DbSet<ReturnBook> ReturnBooks { get; set; }


    }
}


