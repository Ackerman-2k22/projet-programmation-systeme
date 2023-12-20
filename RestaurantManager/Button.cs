using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RestaurantManager;

public class Button
{
    private SpriteFont _font;
    private string _text;
    private Vector2 _position;
    public Rectangle Bounds => new Rectangle((int)_position.X, (int)_position.Y, (int)_font.MeasureString(_text).X, (int)_font.MeasureString(_text).Y);
    public bool IsClicked { get; private set; }
    public bool IsHovered { get; private set; }
 

    public Button(SpriteFont font, string text, Vector2 position)
    {
        _font = font;
        _text = text;
        _position = position;
    }

    public void Update()
    {
        MouseState mouseState = Mouse.GetState();
        Point mousePosition = new Point(mouseState.X, mouseState.Y);

        IsHovered = Bounds.Contains(mousePosition);

        if (IsHovered && mouseState.LeftButton == ButtonState.Pressed)
        {
            IsClicked = true;
        }
        else
        {
            IsClicked = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Color textColor = IsHovered ? Color.Blue : Color.White;
        spriteBatch.DrawString(_font, _text, _position, textColor);
    }
    
}
