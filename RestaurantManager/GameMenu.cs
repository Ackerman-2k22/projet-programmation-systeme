using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RestaurantManager
{
public class GameMenu : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _backgroundTexture;
    private Texture2D _menuTexture;
    private SpriteFont _menuFont;

    private Button _playButton;
    private Button _quitButton;

    public GameMenu()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    
    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1080;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.GraphicsDevice.BlendState = BlendState.AlphaBlend;
        _graphics.ApplyChanges();

        base.Initialize();
    }
    
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _backgroundTexture = Content.Load<Texture2D>("main-background");
        _menuTexture = Content.Load<Texture2D>("menu-overlay");
        _menuFont = Content.Load<SpriteFont>("MenuFont");
        
        _playButton = new Button(_menuFont, "Play", new Vector2(950, 300));
        _quitButton = new Button(_menuFont, "Quit", new Vector2(950, 360));
    }

    protected override void Update(GameTime gameTime)
    {
        _playButton.Update();
        _quitButton.Update();
        
        if (_playButton.IsClicked)
        {
            StartGame();
        }
        else if (_quitButton.IsClicked)
        {
            Exit();
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

        _spriteBatch.Draw(_backgroundTexture, Vector2.Zero, Color.White);
        _spriteBatch.Draw(_menuTexture,Vector2.Zero,new Color(255, 255, 255, 0));

        _playButton.Draw(_spriteBatch);
        _quitButton.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void StartGame()
    {
        using var game = new Game1();
        game.Run();
    }
}

}