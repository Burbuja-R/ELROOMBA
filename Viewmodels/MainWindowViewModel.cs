using CommunityToolkit.Mvvm.ComponentModel;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ELROOMBA.Viewmodels;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
[ObservableObject]
public partial class MainWindowViewModel
{
    /// <summary>
    /// Titulo principal de la aplicacion.
    /// </summary>
    public string Title = "ELROOMBA";


    /// <summary>
    /// Variable Alert Count.
    /// </summary>
    public int _ALERTCOUNT;


    /// <summary>
    /// Primary Main Ctor of this ViewModel.
    /// </summary>
    public void MainConstructorViewModel()
    {
       
    }
}
