using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace EersteVersieProject3
{
    public class Monument : IPinOnMap
    {
        public string ID;
        public string Monument_naam;
        public string Straatnaam;
        public string Oorspronkelijk_gebouw;
        public DateTime Registratie_dag;
        public string Bouwjaar;
        public string Architect;
        public string Bouwstijl;
        public bool Pin_Un_Folded;
        public Vector2 Pin_Coordinates;
        public Texture2D Pin_Logo;
        public Texture2D tekstvak_zonder_tekst;
        public Rectangle Click_area;
     

        public Monument(string ID, string Monument_naam, string Straatnaam, string Oorspronkelijk_gebouw, string Bouwjaar, string Architect, string Bouwstijl, double Wereld_hoogte_graad, double Wereld_breedte_graad, Texture2D Pin_Logo, Texture2D Tekstvak)
        {
            this.ID = ID;
            this.Monument_naam = Monument_naam;
            this.Straatnaam = Straatnaam;
            this.Oorspronkelijk_gebouw = Oorspronkelijk_gebouw;
            this.Bouwjaar = Bouwjaar;
            this.Architect = Architect;
            this.Bouwstijl = Bouwstijl;

            this.Pin_Un_Folded = false;
            this.Pin_Logo = Pin_Logo;
            this.Pin_Coordinates = Create_pin_coordinates(Wereld_breedte_graad, Wereld_hoogte_graad); // see create pin coordinates
            this.tekstvak_zonder_tekst = Tekstvak;
            this.Click_area = this.Create_Click_Area();
        }

        // Notes for DevTeam 1
        /*                  y          x
        Links boven is: 51.925911, 4.462833 
        Rechts boven is: 51.925840, 4.492417 
        Links onder is: 51.915021, 4.462778 
        Rechts onder is: 51.914382, 4.492156

        gemiddelde boven y = 51.9258755
        gemiddelde onder y = 51.9147015
        verschil y = 0.011174 wordt verdeelt over 600pixels
        0.000018623333333333333333333333 wereld_y per pixel

        gemiddelde linker x = 4.4628055
        gemiddelde rechter x = 4.4922865
        verschil x = 0.029481 wordt verdeelt over 800pixels
        0.00003685125 wereld_x per pixel

        LET OP: y assen lopen inverted van elkaar
        */

        private Vector2 Create_pin_coordinates(double Wereld_breedte_graad, double Wereld_hoogte_graad) //translates world coordinates into our map coordinates
        {
            double berekening_pixel_breedte = Wereld_breedte_graad - 4.4628055;
            berekening_pixel_breedte = berekening_pixel_breedte / 0.00003685125;

            double berekening_pixel_hoogte = Wereld_hoogte_graad - 51.9147015;
            berekening_pixel_hoogte = berekening_pixel_hoogte / 0.00001862333333;

            float pixel_breedte = (float)berekening_pixel_breedte;
            float pixel_hoogte = 600 - (float)berekening_pixel_hoogte;

            return new Vector2(pixel_breedte, pixel_hoogte);
        }


        public Vector2 PinCoordinates
        {
            get{ return this.Pin_Coordinates; }

            set{ this.Pin_Coordinates = value; }
        }
        public Texture2D PinLogo
        {
            get{ return this.Pin_Logo; }

            set{ this.Pin_Logo = value; }
        }
        public bool PinUnfolded
        {
            get { return this.Pin_Un_Folded; }

            set { this.Pin_Un_Folded = value; }
        }

        public void ToggleFoldPin() //Self explanatory
        {
            if (this.Pin_Un_Folded == true) {this.Pin_Un_Folded = false;}

            else if (this.Pin_Un_Folded == false) {this.Pin_Un_Folded = true;}

        }

        public static void DrawAllMonumenten(SpriteBatch spriteBatch, SpriteFont Arial_12, List<Monument> Monumentenlijst)
        {

            foreach (Monument monumentje in Monumentenlijst) //Only draw the pin logo if pin is folded
            {
                spriteBatch.Draw(monumentje.Pin_Logo, monumentje.Pin_Coordinates, Color.White);

            }

            foreach (Monument monumentje in Monumentenlijst) //Also draws the textboxwith information if pin is unfolded
            {
                if (monumentje.Pin_Un_Folded == true)
                {
                    spriteBatch.Draw(monumentje.tekstvak_zonder_tekst, new Vector2(monumentje.Pin_Coordinates.X - monumentje.tekstvak_zonder_tekst.Width/100*34, monumentje.Pin_Coordinates.Y - monumentje.Pin_Logo.Height - monumentje.tekstvak_zonder_tekst.Height/100*90), Color.White);
                    spriteBatch.DrawString(Arial_12, "Monument: " + monumentje.Monument_naam, new Vector2(monumentje.Pin_Coordinates.X - 45, monumentje.Pin_Coordinates.Y - monumentje.tekstvak_zonder_tekst.Height + 15), Color.Black);
                    spriteBatch.DrawString(Arial_12, "Straatnaam: " + monumentje.Straatnaam, new Vector2(monumentje.Pin_Coordinates.X - 45, monumentje.Pin_Coordinates.Y - monumentje.tekstvak_zonder_tekst.Height + 31), Color.Black);
                    spriteBatch.DrawString(Arial_12, "Oorspronkelijk: " + monumentje.Oorspronkelijk_gebouw, new Vector2(monumentje.Pin_Coordinates.X - 45, monumentje.Pin_Coordinates.Y - monumentje.tekstvak_zonder_tekst.Height + 47), Color.Black);
                    spriteBatch.DrawString(Arial_12, "Bouwjaar: " + monumentje.Bouwjaar, new Vector2(monumentje.Pin_Coordinates.X - 45, monumentje.Pin_Coordinates.Y - monumentje.tekstvak_zonder_tekst.Height + 63), Color.Black);
                }
            }


        }


        private Rectangle Create_Click_Area() //Creates click areas, so update with input can check (with the new attribute) if the mouse clicked inside the area
        {
            int X_Coordinate = (int)Math.Round(this.Pin_Coordinates.X);
            int Y_Coordinate = (int)Math.Round(this.Pin_Coordinates.Y + PinCoordinates.Y/100*25);


            Rectangle The_Area = new Rectangle(X_Coordinate, Y_Coordinate, this.Pin_Logo.Width, this.Pin_Logo.Height+5);

            
            return The_Area;
        }


    }
}
