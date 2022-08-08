using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContextProfi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "ApplicationNumbers");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Short_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Long_description = table.Column<string>(type: "nvarchar(max)", maxLength: 6000, nullable: false),
                    Blog_image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Is_published = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Map = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Is_posted_on_the_page = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests_applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Application_number = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ApplicationNumbers"),
                    Guest_name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Guest_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Guests_application_text = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Date_receipt_application = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Application_processing_status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests_applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Header_slogans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slogans = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Slogan_used = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Header_slogans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu_sets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_items_main = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Menu_items_services = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Menu_items_projects = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Menu_items_blogs = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Menu_items_contacts = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Is_posted_on_the_page = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_sets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page_actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actions = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page_actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page_buttons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buttons = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page_buttons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page_images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page_images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page_phrases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phrases = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page_phrases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page_texts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page_texts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_company_logo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Link_to_customer_site = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Project_article = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Is_published = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service_description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Is_published = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Main_page_presets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preset_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Text_id = table.Column<int>(type: "int", nullable: true),
                    Image_id = table.Column<int>(type: "int", nullable: true),
                    Phrase_id = table.Column<int>(type: "int", nullable: true),
                    Button_id = table.Column<int>(type: "int", nullable: true),
                    Action_id = table.Column<int>(type: "int", nullable: true),
                    Is_posted_on_the_page = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main_page_presets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Main_page_presets_Page_actions_Action_id",
                        column: x => x.Action_id,
                        principalTable: "Page_actions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Main_page_presets_Page_buttons_Button_id",
                        column: x => x.Button_id,
                        principalTable: "Page_buttons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Main_page_presets_Page_images_Image_id",
                        column: x => x.Image_id,
                        principalTable: "Page_images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Main_page_presets_Page_phrases_Phrase_id",
                        column: x => x.Phrase_id,
                        principalTable: "Page_phrases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Main_page_presets_Page_texts_Text_id",
                        column: x => x.Text_id,
                        principalTable: "Page_texts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Password_hash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password_salt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    User_role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_User_role",
                        column: x => x.User_role,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Main_page_presets_Action_id",
                table: "Main_page_presets",
                column: "Action_id");

            migrationBuilder.CreateIndex(
                name: "IX_Main_page_presets_Button_id",
                table: "Main_page_presets",
                column: "Button_id");

            migrationBuilder.CreateIndex(
                name: "IX_Main_page_presets_Image_id",
                table: "Main_page_presets",
                column: "Image_id");

            migrationBuilder.CreateIndex(
                name: "IX_Main_page_presets_Phrase_id",
                table: "Main_page_presets",
                column: "Phrase_id");

            migrationBuilder.CreateIndex(
                name: "IX_Main_page_presets_Text_id",
                table: "Main_page_presets",
                column: "Text_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_role",
                table: "Users",
                column: "User_role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Guests_applications");

            migrationBuilder.DropTable(
                name: "Header_slogans");

            migrationBuilder.DropTable(
                name: "Main_page_presets");

            migrationBuilder.DropTable(
                name: "Menu_sets");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Page_actions");

            migrationBuilder.DropTable(
                name: "Page_buttons");

            migrationBuilder.DropTable(
                name: "Page_images");

            migrationBuilder.DropTable(
                name: "Page_phrases");

            migrationBuilder.DropTable(
                name: "Page_texts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropSequence(
                name: "ApplicationNumbers");
        }
    }
}
