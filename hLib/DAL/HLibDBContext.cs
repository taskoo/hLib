using hLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace hLib.DAL
{
    public class HLibDBContext : DbContext
    {
        public HLibDBContext() : base("name=HLibDBContext")
        {
        }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Book>()
                .HasMany(c => c.Authors).WithMany(i => i.Books)
                .Map(t => t.MapLeftKey("Book_Id")
                    .MapRightKey("Author_Id")
                    .ToTable("BookAuthors"));
        }

    }
}

