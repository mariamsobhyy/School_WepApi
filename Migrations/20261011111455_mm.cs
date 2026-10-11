using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School_WepApi.Migrations
{
    /// <inheritdoc />
    public partial class mm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentProfiles_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreditHours = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses_teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enrollments_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollments_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "BirthDate", "Email", "FullName", "Gender", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.hassan@school.com", "Ali Hassan", "Male", "01011111111" },
                    { 2, new DateTime(2010, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariam.ahmed@school.com", "Mariam Ahmed", "Female", "01022222222" },
                    { 3, new DateTime(2009, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.khaled@school.com", "Omar Khaled", "Male", "01033333333" }
                });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "Phone" },
                values: new object[,]
                {
                    { 1, "ahmed.samir@school.com", "Ahmed Samir", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01044444444" },
                    { 2, "nour.adel@school.com", "Nour Adel", new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01055555555" },
                    { 3, "hany.mostafa@school.com", "Hany Mostafa", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01066666666" }
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "CreditHours", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 1, 3, 1, "Programming Fundamentals" },
                    { 2, 4, 2, "Database Systems" },
                    { 3, 3, 1, "Web Development" }
                });

            migrationBuilder.InsertData(
                table: "studentProfiles",
                columns: new[] { "Id", "Address", "EmergencyContact", "ParentPhone", "studentId" },
                values: new object[,]
                {
                    { 1, "Nasr City, Cairo", "01211111111", "01111111111", 1 },
                    { 2, "Heliopolis, Cairo", "01222222222", "01122222222", 2 },
                    { 3, "Maadi, Cairo", "01233333333", "01133333333", 3 }
                });

            migrationBuilder.InsertData(
                table: "enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.00m, 1 },
                    { 2, 2, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.50m, 2 },
                    { 3, 3, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_TeacherId",
                table: "courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_CourseId",
                table: "enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_StudentId_CourseId",
                table: "enrollments",
                columns: new[] { "StudentId", "CourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentProfiles_studentId",
                table: "studentProfiles",
                column: "studentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_students_Email",
                table: "students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teachers_Email",
                table: "teachers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "studentProfiles");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
