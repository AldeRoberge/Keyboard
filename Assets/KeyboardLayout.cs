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
        public static readonly Key G = new Key("g");
        public static readonly Key H = new Key("h");
        public static readonly Key J = new Key("j");
        public static readonly Key K = new Key("k");
        public static readonly Key L = new Key("l");

        public static readonly ImageButton Uppercase = new ImageButton("arrow-up", WiderButtons);
        public static readonly Key Z = new Key("z");
        public static readonly Key X = new Key("x");
        public static readonly Key C = new Key("c");
        public static readonly Key V = new Key("v");
        public static readonly Key B = new Key("b");
        public static readonly Key N = new Key("n");
        public static readonly Key M = new Key("m");
        public static readonly ImageButton Backspace = new ImageButton("backspace", WiderButtons);

        public static readonly ToggleableTextButton Symbols = new ToggleableTextButton("?123", "ABC", WiderButtons);
        public static readonly Key At = new Key("@");
        public static readonly TextButton Space = new TextButton("space", SpaceBarWidth);
        public static readonly Key Dot = new Key(".");
        public static readonly TextButton Go = new TextButton("Go", 34);


        // Numbers
        public static readonly Key One = new Key("1");
        public static readonly Key Two = new Key("2");
        public static readonly Key Three = new Key("3");
        public static readonly Key Four = new Key("4");
        public static readonly Key Five = new Key("5");
        public static readonly Key Six = new Key("6");
        public static readonly Key Seven = new Key("7");
        public static readonly Key Eight = new Key("8");
        public static readonly Key Nine = new Key("9");
        public static readonly Key Zero = new Key("0");

        public static readonly Key NumberSign = new Key("#");
        public static readonly Key DollarSign = new Key("$");
        public static readonly Key UnderScore = new Key("_");
        public static readonly Key AndSymbol = new Key("&");
        public static readonly Key Hyphen = new Key("-");
        public static readonly Key PlusSign = new Key("+");
        public static readonly Key OpeningParenthese = new Key("(");
        public static readonly Key ClosingParenthese = new Key(")");
        public static readonly Key ForwardSlash = new Key("/");

        public static readonly ToggleableTextButton MoreSymbols = new ToggleableTextButton("=\\<", "?123", WiderButtons);
        public static readonly Key Asterisk = new Key("*");
        public static readonly Key DoubleQuote = new Key("\"");
        public static readonly Key SingleQuote = new Key("'");
        public static readonly Key Colon = new Key(":");
        public static readonly Key SemiColon = new Key(";");
        public static readonly Key ExclamationMark = new Key("!");
        public static readonly Key QuestionMark = new Key("?");

        public static readonly Key Comma = new Key(",");
    }

    public class KeyboardLayoutHandler
    {
        public KeyboardLayouts KeyboardLayouts;

        public KeyboardLayoutHandler()
        {
            
            // Normal layout
            KeyboardRow normalRowFirst = new KeyboardRow(Keys.Q, Keys.W, Keys.E, Keys.R, Keys.T, Keys.Y, Keys.U, Keys.I, Keys.O, Keys.P);
            KeyboardRow normalRowSecond = new KeyboardRow(Keys.A, Keys.S, Keys.D, Keys.F, Keys.G, Keys.H, Keys.J, Keys.K, Keys.L);
            KeyboardRow normalRowThird = new KeyboardRow(Keys.Uppercase, Keys.Z, Keys.X, Keys.C, Keys.V, Keys.B, Keys.N, Keys.M, Keys.Backspace);
            KeyboardRow normalRowFourth = new KeyboardRow(Keys.Symbols, Keys.At, Keys.Space, Keys.Dot, Keys.Go);

            KeyboardLayout normalLayout = new KeyboardLayout(
                normalRowFirst, normalRowSecond, normalRowThird, normalRowFourth);

            // Symbols layout
            KeyboardRow symbolsRowFirst = new KeyboardRow(Keys.One, Keys.Two, Keys.Three, Keys.Four, Keys.Five, Keys.Six, Keys.Seven, Keys.Eight, Keys.Nine, Keys.Zero);
            KeyboardRow symbolsRowSecond = new KeyboardRow(Keys.At, Keys.NumberSign, Keys.DollarSign, Keys.UnderScore, Keys.AndSymbol, Keys.Hyphen, Keys.PlusSign, Keys.OpeningParenthese, Keys.ClosingParenthese, Keys.ForwardSlash);
            KeyboardRow symbolsRowThird = new KeyboardRow(new Spacer(Keys.WiderButtons), Keys.Asterisk, Keys.DoubleQuote, Keys.SingleQuote, Keys.Colon, Keys.SemiColon, Keys.ExclamationMark, Keys.QuestionMark, Keys.Backspace);
            KeyboardRow symbolsRowFourth = new KeyboardRow(Keys.Symbols, Keys.Comma, Keys.Space, Keys.Dot, Keys.Go);

            KeyboardLayout symbolsLayout = new KeyboardLayout(
                symbolsRowFirst, symbolsRowSecond, symbolsRowThird, symbolsRowFourth);
            
            KeyboardLayouts = new KeyboardLayouts(normalLayout, symbolsLayout);
        }
    }


    public class KeyboardLayouts
    {
        public List<KeyboardLayout> Layouts = new List<KeyboardLayout>();

        public KeyboardLayouts(params KeyboardLayout[] layouts)
        {
            this.Layouts = layouts.ToList();
        }
    }

    public class KeyboardLayout
    {
        public List<KeyboardRow> rows = new List<KeyboardRow>();

        public KeyboardLayout(params KeyboardRow[] rows)
        {
            this.rows = this.rows.ToList();
        }
    }

    public class KeyboardRow
    {
        private readonly List<KeyboardButton> keys = new List<KeyboardButton>();

        public KeyboardRow(params KeyboardButton[] keys)
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