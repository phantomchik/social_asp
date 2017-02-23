using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SocialPoll.Data;

namespace SocialPoll.Data.Migrations
{
    [DbContext(typeof(SocialPollContext))]
    [Migration("20170223183003_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SocialPoll.Data.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gruppa");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("SocialPoll.Data.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TextQuestion");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SocialPoll.Data.Models.Variable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswerId");

                    b.Property<int>("QuestionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId")
                        .IsUnique();

                    b.HasIndex("QuestionId");

                    b.ToTable("Variables");
                });

            modelBuilder.Entity("SocialPoll.Data.Models.Answer", b =>
                {
                    b.HasOne("SocialPoll.Data.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("SocialPoll.Data.Models.Variable", b =>
                {
                    b.HasOne("SocialPoll.Data.Models.Answer", "Answer")
                        .WithOne("Variable")
                        .HasForeignKey("SocialPoll.Data.Models.Variable", "AnswerId");

                    b.HasOne("SocialPoll.Data.Models.Question", "Question")
                        .WithMany("Variables")
                        .HasForeignKey("QuestionId");
                });
        }
    }
}
