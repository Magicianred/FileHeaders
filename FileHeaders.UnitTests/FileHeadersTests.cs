using System.IO;
using Xunit;

namespace FileHeaders.UnitTests
{
    public class FileHeadersTests
    {

        [Theory]
        [ExpectedFileType("FileHeaders.UnitTests.file.png", FileType.Png)]
        [ExpectedFileType("FileHeaders.UnitTests.file.jpg", FileType.Jpg)]
        [ExpectedFileType("FileHeaders.UnitTests.file.jpeg", FileType.Jpg)]
        [ExpectedFileType("FileHeaders.UnitTests.file.gif", FileType.Gif)]
        [ExpectedFileType("FileHeaders.UnitTests.file.tiff", FileType.Tiff)]
        public void Analyze_ShouldReturnCorrectType(Stream fileStream, FileType expectedType)
        {
            Assert.Equal(FileHeaders.Analyze(fileStream), expectedType);
        }

    }
}
