using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgn2.Content
{
    public class Object
    {
        public Model _model;
        public Effect _effect;
        public Texture2D _texture;

        //World Matrix for the Object
        public Vector3 objectPos;

        public Game1 _game1;

        public Object(Game1 game1)
        {
            _game1 = game1;
        }

        public virtual void Start() { }

        public virtual void LoadContent(){}

        public virtual void Update(){}

        public virtual void Draw(){}
    }
}
