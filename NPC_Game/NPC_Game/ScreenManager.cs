using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPC_Game
{
    public class ScreenManager
    {
        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }
        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;

        private static ScreenManager instance;
        private GameScreen currentScreen;
        private XmlManager<GameScreen> xmlGameScreenManager;
        
        public static ScreenManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }


        public ScreenManager()
        {
            Dimensions = new Vector2(1920, 1080);
            currentScreen = new SplashScreen();
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = currentScreen.Type;
            currentScreen = xmlGameScreenManager.Load("Load/SplashScreen.xml");
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gametime)
        {
            currentScreen.Update(gametime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
