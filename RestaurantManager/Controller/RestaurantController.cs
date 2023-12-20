using System;
using System.Collections.Generic;
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
    private List<Client> _clients;
    
    public RestaurantController(Model model, RestaurantView restaurantView, float speed)
    {
        _model = model;
        _restaurantView = restaurantView;
        _speed = speed;
        _initialPosition = _model.ChefDeRang.Position.Position;
        _clients = new List<Client>(_model.AllClients);
        
    }
    private void CallNextClient()
    {
        if (_clients.Count > 0)
        {
            // Sélectionnez le prochain client à partir de la liste des clients à gérer
            Client nextClient = _clients[0];
            _clients.RemoveAt(0); // Retirez le client de la liste

            // Effectuez les actions nécessaires pour appeler le prochain client
            // Par exemple, assignez le prochain client à la variable _model.Client
            _model.Client = nextClient;
            // Réinitialisez les états et effectuez d'autres actions nécessaires pour accueillir le prochain client
            _model.IsClientHandled = false;
            _model.IsClientArrived = false;
            // ...
        }
    }
    public void ResetClientHandlingState()
    {
        // Réinitialisez les états liés au client précédent
        _model.IsClientHandled = false;
        _model.IsChefDeRangHandle = false;
        //assignedTable?.FreeTable();

        // Appelez le deuxième client
        CallNextClient();
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
        ReturnToInitial();
        if (ReturnToInitial())
        {
                  ResetClientHandlingState();
                  _model.Client = new Client("2", "calm", "calm,", 10);
        }
    }
}

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

            bool clientAtTable = MoveToPosition(ref _model._chefDeRangPosition, targetPosition, speed)
                //&& MoveToPosition(ref _model._clientPosition, targetPosition, speed)
                ;
            bool chefDeRangAtTable = MoveToPosition(ref _model._clientPosition, targetPosition, speed);

            if (clientAtTable && chefDeRangAtTable)
            {
                if (Vector2.Distance(_model._clientPosition, assignedTable.Position.Position) < distanceThreshold ||
                    Vector2.Distance(_model._chefDeRangPosition, assignedTable.Position.Position) < distanceThreshold)
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
                }
            }
                return clientAtTable && chefDeRangAtTable;
        }
    }

    return false;
}


public bool ReturnToInitial()
{
    Vector2 initialChefDeRangPosition = new Vector2(450, 200);
    float speed = _speed;

    bool chefDeRangAtInitialPosition = MoveToPosition(ref _model._chefDeRangPosition, initialChefDeRangPosition, speed);
    
    if (chefDeRangAtInitialPosition && Vector2.Distance(_model._chefDeRangPosition, initialChefDeRangPosition) < 1f)
    {
        Console.WriteLine("Le chef de rang est revenu à sa position initiale !");
        ResetClientHandlingState();
        CallNextClient();
    }

    return chefDeRangAtInitialPosition;
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

private Table FindNearestTableWithCapacity(Table referenceTable, int minCapacity)
{
    Table nearestTable = null;
    float nearestDistance = float.MaxValue;

    foreach (Table table in _model.Tables)
    {
        if (!table.Occupied && table.Capacity >= minCapacity)
        {
            float distance = CalculateDistance(referenceTable.Position, table.Position);
            if (distance < nearestDistance)
            {
                nearestTable = table;
                nearestDistance = distance;
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
