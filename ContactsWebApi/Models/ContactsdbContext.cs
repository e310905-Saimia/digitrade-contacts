using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactsWebApi.Models
{
    public partial class ContactsdbContext : DbContext
    {
        public ContactsdbContext()
        {
        }

        public ContactsdbContext(DbContextOptions<ContactsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contact { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}