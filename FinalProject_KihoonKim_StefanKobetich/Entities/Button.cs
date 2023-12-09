using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MissilesNMinesEscape.Entities
{
    /// <summary>
    /// Button Class that allows the use of buttons in our game. Used for the user to choose
    /// </summary>
    public class Button
    {
        private Vector2 position;
        private string text;
        private Color backgroundColor;
        private Color hoverColor;
        private SpriteFont font;
        private GraphicsDevice graphicsDevice;

        public Button(Vector2 position, string text, Color backgroundColor, Color hoverColor, SpriteFont font, GraphicsDevice graphicsDevice)
        {
            this.position = position;
            this.text = text;
            this.backgroundColor = backgroundColor;
            this.hoverColor = hoverColor;
            this.font = font;
            this.graphicsDevice = graphicsDevice;
        }

        // Draws the button
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw button background
            Color currentColor = IsMouseOver() ? hoverColor : backgroundColor;
            Rectangle buttonRectangle = new Rectangle((int)position.X, (int)position.Y, 200, 50);
            spriteBatch.Draw(GetTexture(currentColor), buttonRectangle, currentColor);

            // Draw button text
            Vector2 textSize = font.MeasureString(text);
            Vector2 textPosition = position + new Vector2((buttonRectangle.Width - textSize.X) / 2, (buttonRectangle.Height - textSize.Y) / 2);
            spriteBatch.DrawString(font, text, textPosition, Color.White);
        }

        // Method to handle if the button is clicked
        public bool IsClicked(Point mousePosition)
        {
            Rectangle buttonRectangle = new Rectangle((int)position.X, (int)position.Y, 200, 50);
            return buttonRectangle.Contains(mousePosition);
        }

        // Method to handle if mouse is over the button
        public bool IsMouseOver()
        {
            Rectangle buttonRectangle = new Rectangle((int)position.X, (int)position.Y, 200, 50);
            return buttonRectangle.Contains(Mouse.GetState().Position);
        }

        // The texture of the button
        private Texture2D GetTexture(Color color)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { color });
            return texture;
        }
    }
}
