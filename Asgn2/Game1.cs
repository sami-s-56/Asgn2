using Asgn2.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Asgn2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Form1 _form1;

        public UI _ui;
        Teapot teapot;
        LitTeapot litTeapot;
        Sphere sphere;

        public List<Object> objects = new List<Object>();

        public Matrix viewMat;
        public Matrix projectionMat;
        public float DeltaTime;

        bool bPauseUpdate = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            viewMat = Matrix.CreateLookAt(new Vector3(0, 0, 5),
                new Vector3(0, 0, 0), Vector3.UnitY);   //Camera and Pos 0, 0, 2 looking at origin

            projectionMat = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45f),
                _graphics.GraphicsDevice.Viewport.AspectRatio,
                .1f,
                100f);  //Default Projection Matrix

            teapot = new Teapot(this);
            litTeapot = new LitTeapot(this);
            sphere = new Sphere(this);
            objects.Add(sphere);

            for(int i = 0; i < 4; i++) 
            {
                Box b = new Box(this, sphere);
                b.LoadContent();
                objects.Add(b);
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _ui = new UI(_spriteBatch, Content);
            
            _form1 = new Form1();

            teapot.LoadContent();
            litTeapot.LoadContent();
            sphere.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // TODO: Add your update logic here
            if(_form1.option == 1)
            {
                teapot.Update();
            }
            else if(_form1.option == 2)
            {
                litTeapot.Update();
            }
            else if (_form1.option == 3)
            {
                for(int i = 0; i < objects.Count; i++) 
                {
                    objects[i].Update();
                }

                //Handle new Instantiations

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _form1.Show();

            if (_form1.option == 1)
            {
                teapot.Draw();
            }
            else if (_form1.option == 2)
            {
                litTeapot.Draw();
            }
            else if (_form1.option == 3)
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    objects[i].Draw();
                }
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}