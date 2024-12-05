using MAUIVERTER1.MVVM.Views;

namespace MAUIVERTER1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MenuView());
        }
    }
}
