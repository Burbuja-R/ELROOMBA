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
    /// Variable usada para recibir el estado del inicio de sesion
    /// </summary>
    public bool _LOGINSTATE = true;

    /// <summary>
    /// Variable Alert Count.
    /// </summary>
    public int _ALERTCOUNT;

    /// <summary>
    /// variable bool para la barra el indicador de carga de ElRoomba.
    /// </summary>
    public bool _PROGRESS_INDICATOR_ = false;

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
    /// String que cambiara el texto segun el numero de errores
    /// </summary>
    private string? _STATE_TEXT;
    public string? _STATE_TEXT_CHANGE
    {
        get => _STATE_TEXT;
        set => SetProperty(ref _STATE_TEXT, value);
    }

    /// <summary>
    /// Unos String que se usara para introducir el texto de
    /// un textBlock, para 'Diagnosticar' los diferentes errores - alertas
    /// </summary>
    private string? _Diagnostic_Problem_Text11;
    public string? _Diagnostic_Problem_Text1
    {
        get => _Diagnostic_Problem_Text11;
        set => SetProperty(ref _Diagnostic_Problem_Text11, value);
    }

    private string? _Diagnostic_Problem_Text2;
    public string? _Diagnostic_Problem_Text22
    {
        get => _Diagnostic_Problem_Text2;
        set => SetProperty(ref _Diagnostic_Problem_Text2, value);
    }

    private string? _Diagnostic_Problem_Text3;
    public string? _Diagnostic_Problem_Text33
    {
        get => _Diagnostic_Problem_Text3;
        set => SetProperty(ref _Diagnostic_Problem_Text3, value);
    }

    private string? _Diagnostic_Problem_Text4;
    public string? _Diagnostic_Problem_Text44
    {
        get => _Diagnostic_Problem_Text4;
        set => SetProperty(ref _Diagnostic_Problem_Text4, value);
    }

    private string? _Diagnostic_Problem_Text5;
    public string? _Diagnostic_Problem_Text55
    {
        get => _Diagnostic_Problem_Text5;
        set => SetProperty(ref _Diagnostic_Problem_Text5, value);
    }


    /// <summary>
    /// Metodo de Infobar para Diagnosticar el estado Del equipo
    /// </summary>
    public void SystemDiagnostic()
    {

        /// <summary>
        /// RUTAS STRING
        /// </summary>
        string _INTERNET_STRING_KEY = (@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters");
        string _IRPSTACK_key = (@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters");
        string _EFFICIENT_ENERGY_KEY = (@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power");
        string _QOS_DISABLE_KEY = (@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\Tcpip\QoS");
        string _GAME_DVR_ENABLED_VALUE = (@"HKEY_CURRENT_USER\System\GameConfigStore");

        /// <summary>
        /// VALUES STRING
        /// </summary>
        string _POWERTHROTTLEING_VALUE = ("PowerThrottlingOff");
        string _IRPSTACK_VALUE = ("IRPStackSize");
        string _DEFAULT_TTL_VALUE = ("DefaultTTL");
        string _DO_NOT_USE_LA_VALUE = ("Do not use NLA");
        string _GAME_DVR_ENABLED_KEY = ("GameDVR_Enabled");


        if (Registry.GetValue(_INTERNET_STRING_KEY, _DEFAULT_TTL_VALUE, null) == null)
        {
            _ALERTCOUNT = ++_ALERTCOUNT;
            _Diagnostic_Problem_Text1 = "# - Lanman Settings not Founded -> ElRoomba Doesn´t Found Lanman Settings in your system,\n" +
                " Make sure u check this option in the Tweaks Section";
        }

        if (Registry.GetValue(_IRPSTACK_key, _IRPSTACK_VALUE, null) == null)
        {
            _ALERTCOUNT = ++_ALERTCOUNT;
            _Diagnostic_Problem_Text3 = "# - IRPStackSize Set To Automatic -> ElRoomba Found The IRPStackSize on Automatic,\n" +
                " This may Not allow you to get all your Internet Speed";
        }

        if (Registry.GetValue(_EFFICIENT_ENERGY_KEY, _POWERTHROTTLEING_VALUE, null) == null)
        {
            _ALERTCOUNT = ++_ALERTCOUNT;
            _Diagnostic_Problem_Text22 = "# - PowerThrottling -> ElRoomba Found EfficientEnergy enable,\n" +
                " This will cause Fps Drops";
        }

        if (Registry.GetValue(_QOS_DISABLE_KEY, _DO_NOT_USE_LA_VALUE, null) == null) { }
        else
        {
            _ALERTCOUNT = ++_ALERTCOUNT;
            _Diagnostic_Problem_Text44 = "# - Your Qos packets are Enable -> ElRoomba Found That your QOS packets are,\n" +
                " Enable, This will put a Automatic Max Band width to your internet, If you want to use \n" +
                "your full conection Disable this option can help";
        }

        if (Registry.GetValue(_GAME_DVR_ENABLED_VALUE, _GAME_DVR_ENABLED_KEY, null) == null) { }
        else
        {
            _ALERTCOUNT = ++_ALERTCOUNT;
            _Diagnostic_Problem_Text55 = "# - WindowsGameBar Enabled -> ElRoomba Find That your GameBar Is enabled,\n" +
                " Make sure you Disable this option, This may cause a High Cpu % ussage";
        }

    }

    /// <summary>
    /// Primary Main Ctor of this ViewModel.
    /// </summary>
    public void MainConstructorViewModel()
    {
        SystemDiagnostic();
        if (_ALERTCOUNT > 0) { _ALERT_TEXT = "Hey, We found " + _ALERTCOUNT + " Alerts!"; }
        if (_ALERTCOUNT == 0) { _STATE_TEXT_CHANGE = "There`s no Problems Found."; } else { _STATE_TEXT_CHANGE = "Hey, We found " + _ALERTCOUNT + " Alerts!, Please take a look!"; }
    }
  
}
