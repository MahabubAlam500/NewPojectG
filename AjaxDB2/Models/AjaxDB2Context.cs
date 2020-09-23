using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AjaxDB2.Models
{
    public partial class AjaxDB2Context : DbContext
    {
        internal IEnumerable<object> district;

        public AjaxDB2Context()
        {
        }

        public AjaxDB2Context(DbContextOptions<AjaxDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<DivList> DivLists { get; set; }
        public virtual DbSet<Upazila> Upazilas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("Server=LAPTOP-OG2CS5PK\\SQLEXPRESS;Database=AjaxDB2;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.Property(e => e.DivListId).HasColumnName("DivListID");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.DivList)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.DivListId);
            });

            modelBuilder.Entity<DivList>(entity =>
            {
                entity.ToTable("divList");
            });

            modelBuilder.Entity<Upazila>(entity =>
            {
                entity.ToTable("Upazila");

                entity.Property(e => e.DistrictId).HasColumnName("districtId");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Upazilas)
                    .HasForeignKey(d => d.DistrictId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
