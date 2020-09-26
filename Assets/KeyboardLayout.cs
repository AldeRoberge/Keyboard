using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class Keys
    {


        public const int WiderButtons = 25;
        public const int SpaceBarWidth = 100;
        
        public static readonly Key Q = new Key("q");
        public static readonly Key W = new Key("w");
        public static readonly Key E = new Key("e");
        public static readonly Key R = new Key("r");
        public static readonly Key T = new Key("t");
        public static readonly Key Y = new Key("y");
        public static readonly Key U = new Key("u");
        public static readonly Key I = new Key("i");
        public static readonly Key O = new Key("o");
        public static readonly Key P = new Key("p");
        
        public static readonly Key A = new Key("a");
        public static readonly Key S = new Key("s");
        public static readonly Key D = new Key("d");
        public static readonly Key F = new Key("f");
        public static readonly Key g = new Key("g");
        public static readonly Key h = new Key("h");
        public static readonly Key j = new Key("j");
        public static readonly Key k = new Key("k");
        public static readonly Key l = new Key("l");

        public static readonly ImageButton Uppercase = new ImageButton( "arrow-up", WiderButtons);
        public static readonly Key z = new Key("z");
        public static readonly Key x = new Key("x");
        public static readonly Key c = new Key("c");
        public static readonly Key v = new Key("v");
        public static readonly Key b = new Key("b");
        public static readonly Key n = new Key("n");
        public static readonly Key m = new Key("m");
        public static readonly ImageButton Backspace = new ImageButton( "backspace", WiderButtons);
        
        public static readonly ToggleableTextButton Symbols = new ToggleableTextButton("?123", "ABC", WiderButtons);
        public static readonly Key at = new Key("@");
        public static readonly TextButton Space = new TextButton("space", SpaceBarWidth);
        public static readonly Key point = new Key(".");
        public static readonly TextButton Go = new TextButton("Go", 34);

    }

    public class KeyboardLayoutHandler
    {
        public KeyboardLayouts KeyboardLayouts;

        public KeyboardLayoutHandler()
        {
            KeyboardRow firstRow = new KeyboardRow(Keys.Q, Keys.W, Keys.E, Keys.R, Keys.T, Keys.Y, Keys.U, Keys.I, Keys.O, Keys.P);
            KeyboardRow secondRow = new KeyboardRow(Keys.A, Keys.S, Keys.D, Keys.F, Keys.g, Keys.h, Keys.j, Keys.k, Keys.l);
            KeyboardRow thirdRow = new KeyboardRow(Keys.A, Keys.S, Keys.D, Keys.F, Keys.g, Keys.h, Keys.j, Keys.k, Keys.l);
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
    
    public class ToggleableTextButton : TextButton
    {
        public string DisplayTextToggledOn;
        
        public ToggleableTextButton(string displayText, string displayTextToggledOn, float width) : base(displayText, width)
        {
            this.DisplayTextToggledOn = displayTextToggledOn;
        }
    }

    public class TextButton : KeyboardButton
    {
        public string DisplayText;

        public TextButton(string displayText, float width) : base(width)
        {
            this.DisplayText = displayText;
        }
    }

    public class ToggleableImageButton : ImageButton
    {
        public string ImageToggledOnResourcePath;

        public ToggleableImageButton(string imageResourcePath, string imageToggledOn, float width) : base(imageResourcePath, width)
        {
            ImageToggledOnResourcePath = imageToggledOn;
        }
    }

    public class ImageButton : KeyboardButton
    {
        public string ImageResourcePath;

        public ImageButton(string imageResourcePath, float width) : base(width)
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