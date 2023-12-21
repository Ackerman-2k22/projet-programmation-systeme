using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RestaurantManager.View;
using System.Threading.Tasks;

namespace RestaurantManager.Controller;

public class RestaurantController : IObserver<Table>
{
    private Model _model;
    private RestaurantView _restaurantView;
    private float _speed;
    private Vector2 _initialPosition;
    private bool _clientArrived;
    private bool _chefDeRangMoved;
    private bool clientAtTable;
    private bool _clientMoved;
    private Table assignedTable;
    private ClientController _clientController;
    public RestaurantController(Model model, RestaurantView restaurantView, float speed)
    {
        _model = model;
        _restaurantView = restaurantView;
        _speed = speed;
        _initialPosition = _model.ChefDeRang.Position.Position;
        _clientController = new ClientController(_model, _restaurantView,speed);
        
        
    }

    private bool CheckCollisionWithObstacles(Vector2 position)
    {
        return false;
    }

    public void OnNext(Table value)
    {
        // Implémentation de la méthode OnNext
        // Ce code sera exécuté lorsque la source observable enverra de nouvelles valeurs
    }

    public void OnCompleted()
    {
        // Implémentation de la méthode OnCompleted
        // Ce code sera exécuté lorsque la source observable aura terminé l'envoi de valeurs
    }

    public void OnError(Exception error)
    {
        // Implémentation de la méthode OnError
        // Ce code sera exécuté si une erreur se produit dans la source observable
    }
    public void AssignTableToChefDeRang(Table table)
    {
        _model.MaitreDHotel.AssignTable(table, _model.ChefDeRang);
    }
    public void Update()
    {
        if (!_model.IsClientHandled)
        {
            Table nearestTable = _model.Tables.Find(t => !t.Occupied);

            bool clientArrived = CheckClientArrival(nearestTable);
            bool chefDeRangMoved = MoveChefDeRangIfNeeded(clientArrived);

            if (clientArrived)
            {
                _model.IsClientArrived = true;
            }
        }
        else if (!_model.IsChefDeRangHandle)
        {
            Table nearestTable = _model.Tables.Find(t => !t.Occupied);

            bool clientArrived = CheckClientArrival(nearestTable);
            bool clientMoved = MoveClientAndChefDeRangToTableIfNeeded(nearestTable, clientArrived);
        }
        else if (!_model.IsMenuCommunicationDone)
        {
            bool chefDeRangMovedToChefDeCuisine = MoveChefDeRangToChefDeCuisine();

            if (chefDeRangMovedToChefDeCuisine)
            {
                _model.IsMenuCommunicationDone = true;
            }
        }
        else if (!_model.IsRecipeCommunicationDone)
        {
            bool chefDeCuisineMovedToChefDePartie = MoveChefDeCuisineToChefDePartie();

            if (chefDeCuisineMovedToChefDePartie)
            {
                _model.IsRecipeCommunicationDone = true;
            }
        }
        else if (!_model.IsPreparationCompleted)
        {
            bool chefDePartieMovedToCommisDeCuisine = MoveChefDePartieToCommisDeCuisine();

            if (chefDePartieMovedToCommisDeCuisine)
            {
                _model.IsPreparationCompleted = true;
            }
        }
        else if (!_model.IsDishDeliveryDone)
        {
            bool commisDeCuisineMovedToCounter = MoveCommisDeCuisineToCounter();

            if (commisDeCuisineMovedToCounter)
            {
                _model.IsDishDeliveryDone = true;
            }
        }
        else if (!_model.IsDishServedToClient)
        {
            bool serveurMovedToTable = MoveServeurToTable();

            if (serveurMovedToTable)
            {
                _model.IsDishServedToClient = true;
            }
        }
        else
        {
            _clientController.Update();
        }
    }
    private bool MoveChefDeRangToChefDeCuisine()
{
    Vector2 targetPosition = _model._chefDeCuisinePosition;
    float speed = _speed;

    bool chefDeRangAtChefDeCuisine = MoveToPosition(ref _model._chefDeRangPosition, targetPosition, speed);

    // Vérifier si le chef de rang est arrivé au chef de cuisine
    if (chefDeRangAtChefDeCuisine && Vector2.Distance(_model._chefDeRangPosition, targetPosition) < 1f)
    {
        Console.WriteLine("Le Chef de Rang est arrivé au Chef de Cuisine !");
        return true;
    }

    return false;
}

private bool MoveChefDeCuisineToChefDePartie()
{
    Vector2 targetPosition = _model._chefDePartiePosition;
    float speed = _speed;

    bool chefDeCuisineAtChefDePartie = MoveToPosition(ref _model._chefDeCuisinePosition, targetPosition, speed);

    // Vérifier si le chef de cuisine est arrivé au chef de partie
    if (chefDeCuisineAtChefDePartie && Vector2.Distance(_model._chefDeCuisinePosition, targetPosition) < 1f)
    {
        Console.WriteLine("Le Chef de Cuisine communique la recette au Chef de Partie !");
        return true;
    }

    return false;
}

private bool MoveChefDePartieToCommisDeCuisine()
{
    Vector2 targetPosition = _model._commisDeCuisinePosition;
    float speed = _speed;

    bool chefDePartieAtCommisDeCuisine = MoveToPosition(ref _model._chefDePartiePosition, targetPosition, speed);

    // Vérifier si le chef de partie est arrivé au commis de cuisine
    if (chefDePartieAtCommisDeCuisine && Vector2.Distance(_model._chefDePartiePosition, targetPosition) < 1f)
    {
        Console.WriteLine("Le Chef de Partie prépare le repas avec le Commis de Cuisine !");
        return true;
    }

    return false;
}

private bool MoveCommisDeCuisineToCounter()
{
    Vector2 targetPosition = _model._comptoirPosition;
    float speed = _speed;

    bool commisDeCuisineAtCounter = MoveToPosition(ref _model._commisDeCuisinePosition, targetPosition, speed);

    // Vérifier si le commis de cuisine est arrivé au comptoir
    if (commisDeCuisineAtCounter && Vector2.Distance(_model._commisDeCuisinePosition, targetPosition) < 1f)
    {
        Console.WriteLine("Le Commis de Cuisine dépose le plat au comptoir !");
        return true;
    }

    return false;
}

private bool MoveServeurToTable()
{
    Vector2 targetPosition = _model._clientPosition;
    float speed = _speed;

    bool serveurAtTable = MoveToPosition(ref _model._serveurPosition, targetPosition, speed);

    // Vérifier si le serveur est arrivé à la table
    if (serveurAtTable && Vector2.Distance(_model._serveurPosition, targetPosition) < 1f)
    {
        Console.WriteLine("Le Serveur recupère le plat du comptoir et s'en va servir le client !");
        return true;
    }

    return false;
}

/*private bool MoveToPosition(ref Vector2 currentPosition, Vector2 targetPosition, float speed)
{
    Vector2 direction = targetPosition - currentPosition;
    float distance = Vector2.Distance(currentPosition, targetPosition);

    if (distance > 0.1f)
    {
        Vector2 moveVector = direction.normalized * speed * Time.deltaTime;
        currentPosition += moveVector;
        return false;
    }

    return true;
}*/

private bool CheckClientArrival(Table nearestTable)
{
    if (nearestTable != null && !_clientArrived)
    {
        Vector2 targetPosition1 = _model._maitreDHotelPosition;
        MoveToPosition(ref _model._clientPosition, targetPosition1, _speed);

        if (CheckCollision(_model._maitreDHotelPosition, _restaurantView._maitreDHotelTexture.Width,
            _restaurantView._maitreDHotelTexture.Height, _model._clientPosition,
            _restaurantView._clientTexture.Width, _restaurantView._clientTexture.Height))
        {
            Console.WriteLine("Un client est arrivé !");
            _clientArrived = true;
        }
    }

    return _clientArrived;
}

private bool MoveChefDeRangIfNeeded(bool clientArrived)
{
    if (!_model.ChefDeRang.HasAssignedTable() && clientArrived && !_chefDeRangMoved)
    {
        Vector2 targetPosition = _model._maitreDHotelPosition;
        float speed = _speed;

        _chefDeRangMoved = MoveToPosition(ref _model._chefDeRangPosition, targetPosition, speed);

        if (_chefDeRangMoved)
        {
            Console.WriteLine("Le Chef de Rang a atteint la position du Maître d'Hôtel !");
            _model.IsClientHandled = true;
        }
    }

    return _chefDeRangMoved;
}

public bool MoveClientAndChefDeRangToTableIfNeeded(Table nearestTable, bool clientArrived)
{
    if (clientArrived && _chefDeRangMoved)
    {
        Table assignedTable = FindNearestTableWithCapacity(nearestTable, _model.Client.NumberOfPeople);
        if (assignedTable != null && clientArrived)
        {
            float distanceThreshold = 1.0f; // Limite de distance pour considérer l'arrivée à la table
            Vector2 targetPosition = assignedTable.Position.Position;
            float speed = _speed;

            int entitiesAtTable = 0;

            if (Vector2.Distance(_model._clientPosition, targetPosition) < distanceThreshold)
            {
                entitiesAtTable++;
            }

            if (Vector2.Distance(_model._chefDeRangPosition, targetPosition) < distanceThreshold)
            {
                entitiesAtTable++;
            }

            if (entitiesAtTable == 2)
            {
                Console.WriteLine("Le Chef de Rang et le client sont arrivés à leur table !");
                assignedTable.OccupyTable();
                if (assignedTable.Occupied)
                {
                    Console.WriteLine("Le chef de rang a installé des clients sur une table !");
                    Vector2 target = _model.ChefDeRang.Position.Position;
                    MoveToPosition(ref _model._chefDeRangPosition, target, _speed);
                    _model.IsChefDeRangHandle = true;
                }
                return true;
            }
            else
            {
                float arrivalTimeThreshold = 2.0f; // Temps minimal en secondes pour considérer l'arrivée à la table

                Stopwatch stopwatch = Stopwatch.StartNew();
                bool clientAtTable = false;
                bool chefDeRangAtTable = false;

                while (stopwatch.Elapsed.TotalSeconds < arrivalTimeThreshold)
                {
                    float t = (float)(stopwatch.Elapsed.TotalSeconds / arrivalTimeThreshold);

                    // Interpoler les positions pour un mouvement fluide
                    Vector2 interpolatedChefDeRangPosition = Vector2.Lerp(_model._chefDeRangPosition, targetPosition, t);
                    Vector2 interpolatedClientPosition = Vector2.Lerp(_model._clientPosition, targetPosition, t);

                    MoveToPosition(ref _model._chefDeRangPosition, interpolatedChefDeRangPosition, speed);
                    MoveToPosition(ref _model._clientPosition, interpolatedClientPosition, speed);

                    // Vérifier si le client est arrivé à la table
                    if (!clientAtTable && Vector2.Distance(interpolatedClientPosition, targetPosition) < 0.1f)
                    {
                        clientAtTable = true;
                        MoveToPosition(ref _model._clientPosition, targetPosition, 0f); // Arrêter le mouvement du client
                    }

                    // Vérifier si le chef de rang est arrivé à la table
                    if (!chefDeRangAtTable && Vector2.Distance(interpolatedChefDeRangPosition, targetPosition) < 0.1f)
                    {
                        chefDeRangAtTable = true;
                        MoveToPosition(ref _model._chefDeRangPosition, targetPosition, 0f); // Arrêter le mouvement du chef de rang
                    }

                    // Sortir de la boucle si les deux entités sont arrivées à la table
                    if (clientAtTable && chefDeRangAtTable)
                    {
                        break;
                    }
                }

                stopwatch.Stop();

                if (clientAtTable && chefDeRangAtTable)
                {
                    Console.WriteLine("Le Chef de Rang et le client sont arrivés à leur table !");
                    assignedTable.OccupyTable();
                    if (assignedTable.Occupied)
                    {
                        Console.WriteLine("Le chef de rang a installé des clients sur une table !");
                        Vector2 target = _model.ChefDeRang.Position.Position;
                        MoveToPosition(ref _model._chefDeRangPosition, target, _speed);
                        _model.IsChefDeRangHandle = true;
                    }
                    return true;
                }
            }
        }
    }

    return false;
}


public bool ReturnToInitial()
{
    Vector2 initialChefDeRangPosition = new Vector2(450, 200);
    float speed = _speed;

    bool chefDeRangAtInitialPosition = MoveToPosition(ref _model._chefDeRangPosition, initialChefDeRangPosition, speed);

    // Vérifier si le chef de rang est revenu à sa position initiale
    if (chefDeRangAtInitialPosition && Vector2.Distance(_model._chefDeRangPosition, initialChefDeRangPosition) < 1f)
    {
        Console.WriteLine("Le chef de rang est revenu à sa position initiale !");
        _model.IsChefDeRangHandle = false;
        return true;
    }

    return false;
}

private bool MoveToPosition(ref Vector2 currentPosition, Vector2 targetPosition, float speed)
{
    float distance = Vector2.Distance(currentPosition, targetPosition);
    Vector2 direction = Vector2.Normalize(targetPosition - currentPosition);
    Vector2 displacement = direction * speed;

    if (displacement.Length() > distance)
    {
        currentPosition = targetPosition;
        return true;
    }
    else
    {
        currentPosition += displacement;
        return false;
    }
}

private Table FindNearestTableWithCapacity(Table referenceTable, int numberOfPeople)
{
    Table nearestTable = null;
    float nearestDistance = float.MaxValue;

    foreach (Table table in _model.Tables)
    {
        if (!table.Occupied && table.Capacity == numberOfPeople)
        {
            float distance = CalculateDistance(referenceTable.Position, table.Position);
            if (distance < nearestDistance)
            {
                nearestTable = table;
                nearestDistance = distance;
            }
        }
    }
    if (nearestTable == null)
    {
        foreach (Table table in _model.Tables)
        {
            if (!table.Occupied && table.Capacity > numberOfPeople)
            {
                float distance = CalculateDistance(referenceTable.Position, table.Position);
                if (distance < nearestDistance)
                {
                    nearestTable = table;
                    nearestDistance = distance;
                }
            }
        }
    }

    return nearestTable;
}

private float CalculateDistance(Coordinate position1, Coordinate position2)
{
    float deltaX = position2.Position.X - position1.Position.X;
    float deltaY = position2.Position.Y - position1.Position.Y;
    return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
}

public bool CheckCollision(Vector2 position1, int width1, int height1, Vector2 position2, int width2, int height2)
{
    Rectangle rectangle1 = new Rectangle(
        (int)(position1.X - width1 / 2),
        (int)(position1.Y - height1 / 2),
        width1,
        height1);

    Rectangle rectangle2 = new Rectangle(
        (int)(position2.X - width2 / 2),
        (int)(position2.Y - height2 / 2),
        width2,
        height2);

    return rectangle1.Intersects(rectangle2);
}
}
