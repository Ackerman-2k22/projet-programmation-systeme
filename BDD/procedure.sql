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

<<<<<<< HEAD
CREATE PROCEDURE GetMaterielByRecette1
=======
CREATE PROCEDURE GetMaterielByRecette
>>>>>>> f996ad33d52e8a77808c4f7a76d5d5cde780e273
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
<<<<<<< HEAD
GO

CREATE PROCEDURE InsertUstensil
    @ustensil_id INT,
    @nom VARCHAR(255),
    @qte int
AS
BEGIN
    INSERT INTO Ustensils (ustensil_id, nom, qte)
    VALUES (@ustensil_id, @nom, @qte)
END;


CREATE PROCEDURE InsertProduitConserve
    @conserve_id INT,
    @nom VARCHAR(255),
    @quantité_stock INT,
	@date_livraison DATE,
    @date_peremption DATE
AS
BEGIN
    INSERT INTO ProduitConserve (conserve_id, nom, quantité_stock,date_livraison, date_peremption)
    VALUES (@conserve_id, @nom, @quantité_stock,@date_livraison, @date_peremption)
END


CREATE PROCEDURE InsertProduitSurgele
    @surgele_id INT,
    @nom VARCHAR(255),
    @quantité_stock INT,
	@date_livraison DATE,
    @date_peremption DATE
AS
BEGIN
    INSERT INTO ProduitConserve (conserve_id, nom, quantité_stock,date_livraison, date_peremption)
    VALUES (@surgele_id, @nom, @quantité_stock,@date_livraison, @date_peremption)
END


CREATE PROCEDURE InsertProduitFrais
    @frais_id INT,
    @nom VARCHAR(255),
    @quantité_stock INT,
	@date_livraison DATE,
    @date_peremption DATE
AS
BEGIN
    INSERT INTO ProduitConserve (conserve_id, nom, quantité_stock,date_livraison, date_peremption)
    VALUES (@frais_id, @nom, @quantité_stock,@date_livraison, @date_peremption)
END


CREATE PROCEDURE InsertMaterielCuisine
    @materiel_id INT,
    @nom VARCHAR(255),
    @qte INT
AS
BEGIN
    INSERT INTO MaterielCuisine (materiel_id, nom, qte)
    VALUES (@materiel_id, @nom, @qte)
END


CREATE PROCEDURE InsertRecette
    @recette_id INT,
    @nom VARCHAR(255),
    @etapes VARCHAR(255),
    @instructions TEXT
AS
BEGIN
    INSERT INTO Recette (recette_id, nom, etapes, instructions)
    VALUES (@recette_id, @nom, @etapes, @instructions)
END

CREATE PROCEDURE InsertPlatCuisine
    @plat_id INT,
    @nom VARCHAR(255),
    @description VARCHAR(255),
    @date_cuisson DATE
AS
BEGIN
    INSERT INTO PlatCuisine (plat_id, nom, description, date_cuisson)
    VALUES (@plat_id, @nom, @description, @date_cuisson)
END



CREATE PROCEDURE UpdateUstensil
    @ustensil_id INT,
    @nom VARCHAR(255),
    @qte INT
AS
BEGIN
    UPDATE Ustensils
    SET nom = @nom,
        qte = @qte
    WHERE ustensil_id = @ustensil_id
END

CREATE PROCEDURE UpdateProduitConserve
    @conserve_id INT,
    @nom VARCHAR(255),
    @quantité_stock INT,
	@date_livraison DATE,
    @date_peremption DATE
AS
BEGIN
    UPDATE ProduitConserve
    SET nom = @nom,
        quantité_stock = @quantité_stock,
		date_livraison = @date_livraison,
        date_peremption = @date_peremption
    WHERE conserve_id = @conserve_id
END

CREATE PROCEDURE UpdateProduitSurgele
    @surgele_id INT,
    @nom VARCHAR(255),
    @quantité_stock INT,
	@date_livraison DATE,
    @date_peremption DATE
AS
BEGIN
    UPDATE ProduitConserve
    SET nom = @nom,
        quantité_stock = @quantité_stock,
		date_livraison = @date_livraison,
        date_peremption = @date_peremption
    WHERE conserve_id = @surgele_id
END

CREATE PROCEDURE UpdateProduitFrais
    @frais_id INT,
    @nom VARCHAR(255),
    @quantité_stock INT,
	@date_livraison DATE,
    @date_peremption DATE
AS
BEGIN
    UPDATE ProduitConserve
    SET nom = @nom,
        quantité_stock = @quantité_stock,
		date_livraison = @date_livraison,
        date_peremption = @date_peremption
    WHERE conserve_id = @frais_id
END

CREATE PROCEDURE UpdateMaterielCuisine
    @materiel_id INT,
    @nom VARCHAR(255),
    @qte INT
AS
BEGIN
    UPDATE MaterielCuisine
    SET nom = @nom,
        qte = @qte
    WHERE materiel_id = @materiel_id
END

CREATE PROCEDURE UpdateRecette
    @recette_id INT,
    @nom VARCHAR(255),
    @etapes VARCHAR(255),
    @instructions TEXT
AS
BEGIN
    UPDATE Recette
    SET nom = @nom,
        etapes = @etapes,
        instructions = @instructions
    WHERE recette_id = @recette_id
END

CREATE PROCEDURE UpdatePlatCuisine
    @plat_id INT,
    @nom VARCHAR(255),
    @description VARCHAR(255),
    @date_cuisson DATE
AS
BEGIN
    UPDATE PlatCuisine
    SET nom = @nom,
        description = @description,
        date_cuisson = @date_cuisson
    WHERE plat_id = @plat_id
END

CREATE PROCEDURE DeleteUstensil
    @ustensil_id INT
AS
BEGIN
    DELETE FROM Ustensils
    WHERE ustensil_id = @ustensil_id
END

CREATE PROCEDURE DeleteProduitConserve
    @conserve_id INT
AS
BEGIN
    DELETE FROM ProduitConserve
    WHERE conserve_id = @conserve_id
END

CREATE PROCEDURE DeleteProduitSurgele
    @surgele_id INT
AS
BEGIN
    DELETE FROM ProduitSurgeles
    WHERE surgele_id = @surgele_id
END

CREATE PROCEDURE DeleteProduitFrais
    @frais_id INT
AS
BEGIN
    DELETE FROM ProduitFrais
    WHERE frais_id = @frais_id
END

CREATE PROCEDURE DeleteMaterielCuisine
    @materiel_id INT
AS
BEGIN
    DELETE FROM MaterielCuisine
    WHERE materiel_id = @materiel_id
END

CREATE PROCEDURE DeleteRecette
    @recette_id INT
AS
BEGIN
    DELETE FROM Recette
    WHERE recette_id = @recette_id
END

CREATE PROCEDURE DeletePlatCuisine
    @plat_id INT
AS
BEGIN
    DELETE FROM PlatCuisine
    WHERE plat_id = @plat_id
EN
=======
GO
>>>>>>> f996ad33d52e8a77808c4f7a76d5d5cde780e273
