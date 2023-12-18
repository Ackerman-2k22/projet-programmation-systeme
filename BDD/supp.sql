

-- Code de suppression pour la table Ustensils
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Ustensils')
BEGIN
    DROP TABLE Ustensils;
END
GO



-- Code de suppression pour la table ProduitConserve
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'ProduitConserve')
BEGIN
    DROP TABLE ProduitConserve;
END
GO



-- Code de suppression pour la table ProduitSurgeles
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'ProduitSurgeles')
BEGIN
    DROP TABLE ProduitSurgeles;
END
GO



-- Code de suppression pour la table ProduitFrais
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'ProduitFrais')
BEGIN
    DROP TABLE ProduitFrais;
END
GO



-- Code de suppression pour la table MaterielCuisine
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'MaterielCuisine')
BEGIN
    DROP TABLE MaterielCuisine;
END
GO


-- Code de suppression pour la table Recette
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Recette')
BEGIN
    DROP TABLE Recette;
END
GO



-- Code de suppression pour la table PlatCuisine
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'PlatCuisine')
BEGIN
    DROP TABLE PlatCuisine;
END
GO



-- Code de suppression pour la table RecetteUstensils
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteUstensils')
BEGIN
    DROP TABLE RecetteUstensils;
END
GO



-- Code de suppression pour la table RecetteProduitsConserve
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteProduitsConserve')
BEGIN
    DROP TABLE RecetteProduitsConserve;
END
GO



-- Code de suppression pour la table RecetteProduitsSurgeles
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteProduitsSurgeles')
BEGIN
    DROP TABLE RecetteProduitsSurgeles;
END
GO



-- Code de suppression pour la table RecetteProduitsFrais
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteProduitsFrais')
BEGIN
    DROP TABLE RecetteProduitsFrais;
END
GO



-- Code de suppression pour la table RecetteMateriel
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteMateriel')
BEGIN
    DROP TABLE RecetteMateriel;
END
GO



-- Code de suppression pour la table PlatRecette
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'PlatRecette')
BEGIN
    DROP TABLE PlatRecette;
END
GO