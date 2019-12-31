using FluentAssertions;
using NUnit.Framework;
using System;

namespace AutoSaveFileTests
{
    public class AutoSaveFilePackageTests
    {
        [TestCase]
        public void GetFileType()
        {
            var i = 8;
            i.Should().Be(1);
        }
    }
}
