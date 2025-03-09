using ArchivosEsenciales.Services;

namespace ArchivosEsenciales.Pages;

public partial class PdfPage
{
    private static Color _buttonTextColor = null!;

    public PdfPage()
    {
        InitializeComponent();
    }

    private static void EnableLoadingInButton(Button button, ActivityIndicator indicator)
    {
        _buttonTextColor = button.TextColor;
        button.TextColor = Colors.Transparent;
        button.IsEnabled = false;
        indicator.IsVisible = true;
        indicator.IsRunning = true;
    }

    private static void DisableLoadingInButton(Button button, ActivityIndicator indicator)
    {
        indicator.IsRunning = false;
        indicator.IsVisible = false;
        button.IsEnabled = true;
        button.TextColor = _buttonTextColor;
    }

    private async void OnPdfToWordButtonClicked(object sender, EventArgs e)
    {
        try
        {
            MainThread.BeginInvokeOnMainThread(() => { EnableLoadingInButton(PdfToWord, PdfToWordIndicator); });
            if (BindingContext is not string filePath) throw new NullReferenceException();

            await Task.Run(async () => { await PdfService.ConvertToWord(filePath); });
            await DisplayAlert("Éxito", "El archivo se convirtió correctamente", "Aceptar");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "Aceptar");
        }
        finally
        {
            MainThread.BeginInvokeOnMainThread(() => { DisableLoadingInButton(PdfToWord, PdfToWordIndicator); });
        }
    }

    private async void OnPdfToPptxButtonClicked(object sender, EventArgs e)
    {
        try
        {
            MainThread.BeginInvokeOnMainThread(() => { EnableLoadingInButton(PdfToPptx, PdfToPptxIndicator); });
            if (BindingContext is not string filePath) throw new NullReferenceException();

            await Task.Run(async () => { await PdfService.ConvertToPptx(filePath); });
            await DisplayAlert("Éxito", "El archivo se convirtió correctamente", "Aceptar");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "Aceptar");
        }
        finally
        {
            MainThread.BeginInvokeOnMainThread(() => { DisableLoadingInButton(PdfToPptx, PdfToPptxIndicator); });
        }
    }
}