using EssIL;

enum TextualArgumentOptions
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

static class TextualArgumentOptionsEx
{
    public static bool IsValid(this TextualArgumentOptions value)
        => TextualArgumentOptions.MixEcmaScriptStyleEscapeOnlyFullyQuoted.Has(value);
}