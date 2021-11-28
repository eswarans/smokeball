using SearchRank.Models;

namespace SearchRank.Interfaces.Data
{
    /// <summary>
    /// Seperate interface for data modifications
    /// </summary>
    public interface IDataUpdates
    {
        void Init(string path);
        bool SetUserSetting(UserSetting val);
    }
}