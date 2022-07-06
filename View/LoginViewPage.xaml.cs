using CommunityToolkit.Mvvm.DependencyInjection;
using ELROOMBA.Viewmodels;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ELROOMBA.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginViewPage : Page
    {
        public LoginViewPage()
        {
            this.InitializeComponent();
            Viewmodel = Ioc.Default.GetService<LoginPageViewModel>();
        }

        public LoginPageViewModel? Viewmodel { get; set; }

    }
}
