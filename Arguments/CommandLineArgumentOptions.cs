using EssIL;

enum CommandLineArgumentOptions
{
    Default = 0,
    MixCStyleEscape = 1,
    MixCStyleEscapeOnlyQuoted = 2,
    MixCStyleEscapeOnlyFullyQuoted = 3,

    EnableEcmaScriptStyle = 4,
    MixEcmaScriptStyleEscape = MixCStyleEscape | EnableEcmaScriptStyle,
    MixEcmaScriptStyleEscapeOnlyQuoted = MixCStyleEscapeOnlyQuoted | EnableEcmaScriptStyle,
    MixEcmaScriptStyleEscapeOnlyFullyQuoted = MixCStyleEscapeOnlyFullyQuoted | EnableEcmaScriptStyle,
}

static class CommandLineArgumentOptionsEx
{
    public static bool IsValid(this CommandLineArgumentOptions value)
        => CommandLineArgumentOptions.MixEcmaScriptStyleEscapeOnlyFullyQuoted.Has(value);
}