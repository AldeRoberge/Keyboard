using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public enum Layout
    {
        Normal,
        Symbols
    }

    public class Keys
    {
        // Size constants
        public const int KeyWidth = 20;
        public const int KeyHeight = 24;

        public const int WiderButtonsWidth = 25;
        public const int SpaceBarWidth = 100;

        public const float KeyFontSize = 10;
        public const float SmallerKeyFontSize = 8;

        // Keys (Declaration follows a top to bottom, normal to symbols order)
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

        public static readonly UppercaseToggle Uppercase = new UppercaseToggle("Uppercase", "arrow-up", "arrow-up", WiderButtonsWidth);
        public static readonly Key Z = new Key("z");
        public static readonly Key X = new Key("x");
        public static readonly Key C = new Key("c");
        public static readonly Key V = new Key("v");
        public static readonly Key B = new Key("b");
        public static readonly Key N = new Key("n");
        public static readonly Key M = new Key("m");
        public static readonly BackspaceButton Backspace = new BackspaceButton("Backspace", "backspace", WiderButtonsWidth);

        public static readonly SymbolsToggle Symbols = new SymbolsToggle("?123", "ABC", SmallerKeyFontSize, WiderButtonsWidth);
        public static readonly Key At = new Key("@");
        public static readonly SpaceBarButton Space = new SpaceBarButton("space", SmallerKeyFontSize, SpaceBarWidth);
        public static readonly Key Dot = new Key(".");
        public static readonly TextButton Go = new TextButton("Go", SmallerKeyFontSize, 34);

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

        public static readonly ToggleableTextButton MoreSymbols = new ToggleableTextButton("=\\<", "?123", SmallerKeyFontSize, WiderButtonsWidth);
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
        private static KeyboardLayout normalLayout;
        private static KeyboardLayout symbolsLayout;

        static KeyboardLayoutHandler()
        {
            Spacer thirdRowSpacer = new Spacer(2.5f);

            // Normal layout
            KeyboardRow normalRowOne = new KeyboardRow(0, 0, Keys.Q, Keys.W, Keys.E, Keys.R, Keys.T, Keys.Y, Keys.U, Keys.I, Keys.O, Keys.P);
            KeyboardRow normalRowTwo = new KeyboardRow(1, -18.5f, Keys.A, Keys.S, Keys.D, Keys.F, Keys.G, Keys.H, Keys.J, Keys.K, Keys.L);
            KeyboardRow normalRowThree = new KeyboardRow(2, -0.85f, Keys.Uppercase, thirdRowSpacer, Keys.Z, Keys.X, Keys.C, Keys.V, Keys.B, Keys.N, Keys.M, thirdRowSpacer, Keys.Backspace);
            KeyboardRow normalRowFour = new KeyboardRow(3, -0.85f, Keys.Symbols, Keys.At, Keys.Space, Keys.Dot, Keys.Go);

            normalLayout = new KeyboardLayout(
                normalRowOne, normalRowTwo, normalRowThree, normalRowFour);

            // Symbols layout
            KeyboardRow symbolsRowOne = new KeyboardRow(0, 0, Keys.One, Keys.Two, Keys.Three, Keys.Four, Keys.Five, Keys.Six, Keys.Seven, Keys.Eight, Keys.Nine, Keys.Zero);
            KeyboardRow symbolsRowTwo = new KeyboardRow(1, 0, Keys.At, Keys.NumberSign, Keys.DollarSign, Keys.UnderScore, Keys.AndSymbol, Keys.Hyphen, Keys.PlusSign, Keys.OpeningParenthese, Keys.ClosingParenthese, Keys.ForwardSlash);
            KeyboardRow symbolsRowThree = new KeyboardRow(2, 0, new Spacer(Keys.WiderButtonsWidth), Keys.Asterisk, Keys.DoubleQuote, Keys.SingleQuote, Keys.Colon, Keys.SemiColon, Keys.ExclamationMark, Keys.QuestionMark, Keys.Backspace);
            KeyboardRow symbolsRowFour = new KeyboardRow(3, 0, Keys.Symbols, Keys.Comma, Keys.Space, Keys.Dot, Keys.Go);

            symbolsLayout = new KeyboardLayout(
                symbolsRowOne, symbolsRowTwo, symbolsRowThree, symbolsRowFour);
        }

        public static KeyboardLayout GetLayout(Layout layout)
        {
            switch (layout)
            {
                case Layout.Normal:
                    return normalLayout;
                case Layout.Symbols:
                    return symbolsLayout;
                default:
                    Debug.Log("Fatal : Could not find the KeyboardLayout for layout of type : '" + layout + "'.");
                    return null;
            }
        }

        public static KeyboardLayout GetSymbolsLayout()
        {
            if (symbolsLayout == null)
            {
            }

            return symbolsLayout;
        }
    }

    /// <summary>
    /// A List of KeyboardRows.
    /// </summary>
    public class KeyboardLayout
    {
        public readonly List<KeyboardRow> Rows = new List<KeyboardRow>();

        public KeyboardLayout(params KeyboardRow[] rows)
        {
            Rows = rows.ToList();
        }
    }
    
    /// <summary>
    /// A Row of KeyBoardObjects.
    /// </summary>
    public class KeyboardRow
    {
        public float Spacing;
        public int RowIndex;
        public readonly List<KeyboardObject> Keys;

        public KeyboardRow(int rowIndex, float spacing, params KeyboardObject[] keys)
        {
            RowIndex = rowIndex;
            Spacing = spacing;
            Keys = keys.ToList();
        }
    }
    
    public class SpaceBarButton : Key
    {
        public SpaceBarButton(string name, float fontSize = Keys.KeyFontSize, float width = Keys.KeyWidth) : base(name, fontSize, width)
        {
        }
    }
    
    public class SymbolsToggle : ToggleableTextButton
    {
        public SymbolsToggle(string name, string displayTextToggledOn, float fontSize, float width) : base(name, displayTextToggledOn, fontSize, width)
        {
        }
    }

    public class BackspaceButton : ImageObjectButton
    {
        public BackspaceButton(string name, string imageResourcePath, float width) : base(name, imageResourcePath, width)
        {
        }
    }

    public class UppercaseToggle : ToggleableImageObjectButton
    {
        public UppercaseToggle(string name, string imageResourcePath, string imageToggledOn, float width) : base(name, imageResourcePath, imageToggledOn, width)
        {
        }
    }

    /// <summary>
    /// Like a TextButton but holds an additional string to display once the button is toggled on.
    /// </summary>
    public class ToggleableTextButton : TextButton
    {
        public string DisplayTextToggledOn;

        public ToggleableTextButton(string name, string displayTextToggledOn, float fontSize, float width) : base(name, fontSize, width)
        {
            DisplayTextToggledOn = displayTextToggledOn;
        }
    }

    /// <summary>
    /// A Key that is used to populate a field once pressed.
    /// </summary>
    public class Key : TextButton
    {
        public Key(string name, float fontSize = Keys.KeyFontSize, float width = Keys.KeyWidth) : base(name, fontSize, width)
        {
        }
    }

    /// <summary>
    /// A button that does an action instead of sending a keystroke.
    /// </summary>
    public class TextButton : KeyboardObject
    {
        public readonly float FontSize;

        public TextButton(string name, float fontSize, float width) : base(name, width)
        {
            FontSize = fontSize;
        }
    }

    /// <summary>
    /// Holds a reference to an additional image used when the button is toggled on.
    /// </summary>
    public class ToggleableImageObjectButton : ImageObjectButton
    {
        public string ImageToggledOnResourcePath;

        public ToggleableImageObjectButton(string name, string imageResourcePath, string imageToggledOn, float width) : base(name, imageResourcePath, width)
        {
            ImageToggledOnResourcePath = imageToggledOn;
        }
    }

    /// <summary>
    /// A button that has an image instead of text like the Uppercase and Backspace buttons.
    /// </summary>
    public class ImageObjectButton : KeyboardObject
    {
        public string ImageResourcePath;

        public ImageObjectButton(string name, string imageResourcePath, float width) : base(name, width)
        {
            ImageResourcePath = imageResourcePath;
        }
    }

    /// <summary>
    /// An invisible object used to create empty space.
    /// </summary>
    public class Spacer : KeyboardObject
    {
        public Spacer(float width) : base("Spacer", width)
        {
        }
    }

    /// <summary>
    /// Anything that is placed on the keyboard.
    /// It can be a key, i.e. : Q, W, E, R, T or a button like Backspace.
    /// </summary>
    public class KeyboardObject
    {
        public string Name;

        public float Height { get; }
        public float Width { get; }

        public KeyboardObject(string name, float width = Keys.KeyWidth, float height = Keys.KeyHeight)
        {
            Name = name;
            Width = width;
            Height = height;
        }
    }
}