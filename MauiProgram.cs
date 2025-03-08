using Microsoft.Extensions.Logging;

#if WINDOWS
using Microsoft.Maui.LifecycleEvents;
#endif

namespace ArchivosEsenciales;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Archivo-Black.ttf", "ArchivoBlack");
                fonts.AddFont("Archivo-BlackItalic.ttf", "ArchivoBlackItalic");
                fonts.AddFont("Archivo-Bold.ttf", "ArchivoBold");
                fonts.AddFont("Archivo-BoldItalic.ttf", "ArchivoBoldItalic");
                fonts.AddFont("Archivo-ExtraBold.ttf", "ArchivoExtraBold");
                fonts.AddFont("Archivo-ExtraBoldItalic.ttf", "ArchivoExtraBoldItalic");
                fonts.AddFont("Archivo-ExtraLight.ttf", "ArchivoExtraLight");
                fonts.AddFont("Archivo-ExtraLightItalic.ttf", "ArchivoExtraLightItalic");
                fonts.AddFont("Archivo-Italic.ttf", "ArchivoItalic");
                fonts.AddFont("Archivo-Light.ttf", "ArchivoLight");
                fonts.AddFont("Archivo-LightItalic.ttf", "ArchivoLightItalic");
                fonts.AddFont("Archivo-Medium.ttf", "ArchivoMedium");
                fonts.AddFont("Archivo-MediumItalic.ttf", "ArchivoMediumItalic");
                fonts.AddFont("Archivo-Regular.ttf", "ArchivoRegular");
                fonts.AddFont("Archivo-SemiBold.ttf", "ArchivoSemiBold");
                fonts.AddFont("Archivo-SemiBoldItalic.ttf", "ArchivoSemiBoldItalic");
                fonts.AddFont("Archivo-Thin.ttf", "ArchivoThin");
                fonts.AddFont("Archivo-ThinItalic.ttf", "ArchivoThinItalic");
            });

#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(windowsLifecycleBuilder =>
            {
                windowsLifecycleBuilder.OnWindowCreated(window =>
                {
                    window.Activate();
                    window.ExtendsContentIntoTitleBar = false;

                    var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                    var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
                    if (appWindow is null) return;

                    var displayArea =
                        Microsoft.UI.Windowing.DisplayArea.GetFromWindowId(
                            id,
                            Microsoft.UI.Windowing.DisplayAreaFallback.Nearest
                        );
                    if (displayArea is null) return;

                    var centeredPosition = appWindow.Position;
                    centeredPosition.X = (displayArea.WorkArea.Width - appWindow.Size.Width) / 2;
                    centeredPosition.Y = (displayArea.WorkArea.Height - appWindow.Size.Height) / 2;
                    appWindow.Move(centeredPosition);
                });
            });
        });
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}