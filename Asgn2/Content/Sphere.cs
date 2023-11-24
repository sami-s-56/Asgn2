using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgn2.Content
{
    internal class Sphere : Object
    {
        public Sphere(Game1 game1) : base(game1)
        {
        }

        public override void LoadContent()
        {
            _model = _game1.Content.Load<Model>("Sphere");
            _effect = _game1.Content.Load<Effect>("LitTeapotShader");
            _texture = _game1.Content.Load<Texture2D>("Metal");

            objectPos = new Vector3(0, 0, 0);

        }

        public override void Update()
        {
            //Handle the rotation stuff here
        }

        public override void Draw()
        {
            Matrix mWorld = Matrix.CreateTranslation(objectPos);
            Matrix wvp = mWorld * _game1.viewMat * _game1.projectionMat;

            Matrix wM = Matrix.Identity;

            _effect.Parameters["WorldViewProjection"].SetValue(wvp);
            _effect.Parameters["world"].SetValue(wM);
            _effect.Parameters["Tex"].SetValue(_texture);
            _effect.Parameters["lightColor"].SetValue(new Vector3(1, 1, 1));
            _effect.Parameters["specColor"].SetValue(new Vector3(1, 0, 0));
            _effect.Parameters["camPos"].SetValue(new Vector3(0, 0, 1));

            foreach (ModelMesh mesh in _model.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = _effect;
                }

                // Draw the mesh
                mesh.Draw();
            }
        }
    }
}
