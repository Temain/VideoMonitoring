using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VideoMonitoring.Domain.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asp_role",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    discriminator = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asp_user",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    access_failed_count = table.Column<int>(nullable: false),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    email = table.Column<string>(maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false),
                    lockout_enabled = table.Column<bool>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    normalized_email = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(maxLength: 256, nullable: true),
                    password_hash = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    phone_number_confirmed = table.Column<bool>(nullable: false),
                    security_stamp = table.Column<string>(nullable: true),
                    two_factor_enabled = table.Column<bool>(nullable: false),
                    user_name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "td_product_category",
                columns: table => new
                {
                    product_category_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(nullable: false),
                    deleted_at = table.Column<DateTime>(nullable: true),
                    product_category_name = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_td_product_category", x => x.product_category_id);
                });

            migrationBuilder.CreateTable(
                name: "asp_role_claim",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true),
                    role_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_role_claim_asp_role_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_user_claim",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true),
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_user_claim_asp_user_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_user_login",
                columns: table => new
                {
                    login_provider = table.Column<string>(nullable: false),
                    provider_key = table.Column<string>(nullable: false),
                    provider_display_name = table.Column<string>(nullable: true),
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_user_login", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_user_login_asp_user_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_user_role",
                columns: table => new
                {
                    user_id = table.Column<long>(nullable: false),
                    role_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_user_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_user_role_asp_role_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_user_role_asp_user_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_user_token",
                columns: table => new
                {
                    user_id = table.Column<long>(nullable: false),
                    login_provider = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_user_token", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_user_token_asp_user_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tl_order",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(nullable: false),
                    deleted_at = table.Column<DateTime>(nullable: true),
                    is_checked = table.Column<bool>(nullable: false),
                    is_delivered = table.Column<bool>(nullable: false),
                    is_sended = table.Column<bool>(nullable: false),
                    total_sum = table.Column<decimal>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tl_order", x => x.order_id);
                    table.ForeignKey(
                        name: "fk_tl_order_asp_user_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "td_product_type",
                columns: table => new
                {
                    product_type_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(nullable: false),
                    deleted_at = table.Column<DateTime>(nullable: true),
                    product_category_id = table.Column<int>(nullable: false),
                    product_type_name = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_td_product_type", x => x.product_type_id);
                    table.ForeignKey(
                        name: "fk_td_product_type_td_product_category_product_category_id",
                        column: x => x.product_category_id,
                        principalTable: "td_product_category",
                        principalColumn: "product_category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tl_product",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(nullable: false),
                    deleted_at = table.Column<DateTime>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    in_stock = table.Column<decimal>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    product_name = table.Column<int>(nullable: false),
                    product_type_id = table.Column<int>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tl_product", x => x.product_id);
                    table.ForeignKey(
                        name: "fk_tl_product_td_product_type_product_type_id",
                        column: x => x.product_type_id,
                        principalTable: "td_product_type",
                        principalColumn: "product_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tl_order_detail",
                columns: table => new
                {
                    order_detail_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    count = table.Column<decimal>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    deleted_at = table.Column<DateTime>(nullable: true),
                    order_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tl_order_detail", x => x.order_detail_id);
                    table.ForeignKey(
                        name: "fk_tl_order_detail_tl_order_order_id",
                        column: x => x.order_id,
                        principalTable: "tl_order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tl_order_detail_tl_product_product_id",
                        column: x => x.product_id,
                        principalTable: "tl_product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "role_name_index",
                table: "asp_role",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_role_claim_role_id",
                table: "asp_role_claim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "email_index",
                table: "asp_user",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "user_name_index",
                table: "asp_user",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_user_claim_user_id",
                table: "asp_user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_user_login_user_id",
                table: "asp_user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_user_role_role_id",
                table: "asp_user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_td_product_type_product_category_id",
                table: "td_product_type",
                column: "product_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_tl_order_user_id",
                table: "tl_order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_tl_order_detail_order_id",
                table: "tl_order_detail",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_tl_order_detail_product_id",
                table: "tl_order_detail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_tl_product_product_type_id",
                table: "tl_product",
                column: "product_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asp_role_claim");

            migrationBuilder.DropTable(
                name: "asp_user_claim");

            migrationBuilder.DropTable(
                name: "asp_user_login");

            migrationBuilder.DropTable(
                name: "asp_user_role");

            migrationBuilder.DropTable(
                name: "asp_user_token");

            migrationBuilder.DropTable(
                name: "tl_order_detail");

            migrationBuilder.DropTable(
                name: "asp_role");

            migrationBuilder.DropTable(
                name: "tl_order");

            migrationBuilder.DropTable(
                name: "tl_product");

            migrationBuilder.DropTable(
                name: "asp_user");

            migrationBuilder.DropTable(
                name: "td_product_type");

            migrationBuilder.DropTable(
                name: "td_product_category");
        }
    }
}
