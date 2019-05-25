using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Repositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeatureCollection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadTs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Coordinates = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Ubigeo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadTs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pueblos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    UnidadTId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Coordinates = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Ubigeo = table.Column<string>(nullable: true),
                    CantParcelas = table.Column<int>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    AreaVivienda = table.Column<double>(nullable: false),
                    AreaComunal = table.Column<double>(nullable: false),
                    AreaEducacion = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pueblos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pueblos_UnidadTs_UnidadTId",
                        column: x => x.UnidadTId,
                        principalTable: "UnidadTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PuebloId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Coordinates = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Ubigeo = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Pueblos_PuebloId",
                        column: x => x.PuebloId,
                        principalTable: "Pueblos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manzanas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    ParcelaId = table.Column<int>(nullable: false),
                    PuebloId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Coordinates = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Ubigeo = table.Column<string>(nullable: true),
                    CantLotes = table.Column<int>(nullable: false),
                    Area = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manzanas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manzanas_Parcelas_ParcelaId",
                        column: x => x.ParcelaId,
                        principalTable: "Parcelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manzanas_Pueblos_PuebloId",
                        column: x => x.PuebloId,
                        principalTable: "Pueblos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    ManzanaId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Coordinates = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Ubigeo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calles_Manzanas_ManzanaId",
                        column: x => x.ManzanaId,
                        principalTable: "Manzanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    ManzanaId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Coordinates = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Ubigeo = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    TipoUso = table.Column<string>(nullable: true),
                    MedidFrnt = table.Column<string>(nullable: true),
                    MedidIzq = table.Column<string>(nullable: true),
                    MedidPost = table.Column<string>(nullable: true),
                    MedidDer = table.Column<string>(nullable: true),
                    ColinFrnt = table.Column<string>(nullable: true),
                    ColinIzq = table.Column<string>(nullable: true),
                    ColinPost = table.Column<string>(nullable: true),
                    ColinDer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotes_Manzanas_ManzanaId",
                        column: x => x.ManzanaId,
                        principalTable: "Manzanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    fkey = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    LotePropId = table.Column<int>(nullable: true),
                    LoteGeomId = table.Column<int>(nullable: true),
                    CallePropId = table.Column<int>(nullable: true),
                    CalleGeomId = table.Column<int>(nullable: true),
                    ManzanaPropId = table.Column<int>(nullable: true),
                    ManzanaGeomId = table.Column<int>(nullable: true),
                    ParcelaPropId = table.Column<int>(nullable: true),
                    ParcelaGeomId = table.Column<int>(nullable: true),
                    PuebloPropId = table.Column<int>(nullable: true),
                    PuebloGeomId = table.Column<int>(nullable: true),
                    UnidadTPropId = table.Column<int>(nullable: true),
                    UnidadTGeomId = table.Column<int>(nullable: true),
                    FeatureCollectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Calles_CalleGeomId",
                        column: x => x.CalleGeomId,
                        principalTable: "Calles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_Calles_CallePropId",
                        column: x => x.CallePropId,
                        principalTable: "Calles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_FeatureCollection_FeatureCollectionId",
                        column: x => x.FeatureCollectionId,
                        principalTable: "FeatureCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_Lotes_LoteGeomId",
                        column: x => x.LoteGeomId,
                        principalTable: "Lotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_Lotes_LotePropId",
                        column: x => x.LotePropId,
                        principalTable: "Lotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_Manzanas_ManzanaGeomId",
                        column: x => x.ManzanaGeomId,
                        principalTable: "Manzanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_Manzanas_ManzanaPropId",
                        column: x => x.ManzanaPropId,
                        principalTable: "Manzanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_Parcelas_ParcelaGeomId",
                        column: x => x.ParcelaGeomId,
                        principalTable: "Parcelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_Parcelas_ParcelaPropId",
                        column: x => x.ParcelaPropId,
                        principalTable: "Parcelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_Pueblos_PuebloGeomId",
                        column: x => x.PuebloGeomId,
                        principalTable: "Pueblos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_Pueblos_PuebloPropId",
                        column: x => x.PuebloPropId,
                        principalTable: "Pueblos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_UnidadTs_UnidadTGeomId",
                        column: x => x.UnidadTGeomId,
                        principalTable: "UnidadTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Features_UnidadTs_UnidadTPropId",
                        column: x => x.UnidadTPropId,
                        principalTable: "UnidadTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calles_ManzanaId",
                table: "Calles",
                column: "ManzanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CalleGeomId",
                table: "Features",
                column: "CalleGeomId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CallePropId",
                table: "Features",
                column: "CallePropId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureCollectionId",
                table: "Features",
                column: "FeatureCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_LoteGeomId",
                table: "Features",
                column: "LoteGeomId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_LotePropId",
                table: "Features",
                column: "LotePropId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ManzanaGeomId",
                table: "Features",
                column: "ManzanaGeomId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ManzanaPropId",
                table: "Features",
                column: "ManzanaPropId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ParcelaGeomId",
                table: "Features",
                column: "ParcelaGeomId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ParcelaPropId",
                table: "Features",
                column: "ParcelaPropId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_PuebloGeomId",
                table: "Features",
                column: "PuebloGeomId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_PuebloPropId",
                table: "Features",
                column: "PuebloPropId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_UnidadTGeomId",
                table: "Features",
                column: "UnidadTGeomId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_UnidadTPropId",
                table: "Features",
                column: "UnidadTPropId");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_ManzanaId",
                table: "Lotes",
                column: "ManzanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manzanas_ParcelaId",
                table: "Manzanas",
                column: "ParcelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manzanas_PuebloId",
                table: "Manzanas",
                column: "PuebloId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_PuebloId",
                table: "Parcelas",
                column: "PuebloId");

            migrationBuilder.CreateIndex(
                name: "IX_Pueblos_UnidadTId",
                table: "Pueblos",
                column: "UnidadTId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Calles");

            migrationBuilder.DropTable(
                name: "FeatureCollection");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Manzanas");

            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "Pueblos");

            migrationBuilder.DropTable(
                name: "UnidadTs");
        }
    }
}
