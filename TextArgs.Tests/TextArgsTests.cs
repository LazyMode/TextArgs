using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

using static TextualArgumentOptions;

public class TextArgsTests
{
    [Theory]

    //[InlineData(Default, "foo bar", "foo bar")]

    #region Default
    [InlineData(Default, "quickbrownfoxjumpsoverthelazydog", @"quickbrownfoxjumpsoverthelazydog")]
    [InlineData(Default, "quickbrownfoxjumpsoverthelazydog", @"""quickbrownfoxjumpsoverthelazydog")]
    [InlineData(Default, "quickbrownfoxjumpsoverthelazydog", @"""quickbrownfoxjumpsoverthelazydog""")]
    [InlineData(Default, "quickbrownfoxjumpsoverthelazydog", @"quickbrownfoxjumpsoverthelazydog""")]

    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps""""overthelazydog")]
    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps""""overthelazydog")]
    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps""""overthelazydog""")]
    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps""""overthelazydog""")]

    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps""""overthelazydog")]
    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps""""overthelazydog")]
    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps""""overthelazydog""")]
    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps""""overthelazydog""")]

    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps""""overthelazydog")]
    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps""""overthelazydog")]
    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps""""overthelazydog""")]
    [InlineData(Default, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps""""overthelazydog""")]
    #endregion

    #region MixCLikeEscape
    [InlineData(MixCLikeEscape, "quickbrownfoxjumpsoverthelazydog", @"quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumpsoverthelazydog", @"""quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumpsoverthelazydog", @"""quickbrownfoxjumpsoverthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumpsoverthelazydog", @"quickbrownfoxjumpsoverthelazydog""")]

    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps""""overthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps""""overthelazydog""")]

    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps""""overthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps""""overthelazydog""")]

    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps""""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps""""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps""""overthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps""""overthelazydog""")]

    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps\""overthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps\""overthelazydog""")]

    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps\""overthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps\""overthelazydog""")]

    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps\""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps\""overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps\""overthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps\""overthelazydog""")]

    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"""quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"""quickbrownfoxjumps\\overthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog""")]

    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""foxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""foxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""foxjumps\\overthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""foxjumps\\overthelazydog""")]

    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""fox""jumps\\overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""fox""jumps\\overthelazydog")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""fox""jumps\\overthelazydog""")]
    [InlineData(MixCLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""fox""jumps\\overthelazydog""")]
    #endregion

    #region MixCLikeEscapeOnlyQuoted
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumpsoverthelazydog", @"quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumpsoverthelazydog", @"""quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumpsoverthelazydog", @"""quickbrownfoxjumpsoverthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumpsoverthelazydog", @"quickbrownfoxjumpsoverthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps""""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps""""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps""""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps""""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps""""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps""""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps\""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""foxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""foxjumps\""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps\""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""fox""jumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps\""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""fox""jumps\""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrownfoxjumps\\overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""foxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"""quickbrown""foxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"""quickbrown""foxjumps\\overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""foxjumps\\overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown""fox""jumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""fox""jumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""fox""jumps\\overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown""fox""jumps\\overthelazydog""")]
    #endregion

    #region MixCLikeEscapeOnlyFullyQuoted
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumpsoverthelazydog", @"quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumpsoverthelazydog", @"""quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumpsoverthelazydog", @"""quickbrownfoxjumpsoverthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumpsoverthelazydog", @"quickbrownfoxjumpsoverthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps""""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrownfoxjumps""""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""foxjumps""""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""foxjumps""""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps""""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps""""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"quickbrown""fox""jumps""""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrownfoxjumps\""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""foxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""foxjumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""foxjumps\""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""foxjumps\""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""fox""jumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps\""overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\"overthelazydog", @"""quickbrown""fox""jumps\""overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown""fox""jumps\""overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrownfoxjumps\\overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown""foxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"""quickbrown""foxjumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"""quickbrown""foxjumps\\overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown""foxjumps\\overthelazydog""")]

    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown""fox""jumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""fox""jumps\\overthelazydog")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"""quickbrown""fox""jumps\\overthelazydog""")]
    [InlineData(MixCLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown""fox""jumps\\overthelazydog""")]
    #endregion

    #region EnableEcmaScriptLike
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumpsoverthelazydog", "quickbrownfoxjumpsoverthelazydog")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumpsoverthelazydog", "'quickbrownfoxjumpsoverthelazydog")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumpsoverthelazydog", "'quickbrownfoxjumpsoverthelazydog'")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumpsoverthelazydog", "quickbrownfoxjumpsoverthelazydog'")]

    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "quickbrownfoxjumps''overthelazydog")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "'quickbrownfoxjumps''overthelazydog")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "'quickbrownfoxjumps''overthelazydog'")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "quickbrownfoxjumps''overthelazydog'")]

    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "quickbrown'foxjumps''overthelazydog")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "'quickbrown'foxjumps''overthelazydog")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "'quickbrown'foxjumps''overthelazydog'")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "quickbrown'foxjumps''overthelazydog'")]

    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "quickbrown'fox'jumps''overthelazydog")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "'quickbrown'fox'jumps''overthelazydog")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "'quickbrown'fox'jumps''overthelazydog'")]
    [InlineData(EnableEcmaScriptLike, "quickbrownfoxjumps'overthelazydog", "quickbrown'fox'jumps''overthelazydog'")]
    #endregion

    #region MixEcmaScriptLikeEscape
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumpsoverthelazydog", "quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumpsoverthelazydog", "'quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumpsoverthelazydog", "'quickbrownfoxjumpsoverthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumpsoverthelazydog", "quickbrownfoxjumpsoverthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "quickbrownfoxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "'quickbrownfoxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "'quickbrownfoxjumps''overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "quickbrownfoxjumps''overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "quickbrown'foxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "'quickbrown'foxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "'quickbrown'foxjumps''overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "quickbrown'foxjumps''overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "quickbrown'fox'jumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "'quickbrown'fox'jumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "'quickbrown'fox'jumps''overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", "quickbrown'fox'jumps''overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"quickbrownfoxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"'quickbrownfoxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"'quickbrownfoxjumps\'overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"quickbrownfoxjumps\'overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"quickbrown'foxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"'quickbrown'foxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"'quickbrown'foxjumps\'overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"quickbrown'foxjumps\'overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"quickbrown'fox'jumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"'quickbrown'fox'jumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"'quickbrown'fox'jumps\'overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps'overthelazydog", @"quickbrown'fox'jumps\'overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"'quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"'quickbrownfoxjumps\\overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'foxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'foxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'foxjumps\\overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'foxjumps\\overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'fox'jumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'fox'jumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'fox'jumps\\overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscape, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'fox'jumps\\overthelazydog'")]
    #endregion

    #region MixEcmaScriptLikeEscapeOnlyQuoted
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumpsoverthelazydog", "quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumpsoverthelazydog", "'quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumpsoverthelazydog", "'quickbrownfoxjumpsoverthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumpsoverthelazydog", "quickbrownfoxjumpsoverthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrownfoxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrownfoxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrownfoxjumps''overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrownfoxjumps''overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrown'foxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrown'foxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrown'foxjumps''overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrown'foxjumps''overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrown'fox'jumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrown'fox'jumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrown'fox'jumps''overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrown'fox'jumps''overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", @"'quickbrownfoxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", @"'quickbrownfoxjumps\'overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\'overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", @"quickbrown'foxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'foxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'foxjumps\'overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", @"quickbrown'foxjumps\'overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'fox'jumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", @"'quickbrown'fox'jumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps'overthelazydog", @"'quickbrown'fox'jumps\'overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'fox'jumps\'overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrownfoxjumps\\overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'foxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"'quickbrown'foxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"'quickbrown'foxjumps\\overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'foxjumps\\overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown'fox'jumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'fox'jumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'fox'jumps\\overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown'fox'jumps\\overthelazydog'")]
    #endregion

    #region MixEcmaScriptLikeEscapeOnlyFullyQuoted
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumpsoverthelazydog", "quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumpsoverthelazydog", "'quickbrownfoxjumpsoverthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumpsoverthelazydog", "'quickbrownfoxjumpsoverthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumpsoverthelazydog", "quickbrownfoxjumpsoverthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrownfoxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrownfoxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrownfoxjumps''overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrownfoxjumps''overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrown'foxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrown'foxjumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrown'foxjumps''overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrown'foxjumps''overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrown'fox'jumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrown'fox'jumps''overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "'quickbrown'fox'jumps''overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", "quickbrown'fox'jumps''overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", @"'quickbrownfoxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", @"'quickbrownfoxjumps\'overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrownfoxjumps\'overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'foxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'foxjumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'foxjumps\'overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'foxjumps\'overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'fox'jumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", @"'quickbrown'fox'jumps\'overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps'overthelazydog", @"'quickbrown'fox'jumps\'overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"quickbrown'fox'jumps\'overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrownfoxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrownfoxjumps\\overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrownfoxjumps\\overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown'foxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"'quickbrown'foxjumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"'quickbrown'foxjumps\\overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown'foxjumps\\overthelazydog'")]

    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown'fox'jumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'fox'jumps\\overthelazydog")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\overthelazydog", @"'quickbrown'fox'jumps\\overthelazydog'")]
    [InlineData(MixEcmaScriptLikeEscapeOnlyFullyQuoted, "quickbrownfoxjumps\\\\overthelazydog", @"quickbrown'fox'jumps\\overthelazydog'")]
    #endregion

    public void ForEval(TextualArgumentOptions options, string expected, string input)
    {
        Assert.Equal(expected, TextualArgumentUtility.EvaluateCommandLineArgument(input, options));
    }
}
