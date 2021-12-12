using HtmlAgilityPack;
using Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logic
{
    public class ManagerService : IManagerService
    {
        private readonly HtmlDocument html = new HtmlDocument();
        private List<Celebrity> celebrities = new List<Celebrity>();
        private const string fileName = "celebrities.json";
        private const string baseUrl = "https://www.imdb.com";
        public async Task<List<Celebrity>> GetAllCelebritiesAsync()
        {
            await FatchFromIMDBSaveToJsonFileAsync();
            await FatchDataFromFileAsync();
            return celebrities;
        }
        public async Task<List<Celebrity>> RemoveCelebrityAsync(Celebrity celebrity)
        {
            await FatchDataFromFileAsync();
            celebrities.Remove(celebrity);
            await SaveToFileAsync();
            return celebrities;
        }
        private async Task FatchFromIMDBSaveToJsonFileAsync()
        {
            
            html.LoadHtml(new WebClient().DownloadString($"{baseUrl}/list/ls052283250/"));
            string celebLinkScript = html.DocumentNode.SelectNodes("//script[@type='application/ld+json']").First().InnerText;
            ParentList parentList = JsonSerializer.Deserialize<ParentList>(celebLinkScript);
            parentList.about.itemListElement.ToList().ForEach(async element =>
            {
                html.LoadHtml(new WebClient().DownloadString($"{baseUrl}{element.url}"));
                string script = html.DocumentNode.SelectNodes("//script[@type='application/ld+json']").First().InnerText;
                Celebrity celeb = JsonSerializer.Deserialize<Celebrity>(script);
                celeb.gender = await GenderDetectedProcessor.GetGenderByImgAsync(celeb.image);
                celebrities.Add(celeb);
            });
            await SaveToFileAsync();
        }
        private async Task FatchDataFromFileAsync()
        {
            using FileStream openStream = File.OpenRead(fileName);
            celebrities = await JsonSerializer.DeserializeAsync<List<Celebrity>>(openStream);
        }
        private async Task SaveToFileAsync()
        {
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, celebrities);
            await createStream.DisposeAsync();
        }
    }
}
