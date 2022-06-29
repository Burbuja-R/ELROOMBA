﻿using ELROOMBA.Pages.Components;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ELROOMBA.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainViewPage : Page
    {
        public MainViewPage()
        {
            this.InitializeComponent();
            _INFO_BAR.Navigate(typeof(InfobarViewFrame));

        }
    }
}
