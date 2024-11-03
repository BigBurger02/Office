using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Office.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Audience",
                newName: "TeacherPhone");

            migrationBuilder.AddColumn<string>(
                name: "DeanEmail",
                table: "Deanery",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeanPhone",
                table: "Deanery",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Deanery",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cathedra",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Head",
                table: "Cathedra",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadEmail",
                table: "Cathedra",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadPhone",
                table: "Cathedra",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFloors",
                table: "Building",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YearBuilt",
                table: "Building",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudienceNumber",
                table: "Audience",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Audience",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "Audience",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Audience",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherEmail",
                table: "Audience",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeanEmail",
                table: "Deanery");

            migrationBuilder.DropColumn(
                name: "DeanPhone",
                table: "Deanery");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Deanery");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cathedra");

            migrationBuilder.DropColumn(
                name: "Head",
                table: "Cathedra");

            migrationBuilder.DropColumn(
                name: "HeadEmail",
                table: "Cathedra");

            migrationBuilder.DropColumn(
                name: "HeadPhone",
                table: "Cathedra");

            migrationBuilder.DropColumn(
                name: "NumberOfFloors",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "YearBuilt",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "AudienceNumber",
                table: "Audience");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Audience");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Audience");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Audience");

            migrationBuilder.DropColumn(
                name: "TeacherEmail",
                table: "Audience");

            migrationBuilder.RenameColumn(
                name: "TeacherPhone",
                table: "Audience",
                newName: "Number");
        }
    }
}
