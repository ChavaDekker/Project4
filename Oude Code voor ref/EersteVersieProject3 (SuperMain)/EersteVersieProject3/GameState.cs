using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace EersteVersieProject3
{
    public class GameState
    {
        public bool Loading_Screen, Main_Game, Main_Menu, Windows_form_boot_up;
        public int Loading_Screen_For_Ticks;
        public Textures All_textures;
        public KeyboardState oldState;
        public MouseState oldMouse;


        public GameState(Textures All_textures, KeyboardState oldState, MouseState oldMouse)       //Een heleboel attributes van type bool om te bepalen hoe ver de game is.
        {
            this.Loading_Screen = true;
            this.Loading_Screen_For_Ticks = 0;
            this.Main_Game = false;
            this.Main_Menu = false;
            this.Windows_form_boot_up = false;
            this.All_textures = All_textures;
            this.oldState = oldState;
            this.oldMouse = oldMouse;

        }
        
        public void NextStep(string choose)   //Changes the boolean attributes to determine where we are in the game. "now not anymore in the loading screen, but...."
        {
            if (choose == "Main_Game") { this.Loading_Screen = false; this.Main_Game = true; this.Main_Menu = false; }
            else if (choose == "Main_Menu") { this.Loading_Screen = false; this.Main_Game = false; this.Main_Menu = true; }
            else if (choose == "Loading_Screen") { this.Loading_Screen = true; this.Main_Game = false; this.Main_Menu = false; }
            else if (choose == "Windows_Form") { this.Loading_Screen = false; this.Main_Game = false; this.Main_Menu = true; this.Windows_form_boot_up = true; }
        }
        
        public void ChangeFullScreenMode(GraphicsDeviceManager graphics)   //Toggle full screen.
        {
            if (graphics.IsFullScreen == true) { graphics.IsFullScreen = false; }

            else if (graphics.IsFullScreen == false) { graphics.IsFullScreen = true; }
            graphics.ApplyChanges();
        }


        public void UpdateWithInput(GraphicsDeviceManager graphics, List<Monument> Monumentenlijst, Loading_and_Menu Main_menu_instance, float Screen_Width_Ratio, float Screen_Height_Ratio)
        {
            KeyboardState newState = Keyboard.GetState();
            MouseState newMouse = Mouse.GetState();                                         //Beneath stands the monogame/mouse ratio!!!


            float ThisWillBeX = newMouse.X * (Screen_Width_Ratio); //Matches the pixel resolution with the mouse position
            float ThisWillBeY = newMouse.Y * (Screen_Height_Ratio);
            Vector2 NewMouseCoordinates = new Vector2(ThisWillBeX, ThisWillBeY); //Puts them together


            // Is the key down?
            if (newState.IsKeyDown(Keys.A))                                      //press A to change full screen mode, or don't
            {
                // If not down last update, key has just been pressed.
                if (!this.oldState.IsKeyDown(Keys.A))
                {
                    this.ChangeFullScreenMode(graphics);
                }
            }

            else if (this.oldState.IsKeyDown(Keys.A))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }

            //Depending on which gamestate boolean is true, it checks if the mouse clicked in one of the areas linked with it.

            if (newMouse.LeftButton == ButtonState.Pressed)
            {
                // If not down last update, key has just been pressed.
                if (this.oldMouse.LeftButton != ButtonState.Pressed)
                {
                    if (this.Main_Game == true) //Every pin gets folded
                    {
                        foreach (Monument Monumentje in Monumentenlijst)
                        {
                            Monumentje.Pin_Un_Folded = false;
                        }

                        foreach (Monument Monumentje in Monumentenlijst) //If mouse is in one of the rectangles, unfold that pin
                        {
                            if (Monumentje.Click_area.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y))
                            {
                                Monumentje.ToggleFoldPin();
                            }
                        }

                        //If pressed on the word "menu", change gamestate booleans leading to main menu
                        if (Main_menu_instance.Click_area_exit.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y)) { this.NextStep("Main_Menu"); }
                    }

                    else if (this.Main_Menu == true) //If in main menu, determine next gamestate
                    {
                        if (Main_menu_instance.Click_area_exit.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y)) { Program.Game.Exit(); }
                        if (Main_menu_instance.Click_area_Start_map.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y)) { this.NextStep("Main_Game"); }
                        if (Main_menu_instance.Click_area_start_graph.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y)) { this.NextStep("Windows_Form"); }


                    }

                }
            }

            else if (this.oldMouse.LeftButton == ButtonState.Pressed) { }

            // Update saved state.
            this.oldState = newState;
            this.oldMouse = newMouse;

        }
    }
}
