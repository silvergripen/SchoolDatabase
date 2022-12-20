using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDatabase.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Adressid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Adressid);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Subjectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Classid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Subjectid);
                });

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Workid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Work = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Workid);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bday = table.Column<DateTime>(type: "date", nullable: false),
                    Klassid = table.Column<int>(type: "int", nullable: true),
                    Adressid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_Adress1",
                        column: x => x.Adressid,
                        principalTable: "Adress",
                        principalColumn: "Adressid");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Classid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Subjectid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Classid);
                    table.ForeignKey(
                        name: "FK_Classes_Subject",
                        column: x => x.Subjectid,
                        principalTable: "Subjects",
                        principalColumn: "Subjectid");
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    Jobid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bday = table.Column<DateTime>(type: "date", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: true),
                    Adressid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Jobid);
                    table.ForeignKey(
                        name: "FK_Personel_Adress",
                        column: x => x.Adressid,
                        principalTable: "Adress",
                        principalColumn: "Adressid");
                    table.ForeignKey(
                        name: "FK_Personel_Work",
                        column: x => x.WorkId,
                        principalTable: "Work",
                        principalColumn: "Workid");
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Subjectid = table.Column<int>(type: "int", nullable: true),
                    Studentid = table.Column<int>(type: "int", nullable: true),
                    Dateset = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grade_Student",
                        column: x => x.Studentid,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                    table.ForeignKey(
                        name: "FK_Grade_Subject1",
                        column: x => x.Subjectid,
                        principalTable: "Subjects",
                        principalColumn: "Subjectid");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    Subjectid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.StudentSubjectId);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student",
                        column: x => x.studentid,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subjects",
                        column: x => x.Subjectid,
                        principalTable: "Subjects",
                        principalColumn: "Subjectid");
                });

            migrationBuilder.CreateTable(
                name: "StudentClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentClass_Classes",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Classid");
                    table.ForeignKey(
                        name: "FK_StudentClass_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "PersonelClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Personelid = table.Column<int>(type: "int", nullable: true),
                    Classid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelClasses_Classes",
                        column: x => x.Classid,
                        principalTable: "Classes",
                        principalColumn: "Classid");
                    table.ForeignKey(
                        name: "FK_PersonelClasses_Personel",
                        column: x => x.Id,
                        principalTable: "Personel",
                        principalColumn: "Jobid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Subjectid",
                table: "Classes",
                column: "Subjectid");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Studentid",
                table: "Grade",
                column: "Studentid");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Subjectid",
                table: "Grade",
                column: "Subjectid");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_Adressid",
                table: "Personel",
                column: "Adressid");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_WorkId",
                table: "Personel",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelClasses_Classid",
                table: "PersonelClasses",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Adressid",
                table: "Student",
                column: "Adressid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_ClassId",
                table: "StudentClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_StudentId",
                table: "StudentClass",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_studentid",
                table: "StudentSubject",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_Subjectid",
                table: "StudentSubject",
                column: "Subjectid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "PersonelClasses");

            migrationBuilder.DropTable(
                name: "StudentClass");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Adress");
        }
    }
}
