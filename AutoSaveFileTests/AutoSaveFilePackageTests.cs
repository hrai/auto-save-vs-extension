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
            fileType.Should().Be("cs");
        }

        [TestCase]
        public void GetFileType_ReturnsProjExt_WhenOnlyProjPathIsAvailable()
        {
            var window = new Mock<Window>();
            var project = new Mock<Project>();
            window.Setup(win => win.Project).Returns(project.Object);
            project.Setup(proj => proj.FullName).Returns("c:\\test\\tester.csproj");

            var sut = new Helper();
            var fileType = sut.GetFileType(window.Object);
            fileType.Should().Be("csproj");
        }

        [TestCase]
        public void GetFileType_ReturnsEmptyString_WhenDocumentOrProjectIsNotAvailable()
        {
            var window = new Mock<Window>();

            var sut = new Helper();
            var fileType = sut.GetFileType(window.Object);
            fileType.Should().BeEmpty();
        }
    }
}
