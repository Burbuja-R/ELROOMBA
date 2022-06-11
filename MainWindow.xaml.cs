using CommunityToolkit.Mvvm.DependencyInjection;
using ELROOMBA.Viewmodels;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ELROOMBA;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        ExtendsContentIntoTitleBar = true;
        SetTitleBar(CustomTitleBar);
        Viewmodel = Ioc.Default.GetService<MainWindowViewModel>();
    }

    public MainWindowViewModel? Viewmodel { get; }
}
