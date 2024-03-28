﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleAts.Data;

namespace SimpleAts.Migrations
{
  [DbContext(typeof(SimpleAtsContext))]
  internal partial class SimpleAtsContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
        .HasAnnotation("Relational:MaxIdentifierLength", 128)
        .HasAnnotation("ProductVersion", "5.0.5")
        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

      modelBuilder.Entity("JobVacancyUser", b =>
      {
        b.Property<int>("CandidatesId")
          .HasColumnType("int")
          .HasColumnName("candidates_id");

        b.Property<int>("VacanciesAppliedId")
          .HasColumnType("int")
          .HasColumnName("vacancies_applied_id");

        b.HasKey("CandidatesId", "VacanciesAppliedId")
          .HasName("pk_job_vacancy_user");

        b.HasIndex("VacanciesAppliedId")
          .HasDatabaseName("ix_job_vacancy_user_vacancies_applied_id");

        b.ToTable("job_vacancy_user");
      });

      modelBuilder.Entity("PermissionRole", b =>
      {
        b.Property<int>("RolePermissionsId")
          .HasColumnType("int")
          .HasColumnName("role_permissions_id");

        b.Property<int>("RolesId")
          .HasColumnType("int")
          .HasColumnName("roles_id");

        b.HasKey("RolePermissionsId", "RolesId")
          .HasName("pk_permission_role");

        b.HasIndex("RolesId")
          .HasDatabaseName("ix_permission_role_roles_id");

        b.ToTable("permission_role");
      });

      modelBuilder.Entity("SimpleAts.Domains.Jobs.JobVacancy", b =>
      {
        b.Property<int>("Id")
          .ValueGeneratedOnAdd()
          .HasColumnType("int")
          .HasColumnName("id")
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        b.Property<string>("Description")
          .IsRequired()
          .HasMaxLength(1000)
          .HasColumnType("nvarchar(1000)")
          .HasColumnName("description");

        b.Property<string>("Name")
          .IsRequired()
          .HasMaxLength(100)
          .HasColumnType("nvarchar(100)")
          .HasColumnName("name");

        b.HasKey("Id")
          .HasName("pk_job_vacancies");

        b.ToTable("job_vacancies");
      });

      modelBuilder.Entity("SimpleAts.Domains.Users.Permission", b =>
      {
        b.Property<int>("Id")
          .ValueGeneratedOnAdd()
          .HasColumnType("int")
          .HasColumnName("id")
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        b.Property<string>("Code")
          .IsRequired()
          .HasMaxLength(100)
          .HasColumnType("nvarchar(100)")
          .HasColumnName("code");

        b.Property<string>("Description")
          .HasMaxLength(255)
          .HasColumnType("nvarchar(255)")
          .HasColumnName("description");

        b.HasKey("Id")
          .HasName("pk_permissions");

        b.HasIndex("Code")
          .IsUnique()
          .HasDatabaseName("ix_permissions_code");

        b.ToTable("permissions");
      });

      modelBuilder.Entity("SimpleAts.Domains.Users.Role", b =>
      {
        b.Property<int>("Id")
          .ValueGeneratedOnAdd()
          .HasColumnType("int")
          .HasColumnName("id")
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        b.Property<string>("Name")
          .IsRequired()
          .HasMaxLength(15)
          .HasColumnType("nvarchar(15)")
          .HasColumnName("name");

        b.HasKey("Id")
          .HasName("pk_roles");

        b.ToTable("roles");
      });

      modelBuilder.Entity("SimpleAts.Domains.Users.User", b =>
      {
        b.Property<int>("Id")
          .ValueGeneratedOnAdd()
          .HasColumnType("int")
          .HasColumnName("id")
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        b.Property<string>("Curriculum")
          .HasMaxLength(1000)
          .HasColumnType("nvarchar(1000)")
          .HasColumnName("curriculum");

        b.Property<string>("Email")
          .IsRequired()
          .HasMaxLength(50)
          .HasColumnType("nvarchar(50)")
          .HasColumnName("email");

        b.Property<string>("Name")
          .IsRequired()
          .HasMaxLength(30)
          .HasColumnType("nvarchar(30)")
          .HasColumnName("name");

        b.Property<string>("Password")
          .IsRequired()
          .HasMaxLength(76)
          .HasColumnType("nvarchar(76)")
          .HasColumnName("password");

        b.Property<int>("RoleId")
          .HasColumnType("int")
          .HasColumnName("role_id");

        b.HasKey("Id")
          .HasName("pk_users");

        b.HasIndex("Email")
          .IsUnique()
          .HasDatabaseName("ix_users_email");

        b.HasIndex("RoleId")
          .HasDatabaseName("ix_users_role_id");

        b.ToTable("users");
      });

      modelBuilder.Entity("JobVacancyUser", b =>
      {
        b.HasOne("SimpleAts.Domains.Users.User", null)
          .WithMany()
          .HasForeignKey("CandidatesId")
          .HasConstraintName("fk_job_vacancy_user_users_candidates_id")
          .OnDelete(DeleteBehavior.Cascade)
          .IsRequired();

        b.HasOne("SimpleAts.Domains.Jobs.JobVacancy", null)
          .WithMany()
          .HasForeignKey("VacanciesAppliedId")
          .HasConstraintName("fk_job_vacancy_user_job_vacancies_vacancies_applied_id")
          .OnDelete(DeleteBehavior.Cascade)
          .IsRequired();
      });

      modelBuilder.Entity("PermissionRole", b =>
      {
        b.HasOne("SimpleAts.Domains.Users.Permission", null)
          .WithMany()
          .HasForeignKey("RolePermissionsId")
          .HasConstraintName("fk_permission_role_permissions_role_permissions_id")
          .OnDelete(DeleteBehavior.Cascade)
          .IsRequired();

        b.HasOne("SimpleAts.Domains.Users.Role", null)
          .WithMany()
          .HasForeignKey("RolesId")
          .HasConstraintName("fk_permission_role_roles_roles_id")
          .OnDelete(DeleteBehavior.Cascade)
          .IsRequired();
      });

      modelBuilder.Entity("SimpleAts.Domains.Users.User", b =>
      {
        b.HasOne("SimpleAts.Domains.Users.Role", "Role")
          .WithMany()
          .HasForeignKey("RoleId")
          .HasConstraintName("fk_users_roles_role_id")
          .OnDelete(DeleteBehavior.Cascade)
          .IsRequired();

        b.Navigation("Role");
      });
#pragma warning restore 612, 618
    }
  }
}
