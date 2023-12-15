using System;
using System.Data.SqlClient;
using System.IO;



namespace Restaurant.BDD
{
    public class connection
    {
        public static void Main1()
        {
            string strConnexion = "Data Source=localhost; Integrated Security=SSPI;" + "Initial Catalog=Restaurant";
            try
            {
                SqlConnection oConnection = new SqlConnection(strConnexion);
                oConnection.Open();
                Console.WriteLine("Etat de la connexion : " + oConnection.State);
                oConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("L'erreur suivante a été rencontrée :" + e.Message);
            }
        }
    }
}

//
// using System;
// using System.Data.SqlClient;
//
// public class Connection
// {
//     public static void Main1()
//     {
//         // Chaîne de connexion à la base de données
//         string strConnexion = "Data Source=localhost; Integrated Security=SSPI;" + "Initial Catalog=Restaurant";
//
//         // Création de l'objet de connexion
//         SqlConnection connection = new SqlConnection(strConnexion);
//
//         try
//         {
//             // Ouverture de la connexion
//             connection.Open();
//
//             // Connexion réussie, vous pouvez exécuter des requêtes ici
//
//             // Exemple : exécution d'une requête SELECT
//             string query = "SELECT * FROM essai";
//             SqlCommand command = new SqlCommand(query, connection);
//
//             // Exécution de la requête et récupération des résultats
//             SqlDataReader reader = command.ExecuteReader();
//             while (reader.Read())
//             {
//                 // Traitez les données ici
//                 string valeurColonne = reader.GetString(0);
//                 Console.WriteLine(valeurColonne);
//             }
//             reader.Close();
//         }
//         catch (Exception ex)
//         {
//             // Gestion des erreurs
//             Console.WriteLine("Une erreur s'est produite : " + ex.Message);
//         }
//         finally
//         {
//             // Fermeture de la connexion
//             connection.Close();
//         }
//
//         Console.ReadLine();
//     }
// }
