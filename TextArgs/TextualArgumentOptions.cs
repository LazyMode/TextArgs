using EssIL;

#if PUBLIC
public
#endif
enum TextualArgumentOptions
{
    Default = 0,
    UseCLikeEscape = 1,
    UseCLikeEscapeQuote = 2,
    UseCLikeEscapeStrict = 3,

    EnableEcmaScriptLike = 4,
    UseEcmaScriptLikeEscape = UseCLikeEscape | EnableEcmaScriptLike,
    UseEcmaScriptLikeEscapeQuote = UseCLikeEscapeQuote | EnableEcmaScriptLike,
    UseEcmaScriptLikeEscapeStrict = UseCLikeEscapeStrict | EnableEcmaScriptLike,
}

#if PUBLIC
public
#endif
static class TextualArgumentOptionsEx
{
    public static bool IsValid(this TextualArgumentOptions value)
        => TextualArgumentOptions.UseEcmaScriptLikeEscapeStrict.Has(value);
}