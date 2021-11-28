using SearchRank.Interfaces.Logic;
using System;
using System.Collections.Generic;

namespace SearchRank.Logic
{
    /// <summary>
    /// Logic that finds the rank of the Key in google search results
    /// </summary>
    public class GoogleRank : IRank
    {
        public int GetRank(string text, string key)
        {
            int searchLenth = 200;
            string textId = @"<div class=""ZINbbc xpd O9g5cc uUPGi""><div class=""kCrYT"">"; 
            List<int> positions = new List<int>();
            if(!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(key))
            {
                int startpos = 0;
                while (startpos >= 0 && startpos < text.Length)
                {
                    startpos = text.IndexOf(textId, startpos, StringComparison.OrdinalIgnoreCase);
                    if (startpos >= 0)
                    {
                        positions.Add(startpos);
                        startpos++;
                    }
                }
                for (int i = 0; i< positions.Count; i++)
                {
                    int position = positions[i];
                    int pos = text.IndexOf(key, position, searchLenth, StringComparison.OrdinalIgnoreCase);
                    if(pos >0)
                    {
                        return i++;
                    }
                }
            }
            return -1;
        }
    }
}