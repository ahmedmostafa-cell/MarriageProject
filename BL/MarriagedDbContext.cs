using System;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BL
{
    public partial class MarriagedDbContext : IdentityDbContext<ApplicationUser>
    {
        public MarriagedDbContext()
        {
        }

        public MarriagedDbContext(DbContextOptions<MarriagedDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbInitiativeRegisteredFamilyMember> TbInitiativeRegisteredFamilyMembers { get; set; }
        public virtual DbSet<TbInitiativeRegisteredUser> TbInitiativeRegisteredUsers { get; set; }
        public virtual DbSet<TbInitiativeTerm> TbInitiativeTerms { get; set; }
        public virtual DbSet<TbNormalUser> TbNormalUsers { get; set; }
        public virtual DbSet<TbSlider> TbSliders { get; set; }
        public virtual DbSet<VwRegisteredUser> VwRegisteredUsers { get; set; }

        public virtual DbSet<VwRegisteredUser2> VwRegisteredUsers2 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbInitiativeRegisteredFamilyMember>(entity =>
            {
                entity.HasKey(e => e.InitiativeRegisteredFamilyMemberId);

                entity.ToTable("TbInitiativeRegisteredFamilyMember");

                entity.Property(e => e.InitiativeRegisteredFamilyMemberId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.InitiativeRegisteredFamilyMemberAge).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberBiography).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberBirthDate).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberCertificate).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberFamilyName).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberImage).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberJob).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberJobCompany).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberMaritalStatus).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberName).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberPhoneNo).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredFamilyMemberUniversity).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });


            modelBuilder.Entity<VwRegisteredUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwRegisteredUser");


            });
            modelBuilder.Entity<VwRegisteredUser2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwRegisteredUser2");


            });

            modelBuilder.Entity<TbInitiativeRegisteredUser>(entity =>
            {
                entity.HasKey(e => e.InitiativeRegisteredUserId);

                entity.ToTable("TbInitiativeRegisteredUser");

                entity.Property(e => e.InitiativeRegisteredUserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.InitiativeRegisteredUserAge).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserBioigraphy).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserBirthDate).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserCertificate).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserFamilyName).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserImage).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserJob).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserJobCompany).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserMaritalStatus).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserName).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserPhoneNo).HasMaxLength(200);

                entity.Property(e => e.InitiativeRegisteredUserUniversity).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbInitiativeTerm>(entity =>
            {
                entity.HasKey(e => e.InitiativeTermId);

                entity.ToTable("TbInitiativeTerm");

                entity.Property(e => e.InitiativeTermId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.InitiativeTermImage).HasMaxLength(200);

                entity.Property(e => e.InitiativeTermText).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbNormalUser>(entity =>
            {
                entity.HasKey(e => e.NormalUserId);

                entity.ToTable("TbNormalUser");

                entity.Property(e => e.NormalUserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.NormalUserAge).HasMaxLength(200);

                entity.Property(e => e.NormalUserBioigraphy).HasMaxLength(200);

                entity.Property(e => e.NormalUserBirthDate).HasMaxLength(200);

                entity.Property(e => e.NormalUserCertificate).HasMaxLength(200);

                entity.Property(e => e.NormalUserFamilyName).HasMaxLength(200);

                entity.Property(e => e.NormalUserImage).HasMaxLength(200);

                entity.Property(e => e.NormalUserJob).HasMaxLength(200);

                entity.Property(e => e.NormalUserJobCompany).HasMaxLength(200);

                entity.Property(e => e.NormalUserMaritalStatus).HasMaxLength(200);

                entity.Property(e => e.NormalUserName).HasMaxLength(200);

                entity.Property(e => e.NormalUserPhoneNo).HasMaxLength(200);

                entity.Property(e => e.NormalUserUniversity).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSlider>(entity =>
            {
                entity.HasKey(e => e.SliderId);

                entity.ToTable("TbSlider");

                entity.Property(e => e.SliderId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.SliderImage).HasMaxLength(200);

                entity.Property(e => e.SliderText).HasMaxLength(200);

                entity.Property(e => e.SliderTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
