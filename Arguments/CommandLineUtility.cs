using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using EssIL;

static partial class CommandLineUtility
{
    public static string EvaluateCommandLineArgument(string argument, 
        CommandLineArgumentOptions options = CommandLineArgumentOptions.Default)
    {
        if (!CommandLineArgumentOptions.MixCStyleEscapeOnlyFullyQuoted.Has(options))
            throw new ArgumentOutOfRangeException(nameof(options));

        char? last = null;
        var quoted = false;
        var fullyQuoted = (argument[0] == '"');
        var sb = new StringBuilder();

        foreach (var c in argument)
        {
            if (last == '\\')
            {
                last = null;
            }
            else
            {
                switch (c)
                {
                    case '"':
                        quoted = !quoted;

                        if (last == '"')
                        {
                            last = null;
                        }
                        else
                        {
                            last = '"';
                            continue;
                        }

                        break;
                    case '\\':
                        var shouldEscape = false;
                        switch (options)
                        {
                            case CommandLineArgumentOptions.MixCStyleEscape:
                                shouldEscape = true;
                                break;
                            case CommandLineArgumentOptions.MixCStyleEscapeOnlyQuoted:
                                shouldEscape = quoted;
                                break;
                            case CommandLineArgumentOptions.MixCStyleEscapeOnlyFullyQuoted:
                                shouldEscape = fullyQuoted && quoted;
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
        CommandLineArgumentOptions options = CommandLineArgumentOptions.Default)
        => Environment.CommandLine.ReadCommandLineArguments(options);

    public static string ReadCommandLineArgument(this TextReader reader,
        CommandLineArgumentOptions options = CommandLineArgumentOptions.Default)
    {
        if (!CommandLineArgumentOptions.MixCStyleEscapeOnlyFullyQuoted.Has(options))
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

        var fullyQuoted = (c == '"');
        var quoted = false;
        var sb = new StringBuilder();

        while (cp >= 0)
        {
            c = (char)cp;

            switch (c)
            {
                case '"':
                    quoted = !quoted;
                    break;
                case '\\':
                    var shouldEscape = false;
                    switch (options)
                    {
                        case CommandLineArgumentOptions.MixCStyleEscape:
                            shouldEscape = true;
                            break;
                        case CommandLineArgumentOptions.MixCStyleEscapeOnlyQuoted:
                            shouldEscape = quoted;
                            break;
                        case CommandLineArgumentOptions.MixCStyleEscapeOnlyFullyQuoted:
                            shouldEscape = fullyQuoted && quoted;
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
                    if (!quoted && char.IsWhiteSpace(c))
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
        CommandLineArgumentOptions options = CommandLineArgumentOptions.Default)
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
        CommandLineArgumentOptions options = CommandLineArgumentOptions.Default)
    {
        using (var reader = new StringReader(text))
            return ReadCommandLineArguments(reader, options).ToArray();
    }
}
