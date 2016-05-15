using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPC_Game
{
    public interface XnaStandard
    {
        void LoadContent();
        void UnloadContent();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
