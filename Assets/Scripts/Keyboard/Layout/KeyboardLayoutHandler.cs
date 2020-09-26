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

    /// <summary>
    /// Holds a reference to the different types of layout.
    /// </summary>
    public static class KeyboardLayoutHandler
    {
        private static readonly KeyboardLayout normalLayout;
        private static readonly KeyboardLayout symbolsLayout;

        static KeyboardLayoutHandler()
        {
            Spacer thirdRowSpacer = new Spacer(2.5f);

            // Normal layout
            KeyboardRow normalRowOne = new KeyboardRow(0, 0, Keys.Q, Keys.W, Keys.E, Keys.R, Keys.T, Keys.Y, Keys.U, Keys.I, Keys.O, Keys.P);
            KeyboardRow normalRowTwo = new KeyboardRow(1, -18.5f, Keys.A, Keys.S, Keys.D, Keys.F, Keys.G, Keys.H, Keys.J, Keys.K, Keys.L);
            KeyboardRow normalRowThree = new KeyboardRow(2, -0.85f, Keys.Uppercase, thirdRowSpacer, Keys.Z, Keys.X, Keys.C, Keys.V, Keys.B, Keys.N, Keys.M, thirdRowSpacer, Keys.Backspace);
            KeyboardRow normalRowFour = new KeyboardRow(3, -0.85f, Keys.Symbols, Keys.At, Keys.SpaceBar, Keys.Dot, Keys.Go);

            normalLayout = new KeyboardLayout(
                normalRowOne, normalRowTwo, normalRowThree, normalRowFour);

            // Symbols layout
            KeyboardRow symbolsRowOne = new KeyboardRow(0, 0, Keys.One, Keys.Two, Keys.Three, Keys.Four, Keys.Five, Keys.Six, Keys.Seven, Keys.Eight, Keys.Nine, Keys.Zero);
            KeyboardRow symbolsRowTwo = new KeyboardRow(1, 0, Keys.At, Keys.NumberSign, Keys.DollarSign, Keys.UnderScore, Keys.AndSymbol, Keys.Hyphen, Keys.PlusSign, Keys.OpeningParenthese, Keys.ClosingParenthese, Keys.ForwardSlash);
            KeyboardRow symbolsRowThree = new KeyboardRow(2, 0, new Spacer(Keys.WiderButtonsWidth), Keys.Asterisk, Keys.DoubleQuote, Keys.SingleQuote, Keys.Colon, Keys.SemiColon, Keys.ExclamationMark, Keys.QuestionMark, Keys.Backspace);
            KeyboardRow symbolsRowFour = new KeyboardRow(3, 0, Keys.Symbols, Keys.Comma, Keys.SpaceBar, Keys.Dot, Keys.Go);

            symbolsLayout = new KeyboardLayout(
                symbolsRowOne, symbolsRowTwo, symbolsRowThree, symbolsRowFour);
        }

        /// <summary>
        ///  Returns the given layout.
        /// </summary>
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
    }

    /// <summary>
    /// A List of KeyboardRows.
    /// </summary>
    public class KeyboardLayout
    {
        public readonly List<KeyboardRow> Rows;

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
        public readonly float Spacing;
        public readonly int RowIndex;
        public readonly List<KeyboardObject> Keys;

        public KeyboardRow(int rowIndex, float spacing, params KeyboardObject[] keys)
        {
            RowIndex = rowIndex;
            Spacing = spacing;
            Keys = keys.ToList();
        }
    }
}