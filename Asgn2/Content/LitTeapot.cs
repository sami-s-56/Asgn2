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
    internal class LitTeapot : Object
    {

        Vector3 lightPos;
        Vector3 initMousePos;
        Vector2 viewPortCenter;

        public LitTeapot(Game1 game1) : base(game1)
        {
        }

        public override void LoadContent()
        {
            _model = _game1.Content.Load<Model>("Teapot");
            _texture = _game1.Content.Load<Texture2D>("Metal");
            _effect = _game1.Content.Load<Effect>("LitTeapotShader");

            objectPos = new Vector3(0, 0, 0);
            
            viewPortCenter = new Vector2(_game1.GraphicsDevice.Viewport.Width / 2, _game1.GraphicsDevice.Viewport.Height / 2);
            
            MouseState currentMouseState = Mouse.GetState();
            initMousePos = new Vector3(currentMouseState.X, currentMouseState.Y, 1);
        }

        public override void Start()
        {
            ResetLightPos();
        }

        public override void Update()
        {
            // Get the current state of the mouse
            MouseState currentMouseState = Mouse.GetState();

            // Calculate the change in mouse position
            float deltaX = (initMousePos.X + currentMouseState.X);
            float deltaY = -(initMousePos.Y + currentMouseState.Y);
            
            // Update the object's position based on the change in mouse position
            Vector3 deltaVec = Vector3.Zero;

            deltaVec += new Vector3(deltaX, deltaY, 1);

            lightPos = (deltaVec - new Vector3(viewPortCenter.X, -viewPortCenter.Y, 0)) * .05f;
            lightPos.Z = 1;

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

            _game1._ui.DrawText($"Light Pos At: {lightPos}", Color.White);
        }

        internal void ResetLightPos()
        {
            lightPos = new Vector3(0, 0, 1);
   
            Mouse.SetPosition((int)viewPortCenter.X, (int)viewPortCenter.Y);
        }
    }
}
