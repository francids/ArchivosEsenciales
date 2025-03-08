using ArchivosEsenciales.Pages;

namespace ArchivosEsenciales;

public partial class AppWindow
{
    public AppWindow()
    {
        InitializeComponent();
        Page = new MainPage();
    }
}