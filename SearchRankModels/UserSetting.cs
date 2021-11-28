namespace SearchRank.Models
{
    /// <summary>
    /// Basic user settings
    /// </summary>
    public class UserSetting
    {
        public string UserName { get; set; }
        public string SearchEngineUrl { get; set; }
        public string SearchKey { get; set; }
        public short PreferredRank { get; set; }
    }
}
