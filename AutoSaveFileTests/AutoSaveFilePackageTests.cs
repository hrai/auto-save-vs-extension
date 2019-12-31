using AutoSaveFile;
using EnvDTE;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;

namespace AutoSaveFileTests
{
    public class AutoSaveFilePackageTests
    {
        [TestCase]
        public void GetFileType_ReturnsDocumentExt_WhenDocumentPathIsAvailable()
        {
            var window = new Mock<Window>();
            var document = new Mock<Document>();
            window.Setup(win => win.Document).Returns(document.Object);
            document.Setup(doc => doc.FullName).Returns("c:\\test\\tester.cs");

            var sut = new Helper();
            var fileType = sut.GetFileType(window.Object);
            fileType.Should().Be(".cs");
        }
    }
}
