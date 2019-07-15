using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TripPlanner.DAL.Entities;

namespace TripPlanner.DAL.Models
{
    public partial class TripPlannerDBContext : DbContext
    {
        public TripPlannerDBContext()
        {
        }

        public TripPlannerDBContext(DbContextOptions<TripPlannerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Stay> Stays { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WebLink> WebLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=TripPlannerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TripId);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocumentType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsPublic)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.TripId);
                    
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stay>(entity =>
            {
                entity.Property(e => e.Detail)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.Detail)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Stay)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.StayId);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.CreatedById);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebLink>(entity =>
            {
                entity.Property(e => e.Link)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.WebLinks)
                    .HasForeignKey(d => d.TripId);
            });
        }
    }
}
