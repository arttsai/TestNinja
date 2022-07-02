using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NSubstitute;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_WhenInputNUll_ReturnErrorMessage()
        {
            var fileReader = Substitute.For<IFileReader>();
            var videoRepository = new VideoRepository();
            fileReader.FileReadAllText(Arg.Any<string>()).Returns("");

            var service = new VideoService(fileReader, videoRepository);
            var result = service.ReadVideoTitle();
            
            Assert.AreEqual(result, "Error parsing the video.");
        }
        
        [Test]
        public void ReadVideoTitle_WhenInputValid_ReturnVideoTitle()
        {
            var fileReader = Substitute.For<IFileReader>();
            var videoRepository = new VideoRepository();
            var jsonString = @"{""Title"": ""ABC""}";
            fileReader.FileReadAllText(Arg.Any<string>()).Returns(jsonString);

            Console.WriteLine($"@ literal string: {jsonString}");
            
            var service = new VideoService(fileReader, videoRepository);
            var result = service.ReadVideoTitle();
            
            Assert.AreEqual(result, "ABC");
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenExistUnprocessed_ReturnVideoIdCSV()
        {
            var fileReader = Substitute.For<IFileReader>();
            var videoRepository = Substitute.For<IVideoRepository>();
            var videos = new List<Video>()
            {
                new Video() { Id = 1, IsProcessed = false },
                new Video() { Id = 2, IsProcessed = false },
                new Video() { Id= 3, IsProcessed = true}
            };
            videoRepository.GetVideos().Returns(videos);

            var service = new VideoService(fileReader, videoRepository);
            var result = service.GetUnprocessedVideosAsCsv();
            
            Assert.AreEqual(result, "1,2");
        }
        
        [Test]
        public void GetUnprocessedVideosAsCsv_WhenNoUnprocessed_ReturnEmptyCSV()
        {
            var fileReader = Substitute.For<IFileReader>();
            var videoRepository = Substitute.For<IVideoRepository>();
            var videos = new List<Video>()
            {
                new Video() { Id = 1, IsProcessed = true },
                new Video() { Id = 2, IsProcessed = true },
                new Video() { Id= 3, IsProcessed = true}
            };
            videoRepository.GetVideos().Returns(videos);

            var service = new VideoService(fileReader, videoRepository);
            var result = service.GetUnprocessedVideosAsCsv();
            
            Assert.AreEqual(result, "");
        }
    }
}