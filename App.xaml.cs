namespace ArchivosEsenciales;

public partial class App
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Window appWindow = new AppWindow
        {
            TitleBar = new TitleBar
            {
                Title = "Archivos Esenciales",
            }
        };
        appWindow.Width = appWindow.MinimumWidth = 500;
        appWindow.Height = appWindow.MinimumHeight = 300;
        return appWindow;
    }
}