using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingMovie.Migrations
{
    public partial class @long : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.IdAdmin);
                });

            migrationBuilder.CreateTable(
                name: "Ghe",
                columns: table => new
                {
                    IdGhe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGhe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ghe", x => x.IdGhe);
                });

            migrationBuilder.CreateTable(
                name: "PhongChieu",
                columns: table => new
                {
                    IdPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongChieu", x => x.IdPhong);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    IdTheLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTheLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.IdTheLoai);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: false),
                    TaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietChoNgoi",
                columns: table => new
                {
                    IdChoNgoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhong = table.Column<int>(type: "int", nullable: false),
                    IdGhe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietChoNgoi", x => x.IdChoNgoi);
                    table.ForeignKey(
                        name: "FK_ChiTietChoNgoi_Ghe",
                        column: x => x.IdGhe,
                        principalTable: "Ghe",
                        principalColumn: "IdGhe",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietChoNgoi_PhongChieu",
                        column: x => x.IdPhong,
                        principalTable: "PhongChieu",
                        principalColumn: "IdPhong",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phim",
                columns: table => new
                {
                    IdPhim = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTheLoai = table.Column<int>(type: "int", nullable: false),
                    TenPhim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ThoiLuong = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phim", x => x.IdPhim);
                    table.ForeignKey(
                        name: "FK_Phim_TheLoai",
                        column: x => x.IdTheLoai,
                        principalTable: "TheLoai",
                        principalColumn: "IdTheLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhimLive",
                columns: table => new
                {
                    IdPhimLive = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhim = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdTheLoai = table.Column<int>(type: "int", nullable: false),
                    KeyPhim = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GioBatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhimLive", x => x.IdPhimLive);
                    table.ForeignKey(
                        name: "FK_PhimLive_TheLoai",
                        column: x => x.IdTheLoai,
                        principalTable: "TheLoai",
                        principalColumn: "IdTheLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietChieuPhim",
                columns: table => new
                {
                    IdChiTietChieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhong = table.Column<int>(type: "int", nullable: false),
                    IdPhim = table.Column<int>(type: "int", nullable: false),
                    NgayChieu = table.Column<DateTime>(type: "datetime", nullable: false),
                    GioBatDau = table.Column<DateTime>(type: "datetime", nullable: false),
                    GiaVe = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietChieuPhim_1", x => x.IdChiTietChieu);
                    table.ForeignKey(
                        name: "FK_ChiTietChieuPhim_Phim",
                        column: x => x.IdPhim,
                        principalTable: "Phim",
                        principalColumn: "IdPhim",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietChieuPhim_Phong",
                        column: x => x.IdPhong,
                        principalTable: "PhongChieu",
                        principalColumn: "IdPhong",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhimLive",
                columns: table => new
                {
                    IdChiTietPhimLive = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    IdPhimLive = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhimLive", x => x.IdChiTietPhimLive);
                    table.ForeignKey(
                        name: "FK_ChiTietPhimLive_PhimLive",
                        column: x => x.IdPhimLive,
                        principalTable: "PhimLive",
                        principalColumn: "IdPhimLive",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhimLive_User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ve",
                columns: table => new
                {
                    IdVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdChoNgoi = table.Column<int>(type: "int", nullable: false),
                    IdChiTietChieu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VE", x => x.IdVe);
                    table.ForeignKey(
                        name: "FK_Ve_ChiTietChieuPhim",
                        column: x => x.IdChiTietChieu,
                        principalTable: "ChiTietChieuPhim",
                        principalColumn: "IdChiTietChieu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ve_ChiTietChoNgoi1",
                        column: x => x.IdChoNgoi,
                        principalTable: "ChiTietChoNgoi",
                        principalColumn: "IdChoNgoi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ve_User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChieuPhim_IdPhim",
                table: "ChiTietChieuPhim",
                column: "IdPhim");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChieuPhim_IdPhong",
                table: "ChiTietChieuPhim",
                column: "IdPhong");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChoNgoi_IdGhe",
                table: "ChiTietChoNgoi",
                column: "IdGhe");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChoNgoi_IdPhong",
                table: "ChiTietChoNgoi",
                column: "IdPhong");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhimLive_IdPhimLive",
                table: "ChiTietPhimLive",
                column: "IdPhimLive");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhimLive_IdUser",
                table: "ChiTietPhimLive",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Phim_IdTheLoai",
                table: "Phim",
                column: "IdTheLoai");

            migrationBuilder.CreateIndex(
                name: "IX_PhimLive_IdTheLoai",
                table: "PhimLive",
                column: "IdTheLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdChiTietChieu",
                table: "Ve",
                column: "IdChiTietChieu");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdChoNgoi",
                table: "Ve",
                column: "IdChoNgoi");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdUser",
                table: "Ve",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ChiTietPhimLive");

            migrationBuilder.DropTable(
                name: "Ve");

            migrationBuilder.DropTable(
                name: "PhimLive");

            migrationBuilder.DropTable(
                name: "ChiTietChieuPhim");

            migrationBuilder.DropTable(
                name: "ChiTietChoNgoi");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Phim");

            migrationBuilder.DropTable(
                name: "Ghe");

            migrationBuilder.DropTable(
                name: "PhongChieu");

            migrationBuilder.DropTable(
                name: "TheLoai");
        }
    }
}
