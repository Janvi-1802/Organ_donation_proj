using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Organ_donation.Models;
using System.Text;

#nullable disable

namespace Organ_donation.Migrations
{
    /// <inheritdoc />
    public partial class addAdminAccount : Migration
    {
        /// <inheritdoc />
        const string ADMIN_USER_GUID = "f337a43b-18d8-4db1-aa4b-f566bc500e02";
        const string ADMIN_ROLE_GUID = "11ea919d-afdf-4025-9479-5ce43adf1a58";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<User>();

            var passwordHash = hasher.HashPassword(null, "janvi");

            StringBuilder sb= new StringBuilder();
           

            sb.AppendLine("INSERT INTO AspNetUsers(Id,lastName,City,country,Phone,address,UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp,FirstName)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{ADMIN_USER_GUID}'");
            //sb.AppendLine(",'Janvi'");
            sb.AppendLine(",'Solanki'");
            sb.AppendLine(",'Bharuch'");
            sb.AppendLine(",'India'");
            sb.AppendLine(",'9945612356'");
            sb.AppendLine(",'B-103 Mangaljyot'");
            sb.AppendLine(",'janviSolanki'");
            sb.AppendLine(",'JANVISOLANKI'");
            sb.AppendLine(",'janvivsolanki2004@gmail.com'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'JANVIVSOLANKI2004@GAMIL.COM'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(",'Admin'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{ADMIN_ROLE_GUID}','Admin','ADMIN')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{ADMIN_USER_GUID}','{ADMIN_ROLE_GUID}')");



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{ADMIN_USER_GUID}' AND RoleId = '{ADMIN_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{ADMIN_USER_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{ADMIN_ROLE_GUID}'");
        }
    }
}
