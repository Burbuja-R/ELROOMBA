using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;

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
    /// El titulo que aparecera cuando el AlertDialog este abierto
    /// </summary>
    private string? _ALERT_TEXT = "There`s nothing here...";

    public string? _ALERT_TEXTT
    {
        get => _ALERT_TEXT;
        set => SetProperty(ref _ALERT_TEXT, value);
    }

    /// <summary>
    /// Un String que se usara para introducir el texto de
    /// un textBlock, para 'Diagnosticar' los diferentes errores - alertas
    /// </summary>
    private string? _Diagnostic_Problem_Text11;
    public string? _Diagnostic_Problem_Text1
    {
        get => _Diagnostic_Problem_Text11;
        set => SetProperty(ref _Diagnostic_Problem_Text11, value);
    }

    /// <summary>
    /// Metodo de Infobar para Diagnosticar el estado de la red
    /// </summary>
    public void AlertCountDiagnosticInternet()
    {
        string InternetStringKey = (@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters");
        string DefaultTTL = ("DefaultTTL");

        if (Registry.GetValue(InternetStringKey, DefaultTTL, null) == null)
        {
            //Si la clave No existe
            _ALERTCOUNT = ++_ALERTCOUNT;
            _Diagnostic_Problem_Text1 = "# - Lanman Settings not Founded -> ElRoomba Doesn´t Found Lanman Settings in your system,\n" +
                " Make sure u check this option in the Tweaks Section";
        }
        else
        {
            //Si la clave existe
            _ALERTCOUNT = ++_ALERTCOUNT; 
        }


    }

    /// <summary>
    /// Primary Main Ctor of this ViewModel.
    /// </summary>
    public void MainConstructorViewModel()
    {
        AlertCountDiagnosticInternet();
        if (_ALERTCOUNT > 0) { _ALERT_TEXT = "Hey, We found " + _ALERTCOUNT + " Alerts!"; }
    }
}
