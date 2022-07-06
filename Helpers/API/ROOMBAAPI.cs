using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.IO;
using System.Management;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.
namespace ELROOMBA.Helpers.API;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
[ObservableObject]
public partial class ROOMBAAPI
{


    /// <summary>
    /// El estado de la pantalla de carga
    /// </summary>
    public async Task OnStartLoadingScreenvoid()
    {
        RegistryKey rk = Registry.LocalMachine;
        RegistryKey rk1 = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore");
        string sysRestore = rk1.GetValue("RPSessionInterval").ToString();
        if (sysRestore.Contains("1"))
        {
            dynamic restPoint = Interaction.GetObject("winmgmts:\\\\.\\root\\default:Systemrestore");
            if (restPoint != null)
            {
                if (restPoint.CreateRestorePoint("ELROOMBA-RESTORE-POINT", 0, 100) == 0) { await Task.Delay(50); }
                else { await Task.Delay(50); }
            }
        }
        if (sysRestore.Contains("0"))
        {
            string osDrive = Path.GetPathRoot(Environment.SystemDirectory);
            ManagementScope scope = new ManagementScope("\\\\localhost\\root\\default");
            ManagementPath path = new ManagementPath("SystemRestore");
            ObjectGetOptions options = new ObjectGetOptions();
            ManagementClass process = new ManagementClass(scope, path, options);
            ManagementBaseObject inParams = process.GetMethodParameters("Enable");
            inParams["WaitTillEnabled"] = true;
            inParams["Drive"] = osDrive;
            ManagementBaseObject outParams = process.InvokeMethod("Enable", inParams, null);
            dynamic restPoint = Interaction.GetObject("winmgmts:\\\\.\\root\\default:Systemrestore");
            if (restPoint != null)
            {
                if (restPoint.CreateRestorePoint("ELROOMBA-RESTORE-POINT", 0, 100) == 0) { await Task.Delay(50); }
                else {  await Task.Delay(6000); }
            }
        }
    }

    /// <summary>
    /// Incio de la clase constructor de la api
    /// </summary>
    public void ROOMBAAPISTART()
    {

    }

  
  
}
