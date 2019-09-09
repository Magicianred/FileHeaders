using System;
using System.IO;
using System.Linq;

namespace FileHeaders
{
    public static class FileHeaders
    {

        private static readonly int MaxPossibleHeaderLength = Option.All.Max(o => o.PossibleHeaders.Max(h => h.Length));

        public static FileType Analyze(Stream stream)
        {
            var data = new Span<byte>(new byte[MaxPossibleHeaderLength]);
            stream.Read(data);

            foreach (var option in Option.All)
            {
                foreach (var possibleHeader in option.PossibleHeaders)
                {
                    int length = possibleHeader.Length;

                    if (data.Slice(0, length).SequenceEqual(possibleHeader))
                        return option.Type;
                }
            }

            return FileType.Unknown;
        }

    }
}
