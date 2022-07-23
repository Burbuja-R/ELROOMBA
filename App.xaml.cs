using CommunityToolkit.Mvvm.DependencyInjection;
using ELROOMBA.Helpers.API;
using ELROOMBA.Viewmodels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Threading.Tasks;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ELROOMBA;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {

        this.InitializeComponent();
        Ioc.Default.ConfigureServices(new ServiceCollection()
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<ROOMBAAPI>()
            .BuildServiceProvider());
        Viewmodel = Ioc.Default.GetService<ROOMBAAPI>();
    }

    public ROOMBAAPI? Viewmodel { get; set; }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {


        /// <summary>
        /// Logo de la SplashScreen
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        Image Logo = new Image();
        Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/windows.gif"));
        Logo.Width = 257;
        Logo.Height = 201;
        Logo.VerticalAlignment = VerticalAlignment.Center;
        Logo.HorizontalAlignment = HorizontalAlignment.Center;

        /// <summary>
        /// Texto de la SplashScreen
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        TextBlock LogoTxt = new TextBlock();
        LogoTxt.VerticalAlignment = VerticalAlignment.Center;
        LogoTxt.HorizontalAlignment = HorizontalAlignment.Center;
        LogoTxt.Margin = new Thickness(0, 145, 0, 0);
        LogoTxt.FontWeight = FontWeights.Bold;

        /// <summary>
        /// Barra de progreso de la aplicacion
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        ProgressBar cargando = new ProgressBar();
        cargando.Width = 100;
        cargando.Height = 100;
        cargando.IsIndeterminate = true;
        cargando.HorizontalAlignment = HorizontalAlignment.Center;
        cargando.VerticalAlignment = VerticalAlignment.Center;
        cargando.Margin = new Thickness(0, 245, 0, 0);

        /// <summary>
        /// Grid necesario para el orden de los componentes
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>

        Grid grid = new Grid();
        grid.Children.Add(Logo);
        grid.Children.Add(cargando);
        grid.Children.Add(LogoTxt);

        /// <summary>
        /// Cambiamos algunas propiedades de la ventana principal
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        /// <summary>
        /// Mostramos la ventana y preguardamos el estado incial de la 
        /// ventana en una variable,Mostramos la SplashScreen el tiempo deseado
        /// y Por supuesto despues  de que eso acabe, volvemos a cargar el contenido
        /// preguardado anteriormente en la variable.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        _window = new MainWindow();
        Mwindow = _window.Content;
        _window.Content = grid;
        _window.Activate();
        await Task.Delay(2000);
        await Viewmodel.OnStartLoadingScreenvoid();
        _window.Content = (UIElement)Mwindow;
    }

    private Window? _window;
    private object Mwindow;

}
