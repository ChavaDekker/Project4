using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectSolutution2._0Android.UniversalLogic.Scene;
using ProjectSolutution2._0Android.UniversalLogic;

namespace ProjectSolutution2._0Android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 480;// 800;
            graphics.PreferredBackBufferHeight = 800;//480;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;//DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            SceneManager.AddSceneToDict(new ChooseNeighbourhoodScene(this.GraphicsDevice, "ChooseNeighbourhoodScene"));
            SceneManager.AddSceneToDict(new Testscene(this.GraphicsDevice, "TestScene"));
            SceneManager.AddSceneToDict(new Button1Scene(this.GraphicsDevice, "Button1Scene"));
            SceneManager.AddSceneToDict(new Button2Scene(this.GraphicsDevice, "Button2Scene"));
            SceneManager.AddSceneToDict(new Button3Scene(this.GraphicsDevice, "Button3Scene"));
            SceneManager.AddSceneToDict(new Button4Scene(this.GraphicsDevice, "Button4Scene"));
            SceneManager.AddSceneToDict(new Button5Scene(this.GraphicsDevice, "Button5Scene"));
            SceneManager.AddSceneToDict(new Button6Scene(this.GraphicsDevice, "Button6Scene"));
            SceneManager.AddSceneToDict(new Button7Scene(this.GraphicsDevice, "Button7Scene"));
            SceneManager.AddSceneToDict(new Button8Scene(this.GraphicsDevice, "Button8Scene"));
            SceneManager.AddSceneToDict(new MainMenuScene(this.GraphicsDevice, "MainMenuScene"));
            SceneManager.AddSceneOnStack("MainMenuScene");

            TextDrawing.LoadSpriteFonts(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here
            SceneManager.GetCurrentScene().AndroidUpdate();



            InputAcces.input.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            SceneManager.GetCurrentScene().AndroidDrawBase(spriteBatch, GraphicsDevice);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
