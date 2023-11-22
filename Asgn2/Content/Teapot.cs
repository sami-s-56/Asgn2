using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgn2.Content
{
    internal class Teapot : Object
    {
        MouseState pms;

        public Teapot(Game1 game1) : base(game1)
        {
            pms = Mouse.GetState();
        }

        public override void LoadContent() 
        {
            _model = _game1.Content.Load<Model>("Teapot");
            _effect = _game1.Content.Load<Effect>("TeapotShader");
            _texture = _game1.Content.Load<Texture2D>("Smiley2");

            objectPos = new Vector3(0, 0, 0);

        }

        public override void Update()
        {
            //Handle the movement stuff here
            
            MouseState ms = Mouse.GetState();
            int MouseX = ms.X;
            int MouseY = ms.Y;

            //Vector3 movVec = new Vector3(pms.X - ms.X, pms.Y - ms.Y, 0);
            Vector3 movVec = new Vector3( ms.X - pms.X, ms.Y - pms.Y, 0);
            //objectPos += movVec;
            
            pms = ms;
        }

        public override void Draw()
        {
            Matrix mWorld = Matrix.CreateTranslation(objectPos);
            Matrix wvp = mWorld * _game1.viewMat * _game1.projectionMat;


            _effect.Parameters["WorldViewProjection"].SetValue(wvp);
            _effect.Parameters["Tex"].SetValue(_texture);

            foreach (ModelMesh mesh in _model.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = _effect;
                }

                // Draw the mesh
                mesh.Draw();
            }
            
            //_game1._ui.DrawText($"Teapot At: {objectPos}", Color.White);
        }
    }
}
