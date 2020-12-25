using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerDiary.TestApp.EntityFrameworkCore.Migrations
{
    public partial class StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedures = Directory.GetFiles(AppContext.BaseDirectory + "\\Sql\\Stored Procedures");

            foreach (var procedure in procedures)
            {
                var query = File.ReadAllText(procedure);
                migrationBuilder.Sql(query);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //todo: if procedures exist, drop
        }
    }
}
