using CommunityToolkit.Mvvm.DependencyInjection;
using ELROOMBA.Pages;
using ELROOMBA.View;
using ELROOMBA.Viewmodels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
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
        SetTitleBar(_CUSTOM_TITLE_BAR);
        Viewmodel = Ioc.Default.GetService<MainWindowViewModel>();
        Viewmodel.MainConstructorViewModel();
        _MAIN_FRAME.Navigate(typeof(HelpViewPage), null, new EntranceNavigationTransitionInfo());
    }

    public MainWindowViewModel? Viewmodel { get; set; }

    private void ONCLICK_BTNLOGIN(object sender, RoutedEventArgs e) { _MAIN_FRAME.Navigate(typeof(LoginViewPage), null, new DrillInNavigationTransitionInfo()); }

    private void NAVIGATIONVIEW(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        var selectedItem = (NavigationViewItem)args.SelectedItem;
        if (selectedItem != null)
        {
            string selectedItemTag = ((string)selectedItem.Tag);
            string pageName = "ELROOMBA.View." + selectedItemTag;
            Type pageType = Type.GetType(pageName);
            _MAIN_FRAME.Navigate(pageType, null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

    }


    private async void _ONCLICK_ALERTDIALOG(object sender, RoutedEventArgs e) { ContentDialogResult _ALERTDIALOG = await _ALERT_COUNT_DIALOG.ShowAsync(); }

    private void _ONCLICK_HELPVIEW(object sender, RoutedEventArgs e) { _MAIN_FRAME.Navigate(typeof(HelpViewPage), null, new EntranceNavigationTransitionInfo()); }

}
