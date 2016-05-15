using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NPC_Game
{
    public class Image : XnaStandard
    {
        public float Alpha;
        public string Text;
        public string FontName;
        public string Path;
        public Vector2 Position;
        public Vector2 Scale;
        public Texture2D Texture;
        public Rectangle SourceRect;

        private Vector2 Origin;
        private ContentManager Content;
        private RenderTarget2D RenderTarget;
        private SpriteFont Font;

        public Image()
        {
            Path = String.Empty;
            Text = String.Empty;
            FontName = "Times New Roman";
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            SourceRect = Rectangle.Empty;
        }

        public void LoadContent()
        {
            this.Content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            Vector2 dimensions = Vector2.Zero;

            this.Font = Content.Load<SpriteFont>("Fonts/" + FontName);

            if (this.Path != String.Empty)
            {
                this.Texture = Content.Load<Texture2D>(this.Path);
            }

            if (this.Texture != null)
            {
                dimensions.X += Texture.Width;
                dimensions.Y = Math.Max(Texture.Height, Font.MeasureString(Text).Y);
            }
            else
            {
                dimensions.Y = Font.MeasureString(Text).Y;
            }
            dimensions.X += Font.MeasureString(Text).X;

          

            if(this.SourceRect == Rectangle.Empty)
            {
                SourceRect = new Rectangle(0, 0, (int)dimensions.X, (int)dimensions.Y);
            }

            RenderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, (int)dimensions.X, (int)dimensions.Y);
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(RenderTarget);
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            ScreenManager.Instance.SpriteBatch.Begin();
            ScreenManager.Instance.SpriteBatch.Draw(Texture, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.DrawString(Font, Text, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.End();

            Texture = RenderTarget;

            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);
        }

        public void UnloadContent()
        {
            Content.Unload();
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Origin = new Vector2(SourceRect.Width / 2, SourceRect.Height / 2);
            spriteBatch.Draw(Texture, Position + Origin, SourceRect, Color.White * Alpha, 0.0f, Origin, Scale, SpriteEffects.None, 0.0f);
        }
    }
}
