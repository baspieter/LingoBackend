using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lingo.Migrations
{
    public partial class InitializedProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "final_word",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_final_word", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "word",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_word", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    round = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    final_word_progress = table.Column<List<char>>(type: "character(1)[]", nullable: false),
                    green_balls = table.Column<int>(type: "integer", nullable: false),
                    red_balls = table.Column<int>(type: "integer", nullable: false),
                    final_word_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_final_word_final_word_id",
                        column: x => x.final_word_id,
                        principalTable: "final_word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_word",
                columns: table => new
                {
                    word_id = table.Column<int>(type: "integer", nullable: false),
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    finished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_word", x => new { x.game_id, x.word_id });
                    table.ForeignKey(
                        name: "fk_game_word_game_game_id",
                        column: x => x.game_id,
                        principalTable: "game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_word_word_word_id",
                        column: x => x.word_id,
                        principalTable: "word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_word_progress",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    game_word_id = table.Column<int>(type: "integer", nullable: false),
                    game_word_game_id = table.Column<int>(type: "integer", nullable: false),
                    game_word_word_id = table.Column<int>(type: "integer", nullable: false),
                    word_progress = table.Column<List<string>>(type: "text[]", nullable: false),
                    letter_progress = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_word_progress", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_word_progress_game_word_game_word_game_id_game_word_wo",
                        columns: x => new { x.game_word_game_id, x.game_word_word_id },
                        principalTable: "game_word",
                        principalColumns: new[] { "game_id", "word_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_final_word_id",
                table: "game",
                column: "final_word_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_word_word_id",
                table: "game_word",
                column: "word_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_word_progress_game_word_game_id_game_word_word_id",
                table: "game_word_progress",
                columns: new[] { "game_word_game_id", "game_word_word_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_word_progress");

            migrationBuilder.DropTable(
                name: "game_word");

            migrationBuilder.DropTable(
                name: "game");

            migrationBuilder.DropTable(
                name: "word");

            migrationBuilder.DropTable(
                name: "final_word");
        }
    }
}
