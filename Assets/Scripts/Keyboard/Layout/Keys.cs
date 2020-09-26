namespace DefaultNamespace
{
    /// <summary>
    /// A list of constant and static Keys.
    /// </summary>
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

        public static readonly UppercaseToggle Uppercase = new UppercaseToggle("Uppercase", "arrow-up-empty", "arrow-up", "arrow-up-line", WiderButtonsWidth);
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
        public static readonly SpaceBarButton SpaceBar = new SpaceBarButton("space", SmallerKeyFontSize, SpaceBarWidth);
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
}