using CommunityToolkit.Mvvm.ComponentModel;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.
namespace ELROOMBA.Viewmodels;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
[ObservableObject]
public partial class NavbarFrameViewModel
{
    /// <summary>
    /// String that will display the Name of the user
    /// </summary>
    public string _DISPLAY_NAME_PERSONA_PICTURE = "NOT_LOGGED";
}
