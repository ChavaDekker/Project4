using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Forms = System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Npgsql;



namespace EersteVersieProject3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;     //Contains extra information like screen resolution
        KeyboardState oldState;             //Makes it possible to compare the old keyboard state with the new one
        MouseState oldMouse;                //Makes it possible to compare the old mouse state with the new one
        SpriteBatch spriteBatch;            //Makes it possible to draw on screen
        GameState gamestate;                //See class GameState 
        NpgsqlCommand cmd;        //For communicating with the server given to it in Program.cs

        public Game1(NpgsqlCommand cmd)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            gamestate = new GameState(All_Textures, oldState, oldMouse);
            Main_Menu_Screen = new Loading_and_Menu(cmd, new Rectangle(290, 435, 70, 25), new Rectangle(445, 435, 70, 25), new Rectangle(710, 10, 100, 20));

            this.cmd = cmd;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() 
        {
            base.Initialize();

            oldState = Keyboard.GetState();
            oldMouse = Mouse.GetState();
            this.IsMouseVisible = true;     //You can see the cursor
        }

        

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>        

        Textures All_Textures;
        List<Monument> Monumentenlijst;
        Loading_and_Menu Main_Menu_Screen;
        float Screen_Width_Ratio;
        float Screen_Height_Ratio;

        protected override void LoadContent()             //Everything that can be loaded before running the updates happens here
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            int Screen_Width_Resolution = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;      //Takes the resolution of the pc's display
            int Screen_Height_resolution = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Screen_Width_Ratio = 800f / (float)Screen_Width_Resolution;     //Makes an aspect ratio, used for making it so, that the passed on mouse coordinates match the monogame pixel coordinates 
            Screen_Height_Ratio = 600f / (float)Screen_Height_resolution;

            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            // --------------------------- HERE, ALL THE TEXTURES ARE PLACED ------------------------------------------------------

            Texture2D day_time_background = Content.Load<Texture2D>("Tijdelijk_achtergrond.png");
            Texture2D Stadswapen = Content.Load<Texture2D>("Rotterdam_wapen maar kleiner.png");
            Texture2D MonumentLogo = Content.Load<Texture2D>("Monument-logo.png");
            Texture2D Tekstvak = Content.Load<Texture2D>("tekstvak-zonder-tekst.png");
            Texture2D Main_menu_background = Content.Load<Texture2D>("euromast.png");
            Texture2D Word_Art = Content.Load<Texture2D>("Word_Art.png");

            SpriteFont Arial_12 = Content.Load<SpriteFont>("NewSpriteFont");

            //All textures are put into a class, so they can easily be accessed
            All_Textures = new Textures(day_time_background, Stadswapen, MonumentLogo, Tekstvak, Arial_12, Main_menu_background, Word_Art);

            //BELOW: instances of class Monument are made with data from the database
            MonumentenMaker monumentenmaker = new MonumentenMaker(cmd, 0, 1, 2, 3, 4, 5, 6, 11, 12, All_Textures);

            Monumentenlijst = monumentenmaker.MaakMonumenten();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()  
        {
            All_Textures.Arial_12 = null;           
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))  
                Exit();      //exits the game

            gamestate.UpdateWithInput(graphics, Monumentenlijst, Main_Menu_Screen, Screen_Width_Ratio, Screen_Height_Ratio); //GO TO the method for explanation

            if (gamestate.Windows_form_boot_up == true) { Main_Menu_Screen.Run_Windows_Form(graphics, gamestate); } //Calls method that opens windows form

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // DEPENDING ON WHICH BOOLEAN IS TRUE, IT DRAWS!

            spriteBatch.Begin();
            if (gamestate.Loading_Screen == true)
            {
                Loading_and_Menu.The_Loading_Screen(graphics, All_Textures, spriteBatch, gamestate);
            }

            if (gamestate.Main_Game == true)
            {
                spriteBatch.Draw(All_Textures.day_time_background, Vector2.Zero, Color.White);
                spriteBatch.DrawString(All_Textures.Arial_12, "Back to menu", new Vector2(700, 10), Color.Black);
                Monument.DrawAllMonumenten(spriteBatch, All_Textures.Arial_12, Monumentenlijst);  
            }

            if (gamestate.Main_Menu == true)
            {
                Main_Menu_Screen.Draw_The_Menu(graphics, All_Textures, spriteBatch);
            }


            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
