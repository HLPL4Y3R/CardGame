using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CardGame
{
    public class CardGame : Game
    {
        private Viewport ViewportInstance;
        private GraphicsDeviceManager GraphicsDeviceInstance;
        private SpriteBatch SpriteBatchInstance;
        private InterfaceManager InterfaceManagerInstance;
        private Input InputInstance;
        private Debug DebugInstance;

        public CardGame()
        {
            GraphicsDeviceInstance = new GraphicsDeviceManager(this);
            InputInstance = new Input(Window);
            InterfaceManagerInstance = new InterfaceManager(InputInstance);
            DebugInstance = new Debug();

            Content.RootDirectory = "resources";
            GraphicsDeviceInstance.PreferredBackBufferWidth = 1280;
            GraphicsDeviceInstance.PreferredBackBufferHeight = 720;

            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += UpdateRender;
            Window.AllowAltF4 = true;

            IsMouseVisible = true;
        }

        /// <summary>
        /// Called when the framework has loaded
        /// </summary>
        protected override void Initialize()
        {
            IsFixedTimeStep = true;
            GraphicsDeviceInstance.SynchronizeWithVerticalRetrace = false;
            TargetElapsedTime = TimeSpan.FromTicks((long)(TimeSpan.TicksPerSecond / 75f));
            ViewportInstance = GraphicsDeviceInstance.GraphicsDevice.Viewport;
            base.Initialize();
        }

        /// <summary>
        /// Called when ready to load media content
        /// </summary>
        protected override void LoadContent()
        {
            SpriteBatchInstance = new SpriteBatch(GraphicsDevice);
            Media.LoadMedia(Content);
        }

        /// <summary>
        /// Called every frame alongside Draw, used for logic
        /// </summary>
        protected override void Update(GameTime gameTime)
        {


            InputInstance.Update();
            InterfaceManagerInstance.Update(ViewportInstance, InputInstance, gameTime);



            base.Update(gameTime);
        }

        /// <summary>
        /// Called every frame after Update, used for rendering (consider multithreading)
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(22,22,22));
            SpriteBatchInstance.Begin();

            InterfaceManagerInstance.Draw(SpriteBatchInstance, ViewportInstance);





            DebugInstance.Draw(SpriteBatchInstance, InputInstance);

            SpriteBatchInstance.End();
            base.Draw(gameTime);
        }

        public void UpdateRender(object sender, EventArgs e)
        {
            ViewportInstance.Width = Window.ClientBounds.Width;
            ViewportInstance.Height = Window.ClientBounds.Height;
        }
    }
}
