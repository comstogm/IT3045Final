using Microsoft.EntityFrameworkCore.Migrations;

namespace Comstock_Gabriel_Final.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakfastFoods",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodFullName = table.Column<string>(nullable: true),
                    FoodName = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    TimeToPrepare = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastFoods", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteMusic",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicFullName = table.Column<string>(nullable: true),
                    GenreName = table.Column<string>(nullable: true),
                    Instrument = table.Column<string>(nullable: true),
                    AverageLengthOfSong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteMusic", x => x.MusicId);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbyFullName = table.Column<string>(nullable: true),
                    CostOfHobby = table.Column<int>(nullable: false),
                    TypeOfHobby = table.Column<string>(nullable: true),
                    YearsDoingHobby = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<int>(nullable: false),
                    CollegeProgram = table.Column<string>(nullable: true),
                    YearInProgram = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastFoods");

            migrationBuilder.DropTable(
                name: "FavoriteMusic");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
