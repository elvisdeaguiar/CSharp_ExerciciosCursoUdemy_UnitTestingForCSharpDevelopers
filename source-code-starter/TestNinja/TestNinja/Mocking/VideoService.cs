using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IVideosRepositorio _videosRepositorio;

        public VideoService(IVideosRepositorio videosRepositorio)
        {
            this._videosRepositorio = videosRepositorio;
        }

        public string ReadVideoTitle()
        {
            var str = File.ReadAllText("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            IList<Video> videos;

            videos = _videosRepositorio.ObterVideosNaoProcessados();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
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

    public interface IVideosRepositorio
    {
        IList<Video> ObterVideosNaoProcessados();
    }

    public class VideosRepositorio : IVideosRepositorio
    {
        public IList<Video> ObterVideosNaoProcessados()
        {
            IList<Video> videos;

            using (var context = new VideoContext())
            {
                videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();
            }

            return videos;
        }
    }
}