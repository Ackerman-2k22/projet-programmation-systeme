-- Création de la table Ustensils
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Ustensils')
BEGIN
    CREATE TABLE Ustensils (
        ustensil_id INT PRIMARY KEY,
        nom VARCHAR(50),
        qte INT

    );
END
GO

-- Création de la table ProduitConserve
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ProduitConserve')
BEGIN
    CREATE TABLE ProduitConserve (
        conserve_id INT PRIMARY KEY,
        nom VARCHAR(50),
        quantité_stock INT,
        date_livraison DATE,
        date_peremption DATE
    );
END
GO

-- Création de la table ProduitSurgeles
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ProduitSurgeles')
BEGIN
    CREATE TABLE ProduitSurgeles (
        surgele_id INT PRIMARY KEY,
        nom VARCHAR(50),
        quantité_stock INT,
        date_livraison DATE,
        date_peremption DATE
    );
END
GO

-- Création de la table ProduitFrais
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ProduitFrais')
BEGIN
    CREATE TABLE ProduitFrais (
        frais_id INT PRIMARY KEY,
        nom VARCHAR(50),
        quantité_stock INT,
        date_livraison DATE,
        date_peremption DATE
    );
END
GO

-- Création de la table MaterielCuisine
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MaterielCuisine')
BEGIN
    CREATE TABLE MaterielCuisine (
        materiel_id INT PRIMARY KEY,
        nom VARCHAR(50),
        qte INT
    );
END
GO

-- Création de la table Recette
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Recette')
BEGIN
    CREATE TABLE Recette (
        recette_id INT PRIMARY KEY,
        nom VARCHAR(50),
        etapes VARCHAR(255),
        instructions TEXT
    );
END
GO

-- Création de la table PlatCuisine
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PlatCuisine')
BEGIN
    CREATE TABLE PlatCuisine (
        plat_id INT PRIMARY KEY,
        nom VARCHAR(255),
        description VARCHAR(255),
        date_cuisson DATE
    );
END
GO

-- Création de la table RecetteUstensils
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteUstensils')
BEGIN
    CREATE TABLE RecetteUstensils (
        recette_id INT,
        ustensil_id INT,
		quantité_utilisée INT,
        PRIMARY KEY (recette_id, ustensil_id),
        FOREIGN KEY (recette_id) REFERENCES Recette(recette_id),
        FOREIGN KEY (ustensil_id) REFERENCES Ustensils(ustensil_id)
    );
END
GO

-- Création de la table RecetteProduitsConserve
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteProduitsConserve')
BEGIN
    CREATE TABLE RecetteProduitsConserve (
        recette_id INT,
        conserve_id INT,
        quantité_utilisée INT,
        PRIMARY KEY (recette_id, conserve_id),
        FOREIGN KEY (recette_id) REFERENCES Recette(recette_id),
        FOREIGN KEY (conserve_id) REFERENCES ProduitConserve(conserve_id)
    );
END
GO

-- Création de la table RecetteProduitsSurgeles
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteProduitsSurgeles')
BEGIN
    CREATE TABLE RecetteProduitsSurgeles (
        recette_id INT,
        surgele_id INT,
        quantité_utilisée INT,
        PRIMARY KEY (recette_id, surgele_id),
        FOREIGN KEY (recette_id) REFERENCES Recette(recette_id),
        FOREIGN KEY (surgele_id) REFERENCES ProduitSurgeles(surgele_id)
    );
END
GO

-- Création de la table RecetteProduitsFrais
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteProduitsFrais')
BEGIN
    CREATE TABLE RecetteProduitsFrais (
        recette_id INT,
        frais_id INT,
        quantité_utilisée INT,
        PRIMARY KEY (recette_id, frais_id),
        FOREIGN KEY (recette_id) REFERENCES Recette(recette_id),
        FOREIGN KEY (frais_id) REFERENCES ProduitFrais(frais_id)
    );
END
GO

-- Création de la table RecetteMateriel
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'RecetteMateriel')
BEGIN
    CREATE TABLE RecetteMateriel (
        recette_id INT,
        materiel_id INT,
        quantité_utilisée INT,
        PRIMARY KEY (recette_id, materiel_id),
        FOREIGN KEY (recette_id) REFERENCES Recette(recette_id),
        FOREIGN KEY (materiel_id) REFERENCES MaterielCuisine(materiel_id)
    );
END
GO

-- Création de la table PlatRecette
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PlatRecette')
BEGIN
    CREATE TABLE PlatRecette (
        plat_id INT,
        recette_id INT,
        PRIMARY KEY (plat_id, recette_id),
        FOREIGN KEY (plat_id) REFERENCES PlatCuisine(plat_id),
        FOREIGN KEY (recette_id) REFERENCES Recette(recette_id)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Client' )
BEGIN
    CREATE TABLE Client (
        client_id INT PRIMARY KEY,
        nom VARCHAR(50),
        nombre INT
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Commande' )
BEGIN
    CREATE TABLE Commande (
        client_id INT,
        plat_id INT,
        PRIMARY KEY (client_id, plat_id),
        FOREIGN KEY (client_id) REFERENCES Client(client_id),
        FOREIGN KEY (plat_id) REFERENCES PlatCuisine(plat_id)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Reservation' )
BEGIN
    CREATE TABLE Reservation (
        client_id INT,
        Heure timestamp,
        PRIMARY KEY (client_id),
        FOREIGN KEY (client_id) REFERENCES Client(client_id)
    );
END
GO

