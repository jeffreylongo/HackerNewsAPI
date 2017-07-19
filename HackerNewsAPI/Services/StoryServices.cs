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
        public static IEnumerable<Story> GetStories(NewsSearchModel searchModel)
        {
            //connect to API and get json
            var url = $"https://newsapi.org/v1/articles?source=hacker-news&sortBy=top&apiKey=d83621ac9a174c91823a72f6e131fb00";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            JObject json = JObject.Parse(rawResponse);

            //deserialize json into c# object
            var newStories = json["articles"]
                .Select(s => new Story { Author = s["author"].ToString(), Title = s["title"].ToString(), URL = s["url"].ToString() })
                .GroupBy(g => g.URL).Select(s => s.First());

            //search function logic
            var result = newStories.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.Title != null)
                    newStories = result.Where(w => w.Title.ToLower().Contains(searchModel.Title.ToLower()));
                
            }

            return newStories;
        }

    }
}