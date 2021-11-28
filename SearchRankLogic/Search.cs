using SearchRank.Interfaces.Logic;
using System.Net.Http;

namespace SearchRank.Logic
{
    /// <summary>
    /// Logic that involves in searching and retreiving google search results
    /// </summary>
    public class Search : ISearch
    {
        public string SearchIt(string url)
        {
            using HttpClient client = new HttpClient();
            string result = client.GetStringAsync(url).Result;
            return result;
        }
    }
}