using CommunityToolkit.Mvvm.DependencyInjection;
using ELROOMBA.Pages.Components;
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
            .AddSingleton<NavbarFrameViewModel>()
            .AddSingleton<MainWindowViewModel>()
            .BuildServiceProvider());
    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        try
        {
            /// <summary>
            /// Logo de la SplashScreen
            /// </summary>
            /// <param name="args">Details about the launch request and process.</param>
            Image Logo = new Image();
            Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/ElRoomba.png"));
            Logo.Width = 100;
            Logo.Height = 100;
            Logo.VerticalAlignment = VerticalAlignment.Center;
            Logo.HorizontalAlignment = HorizontalAlignment.Center;

            /// <summary>
            /// Texto de la SplashScreen
            /// </summary>
            /// <param name="args">Details about the launch request and process.</param>
            TextBlock LogoTxt = new TextBlock();
            LogoTxt.Text = "ElRoomba";
            LogoTxt.VerticalAlignment = VerticalAlignment.Center;
            LogoTxt.HorizontalAlignment = HorizontalAlignment.Center;
            LogoTxt.Margin = new Thickness(0, 145, 0, 0);
            LogoTxt.FontWeight = FontWeights.Bold;

            /// <summary>
            /// Barra de progreso de la aplicacion
            /// </summary>
            /// <param name="args">Details about the launch request and process.</param>
            ProgressBar cargando = new ProgressBar();
            cargando.Width = 75;
            cargando.Height = 75;
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
            _window.Content = (UIElement)Mwindow;
        }
        catch (Exception)
        {
            /// <summary>
            /// Logo de la SplashScreen
            /// </summary>
            /// <param name="args">Details about the launch request and process.</param>
            Image LogoE = new Image();
            LogoE.Source = new BitmapImage(new Uri("ms-appx:///Assets/ElRoomba.png"));
            LogoE.Width = 100;
            LogoE.Height = 100;
            LogoE.VerticalAlignment = VerticalAlignment.Center;
            LogoE.HorizontalAlignment = HorizontalAlignment.Center;

            /// <summary>
            /// Texto de la SplashScreen
            /// </summary>
            /// <param name="args">Details about the launch request and process.</param>
            TextBlock LogoTxtE = new TextBlock();
            LogoTxtE.Text = "ElRoomba";
            LogoTxtE.VerticalAlignment = VerticalAlignment.Center;
            LogoTxtE.HorizontalAlignment = HorizontalAlignment.Center;
            LogoTxtE.Margin = new Thickness(0, 145, 0, 0);
            LogoTxtE.FontWeight = FontWeights.Bold;

            /// <summary>
            /// Barra de progreso de  error de la aplicacion
            /// </summary>
            /// <param name="args">Details about the launch request and process.</param>
            ProgressBar cargandoE = new ProgressBar();
            cargandoE.Width = 755;
            cargandoE.Height = 755;
            cargandoE.IsIndeterminate = true;
            cargandoE.ShowError = true;
            cargandoE.HorizontalAlignment = HorizontalAlignment.Center;
            cargandoE.VerticalAlignment = VerticalAlignment.Center;
            cargandoE.Margin = new Thickness(0, 245, 0, 0);

            /// <summary>
            /// Grid necesario para el orden de los componentes
            /// </summary>
            /// <param name="args">Details about the launch request and process.</param>
            Grid gridE = new Grid();
            gridE.Children.Add(cargandoE);
            gridE.Children.Add(LogoTxtE);
            gridE.Children.Add(LogoE);


            /// <summary>
            /// Mostramos la ventana y preguardamos el estado incial de la 
            /// ventana en una variable,Mostramos la SplashScreen el tiempo deseado
            /// y Por supuesto despues  de que eso acabe, volvemos a cargar el contenido
            /// preguardado anteriormente en la variable.
            /// </summary>
            /// <param name="args">Details about the launch request and process.</param>
            _window = new MainWindow();
            _window.Content = gridE;
            _window.Activate();
        }
    }

    private Window? _window;
    private object Mwindow;

}
