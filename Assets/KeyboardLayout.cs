using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class Keys
    {
        public static readonly Key q = new Key("q");
        public static readonly Key w = new Key("w");
        public static readonly Key e = new Key("e");
        public static readonly Key r = new Key("r");
        public static readonly Key t = new Key("t");
        public static readonly Key y = new Key("y");
        public static readonly Key u = new Key("u");
        public static readonly Key i = new Key("i");
        public static readonly Key o = new Key("o");
        public static readonly Key p = new Key("p");

        public static readonly Key a = new Key("a");
        public static readonly Key s = new Key("s");
        public static readonly Key d = new Key("d");
        public static readonly Key f = new Key("f");
        public static readonly Key g = new Key("g");
        public static readonly Key h = new Key("h");
        public static readonly Key j = new Key("j");
        public static readonly Key k = new Key("k");
        public static readonly Key l = new Key("l");

        public static readonly Key z = new Key("z");
        public static readonly Key x = new Key("x");
        public static readonly Key c = new Key("c");
        public static readonly Key v = new Key("v");
        public static readonly Key b = new Key("b");
        public static readonly Key n = new Key("n");
        public static readonly Key m = new Key("m");
    }


    public class KeyboardLayoutHandler
    {
        public KeyboardLayouts KeyboardLayouts;

        public KeyboardLayoutHandler()
        {
            KeyboardRow firstRow = new KeyboardRow(Keys.q, Keys.w, Keys.e, Keys.r, Keys.t, Keys.y, Keys.u, Keys.i, Keys.o, Keys.p);
            KeyboardRow secondRow = new KeyboardRow(Keys.a, Keys.s, Keys.d, Keys.f, Keys.g, Keys.h, Keys.j, Keys.k, Keys.l);
            KeyboardRow thirdRow = new KeyboardRow(Keys.a, Keys.s, Keys.d, Keys.f, Keys.g, Keys.h, Keys.j, Keys.k, Keys.l);
        }
    }


    public class KeyboardLayouts
    {
        public List<KeyboardLayout> Layouts = new List<KeyboardLayout>();
    }

    public class KeyboardLayout
    {
        public List<KeyboardRow> rows = new List<KeyboardRow>();
    }

    public class KeyboardRow
    {
        private readonly List<Key> keys = new List<Key>();

        public KeyboardRow(params Key[] keys)
        {
            this.keys = this.keys.ToList();
        }
    }

    public class Key : KeyboardButton
    {
        private string name;

        public Key(string name)
        {
            this.name = name;
        }
    }


    public class TextButton : KeyboardButton
    {
        public TextButton(float width) : base(width)
        {
            
        }
    }
    
    public class ImageButton : KeyboardButton
    {
        public string ImageResourcePath;
        
        public ImageButton(float width, string imageResourcePath) : base(width)
        {
            this.ImageResourcePath = imageResourcePath;
        }
    }
    

    public class Spacer : KeyboardButton
    {
        public Spacer(float width) : base(width)
        {
            
        }
    }


    public class KeyboardButton
    {
        public float Height { get; }
        public float Width { get; }

        public KeyboardButton(float width = 20, float height = 24)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}