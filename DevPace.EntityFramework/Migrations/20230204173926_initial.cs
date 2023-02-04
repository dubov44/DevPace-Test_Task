using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevPace.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CustomerId", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CompanyName", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1L, "Company 1", "email1@mail.com", "Name 1", "1" },
                    { 2L, "Company 2", "email2@mail.com", "Name 2", "2" },
                    { 3L, "Company 3", "email3@mail.com", "Name 3", "3" },
                    { 4L, "Company 4", "email4@mail.com", "Name 4", "4" },
                    { 5L, "Company 5", "email5@mail.com", "Name 5", "5" },
                    { 6L, "Company 6", "email6@mail.com", "Name 6", "6" },
                    { 7L, "Company 7", "email7@mail.com", "Name 7", "7" },
                    { 8L, "Company 8", "email8@mail.com", "Name 8", "8" },
                    { 9L, "Company 9", "email9@mail.com", "Name 9", "9" },
                    { 10L, "Company 10", "email10@mail.com", "Name 10", "10" },
                    { 11L, "Company 11", "email11@mail.com", "Name 11", "11" },
                    { 12L, "Company 12", "email12@mail.com", "Name 12", "12" },
                    { 13L, "Company 13", "email13@mail.com", "Name 13", "13" },
                    { 14L, "Company 14", "email14@mail.com", "Name 14", "14" },
                    { 15L, "Company 15", "email15@mail.com", "Name 15", "15" },
                    { 16L, "Company 16", "email16@mail.com", "Name 16", "16" },
                    { 17L, "Company 17", "email17@mail.com", "Name 17", "17" },
                    { 18L, "Company 18", "email18@mail.com", "Name 18", "18" },
                    { 19L, "Company 19", "email19@mail.com", "Name 19", "19" },
                    { 20L, "Company 20", "email20@mail.com", "Name 20", "20" },
                    { 21L, "Company 21", "email21@mail.com", "Name 21", "21" },
                    { 22L, "Company 22", "email22@mail.com", "Name 22", "22" },
                    { 23L, "Company 23", "email23@mail.com", "Name 23", "23" },
                    { 24L, "Company 24", "email24@mail.com", "Name 24", "24" },
                    { 25L, "Company 25", "email25@mail.com", "Name 25", "25" },
                    { 26L, "Company 26", "email26@mail.com", "Name 26", "26" },
                    { 27L, "Company 27", "email27@mail.com", "Name 27", "27" },
                    { 28L, "Company 28", "email28@mail.com", "Name 28", "28" },
                    { 29L, "Company 29", "email29@mail.com", "Name 29", "29" },
                    { 30L, "Company 30", "email30@mail.com", "Name 30", "30" },
                    { 31L, "Company 31", "email31@mail.com", "Name 31", "31" },
                    { 32L, "Company 32", "email32@mail.com", "Name 32", "32" },
                    { 33L, "Company 33", "email33@mail.com", "Name 33", "33" },
                    { 34L, "Company 34", "email34@mail.com", "Name 34", "34" },
                    { 35L, "Company 35", "email35@mail.com", "Name 35", "35" },
                    { 36L, "Company 36", "email36@mail.com", "Name 36", "36" },
                    { 37L, "Company 37", "email37@mail.com", "Name 37", "37" },
                    { 38L, "Company 38", "email38@mail.com", "Name 38", "38" },
                    { 39L, "Company 39", "email39@mail.com", "Name 39", "39" },
                    { 40L, "Company 40", "email40@mail.com", "Name 40", "40" },
                    { 41L, "Company 41", "email41@mail.com", "Name 41", "41" },
                    { 42L, "Company 42", "email42@mail.com", "Name 42", "42" },
                    { 43L, "Company 43", "email43@mail.com", "Name 43", "43" },
                    { 44L, "Company 44", "email44@mail.com", "Name 44", "44" },
                    { 45L, "Company 45", "email45@mail.com", "Name 45", "45" },
                    { 46L, "Company 46", "email46@mail.com", "Name 46", "46" },
                    { 47L, "Company 47", "email47@mail.com", "Name 47", "47" },
                    { 48L, "Company 48", "email48@mail.com", "Name 48", "48" },
                    { 49L, "Company 49", "email49@mail.com", "Name 49", "49" },
                    { 50L, "Company 50", "email50@mail.com", "Name 50", "50" },
                    { 51L, "Company 51", "email51@mail.com", "Name 51", "51" },
                    { 52L, "Company 52", "email52@mail.com", "Name 52", "52" },
                    { 53L, "Company 53", "email53@mail.com", "Name 53", "53" },
                    { 54L, "Company 54", "email54@mail.com", "Name 54", "54" },
                    { 55L, "Company 55", "email55@mail.com", "Name 55", "55" },
                    { 56L, "Company 56", "email56@mail.com", "Name 56", "56" },
                    { 57L, "Company 57", "email57@mail.com", "Name 57", "57" },
                    { 58L, "Company 58", "email58@mail.com", "Name 58", "58" },
                    { 59L, "Company 59", "email59@mail.com", "Name 59", "59" },
                    { 60L, "Company 60", "email60@mail.com", "Name 60", "60" },
                    { 61L, "Company 61", "email61@mail.com", "Name 61", "61" },
                    { 62L, "Company 62", "email62@mail.com", "Name 62", "62" },
                    { 63L, "Company 63", "email63@mail.com", "Name 63", "63" },
                    { 64L, "Company 64", "email64@mail.com", "Name 64", "64" },
                    { 65L, "Company 65", "email65@mail.com", "Name 65", "65" },
                    { 66L, "Company 66", "email66@mail.com", "Name 66", "66" },
                    { 67L, "Company 67", "email67@mail.com", "Name 67", "67" },
                    { 68L, "Company 68", "email68@mail.com", "Name 68", "68" },
                    { 69L, "Company 69", "email69@mail.com", "Name 69", "69" },
                    { 70L, "Company 70", "email70@mail.com", "Name 70", "70" },
                    { 71L, "Company 71", "email71@mail.com", "Name 71", "71" },
                    { 72L, "Company 72", "email72@mail.com", "Name 72", "72" },
                    { 73L, "Company 73", "email73@mail.com", "Name 73", "73" },
                    { 74L, "Company 74", "email74@mail.com", "Name 74", "74" },
                    { 75L, "Company 75", "email75@mail.com", "Name 75", "75" },
                    { 76L, "Company 76", "email76@mail.com", "Name 76", "76" },
                    { 77L, "Company 77", "email77@mail.com", "Name 77", "77" },
                    { 78L, "Company 78", "email78@mail.com", "Name 78", "78" },
                    { 79L, "Company 79", "email79@mail.com", "Name 79", "79" },
                    { 80L, "Company 80", "email80@mail.com", "Name 80", "80" },
                    { 81L, "Company 81", "email81@mail.com", "Name 81", "81" },
                    { 82L, "Company 82", "email82@mail.com", "Name 82", "82" },
                    { 83L, "Company 83", "email83@mail.com", "Name 83", "83" },
                    { 84L, "Company 84", "email84@mail.com", "Name 84", "84" },
                    { 85L, "Company 85", "email85@mail.com", "Name 85", "85" },
                    { 86L, "Company 86", "email86@mail.com", "Name 86", "86" },
                    { 87L, "Company 87", "email87@mail.com", "Name 87", "87" },
                    { 88L, "Company 88", "email88@mail.com", "Name 88", "88" },
                    { 89L, "Company 89", "email89@mail.com", "Name 89", "89" },
                    { 90L, "Company 90", "email90@mail.com", "Name 90", "90" },
                    { 91L, "Company 91", "email91@mail.com", "Name 91", "91" },
                    { 92L, "Company 92", "email92@mail.com", "Name 92", "92" },
                    { 93L, "Company 93", "email93@mail.com", "Name 93", "93" },
                    { 94L, "Company 94", "email94@mail.com", "Name 94", "94" },
                    { 95L, "Company 95", "email95@mail.com", "Name 95", "95" },
                    { 96L, "Company 96", "email96@mail.com", "Name 96", "96" },
                    { 97L, "Company 97", "email97@mail.com", "Name 97", "97" },
                    { 98L, "Company 98", "email98@mail.com", "Name 98", "98" },
                    { 99L, "Company 99", "email99@mail.com", "Name 99", "99" },
                    { 100L, "Company 100", "email100@mail.com", "Name 100", "100" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
