using System;
using Microsoft.Xna.Framework;
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
    private Texture2D _paused;

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
        restaurantView = new RestaurantView(_graphics, _spriteBatch, Content.Load<Texture2D>("ChefDeRang"), Content.Load<Texture2D>("MaitreDHotel"),Content.Load<Texture2D>("Table"), Content.Load<Texture2D>("Client"));
        restaurantController = new RestaurantController(_model,restaurantView,5f);
        _model._chefDeRangPosition =
            new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        _model._maitreDHotelPosition =
            new Vector2(250, 200);
        _model._clientPosition =
            new Vector2(30, 10);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _paused = Content.Load<Texture2D>("paused");
        // TODO: use this.Content to load your game content here
        base.LoadContent();
    }
    private bool _pauseKeyPressed = false;
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        bool isPauseKeyDown = Keyboard.GetState().IsKeyDown(Keys.P) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start);
        if (isPauseKeyDown && !_pauseKeyPressed)
        {
            TogglePause();
        }
        _pauseKeyPressed = isPauseKeyDown;

        if (!_isGamePaused)
        {
            restaurantController.Update();
        }

        base.Update(gameTime);
    }
    
    private void UpdateGameLogic(GameTime gameTime)
    { 
        if (!_model.IsClientHandled)
        {
            restaurantController.Update();
        }
        
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
        if (_isGamePaused)
        {
            float pauseScale = Math.Min((float)_graphics.PreferredBackBufferWidth / _paused.Width, (float)_graphics.PreferredBackBufferHeight / _paused.Height);
            Vector2 pausePosition = new Vector2((_graphics.PreferredBackBufferWidth - _paused.Width * pauseScale) / 2, (_graphics.PreferredBackBufferHeight - _paused.Height * pauseScale) / 2);
            _spriteBatch.Draw(_paused, pausePosition, null, Color.White, 0f, Vector2.Zero, pauseScale, SpriteEffects.None, 0f);
        }
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}