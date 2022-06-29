using CommunityToolkit.Mvvm.DependencyInjection;
using ELROOMBA.Pages;
using ELROOMBA.Pages.Components;
using ELROOMBA.Viewmodels;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Drawing;

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
        SetTitleBar(_CUSTOM_TITLE_BAR);
        Viewmodel = Ioc.Default.GetService<MainWindowViewModel>();
        Viewmodel.MainConstructorViewModel();
        _MAIN_FRAME.Navigate(typeof(MainViewPage));
    }

    public MainWindowViewModel? Viewmodel { get; set; }

    
}
