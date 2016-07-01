using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using Forms = System.Windows.Forms;
using Npgsql;


namespace EersteVersieProject3
{
    public class Loading_and_Menu
    {
        public Rectangle Click_area_Start_map, Click_area_start_graph, Click_area_exit;
        NpgsqlCommand cmd;

        public Loading_and_Menu(NpgsqlCommand cmd, Rectangle Click_area_Start_map, Rectangle Click_area_start_graph, Rectangle Click_area_exit)
        {
            this.Click_area_Start_map = Click_area_Start_map;
            this.Click_area_start_graph = Click_area_start_graph;
            this.Click_area_exit = Click_area_exit;
            this.cmd = cmd;
        }

        public void Run_Windows_Form(GraphicsDeviceManager graphics, GameState gamestate) //Boots up windows form in a seperate thread, and freezes monogame
        {
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Thread Tweede_thread = new Thread(new ThreadStart(start_form));
            Tweede_thread.Start();
            gamestate.Windows_form_boot_up = false;

            Tweede_thread.Join();
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        private void start_form() //Starts the form, made as a method so threading became possible
        {
            Forms.Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false); Thought it was usefull, but wasnt in the end
            Forms.Application.Run(new Grafieken(cmd));
            
        }




        public static void The_Loading_Screen(GraphicsDeviceManager graphics, Textures All_Textures, SpriteBatch spriteBatch, GameState gamestate)
        {
            graphics.GraphicsDevice.Clear(Color.White);                                          //These are the images.
            spriteBatch.Draw(All_Textures.Stadswapen, new Vector2(95, 20), Color.White);

            gamestate.Loading_Screen_For_Ticks = gamestate.Loading_Screen_For_Ticks + 1;         //Manages the time the loading-screen-state stays active

            if (gamestate.Loading_Screen_For_Ticks == 150) { gamestate.ChangeFullScreenMode(graphics); }

            if (gamestate.Loading_Screen_For_Ticks > 240) // divide this by 60 and you have the amount of seconds the loadings screen stays
            {
                gamestate.NextStep("Main_Menu"); //Never again boot up the loading screen
            }
            
        }

        public void Draw_The_Menu(GraphicsDeviceManager graphics, Textures All_Textures, SpriteBatch spriteBatch) //Draws the menu
        {
            graphics.GraphicsDevice.Clear(Color.White);
            spriteBatch.Draw(All_Textures.Main_menu_background, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(All_Textures.Word_Art, new Vector2(200, 80), Color.White);
            spriteBatch.DrawString(All_Textures.Arial_12, "Start Map", new Vector2(290, 350), Color.White);
            spriteBatch.DrawString(All_Textures.Arial_12, "Start Graph", new Vector2(440, 350), Color.White);
            spriteBatch.DrawString(All_Textures.Arial_12, "Exit", new Vector2(750, 10), Color.White);







        }






    }
}
