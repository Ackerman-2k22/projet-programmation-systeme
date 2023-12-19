﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RestaurantManager.Controller;
using RestaurantManager.View;

namespace RestaurantManager;

public class Game1 : Game
{
    private RestaurantController restaurantController;
    private RestaurantView restaurantView;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Model _model;
    private bool _isGamePaused = false;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _model = new Model();
        restaurantView = new RestaurantView(_graphics, _spriteBatch, Content.Load<Texture2D>("ChefDeRang"), Content.Load<Texture2D>("Table"));
        restaurantController = new RestaurantController(_model,restaurantView,200f);
        _model._chefDeRangPosition =
            new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here
        base.LoadContent();
    }
    private bool _pauseKeyPressed = false;
    protected override void Update(GameTime gameTime)
    {
        bool isPauseKeyDown = Keyboard.GetState().IsKeyDown(Keys.P) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start);
        if (isPauseKeyDown && !_pauseKeyPressed)
        {
            TogglePause();
        }
        _pauseKeyPressed = isPauseKeyDown;

        // Reste du code de mise à jour
        if (!_isGamePaused)
        {
            restaurantController.Update(gameTime);
            restaurantController.CheckCollision();
        }

        base.Update(gameTime);
        base.Update(gameTime);
    }
    private void TogglePause()
    {
        _isGamePaused = !_isGamePaused;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        restaurantView.Draw(_spriteBatch, _model);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}