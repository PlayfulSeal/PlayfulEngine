using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlayfulEngine {
    /// <summary>
    /// The entry-point for the game
    /// </summary>
    public abstract class GameManager : Game {

        /// <summary>
        /// The <see cref="Camera2D"/> for the whole game
        /// </summary>
        public static Camera2D CAMERA;

        /// <summary>
        /// Creates a new <see cref="GameManager"/>
        /// </summary>
        /// <param name="assetLocation">Where assets should be loaded from</param>
        /// <param name="mouseVisibility">Is the mouse visible</param>
        public GameManager(string assetLocation = "Assets", bool mouseVisibility = true) {
            EngineGlobals.GRAPHICS_DEVICE_MANAGER = new GraphicsDeviceManager(this); // Creates a new GraphicsDeviceManager
            Content.RootDirectory = assetLocation; // Sets the content directory
            EngineGlobals.CONTENT_MANAGER = Content; // Sets the content manager
            IsMouseVisible = mouseVisibility; // Sets the mouse visiblity
            CAMERA = new Camera2D(); // Creates the camera
        }

        /// <summary>
        /// Initalizes the <see cref="GameManager"/>
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Loads the assets for the <see cref="GameManager"/>
        /// </summary>
        public abstract void LoadAssets();

        protected override void Initialize() {

            // TODO: Allow for different resolutions
            EngineGlobals.GRAPHICS_DEVICE_MANAGER.PreferredBackBufferWidth = 1280; // sets the width of the window
            EngineGlobals.GRAPHICS_DEVICE_MANAGER.PreferredBackBufferHeight = 720; // sets the height of the window
            EngineGlobals.GRAPHICS_DEVICE_MANAGER.ApplyChanges(); // Applys the window size
            Init(); // Initalizes the game
            base.Initialize();
        }

        protected override void LoadContent() {
            EngineGlobals.SPRITE_BATCH = new SpriteBatch(GraphicsDevice); // Creates the sprite batch

            LoadAssets(); // Loads the assets
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit(); // Closes the game with Escape

            SceneManager.Tick(); // Ticks the current scene

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            EngineGlobals.GRAPHICS_DEVICE_MANAGER.GraphicsDevice.Clear(Color.CornflowerBlue); // Clears the screen

            EngineGlobals.SPRITE_BATCH.Begin(samplerState: SamplerState.PointClamp, transformMatrix: CAMERA.GetTransformation()); // Starts rendering
            SceneManager.Render(); // Renders the gameObjects
            EngineGlobals.SPRITE_BATCH.End(); // Ends rendering

            EngineGlobals.SPRITE_BATCH.Begin(samplerState: SamplerState.PointClamp); // Starts rendering
            SceneManager.RenderUI(); // Renders all UI elements
            EngineGlobals.SPRITE_BATCH.End(); // Ends rendering

            base.Draw(gameTime);
        }
    }
}
