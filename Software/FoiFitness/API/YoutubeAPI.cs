using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoiFitness
{
    public class YoutubeAPI
    {
        private string apiKey { get; set; }
        private string apiUrl { get; set; }
        private string videoID { get; set; }

        public YoutubeAPI(string videolink)
        {
            apiKey = "AIzaSyDh7nFmWqdyRMphQ-tpRwhXbqW0d5NhF1M";
            videoID = ExtractVideoId(videolink);
            apiUrl = $"https://www.googleapis.com/youtube/v3/videos?id={videoID}&key={apiKey}&part=snippet";
        }

        private string ExtractVideoId(string youtubeLink)
        {
            string videoId = "";
            if (youtubeLink.Contains("watch?v="))
            {
                videoId = youtubeLink.Split("watch?v=")[1];
            }
            else if (youtubeLink.Contains("youtu.be/"))
            {
                videoId = youtubeLink.Split("youtu.be/")[1];
            }
            return videoId;
        }

        public string GetThumbnail()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(apiUrl);
                dynamic data = JsonConvert.DeserializeObject(json);
                string thumbnailUrl = data.items[0].snippet.thumbnails.high.url;
                return thumbnailUrl;
            }
        }
    }
}
