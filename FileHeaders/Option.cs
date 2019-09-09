namespace FileHeaders
{
    public class Option
    {

        public static readonly Option[] All = new[]
        {
            new Option(FileType.Png, 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A),
            new Option
            {
                Type = FileType.Jpg,
                PossibleHeaders = new byte[][]
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
                    // FF D8 FF E1 ?? ?? 45 78 69 66 00 00
                }
            },
            new Option
            {
                Type = FileType.Gif,
                PossibleHeaders = new byte[][]
                {
                    new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 },
                    new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }
                }
            },
            new Option(FileType.Tiff, 0x49, 0x49, 0x2A, 0x00)
        };

        #region Properties

        public FileType Type { get; set; }
        public byte[][] PossibleHeaders { get; set; }

        public bool IsImage => Type == FileType.Gif || Type == FileType.Jpg || Type == FileType.Png || Type == FileType.Tiff;

        #endregion

        public Option() { }

        public Option(FileType type, params byte[] header)
        {
            Type = type;
            PossibleHeaders = new byte[][] { header };
        }

    }
}
