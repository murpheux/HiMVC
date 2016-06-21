using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using HiMVC.Data;

namespace HiMVC.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160617174034_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HiMVC.Models.Domain.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("AuthorID");
                });

            modelBuilder.Entity("HiMVC.Models.Domain.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorID");

                    b.Property<string>("Genre");

                    b.Property<decimal>("Price");

                    b.Property<int?>("StudentStudentId");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("BookId");
                });

            modelBuilder.Entity("HiMVC.Models.Domain.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Score");

                    b.Property<int?>("StudentStudentId");

                    b.Property<int>("Unit");

                    b.HasKey("CourseId");
                });

            modelBuilder.Entity("HiMVC.Models.Domain.Lecturer", b =>
                {
                    b.Property<int>("LecturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviated");

                    b.Property<int?>("CourseCourseId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("Rating");

                    b.Property<int>("Title");

                    b.HasKey("LecturerId");
                });

            modelBuilder.Entity("HiMVC.Models.Domain.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<float>("GPA");

                    b.Property<string>("LastName");

                    b.Property<int?>("LecturerLecturerId");

                    b.Property<string>("Nationality");

                    b.Property<string>("SexString")
                        .HasAnnotation("Relational:ColumnName", "Sex");

                    b.HasKey("StudentId");
                });

            modelBuilder.Entity("HiMVC.Models.Domain.Book", b =>
                {
                    b.HasOne("HiMVC.Models.Domain.Author")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("HiMVC.Models.Domain.Student")
                        .WithMany()
                        .HasForeignKey("StudentStudentId");
                });

            modelBuilder.Entity("HiMVC.Models.Domain.Course", b =>
                {
                    b.HasOne("HiMVC.Models.Domain.Student")
                        .WithMany()
                        .HasForeignKey("StudentStudentId");
                });

            modelBuilder.Entity("HiMVC.Models.Domain.Lecturer", b =>
                {
                    b.HasOne("HiMVC.Models.Domain.Course")
                        .WithMany()
                        .HasForeignKey("CourseCourseId");
                });

            modelBuilder.Entity("HiMVC.Models.Domain.Student", b =>
                {
                    b.HasOne("HiMVC.Models.Domain.Lecturer")
                        .WithMany()
                        .HasForeignKey("LecturerLecturerId");
                });
        }
    }
}
