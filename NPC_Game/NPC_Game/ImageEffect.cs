using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPC_Game
{
    public class ImageEffect
    {
        public bool IsActive;
        protected Image Image;

        public ImageEffect()
        {
            this.IsActive = false;
        }

        public virtual void LoadContent(ref Image Image)
        {
            this.Image = Image;
        }

        public virtual void UnloadContent()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
