using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace EersteVersieProject3
{
    public class Textures    //Places all the texture in one class instances as different attributes, so the textures are easily accessable for other game1 methods
    {
        public Texture2D day_time_background, Stadswapen, Monumentlogo, tekstvak, Main_menu_background, Word_Art;
        public SpriteFont Arial_12;
      

        public Textures(Texture2D day_time_background, Texture2D Stadswapen, Texture2D Monumentlogo, Texture2D tekstvak, SpriteFont Arial_12, Texture2D Main_menu_background, Texture2D Word_Art)
        {
            this.day_time_background = day_time_background;
            this.Stadswapen = Stadswapen;
            this.Monumentlogo = Monumentlogo;
            this.tekstvak = tekstvak;
            this.Arial_12 = Arial_12;
            this.Main_menu_background = Main_menu_background;
            this.Word_Art = Word_Art;

        }




    }

}