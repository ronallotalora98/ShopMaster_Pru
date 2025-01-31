using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Comers_Pru.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SM_CATEGORIA",
                columns: table => new
                {
                    CAT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAT_NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAT_CODIGO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SM_CATEGORIA", x => x.CAT_ID);
                });

            migrationBuilder.CreateTable(
                name: "SM_ROL",
                columns: table => new
                {
                    ROL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROL_DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ROL_CODIGO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SM_ROL", x => x.ROL_ID);
                });

            migrationBuilder.CreateTable(
                name: "SM_TIPO_PROMOCION",
                columns: table => new
                {
                    TPR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TPR_DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TPR_CODIGO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SM_TIPO_PROMOCION", x => x.TPR_ID);
                });

            migrationBuilder.CreateTable(
                name: "SM_PRODUCTO",
                columns: table => new
                {
                    PRO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRO_NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRO_DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRO_PRECIO = table.Column<int>(type: "int", nullable: false),
                    PRO_CATEGORIA_ID = table.Column<int>(type: "int", nullable: false),
                    PRO_IMAGEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRO_INVENTARIO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SM_PRODUCTO", x => x.PRO_ID);
                    table.ForeignKey(
                        name: "FK_SM_PRODUCTO_SM_CATEGORIA_PRO_CATEGORIA_ID",
                        column: x => x.PRO_CATEGORIA_ID,
                        principalTable: "SM_CATEGORIA",
                        principalColumn: "CAT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SM_USUARIO",
                columns: table => new
                {
                    USU_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USU_NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USU_CORREO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USU_CLAVE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USU_ROL_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SM_USUARIO", x => x.USU_ID);
                    table.ForeignKey(
                        name: "FK_SM_USUARIO_SM_ROL_USU_ROL_ID",
                        column: x => x.USU_ROL_ID,
                        principalTable: "SM_ROL",
                        principalColumn: "ROL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SM_PROMOCION",
                columns: table => new
                {
                    PRO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRO_DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRO_TIPO_PROMOCION_ID = table.Column<int>(type: "int", nullable: false),
                    PRO_DESCUENTO = table.Column<int>(type: "int", nullable: false),
                    PRO_CONDICION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRO_FECHA_INICIO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PRO_FECHA_FIN = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SM_PROMOCION", x => x.PRO_ID);
                    table.ForeignKey(
                        name: "FK_SM_PROMOCION_SM_TIPO_PROMOCION_PRO_TIPO_PROMOCION_ID",
                        column: x => x.PRO_TIPO_PROMOCION_ID,
                        principalTable: "SM_TIPO_PROMOCION",
                        principalColumn: "TPR_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SM_ORDEN",
                columns: table => new
                {
                    ORD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORD_USER_ID = table.Column<int>(type: "int", nullable: false),
                    ORD_FECHA_ORDEN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ORD_ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORD_TOTAL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SM_ORDEN", x => x.ORD_ID);
                    table.ForeignKey(
                        name: "FK_SM_ORDEN_SM_USUARIO_ORD_USER_ID",
                        column: x => x.ORD_USER_ID,
                        principalTable: "SM_USUARIO",
                        principalColumn: "USU_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SM_DETALLE_ORDEN",
                columns: table => new
                {
                    DOR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOR_ORDEN_ID = table.Column<int>(type: "int", nullable: false),
                    DOR_PRODUCTO_ID = table.Column<int>(type: "int", nullable: false),
                    DOR_CANTIDAD = table.Column<int>(type: "int", nullable: false),
                    DOR_PRECIO_UNITARIO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SM_DETALLE_ORDEN", x => x.DOR_ID);
                    table.ForeignKey(
                        name: "FK_SM_DETALLE_ORDEN_SM_ORDEN_DOR_ORDEN_ID",
                        column: x => x.DOR_ORDEN_ID,
                        principalTable: "SM_ORDEN",
                        principalColumn: "ORD_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SM_DETALLE_ORDEN_SM_PRODUCTO_DOR_PRODUCTO_ID",
                        column: x => x.DOR_PRODUCTO_ID,
                        principalTable: "SM_PRODUCTO",
                        principalColumn: "PRO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SM_DETALLE_ORDEN_DOR_ORDEN_ID",
                table: "SM_DETALLE_ORDEN",
                column: "DOR_ORDEN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SM_DETALLE_ORDEN_DOR_PRODUCTO_ID",
                table: "SM_DETALLE_ORDEN",
                column: "DOR_PRODUCTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SM_ORDEN_ORD_USER_ID",
                table: "SM_ORDEN",
                column: "ORD_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SM_PRODUCTO_PRO_CATEGORIA_ID",
                table: "SM_PRODUCTO",
                column: "PRO_CATEGORIA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SM_PROMOCION_PRO_TIPO_PROMOCION_ID",
                table: "SM_PROMOCION",
                column: "PRO_TIPO_PROMOCION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SM_USUARIO_USU_ROL_ID",
                table: "SM_USUARIO",
                column: "USU_ROL_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SM_DETALLE_ORDEN");

            migrationBuilder.DropTable(
                name: "SM_PROMOCION");

            migrationBuilder.DropTable(
                name: "SM_ORDEN");

            migrationBuilder.DropTable(
                name: "SM_PRODUCTO");

            migrationBuilder.DropTable(
                name: "SM_TIPO_PROMOCION");

            migrationBuilder.DropTable(
                name: "SM_USUARIO");

            migrationBuilder.DropTable(
                name: "SM_CATEGORIA");

            migrationBuilder.DropTable(
                name: "SM_ROL");
        }
    }
}
