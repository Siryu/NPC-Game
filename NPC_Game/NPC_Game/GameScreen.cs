using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NPC_Game
{
    public class GameScreen
    {
        protected ContentManager Content;
        [XmlIgnore]
        public Type Type { get; private set; }

        public GameScreen()
        {
            Type = this.GetType();
        }

        public virtual void LoadContent()
        {
            this.Content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            this.Content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
