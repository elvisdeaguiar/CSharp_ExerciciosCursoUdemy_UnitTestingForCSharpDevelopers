using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.TestesUnitarios.Mocking
{
    [TestFixture]
    public class VideoServiceTestes
    {
        private Mock<IVideosRepositorio> videosRepositorioMock;
        private VideoService videoService;

        [SetUp]
        public void SetUp()
        {
            videosRepositorioMock = new Mock<IVideosRepositorio>();
            videoService = new VideoService(videosRepositorioMock.Object);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_QuandoAListaDeVideosNaoProcessadosForVazia_DeveRetornarStringVazia()
        {
            videosRepositorioMock.Setup(vr => vr.ObterVideosNaoProcessados()).Returns(new List<Video>());
            
            string csv = videoService.GetUnprocessedVideosAsCsv();
                        
            Assert.That(csv, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_QuandoAListaDeVideosPossuirUmVideo_DeveRetornarOIdDaqueleVideo()
        {
            var video1 = new Video { Id = 1, Title = "Vídeo 1", IsProcessed = false };
            videosRepositorioMock.Setup(vr => vr.ObterVideosNaoProcessados()).Returns(new List<Video> { video1 });

            string csv = videoService.GetUnprocessedVideosAsCsv();

            Assert.That(csv, Is.EqualTo("1"));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_QuandoAListaDeVideosPossuirMaisDeUmVideo_DeveRetornarOsIdsDosVideosSeparadosPorVirgula()
        {
            var video1 = new Video { Id = 1, Title = "Vídeo 1", IsProcessed = false };
            var video2 = new Video { Id = 2, Title = "Vídeo 2", IsProcessed = false };
            videosRepositorioMock.Setup(vr => vr.ObterVideosNaoProcessados()).Returns(new List<Video> { video1, video2 });

            string csv = videoService.GetUnprocessedVideosAsCsv();

            Assert.That(csv, Is.EqualTo("1,2"));
        }
    }
}
