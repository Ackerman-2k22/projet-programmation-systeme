using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using RestaurantManager.View;

namespace RestaurantManager.Controller;

public class ClientController
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
    public ClientController(Model model, RestaurantView restaurantView, float speed)
    {
        _model = model;
        _restaurantView = restaurantView;
        _speed = speed;
        _initialPosition = _model.ChefDeRang.Position.Position;
        
        
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
    else
    {
        //ReturnToInitial();
    }
}

private bool CheckClientArrival(Table nearestTable)
{
    if (nearestTable != null && !_clientArrived)
    {
        Vector2 targetPosition1 = _model._maitreDHotelPosition;
        MoveToPosition(ref _model._groupePosition, targetPosition1, _speed);

        if (CheckCollision(_model._maitreDHotelPosition, _restaurantView._maitreDHotelTexture.Width,
            _restaurantView._maitreDHotelTexture.Height, _model._groupePosition,
            _restaurantView._clientTexture.Width, _restaurantView._clientTexture.Height))
        {
            Console.WriteLine("Un groupe de client est arrivé !");
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
        Table assignedTable = FindNearestTableWithCapacity(nearestTable, _model.Groupe.NumberOfPeople);
        if (assignedTable != null && clientArrived)
        {
            float distanceThreshold = 1.0f; // Limite de distance pour considérer l'arrivée à la table
            Vector2 targetPosition = assignedTable.Position.Position;
            float speed = _speed;

            int entitiesAtTable = 0;

            if (Vector2.Distance(_model._groupePosition, targetPosition) < distanceThreshold)
            {
                entitiesAtTable++;
            }

            if (Vector2.Distance(_model._chefDeRangPosition, targetPosition) < distanceThreshold)
            {
                entitiesAtTable++;
            }

            if (entitiesAtTable == 2)
            {
                Console.WriteLine("Le Chef de Rang et les clients sont arrivés à leur table !");
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
                    Vector2 interpolatedgroupePosition = Vector2.Lerp(_model._groupePosition, targetPosition, t);

                    MoveToPosition(ref _model._chefDeRangPosition, interpolatedChefDeRangPosition, speed);
                    MoveToPosition(ref _model._groupePosition, interpolatedgroupePosition, speed);

                    // Vérifier si le client est arrivé à la table
                    if (!clientAtTable && Vector2.Distance(interpolatedgroupePosition, targetPosition) < 0.1f)
                    {
                        clientAtTable = true;
                        MoveToPosition(ref _model._groupePosition, targetPosition, 0f); // Arrêter le mouvement du client
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