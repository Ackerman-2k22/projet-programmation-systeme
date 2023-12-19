using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RestaurantManager.Controller;

namespace RestaurantManager.View;

public class RestaurantView
{
    public SpriteBatch _spriteBatch;
    public Texture2D _chefDeRangTexture;
    public Texture2D _tableTexture;
    public GraphicsDeviceManager _graphics;
    

    public RestaurantView(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Texture2D chefDeRangTexture, Texture2D tableTexture)
    {
        _graphics = graphics;
        _spriteBatch = spriteBatch;
        _chefDeRangTexture = chefDeRangTexture;
        _tableTexture = tableTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Model model)
    {
        foreach (var table in model.Tables)
        {
            Vector2 tablePosition = table.Position.Position;
            spriteBatch.Draw(_tableTexture, tablePosition, Color.White);
        }

        spriteBatch.Draw(
            _chefDeRangTexture,
            model._chefDeRangPosition,
            null,
            Color.White,
            0f,
            new Vector2(_chefDeRangTexture.Width / 2, _chefDeRangTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        
    }
}