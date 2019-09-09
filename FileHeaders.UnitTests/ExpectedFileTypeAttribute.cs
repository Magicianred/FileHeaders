using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FileHeaders.UnitTests
{
    public class ExpectedFileTypeAttribute : DataAttribute
    {

        private static readonly Assembly Assembly = typeof(ExpectedFileTypeAttribute).GetTypeInfo().Assembly;

        public string EmbeddedResource { get; }
        public FileType ExpectedType { get; }

        public ExpectedFileTypeAttribute(string embeddedResource, FileType expectedType)
        {
            EmbeddedResource = embeddedResource;
            ExpectedType = expectedType;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return new[]
            {
                new object[] { Assembly.GetManifestResourceStream(EmbeddedResource), ExpectedType }
            };
        }

    }
}
