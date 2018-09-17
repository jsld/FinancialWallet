using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MasterTypeId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterData_MasterType_MasterTypeId",
                        column: x => x.MasterTypeId,
                        principalTable: "MasterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    TipoEmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_MasterData_TipoEmpresaId",
                        column: x => x.TipoEmpresaId,
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoDeServicioId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TipoAdjudicacionId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    Facturado = table.Column<bool>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    Costo = table.Column<int>(nullable: true),
                    FechaAdjudicacion = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: true),
                    FechaTermino = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_MasterData_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_MasterData_TipoAdjudicacionId",
                        column: x => x.TipoAdjudicacionId,
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_MasterData_TipoDeServicioId",
                        column: x => x.TipoDeServicioId,
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    BancoId = table.Column<int>(nullable: false),
                    TipoTarjetaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjetas_MasterData_BancoId",
                        column: x => x.BancoId,
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarjetas_MasterData_TipoTarjetaId",
                        column: x => x.TipoTarjetaId,
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTransaccionId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    ServicioId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    MontoTotal = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacciones_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_MasterData_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_MasterData_TipoTransaccionId",
                        column: x => x.TipoTransaccionId,
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransaccionId = table.Column<int>(nullable: false),
                    Monto = table.Column<int>(nullable: false),
                    TipoDePagoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_MasterData_TipoDePagoId",
                        column: x => x.TipoDePagoId,
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Transacciones_TransaccionId",
                        column: x => x.TransaccionId,
                        principalTable: "Transacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialTarjetasCredito",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PagoId = table.Column<int>(nullable: false),
                    TarjetaId = table.Column<int>(nullable: false),
                    NumeroCuotas = table.Column<int>(nullable: false),
                    MontoTotal = table.Column<int>(nullable: false),
                    HistorialTarjetaId = table.Column<int>(nullable: true),
                    Cuota = table.Column<int>(nullable: true),
                    MontoCuota = table.Column<int>(nullable: true),
                    VencimientoCuota = table.Column<DateTime>(nullable: true),
                    PagosId = table.Column<int>(nullable: true),
                    TarjetasId = table.Column<int>(nullable: true),
                    HistorialTCId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialTarjetasCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialTarjetasCredito_HistorialTarjetasCredito_HistorialTCId",
                        column: x => x.HistorialTCId,
                        principalTable: "HistorialTarjetasCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialTarjetasCredito_Pagos_PagosId",
                        column: x => x.PagosId,
                        principalTable: "Pagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialTarjetasCredito_Tarjetas_TarjetasId",
                        column: x => x.TarjetasId,
                        principalTable: "Tarjetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_TipoEmpresaId",
                table: "Empresas",
                column: "TipoEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialTarjetasCredito_HistorialTCId",
                table: "HistorialTarjetasCredito",
                column: "HistorialTCId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialTarjetasCredito_PagosId",
                table: "HistorialTarjetasCredito",
                column: "PagosId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialTarjetasCredito_TarjetasId",
                table: "HistorialTarjetasCredito",
                column: "TarjetasId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterData_MasterTypeId",
                table: "MasterData",
                column: "MasterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TipoDePagoId",
                table: "Pagos",
                column: "TipoDePagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TransaccionId",
                table: "Pagos",
                column: "TransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_EstadoId",
                table: "Servicios",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_TipoAdjudicacionId",
                table: "Servicios",
                column: "TipoAdjudicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_TipoDeServicioId",
                table: "Servicios",
                column: "TipoDeServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_BancoId",
                table: "Tarjetas",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_TipoTarjetaId",
                table: "Tarjetas",
                column: "TipoTarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_EmpresaId",
                table: "Transacciones",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_EstadoId",
                table: "Transacciones",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ServicioId",
                table: "Transacciones",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_TipoTransaccionId",
                table: "Transacciones",
                column: "TipoTransaccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialTarjetasCredito");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "MasterData");

            migrationBuilder.DropTable(
                name: "MasterType");
        }
    }
}
