using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalorhytm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixFoodIdIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraints that reference FoodId
            migrationBuilder.DropForeignKey(
                name: "FK_MealEntry_Food_FoodId",
                table: "MealEntry");

            // Create a new table without IDENTITY
            migrationBuilder.CreateTable(
                name: "Food_Temp",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Fiber = table.Column<double>(type: "float", nullable: false),
                    Sugar = table.Column<double>(type: "float", nullable: false),
                    Sodium = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServingSize = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food_Temp", x => x.FoodId);
                });

            // Copy data from old table to new table
            migrationBuilder.Sql(@"
                INSERT INTO Food_Temp (FoodId, Name, Calories, Protein, Carbohydrates, Fat, Fiber, Sugar, Sodium, Unit, ServingSize)
                SELECT FoodId, Name, Calories, Protein, Carbohydrates, Fat, Fiber, Sugar, Sodium, Unit, ServingSize
                FROM Food;
            ");

            // Drop old table
            migrationBuilder.DropTable(
                name: "Food");

            // Rename new table to original name
            migrationBuilder.RenameTable(
                name: "Food_Temp",
                newName: "Food");

            // Recreate foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_MealEntry_Food_FoodId",
                table: "MealEntry",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_MealEntry_Food_FoodId",
                table: "MealEntry");

            // Create table with IDENTITY
            migrationBuilder.CreateTable(
                name: "Food_Temp",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Fiber = table.Column<double>(type: "float", nullable: false),
                    Sugar = table.Column<double>(type: "float", nullable: false),
                    Sodium = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServingSize = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food_Temp", x => x.FoodId);
                });

            // Copy data (FoodId will be regenerated)
            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT Food_Temp ON;
                INSERT INTO Food_Temp (FoodId, Name, Calories, Protein, Carbohydrates, Fat, Fiber, Sugar, Sodium, Unit, ServingSize)
                SELECT FoodId, Name, Calories, Protein, Carbohydrates, Fat, Fiber, Sugar, Sodium, Unit, ServingSize
                FROM Food;
                SET IDENTITY_INSERT Food_Temp OFF;
            ");

            // Drop old table
            migrationBuilder.DropTable(
                name: "Food");

            // Rename new table
            migrationBuilder.RenameTable(
                name: "Food_Temp",
                newName: "Food");

            // Recreate foreign key
            migrationBuilder.AddForeignKey(
                name: "FK_MealEntry_Food_FoodId",
                table: "MealEntry",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
