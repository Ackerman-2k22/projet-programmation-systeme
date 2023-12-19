using System;
using Microsoft.Xna.Framework;
using RestaurantManager.View;

namespace RestaurantManager.Controller;

public class RestaurantController
{
    private Model _model;
    private RestaurantView _restaurantView;
    private float _speed;
    private Vector2 _initialPosition;

    public RestaurantController(Model model, RestaurantView restaurantView, float speed)
    {
        _model = model;
        _restaurantView = restaurantView;
        _speed = speed;
        _initialPosition = _model._chefDeRangPosition;

    }

    public void Update(GameTime gameTime)
    {
        /*
    var kstate = Keyboard.GetState();

    if (kstate.IsKeyDown(Keys.Up))
    {
        _model._chefDeRangPosition.Y -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    if (kstate.IsKeyDown(Keys.Down))
    {
        _model._chefDeRangPosition.Y += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    if (kstate.IsKeyDown(Keys.Left))
    {
        _model._chefDeRangPosition.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    if (kstate.IsKeyDown(Keys.Right))
    {
        _model._chefDeRangPosition.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    if (_model._chefDeRangPosition.X > _restaurantView._graphics.PreferredBackBufferWidth -
        _restaurantView._chefDeRangTexture.Width / 2)
    {
        _model._chefDeRangPosition.X = _restaurantView._graphics.PreferredBackBufferWidth -
                                       _restaurantView._chefDeRangTexture.Width / 2;
    }
    else if (_model._chefDeRangPosition.X < _restaurantView._chefDeRangTexture.Width / 2)
    {
        _model._chefDeRangPosition.X = _restaurantView._chefDeRangTexture.Width / 2;
    }

    if (_model._chefDeRangPosition.Y > _restaurantView._graphics.PreferredBackBufferHeight -
        _restaurantView._chefDeRangTexture.Height / 2)
    {
        _model._chefDeRangPosition.Y = _restaurantView._graphics.PreferredBackBufferHeight -
                                       _restaurantView._chefDeRangTexture.Height / 2;
    }
    else if (_model._chefDeRangPosition.Y < _restaurantView._chefDeRangTexture.Height / 2)
    {
        _model._chefDeRangPosition.Y = _restaurantView._chefDeRangTexture.Height / 2;
    }*/

        if (_model.Tables.Find(t => !t.Occupied) is Table nearestTable)
        {
            MoveToPosition(nearestTable.Position.Position,gameTime);
            if (Vector2.Distance(_model._chefDeRangPosition, nearestTable.Position.Position) < 5f)
            {
                nearestTable.OccupyTable();
                ReturnToPosition(_initialPosition,gameTime);
            }
        }
    }

    private void MoveToPosition(Vector2 position, GameTime gameTime)
    {
        Vector2 direction = position - _model._chefDeRangPosition;
        direction.Normalize();
        _model._chefDeRangPosition += direction * _speed* (float)gameTime.ElapsedGameTime.TotalSeconds;

        Console.WriteLine("Chef de rang position: X = " + _model._chefDeRangPosition.X + ", Y = " + _model._chefDeRangPosition.Y);
    }

    private void ReturnToPosition(Vector2 position,GameTime gameTime)
    {
        Vector2 direction = position - _model._chefDeRangPosition;
        direction.Normalize();
        _model._chefDeRangPosition += direction * _speed *(float)gameTime.ElapsedGameTime.TotalSeconds;

        Console.WriteLine("Chef de rang position: X = " + _model._chefDeRangPosition.X + ", Y = " + _model._chefDeRangPosition.Y);
    }
    
    

    public void CheckCollision()
    {
        Rectangle chefDeRangRectangle = new Rectangle(
            (int)(_model._chefDeRangPosition.X - _restaurantView._chefDeRangTexture.Width / 2),
            (int)(_model._chefDeRangPosition.Y - _restaurantView._chefDeRangTexture.Height / 2),
            _restaurantView._chefDeRangTexture.Width,
            _restaurantView._chefDeRangTexture.Height);

        foreach (var table in _model.Tables)
        {
            Rectangle tableRectangle = new Rectangle(
                (int)table.Position.Position.X,
                (int)table.Position.Position.Y,
                _restaurantView._tableTexture.Width,
                _restaurantView._tableTexture.Height);
            if (!table.Occupied && chefDeRangRectangle.Intersects(tableRectangle))
            {
                Console.WriteLine("Le chef de rang est à une table !");
                table.OccupyTable();
            }
        }
    }
}