using SearchRank.Interfaces.Data;
using SearchRank.Models;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System;

namespace SearchRank.Data.Updates.xml
{
    /// <summary>
    /// 
    /// </summary>
    public class XUpdate : IDataUpdates
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool SetUserSetting(UserSetting val)
        {
            try
            {
                XmlDocument xdoc;
                if (File.Exists(filepath))
                {
                    xdoc = new XmlDocument();
                    xdoc.Load(filepath);

                    XmlNodeList nodelist = xdoc.GetElementsByTagName("userSetting");

                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        XmlNode node = nodelist[i];

                        string userName = node.SelectSingleNode("userName").InnerText;
                        if (userName.ToUpper().Trim() == val.UserName.ToUpper().Trim())
                        {
                            xdoc.DocumentElement.RemoveChild(node);
                            UpdateNode(xdoc, val);
                            return true;
                        }
                    }
                    UpdateNode(xdoc, val); // user name doesn't exist
                }
                else
                {
                    xdoc = new XmlDocument();
                    var root = xdoc.CreateElement("root");
                    xdoc.AppendChild(root);
                    UpdateNode(xdoc, val);
                }
                return true;
            }
            catch(Exception ex)
            {
                string err = ex.ToString();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xdoc"></param>
        /// <param name="val"></param>
        private void UpdateNode(XmlDocument xdoc, UserSetting val)
        {

            XmlElement userSettingX = xdoc.CreateElement("userSetting");

            XmlElement userNameX = xdoc.CreateElement("userName");
            userNameX.InnerText = val.UserName;
            userSettingX.AppendChild(userNameX);

            XmlElement PreferredRankX = xdoc.CreateElement("preferredRank");
            PreferredRankX.InnerText = val.PreferredRank.ToString();
            userSettingX.AppendChild(PreferredRankX);

            XmlElement SearchEngineUrlX = xdoc.CreateElement("searchEngineUrl");
            SearchEngineUrlX.InnerText = val.SearchEngineUrl;
            userSettingX.AppendChild(SearchEngineUrlX);

            XmlElement SearchKeyX = xdoc.CreateElement("searchKey");
            SearchKeyX.InnerText = val.SearchKey;
            userSettingX.AppendChild(SearchKeyX);

            xdoc.DocumentElement.PrependChild(userSettingX);
            xdoc.Save(filepath);
        }
    }
}