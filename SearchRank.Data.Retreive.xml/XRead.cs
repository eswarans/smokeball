using SearchRank.Interfaces.Data;
using SearchRank.Models;
using System.Xml;
using System.IO;
using System;

namespace SearchRank.data.xml
{
    /// <summary>
    /// 
    /// </summary>
    public class XRead : IDataRetreive
    {
        private string filepath = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void Init(string path)
        {
            filepath = path;
        }

        public UserSetting GetUserSetting(string user)
        {
            if (File.Exists(filepath))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(filepath);

                XmlNodeList nodelist = xd.GetElementsByTagName("userSetting");
                if (!string.IsNullOrEmpty(user))
                {
                    foreach (XmlNode node in nodelist)
                    {
                        try
                        {
                            string userName = node.SelectSingleNode("userName").InnerText;
                            if (userName.ToUpper().Trim() == user.ToUpper().Trim())
                            {
                                string searchEngineUrl = node.SelectSingleNode("searchEngineUrl").InnerText;
                                string searchKey = node.SelectSingleNode("searchKey").InnerText;
                                string strPreferredRank = node.SelectSingleNode("preferredRank").InnerText;
                                short preferredRank = Convert.ToInt16(strPreferredRank);
                                return new UserSetting()
                                {
                                    PreferredRank = preferredRank,
                                    SearchEngineUrl = searchEngineUrl,
                                    SearchKey = searchKey,
                                    UserName = user
                                };
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    try
                    {
                        XmlNode node = nodelist[0];
                        string userName = node.SelectSingleNode("userName").InnerText;
                        string searchEngineUrl = node.SelectSingleNode("searchEngineUrl").InnerText;
                        string searchKey = node.SelectSingleNode("searchKey").InnerText;
                        string strPreferredRank = node.SelectSingleNode("preferredRank").InnerText;
                        short preferredRank = Convert.ToInt16(strPreferredRank);
                        return new UserSetting()
                        {
                            PreferredRank = preferredRank,
                            SearchEngineUrl = searchEngineUrl,
                            SearchKey = searchKey,
                            UserName = userName
                        };
                    }
                    catch
                    {
                    }

                }
            }
            return null;
        }
    }
}
