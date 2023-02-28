using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using MonoFightingGameProject.utils;

namespace MonoFightingGameProject
{
    using static MFGConstants;
    using static GameSimulation;

    public static class MFGConstants
    {
        public const int INPUT_LEFT = (1 << 0);
        public const int INPUT_RIGHT = (1 << 1);
        public const int INPUT_UP = (1 << 2);
        public const int INPUT_DOWN = (1 << 3);
    }

    public struct ActionStateFuncs
    {
        public Action OnStart;
        public Action OnUpdate;
        public Action OnEnd;
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont font;

        // Test sprites
        public Texture2D ballTexture;

        public string debugMessage;

        long inputs;
        public GameState gameState;
        public ActionStateFuncs TestFuncs;

        public void TestOnStart()
        {
            Console.WriteLine("on start func test");
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Change window size from default.
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 360;
            _graphics.ApplyChanges();

            Console.WriteLine("Game has been opened.");

            gameState = new GameState(2);

            // Initial object state
            gameState.physicsComponents[0].position = new IntVector2D()
            {
                x = 350,
                y = 200
            };

            TestFuncs = new ActionStateFuncs()
            {
                OnStart = TestOnStart
            };

            TestFuncs.OnStart();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ballTexture = Content.Load<Texture2D>("Sprites/target");
            font = Content.Load<SpriteFont>("Fonts/DefaultFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Reset input values
            inputs = 0;

            // Inputs from Gamepad
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            if (gamePadState.IsConnected)
            {
                if(gamePadState.DPad.Left == ButtonState.Pressed)
                {
                    inputs |= INPUT_LEFT;
                }
                if(gamePadState.DPad.Right == ButtonState.Pressed)
                {
                    inputs |= INPUT_RIGHT;
                }
                if(gamePadState.DPad.Up == ButtonState.Pressed)
                {
                    inputs |= INPUT_UP;
                }
                if(gamePadState.DPad.Down == ButtonState.Pressed)
                {
                    inputs |= INPUT_DOWN;
                }
            }

            // Inputs from Keyboard
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState != null)
            {
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    inputs |= INPUT_LEFT;
                }
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    inputs |= INPUT_RIGHT;
                }
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    inputs |= INPUT_UP;
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    inputs |= INPUT_DOWN;
                }
            }

            debugMessage = Convert.ToString(inputs, 2);

            // Game Simulation
            {
                // Update position of object based on player input.
                {
                    ref PhysicsComponent entity = ref gameState.physicsComponents[0];
                    if ((inputs & INPUT_LEFT) != 0) { entity.velocity.x = -1; ; }
                    else if ((inputs & INPUT_RIGHT) != 0) { entity.velocity.x = 1; }
                    else { entity.velocity.x = 0; }
                    if ((inputs & INPUT_UP) != 0) { entity.velocity.y = -1; }
                    else if ((inputs & INPUT_DOWN) != 0) { entity.velocity.y = 1; }
                    else { entity.velocity.y = 0; }
                }

                UpdateGame(ref gameState);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(ballTexture,
                new Vector2(gameState.physicsComponents[0].position.x, gameState.physicsComponents[0].position.y),
                Color.White);

            _spriteBatch.DrawString(font, gameState.frameCount.ToString(), new Vector2(10, 10), Color.White);
            _spriteBatch.DrawString(font, debugMessage, new Vector2(10, 300), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
