-- Insertions pour la table Ustensils
INSERT INTO Ustensils (ustensil_id, nom, qte)
VALUES (1, 'Couteau', 10),
(2, 'Spatule', 5),
(3, 'Fouet', 3),
(4, 'Cuillère en bois', 8),
(5, 'Mixeur', 2);

-- Insertions pour la table ProduitConserve
INSERT INTO ProduitConserve (conserve_id, nom, quantité_stock, date_livraison, date_peremption)
VALUES (1, 'Haricots verts en conserve', 50, '2023-01-05', '2025-01-05'),
(2, 'Thon en conserve', 30, '2023-02-10', '2024-12-31'),
(3, 'Maïs en conserve', 40, '2023-03-15', '2025-03-15'),
(4, 'Tomates en conserve', 20, '2023-04-20', '2024-11-30'),
(5, 'Pois chiches en conserve', 25, '2023-05-25', '2024-05-25');

-- Insertions pour la table ProduitSurgeles
INSERT INTO ProduitSurgeles (surgele_id, nom, quantité_stock, date_livraison, date_peremption)
VALUES (1, 'Poisson surgelé', 40, '2023-01-10', '2024-01-10'),
(2, 'Légumes surgelés', 60, '2023-02-15', '2024-02-15'),
(3, 'Fruits surgelés', 50, '2023-03-20', '2024-03-20'),
(4, 'Poulet surgelé', 35, '2023-04-25', '2024-04-25'),
(5, 'Pâtes surgelées', 45, '2023-05-30', '2024-05-30');

-- Insertions pour la table ProduitFrais
INSERT INTO ProduitFrais (frais_id, nom, quantité_stock, date_livraison, date_peremption)
VALUES (1, 'Lait', 100, '2023-01-01', '2023-01-07'),
(2, 'Œufs', 50, '2023-02-05', '2023-02-15'),
(3, 'Légumes frais', 80, '2023-03-10', '2023-03-18'),
(4, 'Viande fraîche', 70, '2023-04-15', '2023-04-20'),
(5, 'Fruits frais', 90, '2023-05-20', '2023-05-28');

-- Insertions pour la table MaterielCuisine
INSERT INTO MaterielCuisine (materiel_id, nom, qte)
VALUES (1, 'Poêle', 5),
(2, 'Casserole', 8),
(3, 'Fouet', 3),
(4, 'Mixeur', 2),
(5, 'Planche à découper', 6);

-- Insertions pour la table Recette
INSERT INTO Recette (recette_id, nom, etapes, instructions)
VALUES (1, 'Salade César', '1. Préparer la sauce, 2. Préparer les ingrédients, 3. Assembler la salade', 'Les instructions de préparation de la salade César...'),
(2, 'Poulet rôti', '1. Préparer le poulet, 2. Assaisonner, 3. Cuire au four', 'Les instructions de préparation du poulet rôti...'),
(3, 'Spaghetti bolognese', '1. Cuire les pâtes, 2. Préparer la sauce, 3. Mélanger la sauce avec les pâtes', 'Les instructions de préparation des spaghetti bolognese...'),
(4, 'Tarte aux pommes', '1. Préparer la pâte, 2. Éplucher et couper les pommes, 3. Assembler la tarte', 'Les instructions de préparation de la tarte aux pommes...'),
(5, 'Risotto aux champignons', '1. Faire revenir','les instruction');


-- Insertions pour la table RecetteUstensils (liaison entre Recette et Ustensils)
INSERT INTO RecetteUstensils (recette_id, ustensil_id, quantité_utilisée)
VALUES (1, 1, 1), -- Salade César utilise 1 couteau
(1, 4, 2), -- Salade César utilise 2 cuillères en bois
(2, 1, 1), -- Poulet rôti utilise 1 couteau
(2, 2, 1), -- Poulet rôti utilise 1 spatule
(2, 4, 1), -- Poulet rôti utilise 1 cuillère en bois
(3, 1, 1), -- Spaghetti bolognese utilise 1 couteau
(3, 2, 1), -- Spaghetti bolognese utilise 1 spatule
(4, 1, 1), -- Tarte aux pommes utilise 1 couteau
(4, 5, 1), -- Tarte aux pommes utilise 1 planche à découper
(5, 2, 1), -- Risotto aux champignons utilise 1 spatule
(5, 4, 1); -- Risotto aux champignons utilise 1 cuillère en bois

-- Insertions pour la table RecetteProduitConserve (liaison entre Recette et ProduitConserve)
INSERT INTO RecetteProduitsConserve (recette_id, conserve_id, quantité_utilisée)
VALUES (1, 1, 2), -- Salade César utilise 2 boîtes de haricots verts en conserve
(2, 2, 1), -- Poulet rôti utilise 1 boîte de thon en conserve
(3, 4, 3), -- Spaghetti bolognese utilise 3 boîtes de tomates en conserve
(4, 1, 1), -- Tarte aux pommes utilise 1 boîte de haricots verts en conserve
(5, 3, 2); -- Risotto aux champignons utilise 2 boîtes de maïs en conserve

-- Insertions pour la table RecetteProduitSurgeles (liaison entre Recette et ProduitSurgeles)
INSERT INTO RecetteProduitsSurgeles (recette_id, surgele_id, quantité_utilisée)
VALUES (1, 2, 1), -- Salade César utilise 1 sachet de légumes surgelés
(2, 1, 2), -- Poulet rôti utilise 2 filets de poisson surgelé
(3, 5, 2), -- Spaghetti bolognese utilise 2 portions de pâtes surgelées
(4, 2, 1), -- Tarte aux pommes utilise 1 sachet de légumes surgelés
(5, 4, 1); -- Risotto aux champignons utilise 1 filet de poulet surgelé

-- Insertions pour la table RecetteProduitFrais (liaison entre Recette et ProduitFrais)
INSERT INTO RecetteProduitsFrais (recette_id, frais_id, quantité_utilisée)
VALUES (1, 3, 3), -- Salade César utilise 3 portions de légumes frais
(2, 4, 1), -- Poulet rôti utilise 1 morceau de viande fraîche
(3, 2, 2), -- Spaghetti bolognese utilise 2 œufs
(4, 5, 2), -- Tarte aux pommes utilise 2 portions de fruits frais
(5, 3, 2); -- Risotto aux champignons utilise 2 portions de légumes frais

-- Insertions pour la table RecetteMateriel (liaison entre Recette et Materiel)
INSERT INTO RecetteMateriel (recette_id, materiel_id, quantité_utilisée)
VALUES (1, 1, 2), -- Salade César nécessite 2 couteaux
       (1, 4, 1), -- Salade César nécessite 1 cuillère en bois
       (2, 1, 2), -- Poulet rôti nécessite 2 couteaux
       (2, 2, 1), -- Poulet rôti nécessite 1 spatule
       (2, 4, 1), -- Poulet rôti nécessite 1 cuillère en bois
       (3, 1, 1), -- Spaghetti bolognese nécessite 1 couteau
       (3, 2, 1), -- Spaghetti bolognese nécessite 1 spatule
       (4, 1, 2), -- Tarte aux pommes nécessite 2 couteaux
       (4, 5, 1), -- Tarte aux pommes nécessite 1 planche à découper
       (5, 2, 1), -- Risotto aux champignons nécessite 1 spatule
       (5, 4, 1); -- Risotto aux champignons nécessite 1 cuillère en bois