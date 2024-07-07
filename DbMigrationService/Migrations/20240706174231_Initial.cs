using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DbMigrationService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JO_70",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_70", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_71",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_71", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_72",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_72", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_73",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_73", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_74",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_74", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_75",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_75", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_76",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_76", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_92224",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_92224", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_92225",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_92225", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_92226",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_92226", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_92276",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_92276", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_92277",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_92277", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_92278",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_92278", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_9751",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_9751", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_9752",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_9752", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_9753",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_9753", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "JO_9754",
                columns: table => new
                {
                    Time = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Q64 = table.Column<double>(type: "double precision", nullable: false),
                    Q193 = table.Column<double>(type: "double precision", nullable: false),
                    Q1 = table.Column<double>(type: "double precision", nullable: false),
                    Q2 = table.Column<double>(type: "double precision", nullable: false),
                    Q3 = table.Column<double>(type: "double precision", nullable: false),
                    Q4 = table.Column<double>(type: "double precision", nullable: false),
                    Q5 = table.Column<double>(type: "double precision", nullable: false),
                    Q6 = table.Column<double>(type: "double precision", nullable: false),
                    Q70 = table.Column<double>(type: "double precision", nullable: false),
                    Q7 = table.Column<double>(type: "double precision", nullable: false),
                    Q8 = table.Column<double>(type: "double precision", nullable: false),
                    Q9 = table.Column<double>(type: "double precision", nullable: false),
                    Q10 = table.Column<double>(type: "double precision", nullable: false),
                    Q11 = table.Column<double>(type: "double precision", nullable: false),
                    Q12 = table.Column<double>(type: "double precision", nullable: false),
                    Q13 = table.Column<double>(type: "double precision", nullable: false),
                    Q14 = table.Column<double>(type: "double precision", nullable: false),
                    Q15 = table.Column<double>(type: "double precision", nullable: false),
                    Q16 = table.Column<double>(type: "double precision", nullable: false),
                    Q80 = table.Column<double>(type: "double precision", nullable: false),
                    Q17 = table.Column<double>(type: "double precision", nullable: false),
                    Q18 = table.Column<double>(type: "double precision", nullable: false),
                    Q19 = table.Column<double>(type: "double precision", nullable: false),
                    Q20 = table.Column<double>(type: "double precision", nullable: false),
                    Q21 = table.Column<double>(type: "double precision", nullable: false),
                    Q22 = table.Column<double>(type: "double precision", nullable: false),
                    Q23 = table.Column<double>(type: "double precision", nullable: false),
                    Q24 = table.Column<double>(type: "double precision", nullable: false),
                    Q60 = table.Column<double>(type: "double precision", nullable: false),
                    Q61 = table.Column<double>(type: "double precision", nullable: false),
                    Q62 = table.Column<double>(type: "double precision", nullable: false),
                    Q63 = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ShowName = table.Column<string>(type: "text", nullable: true),
                    ShowCode = table.Column<string>(type: "text", nullable: true),
                    Digits = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JO_9754", x => x.Time);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JO_70");

            migrationBuilder.DropTable(
                name: "JO_71");

            migrationBuilder.DropTable(
                name: "JO_72");

            migrationBuilder.DropTable(
                name: "JO_73");

            migrationBuilder.DropTable(
                name: "JO_74");

            migrationBuilder.DropTable(
                name: "JO_75");

            migrationBuilder.DropTable(
                name: "JO_76");

            migrationBuilder.DropTable(
                name: "JO_92224");

            migrationBuilder.DropTable(
                name: "JO_92225");

            migrationBuilder.DropTable(
                name: "JO_92226");

            migrationBuilder.DropTable(
                name: "JO_92276");

            migrationBuilder.DropTable(
                name: "JO_92277");

            migrationBuilder.DropTable(
                name: "JO_92278");

            migrationBuilder.DropTable(
                name: "JO_9751");

            migrationBuilder.DropTable(
                name: "JO_9752");

            migrationBuilder.DropTable(
                name: "JO_9753");

            migrationBuilder.DropTable(
                name: "JO_9754");
        }
    }
}
