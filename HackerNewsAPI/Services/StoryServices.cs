using HackerNewsAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace HackerNewsAPI.Services
{
    public class StoryServices
    {
        public static IEnumerable<Story> GetStories()
        {
            var url = $"https://hacker-news.firebaseio.com/v0/item/8863.json?print=pretty";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            JObject json = JObject.Parse(rawResponse);

            var newStories = json["articles"]
                .Select(s => new Story { Author = s["author"].ToString(), Title = s["title"].ToString(), URL = s["url"].ToString() })
                .GroupBy(g => g.URL).Select(s => s.First());

            return newStories;
        }
    }
}