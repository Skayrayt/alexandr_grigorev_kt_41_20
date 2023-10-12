using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lab1_alexandr_grigorev_kt_41_20.Migrations
{
    /// <inheritdoc />
    public partial class qqeq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_groupname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_GroupId", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_subjectname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_SubjectId", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    c_student_secname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    c_student_groupid = table.Column<int>(type: "int4", maxLength: 100, nullable: false, comment: "Идентификатор группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_StudentId", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.c_student_groupid,
                        principalTable: "Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор успеваемости")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_gradenumber = table.Column<int>(type: "int4", nullable: false, comment: "Оценка"),
                    c_student_gradedate = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Дата оценки"),
                    c_student_subjectid = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор предмета"),
                    c_student_studentid = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор студента"),
                    StudentId1 = table.Column<int>(type: "integer", nullable: true),
                    SubjectId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_GradeId", x => x.grade_id);
                    table.ForeignKey(
                        name: "FK_Grade_Student_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Student",
                        principalColumn: "student_id");
                    table.ForeignKey(
                        name: "FK_Grade_Subjects_SubjectId1",
                        column: x => x.SubjectId1,
                        principalTable: "Subjects",
                        principalColumn: "subject_id");
                    table.ForeignKey(
                        name: "fk_f_student_id",
                        column: x => x.c_student_studentid,
                        principalTable: "Student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_subject_id",
                        column: x => x.c_student_subjectid,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    test_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор успеваемости (зачеты)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_testname = table.Column<string>(type: "varchar", nullable: false, comment: "Наименование зачета"),
                    c_student_dateoftest = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Дата зачета"),
                    c_student_testcondition = table.Column<string>(type: "varchar", nullable: false, comment: "Итог зачета"),
                    c_student_subjectid = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор предмета"),
                    c_student_studentid = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор студента"),
                    StudentId1 = table.Column<int>(type: "integer", nullable: true),
                    SubjectId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_TestId", x => x.test_id);
                    table.ForeignKey(
                        name: "FK_Test_Student_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Student",
                        principalColumn: "student_id");
                    table.ForeignKey(
                        name: "FK_Test_Subjects_SubjectId1",
                        column: x => x.SubjectId1,
                        principalTable: "Subjects",
                        principalColumn: "subject_id");
                    table.ForeignKey(
                        name: "fk_f_student_id",
                        column: x => x.c_student_studentid,
                        principalTable: "Student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_subject_id",
                        column: x => x.c_student_subjectid,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_(TableName)_fk_f_student_id",
                table: "Grade",
                column: "c_student_studentid");

            migrationBuilder.CreateIndex(
                name: "idx_(TableName)_fk_f_subject_id",
                table: "Grade",
                column: "c_student_subjectid");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentId1",
                table: "Grade",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SubjectId1",
                table: "Grade",
                column: "SubjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_c_student_groupid",
                table: "Student",
                column: "c_student_groupid");

            migrationBuilder.CreateIndex(
                name: "idx_(TableName)_fk_f_student_id1",
                table: "Test",
                column: "c_student_studentid");

            migrationBuilder.CreateIndex(
                name: "idx_(TableName)_fk_f_subject_id1",
                table: "Test",
                column: "c_student_subjectid");

            migrationBuilder.CreateIndex(
                name: "IX_Test_StudentId1",
                table: "Test",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Test_SubjectId1",
                table: "Test",
                column: "SubjectId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
