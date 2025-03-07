using Microsoft.Extensions.Logging;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}