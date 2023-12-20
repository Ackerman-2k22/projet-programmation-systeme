using System;
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
    private bool _clientMoved;
    private Table assignedTable;
    public RestaurantController(Model model, RestaurantView restaurantView, float speed
        //,GameTime gameTime
        )
    {
        _model = model;
        _restaurantView = restaurantView;
        _speed = speed
                 //*(float)gameTime.ElapsedGameTime.TotalSeconds
                 ;
        _initialPosition = _model.ChefDeRang.Position.Position;
        //_clientArrived = false;
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
            HandleKeyboardInput();

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

            if (clientMoved)
            {
                HandleTableOccupation(nearestTable);
            }
        }
    }

private bool CheckClientArrival(Table nearestTable)
{
    if (nearestTable != null && !_clientArrived)
    {
        Vector2 targetPosition1 = _model._maitreDHotelPosition;
        MoveToPosition2(ref _model._clientPosition, targetPosition1, _speed);

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

        Task.Run(async () =>
        {
            _chefDeRangMoved = MoveTowardsPosition(ref _model._chefDeRangPosition, targetPosition, speed);

            if (_chefDeRangMoved)
            {
                Console.WriteLine("Le Chef de Rang a atteint la position du Maître d'Hôtel !");
                _model.IsClientHandled = true;
            }
        }).Wait(TimeSpan.FromSeconds(2));
    }

    return _chefDeRangMoved;
}

private void HandleTableOccupation(Table nearestTable)
{
    if (CheckCollision(nearestTable.Position.Position, _restaurantView._tableTexture.Width,
            _restaurantView._tableTexture.Height, _model._chefDeRangPosition,
            _restaurantView._chefDeRangTexture.Width, _restaurantView._chefDeRangTexture.Height) &&
        CheckCollision(nearestTable.Position.Position, _restaurantView._tableTexture.Width,
            _restaurantView._tableTexture.Height, _model._clientPosition,
            _restaurantView._clientTexture.Width, _restaurantView._clientTexture.Height))
    {
        Console.WriteLine("Le chef de rang a installé des clients sur une table !");
        nearestTable.OccupyTable();
    }
    else
    {
        // Actions à effectuer si la table n'est pas occupée
    }
}

public bool MoveClientAndChefDeRangToTableIfNeeded(Table nearestTable, bool clientArrived)
{
    if (clientArrived && !_clientMoved && _chefDeRangMoved)
    {
        Table assignedTable = FindNearestTableWithCapacity(nearestTable, _model.Client.NumberOfPeople);
        if (assignedTable != null && !_clientMoved)
        {
            Task.Run(async () =>
            {
                Vector2 targetClientPosition = assignedTable.Position.Position;
                _clientMoved = MoveTowardsPosition(ref _model._clientPosition, targetClientPosition, _speed*60);
                Vector2 targetChefDeRangPosition = assignedTable.Position.Position;
                _chefDeRangMoved = MoveTowardsPosition(ref _model._chefDeRangPosition, targetChefDeRangPosition, _speed*60);
                if (CheckCollision(assignedTable.Position.Position, _restaurantView._tableTexture.Width, _restaurantView._tableTexture.Height, _model._clientPosition, _restaurantView._clientTexture.Width, _restaurantView._clientTexture.Height) || CheckCollision(assignedTable.Position.Position, _restaurantView._tableTexture.Width, _restaurantView._tableTexture.Height, _model._chefDeRangPosition, _restaurantView._chefDeRangTexture.Width, _restaurantView._chefDeRangTexture.Height))
                {
                    Console.WriteLine("Le Chef de Rang et le client sont arrivés à leur table !");
                    _model.IsChefDeRangHandle = true;
                }



                // Effectuez les actions supplémentaires ici une fois que les deux sont à la table

            }).Wait(TimeSpan.FromSeconds(2));
        }
        return _clientMoved && _chefDeRangMoved;
    }
    return false;
}

private bool MoveTowardsPosition(ref Vector2 currentPosition, Vector2 targetPosition, float speed)
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
    
    private async Task<bool> MoveToPositionAsync( Vector2 currentPosition, Vector2 targetPosition, float speed, GameTime gameTime)
    {
        float distance = Vector2.Distance(currentPosition, targetPosition);
        Vector2 direction = Vector2.Normalize(targetPosition - currentPosition);
        Vector2 displacement = direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Vérifier si le déplacement dépasse la distance restante
        if (displacement.Length() > distance)
        {
            currentPosition = targetPosition;
            return true;
        }
        else
        {
            currentPosition += displacement;
            await Task.Delay(1); // Attendre un court laps de temps pour laisser la tâche se terminer
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
    
    private void MoveToPosition2(ref Vector2 currentPosition, Vector2 targetPosition, float speed)
    {
        Vector2 direction = targetPosition - currentPosition;
        direction.Normalize();
        currentPosition += direction * speed;
        Console.WriteLine("Position : X = " + currentPosition.X + ", Y = " + currentPosition.Y);
        //_model._chefDeRangPosition=currentPosition ;
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
    private void HandleKeyboardInput()
    {
        var kstate = Keyboard.GetState();
        if (kstate.IsKeyDown(Keys.Z))
        {
            _model._clientPosition.Y -= _speed;
        }
        if (kstate.IsKeyDown(Keys.S))
        {
            _model._clientPosition.Y += _speed;
        }
        if (kstate.IsKeyDown(Keys.Q))
        {
            _model._clientPosition.X -= _speed;
        }
        if (kstate.IsKeyDown(Keys.D))
        {
            _model._clientPosition.X += _speed;
        }
    }

}
    /*
public async void Update(GameTime gameTime)
{
    HandleKeyboardInput(gameTime);

    Table nearestTable = _model.Tables.Find(t => !t.Occupied);
    // Trouver la table attribuée de manière asynchrone
    Table assignedTable = await FindNearestTableWithCapacityAsync(ref nearestTable, _model.Client.NumberOfPeople);

    if (nearestTable != null && !clientArrived)
    {
        // Déplacer le client de manière asynchrone
        Vector2 targetPosition1 = _model._maitreDHotelPosition;
        bool clientCollisionDetected = false;

        await Task.Run(async () =>
        {
            _model._clientPosition = await MoveToPositionAsync(_model._clientPosition, targetPosition1, _speed, gameTime);
            clientCollisionDetected = CheckCollisionWithObstacles(_model._clientPosition);
        });

        if (clientCollisionDetected)
        {
            Console.WriteLine("Un client est arrivé !");
            clientArrived = true;
        }
    }

    if (clientArrived)
    {
        // Déplacer le chef de rang de manière asynchrone
        Vector2 targetPosition1 = _model._maitreDHotelPosition;
        bool chefDeRangCollisionDetected = false;

        await Task.Run(async () =>
        {
            _model._chefDeRangPosition = await MoveToPositionAsync(_model._chefDeRangPosition, targetPosition1, _speed, gameTime);
            chefDeRangCollisionDetected = CheckCollisionWithObstacles(_model._chefDeRangPosition);
        });

        if (chefDeRangCollisionDetected)
        {
            // Une collision a été détectée pour le chef de rang, arrêtez le déplacement ici si nécessaire
            return;
        }


        if (!_model.ChefDeRang.HasAssignedTable() && CheckCollision(_model._maitreDHotelPosition, _restaurantView._maitreDHotelTexture.Width, _restaurantView._maitreDHotelTexture.Height, _model._chefDeRangPosition, _restaurantView._chefDeRangTexture.Width, _restaurantView._chefDeRangTexture.Height))
        {
            // Déplacer le chef de rang et le client vers la position de la table de manière asynchrone
            Vector2 targetPosition = assignedTable.Position.Position;

            await Task.Run(async () =>
            {
                _model._clientPosition = await MoveToPositionAsync(_model._clientPosition, targetPosition, _speed, gameTime);
            });
        }

        if (assignedTable != null && clientArrived)
        {
            Vector2 targetPosition2 = assignedTable.Position.Position;

            await Task.Run(async () =>
            {
                _model._chefDeRangPosition = await MoveToPositionAsync(_model._chefDeRangPosition, targetPosition2, _speed, gameTime);
            });
        }

        if (CheckCollision(nearestTable.Position.Position, _restaurantView._tableTexture.Width, _restaurantView._tableTexture.Height, _model._clientPosition, _restaurantView._clientTexture.Width, _restaurantView._clientTexture.Height) && CheckCollision(nearestTable.Position.Position, _restaurantView._tableTexture.Width, _restaurantView._tableTexture.Height, _model._chefDeRangPosition, _restaurantView._chefDeRangTexture.Width, _restaurantView._chefDeRangTexture.Height))
        {
            Console.WriteLine("Le chef de rang a installé des clients sur une table !");
            nearestTable.OccupyTable();
        }
    }

    // ...
}

private Task<Vector2> MoveToPositionAsync(Vector2 currentPosition, Vector2 targetPosition, float speed, GameTime gameTime)
{
    return Task.Run(() =>
    {
        Vector2 direction = targetPosition - currentPosition;
        direction.Normalize();
        float distance = Vector2.Distance(currentPosition, targetPosition);
        float displacement = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        while (distance > displacement)
        {
            currentPosition += direction * displacement;

            // Check for collision here if necessary
            if (CheckCollisionWithObstacles(currentPosition))
            {
                return currentPosition;
            }

            distance = Vector2.Distance(currentPosition, targetPosition);
            Console.WriteLine("Position : X = " + currentPosition.X + ", Y = " + currentPosition.Y);
        }

        // Move the object to the final target position
        currentPosition = targetPosition;

        return currentPosition;
    });
}
private Task<Table> FindNearestTableWithCapacityAsync(ref Table nearestTable, int numberOfPeople)
{
    return Task.Run(() =>
    {
        Table tableWithCapacity = null;
        foreach (Table table in _model.Tables)
        {
            if (!table.Occupied && table.Capacity >= numberOfPeople)
            {
                tableWithCapacity = table;
                break;
            }
        }
        return tableWithCapacity;
    });
}
   */
/*
private void ReturnToPosition(Vector2 position, GameTime gameTime)
 {
     Vector2 direction = position - _model._chefDeRangPosition;
     direction.Normalize();

     if (direction.Length() > 0.01f)
     {
         _model._chefDeRangPosition += direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

         Console.WriteLine("Position du chef de rang : X = " + _model._chefDeRangPosition.X + ", Y = " +
                           _model._chefDeRangPosition.Y);
     }
     else
     {
         _model.ChefDeRang.ClearAssignedTable();
     }
 }
private Table GetNearestAvailableTable()
{
    Table nearestTable = null;
    float nearestDistance = float.MaxValue;

    foreach (Table table in _model.Tables)
    {
        if (!table.Occupied && table.Capacity >= _model.Client.NumberOfPeople)
        {
            float distance = Vector2.Distance(_model.ChefDeRang.Position.Position, table.Position.Position);
            if (distance < nearestDistance)
            {
                nearestTable = table;
                nearestDistance = distance;
            }
        }
    }
    return nearestTable;
}*/