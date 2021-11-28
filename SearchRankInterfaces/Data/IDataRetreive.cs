using SearchRank.Models;

namespace SearchRank.Interfaces.Data
{
    /// <summary>
    /// Retreive data interface (Cannot update data with this interface)
    /// </summary>
    public interface IDataRetreive
    {
        void Init(string path);
        UserSetting GetUserSetting(string user);
    }
}