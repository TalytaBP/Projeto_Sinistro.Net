using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSinistroAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PacienteSP3",
                columns: table => new
                {
                    Paciente_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_Paciente = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email_Paciente = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteSP3", x => x.Paciente_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacienteSP3");
        }
    }
}
