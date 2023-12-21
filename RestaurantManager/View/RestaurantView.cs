using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RestaurantManager.Controller;

namespace RestaurantManager.View;

public class RestaurantView
{
    public SpriteBatch _spriteBatch;
    public Texture2D _chefDeRangTexture;
    public Texture2D _maitreDHotelTexture;
    public Texture2D _clientTexture;
    public Texture2D _tableTexture;
    public Texture2D _serveurTexture;
    public Texture2D _comptoirTexture;
    public Texture2D _commisDeSalleTexture;
    public Texture2D _chefDeCuisineTexture;
    public Texture2D _chefDePartieTexture;
    public Texture2D _plongeurTexture;
    public Texture2D _commisDeCuisineTexture;
    public Texture2D _restaurantTexture;
    public Texture2D _groupeTexture;
    public GraphicsDeviceManager _graphics;
    

    public RestaurantView(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Texture2D chefDeRangTexture, Texture2D maitreDHotelTexture, Texture2D tableTexture, Texture2D clientTexture,
    Texture2D serveurTexture,
    Texture2D comptoirTexture,
    Texture2D commisDeSalleTexture,
    Texture2D restaurantTexture,
    Texture2D groupeTexture,
     Texture2D chefDeCuisineTexture,
     Texture2D chefDePartieTexture,
     Texture2D plongeurTexture,
     Texture2D commisDeCuisineTexture)
    {
        _graphics = graphics;
        _spriteBatch = spriteBatch;
        _chefDeRangTexture = chefDeRangTexture;
        _tableTexture = tableTexture;
        _maitreDHotelTexture = maitreDHotelTexture;
        _clientTexture = clientTexture;
        _serveurTexture = serveurTexture;
        _comptoirTexture = comptoirTexture;
        _commisDeSalleTexture = commisDeSalleTexture;
        _restaurantTexture = restaurantTexture;
        _groupeTexture = groupeTexture;
        _plongeurTexture = plongeurTexture;
        _commisDeCuisineTexture = commisDeCuisineTexture;
        _chefDePartieTexture = chefDePartieTexture;
        _chefDeCuisineTexture = chefDeCuisineTexture;
        _graphics.PreferredBackBufferHeight = _restaurantTexture.Height;
        _graphics.PreferredBackBufferHeight = _restaurantTexture.Width;


    }

    public void Draw(SpriteBatch spriteBatch, Model model)
    {
        // Calculate the scale to fit the background image to the window size
        float scale = 1.0f;

// Calculate the position to center the background image
        _graphics.PreferredBackBufferWidth = 1080; 
        _graphics.PreferredBackBufferHeight = 740;
        Vector2 position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);

        spriteBatch.Draw(
            _restaurantTexture,
            position,
            null,
            Color.White,
            0f,
            new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
            scale,
            SpriteEffects.None,
            0f
        );
        foreach (var table in model.Tables)
        {
            Vector2 tablePosition = table.Position.Position;
            spriteBatch.Draw(_tableTexture, tablePosition, Color.White);
        }
        spriteBatch.Draw(
            _maitreDHotelTexture,
            model._maitreDHotelPosition,
            null,
            Color.White,
            0f,
            new Vector2(_chefDeRangTexture.Width / 2, _chefDeRangTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
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
        spriteBatch.Draw(
            _clientTexture,
            model._clientPosition,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            _groupeTexture,
            model._groupePosition,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            _serveurTexture,
            model._serveurPosition,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            _commisDeSalleTexture,
            model._commisDeSallePosition,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            _commisDeCuisineTexture,
            model._commisDeCuisinePosition,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            _chefDeCuisineTexture,
            model._chefDeCuisinePosition,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            _chefDePartieTexture,
            model._chefDePartiePosition,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            _comptoirTexture,
            model._comptoirPosition,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        
        spriteBatch.Draw(
            _chefDeRangTexture,
            model._chefDeRangPosition2,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            _plongeurTexture,
            model._plongeurPosition,
            null,
            Color.White,
            0f,
            new Vector2(_clientTexture.Width / 2, _clientTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
    }
}