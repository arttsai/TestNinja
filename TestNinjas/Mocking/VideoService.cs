using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public interface IFileReader
    {
        string FileReadAllText(string filename);
    }

    public class VideoService
    {
        public IFileReader FileReader { get; set; }
        public IVideoRepository VideoRepository { get; set; }
        
        public VideoService(IFileReader fileReader, IVideoRepository videoRepository)
        {
            FileReader = fileReader;
            VideoRepository = videoRepository;
        }

        public string ReadVideoTitle()
        {
            var str = FileReader.FileReadAllText("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        // public string FileReadAllText(string filename)
        // {
        //     return File.ReadAllText(filename);
        // }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
            // 測: 
            // 1. !video.IsProcessed 的項目，都有被挑到 (到  videoIds) 
            // 2. video.IsProcessed = true 的項目，都沒有被挑到 
            var videos = 
                (from video in VideoRepository.GetVideos()
                    where !video.IsProcessed
                    select video).ToList();
                
            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class FileReader : IFileReader
    {
        public string FileReadAllText(string filename)
        {
            return File.ReadAllText(filename);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
    
    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetVideos()
        {
            return new VideoContext().Videos; 
        }
    }

    public interface IVideoRepository
    {
        IEnumerable<Video> GetVideos();
    }
}