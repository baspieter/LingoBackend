﻿// <auto-generated />
using Lingo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lingo.Migrations
{
    [DbContext(typeof(LingoContext))]
    partial class LingoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lingo.Models.FinalWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_final_word");

                    b.ToTable("final_word", (string)null);
                });

            modelBuilder.Entity("Lingo.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FinalWordId")
                        .HasColumnType("integer")
                        .HasColumnName("final_word_id");

                    b.Property<string>("FinalWordProgress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("final_word_progress");

                    b.Property<int>("Round")
                        .HasColumnType("integer")
                        .HasColumnName("round");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int>("Timer")
                        .HasColumnType("integer")
                        .HasColumnName("timer");

                    b.HasKey("Id")
                        .HasName("pk_game");

                    b.HasIndex("FinalWordId")
                        .HasDatabaseName("ix_game_final_word_id");

                    b.ToTable("game", (string)null);
                });

            modelBuilder.Entity("Lingo.Models.GameWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Finished")
                        .HasColumnType("boolean")
                        .HasColumnName("finished");

                    b.Property<int>("GameId")
                        .HasColumnType("integer")
                        .HasColumnName("game_id");

                    b.Property<int>("WordId")
                        .HasColumnType("integer")
                        .HasColumnName("word_id");

                    b.HasKey("Id")
                        .HasName("pk_game_word");

                    b.HasIndex("GameId")
                        .HasDatabaseName("ix_game_word_game_id");

                    b.HasIndex("WordId")
                        .HasDatabaseName("ix_game_word_word_id");

                    b.ToTable("game_word", (string)null);
                });

            modelBuilder.Entity("Lingo.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_word");

                    b.ToTable("word", (string)null);
                });

            modelBuilder.Entity("Lingo.Models.WordEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GameWordId")
                        .HasColumnType("integer")
                        .HasColumnName("game_word_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_word_entry");

                    b.HasIndex("GameWordId")
                        .HasDatabaseName("ix_word_entry_game_word_id");

                    b.ToTable("word_entry", (string)null);
                });

            modelBuilder.Entity("Lingo.Models.Game", b =>
                {
                    b.HasOne("Lingo.Models.FinalWord", "FinalWord")
                        .WithMany("Games")
                        .HasForeignKey("FinalWordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_game_final_word_final_word_id");

                    b.Navigation("FinalWord");
                });

            modelBuilder.Entity("Lingo.Models.GameWord", b =>
                {
                    b.HasOne("Lingo.Models.Game", "Game")
                        .WithMany("GameWords")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_game_word_game_game_id");

                    b.HasOne("Lingo.Models.Word", "Word")
                        .WithMany("GameWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_game_word_word_word_id");

                    b.Navigation("Game");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Lingo.Models.WordEntry", b =>
                {
                    b.HasOne("Lingo.Models.GameWord", "GameWord")
                        .WithMany("WordEntries")
                        .HasForeignKey("GameWordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_word_entry_game_word_game_word_id");

                    b.Navigation("GameWord");
                });

            modelBuilder.Entity("Lingo.Models.FinalWord", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Lingo.Models.Game", b =>
                {
                    b.Navigation("GameWords");
                });

            modelBuilder.Entity("Lingo.Models.GameWord", b =>
                {
                    b.Navigation("WordEntries");
                });

            modelBuilder.Entity("Lingo.Models.Word", b =>
                {
                    b.Navigation("GameWords");
                });
#pragma warning restore 612, 618
        }
    }
}
