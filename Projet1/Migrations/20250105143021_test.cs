using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet1.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domiciliation_Adresse_AdresseDomiciliationId",
                table: "Domiciliation");

            migrationBuilder.DropForeignKey(
                name: "FK_Domiciliation_Entreprise_EntrepriseId",
                table: "Domiciliation");

            migrationBuilder.DropForeignKey(
                name: "FK_Domiciliation_Facture_FactureId",
                table: "Domiciliation");

            migrationBuilder.DropIndex(
                name: "IX_Domiciliation_EntrepriseId",
                table: "Domiciliation");

            migrationBuilder.DropColumn(
                name: "EntrepriseId",
                table: "Domiciliation");

            migrationBuilder.RenameColumn(
                name: "FactureId",
                table: "Domiciliation",
                newName: "UtilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_Domiciliation_FactureId",
                table: "Domiciliation",
                newName: "IX_Domiciliation_UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domiciliation_Adresse_AdresseDomiciliationId",
                table: "Domiciliation",
                column: "AdresseDomiciliationId",
                principalTable: "Adresse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Domiciliation_Utilisateur_UtilisateurId",
                table: "Domiciliation",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domiciliation_Adresse_AdresseDomiciliationId",
                table: "Domiciliation");

            migrationBuilder.DropForeignKey(
                name: "FK_Domiciliation_Utilisateur_UtilisateurId",
                table: "Domiciliation");

            migrationBuilder.RenameColumn(
                name: "UtilisateurId",
                table: "Domiciliation",
                newName: "FactureId");

            migrationBuilder.RenameIndex(
                name: "IX_Domiciliation_UtilisateurId",
                table: "Domiciliation",
                newName: "IX_Domiciliation_FactureId");

            migrationBuilder.AddColumn<int>(
                name: "EntrepriseId",
                table: "Domiciliation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Domiciliation_EntrepriseId",
                table: "Domiciliation",
                column: "EntrepriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domiciliation_Adresse_AdresseDomiciliationId",
                table: "Domiciliation",
                column: "AdresseDomiciliationId",
                principalTable: "Adresse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Domiciliation_Entreprise_EntrepriseId",
                table: "Domiciliation",
                column: "EntrepriseId",
                principalTable: "Entreprise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Domiciliation_Facture_FactureId",
                table: "Domiciliation",
                column: "FactureId",
                principalTable: "Facture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
