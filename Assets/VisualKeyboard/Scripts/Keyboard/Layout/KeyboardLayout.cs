using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    
    
    public class SpaceBarButton : TextButton
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
        public BackspaceButton(string name, string imageKey, float width) : base(name, imageKey, width)
        {
        }
    }

    public class UppercaseToggle : ToggleableImageObjectButton
    {
        public string ImageCapsLockKey;

        public UppercaseToggle(string name, string imageKey, string imageToggledOn, string imageCapsLockKey, float width) : base(name, imageKey, imageToggledOn, width)
        {
            ImageCapsLockKey = imageCapsLockKey;
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
        public readonly string ImageToggledOnKey;

        public ToggleableImageObjectButton(string name, string imageKey, string imageToggledOn, float width) : base(name, imageKey, width)
        {
            ImageToggledOnKey = imageToggledOn;
        }
    }

    /// <summary>
    /// A button that has an image instead of text like the Uppercase and Backspace buttons.
    /// </summary>
    public class ImageObjectButton : KeyboardObject
    {
        public readonly string ImageKey;

        public ImageObjectButton(string name, string imageKey, float width) : base(name, width)
        {
            ImageKey = imageKey;
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
        public readonly string Name;

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