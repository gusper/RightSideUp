using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace RightSideUp
{
    enum Orientation  
    {
        Straight = 1,
        Left = 6,
        Right = 8
    }
    
    class ExifTags
    {
        internal const int Orientation = 0x112;
    }

    class ExifImageInfo 
    {
        internal static Orientation GetOrientation(string filename) 
        {
            using (Image i = Image.FromFile(filename)) 
            {
                foreach (PropertyItem pi in i.PropertyItems) 
                {
                    if (pi.Id == ExifTags.Orientation) 
                    {
                        return (Orientation)pi.Value[0];
                    }
                }
            }

            return Orientation.Straight;
        }
    }
}
