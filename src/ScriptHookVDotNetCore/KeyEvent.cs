namespace GTA;

public struct KeyEventArgs
{
    /// <summary>
    ///  Initializes a new instance of the <see cref="KeyEventArgs"/> class.
    /// </summary>
    public KeyEventArgs(Keys keyData)
    {
        KeyData = keyData;
    }

    /// <summary>
    ///  Gets a value indicating whether the ALT key was pressed.
    /// </summary>
    public bool Alt => (KeyData & Keys.Alt) == Keys.Alt;

    /// <summary>
    ///  Gets a value indicating whether the CTRL key was pressed.
    /// </summary>
    public bool Control => (KeyData & Keys.Control) == Keys.Control;

    /// <summary>
    ///  Gets or sets a value indicating whether the event was handled.
    /// </summary>
    public bool Handled { get; set; }

    /// <summary>
    ///  Gets the keyboard code for a <see cref="GTA.Script.KeyDown"/> or
    /// <see cref="GTA.Script.KeyUp"/> event.
    /// </summary>
    public Keys KeyCode
    {
        get
        {
            Keys keyGenerated = KeyData & Keys.KeyCode;

            // since Keys can be discontiguous, keeping Enum.IsDefined.
            if (!Enum.IsDefined(typeof(Keys), (int)keyGenerated))
            {
                return Keys.None;
            }

            return keyGenerated;
        }
    }

    /// <summary>
    ///  Gets the keyboard value for a <see cref="GTA.Script.KeyDown"/> or
    /// <see cref="GTA.Script.KeyUp"/> event.
    /// </summary>
    public int KeyValue => (int)(KeyData & Keys.KeyCode);

    /// <summary>
    ///  Gets the key data for a <see cref="Script.KeyDown"/> or
    /// <see cref="Script.KeyUp"/> event.
    /// </summary>
    public Keys KeyData { get; }

    /// <summary>
    ///  Gets the modifier flags for a <see cref="Script.KeyDown"/> or
    /// <see cref="GTA.Script.KeyUp"/> event.
    ///  This indicates which modifier keys (CTRL, SHIFT, and/or ALT) were pressed.
    /// </summary>
    public Keys Modifiers => KeyData & Keys.Modifiers;

    /// <summary>
    ///  Gets a value indicating whether the SHIFT key was pressed.
    /// </summary>
    public bool Shift => (KeyData & Keys.Shift) == Keys.Shift;
}