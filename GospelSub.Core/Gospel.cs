using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Input;

namespace GospelSub.Core
{
#pragma warning disable CS0660 
#pragma warning disable CS0661 
    public class Gospel : Notifier
#pragma warning restore CS0661
#pragma warning restore CS0660
    {
        public string this[int index]
        {
            get
            {
                if (index > Lyrics.Count) throw new IndexOutOfRangeException("Over");
                else if (index < 0) throw new IndexOutOfRangeException("Below");
                else if (index == 0) return Name;
                else return Lyrics[index - 1];
            }

            set => Lyrics[index - 1] = value;
        }

        public int Count => Lyrics.Count + 1;

        public string Name { get; }

        public List<string> Lyrics { get; }

        public bool Chosen { get; set; } = false;

        public Dictionary<Key, int> Tags { get; } = new Dictionary<Key, int>();
        public bool Tagged => Tags.Count > 0;
        public bool Taggable { get; private set; } = true;

        public void ExtractTags()
        {
            if (Tagged) return;
            var tags = Lyrics.Select(s => IsTag(s));
            if (tags.All(i => i == 0)) { Taggable = false; return; }
            for (int i = 0; i < tags.Count(); i++)
            {
                switch (Lyrics[i].IsTag())
                {
                    case 1: Tags[Lyrics[i][1].ToKey()] = i + 1; break;
                    case 2: Tags[Lyrics[i][0].ToKey()] = i + 1; break;
                    default: break;
                }
            }
        }

        public Gospel(string[] raw)
        {
            (Name, Lyrics) = (raw[0], new List<string>(raw));
            Lyrics.RemoveAt(0);
        }

        public static Gospel Load(StreamReader reader)
        {
            Gospel g;
            var raw = reader.ReadToEnd();
            var lyrics = raw.Split(new string[1] { @"

" }, StringSplitOptions.RemoveEmptyEntries);
            g = new Gospel(lyrics);
            reader.Close();
            return g;
        }

        public static int IsTag(string s)
        {
            if (s[0] == '[' && s[2] == ']' && char.IsLetterOrDigit(s[1])) return 1;
            if (s[1] == '.' && char.IsDigit(s[0])) return 2;
            return 0;
        }

        public static Key ToKey(char c) => (Key)(int.TryParse(c.ToString(), out int a) ? 34 + a : c - 53);
        
        public static bool operator==(Gospel o, Gospel o2)
        {
            if (o.Chosen != o2.Chosen) return false;
            else if (o.Name != o2.Name) return false;
            else if (o.Lyrics != o2.Lyrics) return false;
            else if (o.Tags != o2.Tags) return false;
            else return true;
        }

        public static bool operator !=(Gospel o, Gospel o2) => !( o == o2);
    }
}
