using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarinersApi.Migrations
{
    public partial class AddPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Average", "CreatorId", "Homerun", "Name", "Number", "OnBase", "Ops", "Slug" },
                values: new object[,]
                {
                    { 4, 0.25, null, 12, "Ty France", 23, 0.33700000000000002, 0.76200000000000001, 0.36599999999999999 },
                    { 5, 0.25800000000000001, null, 26, "Teoscar Hernandez", 35, 0.30499999999999999, 0.76200000000000001, 0.435 },
                    { 6, 0.23200000000000001, null, 22, "Eugenio Suarez", 28, 0.32300000000000001, 0.76200000000000001, 0.39100000000000001 },
                    { 7, 0.253, null, 11, "Jarred Kelenic", 29, 0.32700000000000001, 0.76200000000000001, 0.41899999999999998 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 7);
        }
    }
}
