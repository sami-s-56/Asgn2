using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Asgn2.Content
{
    public class Box : Object, IDisposable
    {
        Object target;

        public Box(Game1 game1, Object target) : base(game1)
        {
            this.target = target;
        }

        public override void LoadContent()
        {
            _model = _game1.Content.Load<Model>("Box");
            _effect = _game1.Content.Load<Effect>("LitTeapotShader");
            //_effect = _game1.Content.Load<Effect>("LightShader");
            _texture = _game1.Content.Load<Texture2D>("Smiley2");

            objectPos = GetRandomVector();

        }

        public override void Update()
        {
            Vector3 direction = target.objectPos - objectPos;
            direction.Normalize();

            objectPos += (direction * _game1.DeltaTime);

            if (Vector3.Distance(objectPos, target.objectPos) <= 1f)
                Dispose();
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
        }

        private Vector3 GetRandomVector()
        {
            Random random = new Random();

            float minX = -5f;
            float minY = -5f;
            float minZ = -5f;

            float maxX = 5f;
            float maxY = 5f;
            float maxZ = 5f;

            float randomX = (float)(random.NextDouble() * (maxX - minX) + minX);
            float randomY = (float)(random.NextDouble() * (maxY - minY) + minY);
            float randomZ = (float)(random.NextDouble() * (maxZ - minZ) + minZ);

            return new Vector3(randomX, randomY, randomZ);
        }

        public void Dispose()
        {
            _game1.objects.Remove(this);
        }
    }
}
