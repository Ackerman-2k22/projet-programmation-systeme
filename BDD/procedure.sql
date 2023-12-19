-- Création de la procédure stockée
CREATE PROCEDURE GetProduitsByRecette
    @recette_id INT
AS
BEGIN
    -- Sélection des produits nécessaires à la recette spécifiée
    SELECT pc.nom AS nom_produit, pc.description AS description_produit
    FROM ProduitConserve pc
    INNER JOIN RecetteProduitsConserve rpc ON pc.conserve_id = rpc.conserve_id
    WHERE rpc.recette_id = @recette_id

    UNION ALL

    SELECT ps.nom AS nom_produit, ps.description AS description_produit
    FROM ProduitSurgeles ps
    INNER JOIN RecetteProduitsSurgeles rps ON ps.surgele_id = rps.surgele_id
    WHERE rps.recette_id = @recette_id

    UNION ALL

    SELECT pf.nom AS nom_produit, pf.description AS description_produit
    FROM ProduitFrais pf
    INNER JOIN RecetteProduitsFrais rpf ON pf.frais_id = rpf.frais_id
    WHERE rpf.recette_id = @recette_id;
END


CREATE PROCEDURE GetUstensilesByRecette
    @recette_id INT
AS
BEGIN
    SELECT DISTINCT
        Recette.nom AS NomRecette,
        Ustensils.nom AS NomUstensil,
        RecetteUstensils.quantité_utilisée AS QuantiteUstensil
    FROM Recette
    LEFT JOIN RecetteUstensils ON Recette.recette_id = RecetteUstensils.recette_id
    LEFT JOIN Ustensils ON RecetteUstensils.ustensil_id = Ustensils.ustensil_id
    WHERE Recette.recette_id = @recette_id;
END
GO

USE Projet;
GO

CREATE PROCEDURE GetMaterielByRecette
    @recette_id INT
AS
BEGIN
    SELECT DISTINCT
        Recette.nom AS NomRecette,
        MaterielCuisine.nom AS NomMateriel,
        RecetteMateriel.quantité_utilisée AS QuantiteMateriel
    FROM Recette
    LEFT JOIN RecetteMateriel ON Recette.recette_id = RecetteMateriel.recette_id
    LEFT JOIN MaterielCuisine ON RecetteMateriel.materiel_id = MaterielCuisine.materiel_id
    WHERE Recette.recette_id = @recette_id;
END
GO