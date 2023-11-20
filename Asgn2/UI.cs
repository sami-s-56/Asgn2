using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgn2
{
    public class UI
    {
        //Font
        private SpriteFont _font;

        SpriteBatch _spriteBatch;

        public UI(SpriteBatch sb, ContentManager _content) 
        {
            _spriteBatch = sb;
            _font = _content.Load<SpriteFont>("Ariel12");
        }

        //For Drawing Text
        public void DrawText(string _text, Color color)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, _text, new Vector2(50, 50), color);
            _spriteBatch.End();
        }
    }
}
