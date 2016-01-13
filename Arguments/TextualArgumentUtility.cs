﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using EssIL;
using static TextualArgumentOptions;

static partial class TextualArgumentUtility
{
    const char RegularQuoteChar = '"';
    const char ESStyleAdditionalQuoteChar = '\'';

    public static string EvaluateCommandLineArgument(string argument,
        TextualArgumentOptions options = Default)
    {
        if (!options.IsValid())
            throw new ArgumentOutOfRangeException(nameof(options));

        char? last = null;
        char? quote = null;
        var useESStyle = options.Has(EnableEcmaScriptStyle);
        var fullyQuoted = (argument[0] == RegularQuoteChar || useESStyle && argument[0] == ESStyleAdditionalQuoteChar);
        var sb = new StringBuilder();

        foreach (var c in argument)
        {
            if (last == '\\')
                last = null;
            else
            {
                switch (c)
                {
                    case ESStyleAdditionalQuoteChar:
                        if (useESStyle)
                            goto case RegularQuoteChar;
                        goto default;
                    case RegularQuoteChar:
                        if (c == quote)
                            quote = null;
                        else
                            quote = c;

                        if (c == last)
                            last = null;
                        else
                        {
                            last = c;
                            continue;
                        }
                        break;
                    case '\\':
                        var shouldEscape = false;
                        switch (options)
                        {
                            case MixCStyleEscape:
                                shouldEscape = true;
                                break;
                            case MixCStyleEscapeOnlyQuoted:
                                shouldEscape = quote.HasValue;
                                break;
                            case MixCStyleEscapeOnlyFullyQuoted:
                                shouldEscape = fullyQuoted && quote.HasValue;
                                break;
                        }

                        if (shouldEscape)
                        {
                            last = '\\';
                            continue;
                        }

                        break;
                    default:
                        last = null;
                        break;
                }
            }
            sb.Append(c);
        }
        return sb.ToString();
    }

    public static string[] GetCommandLineArguments(
        TextualArgumentOptions options = Default)
        => Environment.CommandLine.ReadCommandLineArguments(options);

    public static string ReadCommandLineArgument(this TextReader reader,
        TextualArgumentOptions options = Default)
    {
        if (!options.IsValid())
            throw new ArgumentOutOfRangeException(nameof(options));

        int cp;
        char c;
        for (;;)
        {
            cp = reader.Read();
            if (cp < 0) return null;

            c = (char)cp;
            if (!char.IsWhiteSpace(c))
                break;
        }

        char? quote = null;
        var useESStyle = options.Has(EnableEcmaScriptStyle);
        var fullyQuoted = (c == RegularQuoteChar || useESStyle && c == ESStyleAdditionalQuoteChar);
        var sb = new StringBuilder();

        while (cp >= 0)
        {
            c = (char)cp;

            switch (c)
            {
                case ESStyleAdditionalQuoteChar:
                    if (useESStyle)
                        goto case RegularQuoteChar;
                    goto default;
                case RegularQuoteChar:
                    if (c == quote)
                        quote = null;
                    else
                        quote = c;
                    break;
                case '\\':
                    var shouldEscape = false;
                    switch (options)
                    {
                        case MixCStyleEscape:
                            shouldEscape = true;
                            break;
                        case MixCStyleEscapeOnlyQuoted:
                            shouldEscape = quote.HasValue;
                            break;
                        case MixCStyleEscapeOnlyFullyQuoted:
                            shouldEscape = fullyQuoted && quote.HasValue;
                            break;
                    }

                    if (shouldEscape)
                    {
                        sb.Append('\\');

                        cp = reader.Read();
                        if (cp < 0) continue;

                        c = (char)cp;
                    }
                    break;
                default:
                    if (!quote.HasValue && char.IsWhiteSpace(c))
                    {
                        cp = -1;
                        continue;
                    }
                    break;
            }
            sb.Append(c);

            cp = reader.Read();
        }
        return sb.ToString();
    }
    public static IEnumerable<string> ReadCommandLineArguments(this TextReader reader,
        TextualArgumentOptions options = Default)
    {
        string argument;
        for (;;)
        {
            argument = ReadCommandLineArgument(reader, options);
            if (argument == null) yield break;
            yield return argument;
        }
    }
    public static string[] ReadCommandLineArguments(this string text,
        TextualArgumentOptions options = Default)
    {
        using (var reader = new StringReader(text))
            return ReadCommandLineArguments(reader, options).ToArray();
    }
}