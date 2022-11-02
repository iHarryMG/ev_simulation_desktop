using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ElectricVehicle
{
    class ImageFile
    { 
        private string ImageName;

        public ImageFile(string imageName)
        {
            ImageName = imageName;
        }

        public Image GetImage()
        {
            return Image.FromFile("C:/Users/BMG/Documents/4학년/1학기/종합설계/EV/Images/" + ImageName);
        }
    }
}
