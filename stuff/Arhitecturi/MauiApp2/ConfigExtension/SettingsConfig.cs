namespace ConfigExtension;

public sealed class SettingsOptionsJson
{
    public int KeyOne { get; set; }
    public bool KeyTwo { get; set; }
    public NestedSettings KeyThree { get; set; } = null!;
}

public sealed class NestedSettings
{
    public string Message { get; set; } = null!;
}