using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace GospelSub.Core
{
    public class Setting : Notifier
    {
        public FontFamily Font { get; set; } = new FontFamily();
        public bool Black { get => (Color, Background) == (Colors.White, Brushes.Black); set { if (value) (Color, Background) = (Colors.White, Brushes.Black); } }
        public bool White { get => (Color, Background) == (Colors.Black, Brushes.White); set { if (value) (Color, Background) = (Colors.Black, Brushes.White); } }
        public Color Color { get; set; } = Colors.Black;
        public List<Gospel> Sequence { get; set; } = new List<Gospel>();
        public List<Gospel> Gospels { get; set; } = new List<Gospel>();
        public Dictionary<Key, string> KeyMaps { get; set; } = new Dictionary<Key, string>();
        public Brush Background { get; set; } = Brushes.White;

        public static Setting Current { get; } = new Setting();
    }
}
