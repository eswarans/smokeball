using SearchRank.Models;
using SearchRank.Ui.WebInterface;
using System.Windows;

namespace SearchRank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        private UserSetting userSetting = new UserSetting()
        {
            PreferredRank = 100,
            SearchEngineUrl = "Google",
            SearchKey = "conveyancing software",
            UserName = ""
        };

        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = userSetting;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            ServerEndpoint server = new ServerEndpoint();
            server.SaveUserSettings(userSetting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ServerEndpoint server = new ServerEndpoint();
            userSetting = server.GetUserSettings("");
            DataContext = null;
            DataContext = userSetting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            ServerEndpoint server = new ServerEndpoint();
            int rank = server.GetResults();
            MessageBox.Show("Hi " + userSetting.UserName + ", current Rank is : " + rank.ToString());

        }
    }
}
