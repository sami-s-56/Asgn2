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
        
        public Vector3 camPos = new Vector3(0,0,4);
        public Matrix mWorld = Matrix.Identity;

        bool bRestart = false;
        int noOfBoxes = 0;



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

        int prevOption = 0;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(prevOption != _form1.option)
            {
                noOfBoxes = 0;
                bRestart = true;
            }

            // TODO: Add your update logic here
            if(_form1.option == 1)
            {
                if(bRestart)
                    teapot.Start();

                teapot.Update();
            }
            else if(_form1.option == 2)
            {
                if (bRestart)
                    litTeapot.Start();
                litTeapot.Update();
                if(_form1.bResetPos)
                {
                    litTeapot.ResetLightPos();
                    _form1.ResetBool();
                }
            }
            else if (_form1.option == 3)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (!bSpawned)
                    {
                        SpawnCube();
                        bSpawned = true;
                    }
                }
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    bSpawned = false;
                }
                    
                for (int i = 0; i < objects.Count; i++) 
                {
                    if (bRestart)
                        objects[i].Start();
                    objects[i].Update();
                }
            }

            if(bRestart) bRestart = false;
            prevOption = _form1.option;

            base.Update(gameTime);
        }

        bool bSpawned = false;

        private void SpawnCube()
        {
            noOfBoxes++;
            Box b = new Box(this, sphere);
            b.LoadContent();
            b.Start();
            objects.Add(b);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _form1.Show();

            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
            
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
                _ui.DrawText($"Box Count: {noOfBoxes}", Color.LightGreen);
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}