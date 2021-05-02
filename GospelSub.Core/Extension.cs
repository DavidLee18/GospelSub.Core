using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace GospelSub.Core
{
    public static class Extension
    {
        public static Key ToKey(this char c) => Gospel.ToKey(c);
        public static int IsTag(this string s) => Gospel.IsTag(s);
        public static Color ToWindowsColor(this System.Drawing.Color color) => Color.FromArgb(color.A, color.R, color.G, color.B);
    }
}
