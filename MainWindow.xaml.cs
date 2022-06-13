using CommunityToolkit.Mvvm.DependencyInjection;
using ELROOMBA.Viewmodels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

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
        Viewmodel.MainConstructorViewModel();
    }

    public MainWindowViewModel? Viewmodel { get; }

    private async void _ONCLICK_ALERTDIALOG(object sender, RoutedEventArgs e) { ContentDialogResult _AlertDialog = await _ALERT_COUNT_DIALOG.ShowAsync(); }
}
