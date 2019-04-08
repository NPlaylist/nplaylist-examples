using System;
using CommandLine;

namespace NPlaylist.Converter
{
    public class ConsoleOptions
    {
        [Value(0, HelpText = "source file path", Required = true)]
        public string SourceFile { get; set; }

        [Value(1, HelpText = "source file path", Required = true)]
        public string DestinationFile { get; set; }

        [Value(2, HelpText = "Output format:ASX,M3U,PLS,XSPF,WPL", Required = true)]
        public Format Format { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser(with => with.CaseInsensitiveEnumValues = true);
            parser.ParseArguments<ConsoleOptions>(args)
                .WithParsed(options => Convert(options));
        }

        private static void Convert(ConsoleOptions options)
        {
            try
            {
                ConversionTool.Convert(options.SourceFile, options.DestinationFile, options.Format);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
