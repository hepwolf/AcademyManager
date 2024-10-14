﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyManager.Migrations
{
    /// <inheritdoc />
    public partial class manageriswork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "UserAccunt",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "UserAccunt");
        }
    }
}
