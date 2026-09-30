using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School_WepApi.Migrations
{
    /// <inheritdoc />
    public partial class inet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeLevel = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_students_classRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "classRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teachers_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MaxGrade = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subjects_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_subjects_teachers_TeacherId",
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
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enrollments_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollments_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "classRooms",
                columns: new[] { "Id", "Capacity", "GradeLevel", "Name" },
                values: new object[,]
                {
                    { 1, 30, 10, "Room 101" },
                    { 2, 30, 11, "Room 102" },
                    { 3, 30, 12, "Room 103" }
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Department of Mathematics", "Mathematics" },
                    { 2, "Department of Physics", "Physics" },
                    { 3, "Department of Chemistry", "Chemistry" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "ClassRoomId", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2000, 1, 1), "basil.mohamed@example.com", "Basil", "Mohamed", "01158589053" },
                    { 2, 2, new DateOnly(2001, 5, 15), "ahmed.ali@example.com", "Ahmed", "Ali", "01158589054" },
                    { 3, 3, new DateOnly(2002, 9, 20), "fatima.mohamed@example.com", "Fatima", "Mohamed", "01158589055" }
                });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", "John", "Doe", "01158589056", 50000 },
                    { 2, 2, "jane.smith@example.com", "Jane", "Smith", "01158589057", 55000 },
                    { 3, 3, "bob.johnson@example.com", "Bob", "Johnson", "01158589058", 60000 },
                    { 4, 1, "alice.williams@example.com", "Alice", "Williams", "01158589059", 52000 },
                    { 5, 2, "charlie.brown@example.com", "Charlie", "Brown", "01158589060", 58000 }
                });

            migrationBuilder.InsertData(
                table: "subjects",
                columns: new[] { "Id", "Description", "MaxGrade", "Name", "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Mathematics subject", 100, "Mathematics", null, 1 },
                    { 2, "Physics subject", 100, "Physics", null, 2 },
                    { 3, "Chemistry subject", 100, "Chemistry", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "enrollments",
                columns: new[] { "Id", "EnrollmentDate", "Grade", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, 1, 2 },
                    { 2, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 85m, 2, 1 },
                    { 3, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 88m, 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_StudentId_SubjectId",
                table: "enrollments",
                columns: new[] { "StudentId", "SubjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_SubjectId",
                table: "enrollments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_students_ClassRoomId",
                table: "students",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_StudentId",
                table: "subjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_TeacherId",
                table: "subjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_DepartmentId",
                table: "teachers",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "classRooms");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
