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
public partial class ROOMBAAPI : ObservableObject
{


    /// <summary>
    /// El estado de la pantalla de carga
    /// </summary>
    public async Task OnStartLoadingScreenvoid()
    {
        await Task.Delay(50);
        RegistryKey rk = Registry.LocalMachine;
        RegistryKey rk1 = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore");
        string sysRestore = rk1.GetValue("RPSessionInterval").ToString();
        if (sysRestore.Contains("1"))
        {
            await Task.Delay(50);
            dynamic restPoint = Interaction.GetObject("winmgmts:\\\\.\\root\\default:Systemrestore");
            if (restPoint != null)
            {
                if (restPoint.CreateRestorePoint("ELRoomba", 0, 100) == 0) { await Task.Delay(50); }
                else { await Task.Delay(50); }
            }
        }
        if (sysRestore.Contains("0"))
        {
            await Task.Delay(50);
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
                if (restPoint.CreateRestorePoint("ELRoomba", 0, 100) == 0) { await Task.Delay(50); }
                else {  await Task.Delay(50); }
            }
        }
    }

    #region --> Call Methods API
    public static void MouseDataQueueSizeWithKbdDataQueueSize()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\mouclass\Parameters", "MouseDataQueueSize", "00000025", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\kbdclass\Parameters", "KeyboardDataQueueSize", "00000025", RegistryValueKind.DWord);

        }
        catch (Exception)
        {

        }
    }

    public static void Win32PrioritySeparation()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Control\PriorityControl", "Win32PrioritySeparation", "00000026", RegistryValueKind.DWord);
        }
        catch (Exception)
        {
        }
    }

    public static void SvcHostSplitThreshold()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control", "SvcHostSplitThresholdInKB ", "16777216", RegistryValueKind.DWord);
        }
        catch (Exception)
        {
        }
    }

    public static void AmdGpuControlSettings()
    {
        try
        {
            RegistryKey rk = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Class{4d36e968-e325-11ce-bfc1-08002be10318}\0000", writable: true);
            rk.SetValue("EnableVceSwClockGating", "00000001", RegistryValueKind.DWord);
            rk.SetValue("EnableUvdClockGating", "00000001", RegistryValueKind.DWord);
            rk.SetValue("DisableVCEPowerGating", "00000000", RegistryValueKind.DWord);
            rk.SetValue("DisableUVDPowerGatingDynamic", "00000000", RegistryValueKind.DWord);
            rk.SetValue("DisablePowerGating", "00000001", RegistryValueKind.DWord);
            rk.SetValue("DisableFBCForFullScreenApp", "00000000", RegistryValueKind.DWord);
            rk.SetValue("DisableFBCSupport", "00000000", RegistryValueKind.DWord);
            rk.SetValue("PP_GPUPowerDownEnabled", "00000000", RegistryValueKind.DWord);
            rk.SetValue("DisableDrmdmaPowerGating", "00000001", RegistryValueKind.DWord);
            rk.SetValue("PP_SclkDeepSleepDisable", "00000001", RegistryValueKind.DWord);
            rk.SetValue("PP_ThermalAutoThrottlingEnable", "00000001", RegistryValueKind.DWord);
            rk.SetValue("PP_ODNFeatureEnable", "00000001", RegistryValueKind.DWord);
            rk.SetValue("EnableUlps", "00000000", RegistryValueKind.DWord);
            rk.SetValue("GCOOPTION_DisableGPIOPowerSaveMode", "00000001", RegistryValueKind.DWord);
            rk.SetValue("PP_AllGraphicLevel_DownHyst", "00000014", RegistryValueKind.DWord);
            rk.SetValue("PP_AllGraphicLevel_UpHyst", "00000000", RegistryValueKind.DWord);
            rk.SetValue("KMD_FRTEnabled", "00000000", RegistryValueKind.DWord);
            rk.SetValue("DisableBlockWrite", "00000001", RegistryValueKind.DWord);
            rk.SetValue("PP_ODNFeatureEnable", "00000000", RegistryValueKind.DWord);
            rk.SetValue("KMD_MaxUVDSessions", "00000020", RegistryValueKind.DWord);
            rk.SetValue("DalAllowDirectMemoryAccessTrig", "00000001", RegistryValueKind.DWord);
            rk.SetValue("PP_MCLKStutterModeThreshold", "000001000", RegistryValueKind.DWord);
            rk.SetValue("StutterMode", "00000000", RegistryValueKind.DWord);
            RegistryKey rkk = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Class{4d36e968-e325-11ce-bfc1-08002be10318}\0000\UMD", writable: true);
            rkk.SetValue("AreaAniso_DEF", "00000008", RegistryValueKind.DWord);
            rkk.SetValue("00000000", "00000001", RegistryValueKind.DWord);
            rkk.SetValue("Main3D_DEF", "00000001", RegistryValueKind.DWord);
            rkk.SetValue("AnisoType_DEF", "00000000", RegistryValueKind.DWord);
            rkk.SetValue("AnisoDegree_DEF", "00000004", RegistryValueKind.DWord);
            rkk.SetValue("ForceTripleBuffering_DEF", "00000000", RegistryValueKind.DWord);
            rkk.SetValue("TextureOpt_DEF", "00000001", RegistryValueKind.DWord);
            rkk.SetValue("TextureLod_DEF", "00000001", RegistryValueKind.DWord);
            rkk.SetValue("TruformMode_DEF", "00000002", RegistryValueKind.DWord);
            rkk.SetValue("LodAdj", "00000000", RegistryValueKind.DWord);
            rkk.SetValue("ForceZBufferDepth_DEF", "00000001", RegistryValueKind.DWord);
            rkk.SetValue("essellation_OPTION_DEF", "00000000", RegistryValueKind.DWord);
            rkk.SetValue("NoOSPowerOptions", "00000001", RegistryValueKind.DWord);
            rkk.SetValue("ForceZBufferDepth_DEF", "00000001", RegistryValueKind.DWord);
            rkk.SetValue("Tessellation_DEF", "00000000", RegistryValueKind.DWord);
            RegistryKey rkvk = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\amdkmdag\UMD", writable: true);
            rkvk.SetValue("FlipQueueSize", "00000001", RegistryValueKind.DWord);
            rkvk.SetValue("Main3D_DEF", "00000001", RegistryValueKind.DWord);

        }
        catch (Exception)
        {
        }
    }

    public static void DisplayRealRefreshRate()
    {
        try
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\DXGKrnl", "MonitorLatencyTolerance", "00000000", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\DXGKrnl", "MonitorRefreshLatencyTolerance", "00000000", RegistryValueKind.Unknown);
        }
        catch (Exception)
        {
        }
    }

    public static void DmaRemappingDisable()
    {
        try
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\intelppm\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\intelppm\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\pci\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\kbdclass\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\kbdhid\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\NdisWan\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\EhStorClass\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\HDAudBus\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\partmgr\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\ACPI\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\acpipagr\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\BasicDisplay\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\BasicRender\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\dc1-controller\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\intelpep\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\MEIx64\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\msisadrv\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\NdisVirtualBus\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\NvModuleTracker\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\storahci\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\umbus\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\USBHUB3\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\USBXHCI\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\vdrvroot\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\vwifibus\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\WpdUpFltr\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\xinputhid\\Parameters", "DmaRemappingCompatible", "00000000", RegistryValueKind.DWord);
        }
        catch (Exception)
        {
        }
    }
    public static void NoLazyMode()
    {
        try
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "NoLazyMode", "00000001", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "AlwaysOn", "00000001", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Power", "HighPerformance", "00000001", RegistryValueKind.QWord);
        }
        catch (Exception)
        {
        }
    }
    public static void DisableTaggedEnergyLogging()
    {
        try
        {
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power\\EnergyEstimation\\TaggedEnergy", writable: true);
            registryKey.SetValue("DisableTaggedEnergyLogging", "00000001", RegistryValueKind.DWord);
            registryKey.SetValue("TelemetryMaxApplication", "0", RegistryValueKind.DWord);
            registryKey.SetValue("TelemetryMaxTagPerApplication", "0", RegistryValueKind.DWord);
        }
        catch (Exception)
        {
        }
    }
    public static void TCPParameters()
    {
        try
        {
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", writable: true);
            registryKey.SetValue("DefaultTTL", "00000040", RegistryValueKind.DWord);
            registryKey.SetValue("DisableTaskOffload", "00000001", RegistryValueKind.DWord);
            registryKey.SetValue("EnableConnectionRateLimiting", "00000000", RegistryValueKind.DWord);
            registryKey.SetValue("EnableDCA", "00000001", RegistryValueKind.DWord);
            registryKey.SetValue("EnablePMTUBHDetect", "0", RegistryValueKind.DWord);
            registryKey.SetValue("EnableRSS", "00000001", RegistryValueKind.DWord);
            registryKey.SetValue("TcpTimedWaitDelay", "0000001e", RegistryValueKind.Unknown);
            registryKey.SetValue("EnableWsd", "0", RegistryValueKind.DWord);
            registryKey.SetValue("GlobalMaxTcpWindowSize", "0000ffff", RegistryValueKind.Unknown);
            registryKey.SetValue("MaxConnectionsPer1_0Server", "000000a", RegistryValueKind.Unknown);
            registryKey.SetValue("MaxConnectionsPerServer", "000000a", RegistryValueKind.Unknown);
            registryKey.SetValue("MaxFreeTcbs", "00010000", RegistryValueKind.DWord);
            registryKey.SetValue("EnableTCPA", "0", RegistryValueKind.DWord);
            registryKey.SetValue("Tcp1323Opts", "00000001", RegistryValueKind.DWord);
            registryKey.SetValue("TcpCreateAndConnectTcbRateLimitDepth", "00000000", RegistryValueKind.DWord);
            registryKey.SetValue("TcpMaxDataRetransmissions", "00000003", RegistryValueKind.DWord);
            registryKey.SetValue("TcpMaxDupAcks", "00000002", RegistryValueKind.DWord);
            registryKey.SetValue("TcpMaxSendFree", "0000ffff", RegistryValueKind.Unknown);
            registryKey.SetValue("TcpNumConnections", "00fffffe", RegistryValueKind.Unknown);
            registryKey.SetValue("MaxHashTableSize", "00010000", RegistryValueKind.DWord);
            registryKey.SetValue("MaxUserPort", "0000fffe", RegistryValueKind.Unknown);
            registryKey.SetValue("SackOpts", "00000001", RegistryValueKind.DWord);
            registryKey.SetValue("SynAttackProtect", "00000001", RegistryValueKind.DWord);

        }
        catch (Exception)
        {
        }
    }
    public static void LanmanParameters()
    {
        try
        {
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\services\\LanmanServer\\Parameters", writable: true);
            registryKey.SetValue("autodisconnect", "ffffffff", RegistryValueKind.Unknown);
            registryKey.SetValue("Size", "00000003", RegistryValueKind.DWord);
            registryKey.SetValue("EnableOplocks", "00000000", RegistryValueKind.DWord);
            registryKey.SetValue("IRPStackSize", "00000020", RegistryValueKind.DWord);
            registryKey.SetValue("SharingViolationDelay", "00000000", RegistryValueKind.DWord);
            registryKey.SetValue("SharingViolationRetries", "00000000", RegistryValueKind.DWord);
            RegistryKey registryKey2 = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", writable: true);
            registryKey2.SetValue("DelayedAckFrequency", "1", RegistryValueKind.DWord);
            registryKey2.SetValue("DelayedAckTicks", "1", RegistryValueKind.DWord);
            registryKey2.SetValue("CongestionAlgorithm", "1", RegistryValueKind.DWord);
            registryKey2.SetValue("FastCopyReceiveThreshold", "00004000", RegistryValueKind.DWord);
            registryKey2.SetValue("FastSendDatagramThreshold", "0000000040000000", RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\services\\Tcpip\\QoS", "Do not use NLA", "1", RegistryValueKind.DWord);


        }
        catch (Exception)
        {
        }
    }

    public static void DNSConfig()
    {
        try
        {
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\ServiceProvider", writable: true);
            registryKey.SetValue("LocalPriority", "00000004", RegistryValueKind.DWord);
            registryKey.SetValue("HostsPriority", "00000005", RegistryValueKind.DWord);
            registryKey.SetValue("DnsPriority", "00000006", RegistryValueKind.DWord);
            registryKey.SetValue("NetbtPriority", "00000007", RegistryValueKind.DWord);

        }
        catch (Exception)
        {
        }
    }


    public static void InternetGeneralSettings()
    {
        try
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "DefaultTTL", "40", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "DisableTaskOffload", "1", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "EnableConnectionRateLimiting", "0", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "EnableDCA", "1", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "EnablePMTUBHDetect", "0", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "EnablePMTUDiscovery", "1", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "EnableRSS", "1", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "TcpTimedWaitDelay", "#0000001e", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "EnableWsd", "0", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "GlobalMaxTcpWindowSize", "0000ffff", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "MaxConnectionsPer1_0Server", "#000000a", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "MaxConnectionsPerServer", "000000a", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "MaxFreeTcbs", "00010000", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "EnableTCPA", "0", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "Tcp1323Opts", "1", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "TcpCreateAndConnectTcbRateLimitDepth", "0", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "TcpMaxDataRetransmissions", "3", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "TcpMaxDupAcks", "2", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "TcpMaxSendFree", "0000ffff", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "TcpNumConnections", "00fffffe", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "MaxHashTableSize", "00010000", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "MaxUserPort", "0000fffe", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "SynAttackProtect", "00000001", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "SackOpts", "00000001", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSMQ\\Parameters", "TCPNoDelay", "00000001", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\ServiceProvider", "LocalPriority", "00000004", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\ServiceProvider", "HostsPriority", "00000005", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\ServiceProvider", "DnsPriority", "00000006", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\ServiceProvider", "NetbtPriority", "00000007", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "NetworkThrottlingIndex", "ffffffff", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "SystemResponsiveness", "00000000", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\Psched", "NonBestEffortLimit", "00000000", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Psched", "NonBestEffortLimit", "00000000", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanWorkstation\\Parameters", "MaxCmds", "0000001e", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanWorkstation\\Parameters", "MaxThreads", "0000001e", RegistryValueKind.Unknown);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanWorkstation\\Parameters", "MaxCollectionCount", "00000020", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters", "IRPStackSize", "00000032", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters", "SizReqBuf", "00004410", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters", "Size", "00000003", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters", "MaxWorkItems", "00002000", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters", "MaxMpxCt", "00000800", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters", "MaxCmds", "00000800", RegistryValueKind.QWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters", "DisableStrictNameChecking", "00000001", RegistryValueKind.QWord);
        }
        catch (Exception)
        {
        }

    }


    public static void BufferBloatWindows()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Psched", "ExcludeWUDriversInQualityUpdate", "00000001", RegistryValueKind.DWord);

        }
        catch (Exception)
        {
        }
    }


    public static void ExcludeDriversInQualityUpdate()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Device Metadata", "PreventDeviceMetadataFromNetwork", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PolicyManager\current\device\Update", "ExcludeWUDriversInQualityUpdate", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PolicyManager\default\Update", "ExcludeWUDriversInQualityUpdate", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PolicyManager\default\Update\ExcludeWUDriversInQualityUpdate", "value", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "ExcludeWUDriversInQualityUpdate", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate", "ExcludeWUDriversInQualityUpdate", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DriverSearching", "SearchOrderConfig", "00000000", RegistryValueKind.DWord);
        }
        catch (Exception)
        {
        }
    }

    public static void RespectPowerModes()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Search\Gather\Windows\SystemIndex", "RespectPowerModes", "00000001", RegistryValueKind.DWord);

        }
        catch (Exception ex)
        {
        }
    }

    public static void DisableSpectreAndMeltdown()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "FeatureSettingsOverride", "00000003", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "FeatureSettingsOverrideMask", "00000003", RegistryValueKind.DWord);

        }
        catch (Exception)
        {
        }
    }

    public static void FullScreenOptimization()
    {
        try
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_Enabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehaviorMode", "00000002", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_HonorUserFSEBehaviorMode", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_DXGIHonorFSEWindowsCompatible", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "PreventDeviceMetadataFromNetwork", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_EFSEFeatureFlags", "00000000", RegistryValueKind.DWord);
        }
        catch (Exception)
        {
        }
    }

    public static void IRPStackSize()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters", "IRPStackSize", "00000032", RegistryValueKind.DWord);

        }
        catch (Exception)
        {
        }
    }


    public static void MMCS()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "NetworkThrottlingIndex", "0000000a", RegistryValueKind.Unknown);

        }
        catch (Exception)
        {
        }


    }

    public static void PowerThrottlingOff()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling", "PowerThrottlingOff", "00000001", RegistryValueKind.DWord);

        }
        catch (Exception)
        {
        }
    }


    public static void ConfigurationWindows()
    {
        try
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance", "MaintenanceDisabled", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes", "ThemeChangesDesktopIcons", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes", "ThemeChangesMousePointers", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowSyncProviderNotifications", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SoftLandingEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "RotatingLockScreenEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "RotatingLockScreenOverlayEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-310093Enabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-314563Enabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338387Enabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338388Enabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338389Enabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338389Enabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338393Enabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-353698Enabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DisallowShaking", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer", "NoUseStoreOpenWith", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Attachments", "SaveZoneInformation", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate", "ExcludeWUDriversInQualityUpdate", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\MRT", "DontOfferThroughWUAU", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "EnableActivityFeed", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", "AUOptions", "00000002", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\Windows Error Reporting", "Disabled", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer", "NoNewAppAlert", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\CrashControl", "DisplayParameters", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer", "DisableNotificationCenter", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications", "NoTileApplicationNotification", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\Explorer", "HidePeopleBar", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Shell\ActionCenter\Quick Actions", "PinnedQuickActionSlotCount", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "BingSearchEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "AllowSearchToUseLocation", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "CortanaConsent", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "HoverSelectDesktops", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\People", "TaskbarCapacity", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "JPEGImportQuality", "00000100", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_TrackDocs", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\Explorer", "DisableSearchBoxSuggestions", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CLASSES_ROOT\CLSID\{018D5C66-4533-4307-9B53-224DE2ED1FE6}", "System.IsPinnedToNameSpaceTree", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters", "AutoShareWks", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\WindowsStore", "AutoDownload", "00000002", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_USERS\.DEFAULT\Control Panel\Mouse", "MouseHoverTime", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_USERS\.DEFAULT\Control Panel\Mouse", "MouseSpeed", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_USERS\.DEFAULT\Control Panel\Mouse", "MouseThreshold1", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_USERS\.DEFAULT\Control Panel\Mouse", "MouseThreshold2", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Siuf\Rules", "NumberOfSIUFInPeriod", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\MouseKeys", "Flags", "00000186", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\MouseKeys", "MaximumSpeed", "00000040", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\MouseKeys", "TimeToMaximumSpeed", "00003000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationAfterglow", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "EnableTransparency", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "EnableSmartScreen", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "EnableActivityFeed", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "PublishUserActivities", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "UploadUserActivities", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "DisableLogonBackgroundImage", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "DisableAcrylicBackgroundOnLogon", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "UseDefaultTile", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarBadges", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoStartMenuMorePrograms", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoStartMenuMorePrograms", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer", "HideRecentlyAddedApps", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "HideRecentlyAddedApps", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer", "DisableNotificationCenter", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Windows", "LegacyDefaultPrinterMode", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MouseWheelRouting", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\TabletTip\1.7", "EnableTextPrediction", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\TabletTip\1.7", "EnablePredictionSpaceInsertion", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\TabletTip\1.7", "EnableDoubleTapSpace", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Shell\USB", "NotifyOnUsbErrors", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "VirtualDesktopTaskbarFilter", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "VirtualDesktopAltTabFilter", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Keyboard Layout\Toggle", "Language Hotkey", "00000003", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Keyboard Layout\Toggle", "Hotkey", "00000003", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Keyboard Layout\Toggle", "Layout Hotkey", "00000003", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\CTF\LangBar", "ShowStatus", "00000003", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\CTF\LangBar", "ExtraIconsOnMinimized", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\CTF\LangBar", "Label", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings", "ShowSleepOption", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings", "ShowLockOption", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Multimedia\Audio", "UserDuckingPreference", "00000003", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseSpeed", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseThreshold1", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseThreshold2", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GraphicsDrivers", "HwSchMode", "00000002", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Notifications\Settings", "NOC_GLOBAL_SETTING_ALLOW_NOTIFICATION_SOUND", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Bluetooth", "QuickPair", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Notifications\Settings", "NOC_GLOBAL_SETTING_ALLOW_CRITICAL_TOASTS_ABOVE_LOCK", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors", "ContactVisualization", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors", "GestureVisualization", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy", "04", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy", "01", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy", "2048", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy", "08", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy", "256", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy", "32", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Input\Settings", "EnableExpressiveInputEmojiMultipleSelection", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableRealtimeMonitoring", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet", "SubmitSamplesConsent", "00000002", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet", "SpynetReporting", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter", "EnabledV9", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Systray", "HideSystray", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\OneDrive\Accounts\Personal", "ShareNotificationDisabled", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\OneDrive\Accounts\Personal", "MassDeleteNotificationDisabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\WindowsMitigation", "UserPreference", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Speech_OneCore\Settings\VoiceActivation\UserPreferenceForAllApps", "AgentActivationEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Speech_OneCore\Settings\VoiceActivation\UserPreferenceForAllApps", "AgentActivationLastUsed", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings", "SafeSearchMode", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCloudSearch", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "DeviceHistoryEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors", "ContactVisualization", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\ScreenMagnifier", "RunningState", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\ScreenMagnifier", "FollowMouse", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\ScreenMagnifier", "FollowFocus", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\ScreenMagnifier", "FollowCaret", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\ScreenMagnifier", "FollowNarrator", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator\NoRoam", "WinEnterLaunchEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator\NarratorHome", "AutoStart", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator\NarratorHome", "MinimizeType", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\StickyKeys", "Flags", "00000506", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\ToggleKeys", "Flags", "00000034", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\Keyboard Response", "Flags", "00000002", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\StickyKeys", "Flags", "00000002", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility", "Sound on Activation", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility", "Warning Sounds", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator\NoRoam", "DuckAudio", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator", "IntonationPause", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator", "ReadHints", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator", "ErrorNotificationType", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator", "PlayAudioCues", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator", "EchoChars", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator", "EchoWords", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator\NoRoam", "EchoToggleKeys", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator\NoRoam", "EchoModifierKeys", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator", "NarratorCursorHighlight", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Narrator", "CoupleNarratorCursorKeyboard", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Narrator\NoRoam", "ScriptingEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Narrator\NoRoam", "OnlineServicesEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "UseNexusForGameBarEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\Maps", "AutoUpdateEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\PushNotifications", "DatabaseMigrationCompleted", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\PushNotifications", "ToastEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\PushNotifications", "LockScreenToastEnabled", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ImmersiveShell", "TabletMode", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ImmersiveShell", "SignInMode", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ImmersiveShell", "ConvertibleSlateModePromptPreference", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAppsVisibleInTabletMode", "00000001", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAutoHideInTabletMode", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CDP", "CdpSessionUserAuthzPolicy", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CDP", "NearShareChannelUserAuthzPolicy", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CDP", "RomeSdkChannelUserAuthzPolicy", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\HighContrast", "Flags", "00004218", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\MouseKeys", "Flags", "00000130", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\MouseKeys", "MaximumSpeed", "00000039", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\MouseKeys", "TimeToMaximumSpeed", "00003000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\SoundSentry", "Flags", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\SoundSentry", "FSTextEffect", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\SoundSentry", "TextEffect", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\SoundSentry", "WindowsEffect", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\SlateLaunch", "LaunchAT", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Remote Assistance", "fAllowFullControl", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Remote Assistance", "fAllowToGetHelp", "00000000", RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings", "IsDeviceSearchHistoryEnabled", "00000000", RegistryValueKind.DWord);
        }
        catch (Exception)
        {
        }
    }

    #endregion

    /// <summary>
    /// Incio de la clase constructor de la api
    /// </summary>
    public void ROOMBAAPISTART()
    {

    }
  
}
