using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;



namespace EersteVersieProject3
{
    public interface IPinOnMap //This interface was made for when there were multiple kinds of pins, in the end we changed it to only monuments
    {
        Vector2 PinCoordinates { get; set; }
        Texture2D PinLogo { get; set; }
        bool PinUnfolded { get; set; }

    }
}
