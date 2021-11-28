using SearchRank.Interfaces.Logic;
using System;

namespace SearchRank.Logic
{
    /// <summary>
    /// Google specific search url building logic
    /// </summary>
    public class GoogleSearchUrlBuilder : IUrlBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string SearchUrl(string Key)
        {
            Key = Key.Trim();
            string[] keys = Key.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return @"https://www.google.com.au/search?num=100&q=" + string.Join('+', keys);
        }
    }
}