using CommunityToolkit.Mvvm.DependencyInjection;
using ELROOMBA.Viewmodels;
using Microsoft.UI.Xaml.Controls;
using System;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ELROOMBA.Pages.Components;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class InfobarViewFrame : Page
{
    public InfobarViewFrame()
    {
        this.InitializeComponent();
        Viewmodel = Ioc.Default.GetService<InfobarFrameViewModel>();
        Viewmodel.MainInfobarFrameViewModel();
        
    }

    public InfobarFrameViewModel? Viewmodel { get; set; }

    private async void _ONCLICK_ALERTDIALOG(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) { ContentDialogResult _AlertDialog = await _ALERT_COUNT_DIALOG.ShowAsync(); }
}
