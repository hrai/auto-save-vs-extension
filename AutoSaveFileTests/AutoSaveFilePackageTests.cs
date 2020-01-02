using AutoSaveFile;
using EnvDTE;
using FluentAssertions;
using Moq;
using Xunit;

namespace AutoSaveFileTests
{
    public class HelperTests
    {
        [Fact]
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

        [Fact]
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

        [Fact]
        public void GetFileType_ReturnsEmptyString_WhenDocumentOrProjectIsNotAvailable()
        {
            var window = new Mock<Window>();

            var sut = new Helper();
            var fileType = sut.GetFileType(window.Object);
            fileType.Should().BeEmpty();
        }

        /* todo - complete this test
        [VsixFact]
        public void ShouldSaveDocument_ReturnsTrue_WhenIgnoredFileTypesIsEmpty()
        {
            var document = new Mock<Document>();
            document.Setup(doc => doc.FullName).Returns("c:\\test\\tester.cs");

            var windowMock = new Mock<Window>();
            windowMock.Setup(win => win.Document).Returns(document.Object);
            windowMock.SetupGet(win => win.Kind).Returns("Document");

            //var optionsPage = new OptionPageGrid { TimeDelay = 1, IgnoredFileTypes = null };
            var optionsPage = (OptionPageGrid)GetDialogPage(typeof(OptionPageGrid));

            var sut = new Helper();
            sut.ShouldSaveDocument(windowMock.Object, optionsPage).Should().BeTrue();
        }
        */
    }
}
