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
    private ClientController clientController;
    private RestaurantView restaurantView;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Model _model;
    private bool _isGamePaused = false;
    private Texture2D _paused;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1080; 
        _graphics.PreferredBackBufferHeight = 740;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _model = new Model();

        restaurantView = new RestaurantView(_graphics, _spriteBatch, Content.Load<Texture2D>("client1"), Content.Load<Texture2D>("client4"),Content.Load<Texture2D>("Table"), Content.Load<Texture2D>("client3"),Content.Load<Texture2D>("client2"),Content.Load<Texture2D>("Client"),Content.Load<Texture2D>("client3"),Content.Load<Texture2D>("restaurant"),Content.Load<Texture2D>("groupe7"),Content.Load<Texture2D>("cuisto"),Content.Load<Texture2D>("cuisto"),Content.Load<Texture2D>("client2"),Content.Load<Texture2D>("client4"));
        restaurantController = new RestaurantController(_model, restaurantView, 1f);
        clientController = new ClientController(_model, restaurantView, 1f);
        _model._chefDeRangPosition =
            new Vector2(415,210);
        _model._maitreDHotelPosition =
            new Vector2(920, 320);
        _model._clientPosition =
            new Vector2(920, 730);
        _model._groupePosition = 
            new Vector2(920, 730);
        _model._serveurPosition =
            new Vector2(170, 250);
        _model._commisDeSallePosition =
            new Vector2(189, 460);
        _model._chefDeCuisinePosition =
            new Vector2(76, 119);
        _model._chefDePartiePosition =
            new Vector2(79, 349);
        _model._plongeurPosition = 
            new Vector2(74, 650);
        _model._commisDeCuisinePosition =
            new Vector2(74, 545);
        _model._comptoirPosition = 
            new Vector2(123, 350);
        _model._chefDeRangPosition2 =
            new Vector2(415, 382);
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

        bool isRestaurantUpdateFinished = false;

        if (!_isGamePaused)
        {
            restaurantController.Update();
        }

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