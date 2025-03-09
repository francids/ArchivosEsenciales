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
            EnableLoadingInButton(PdfToWord, PdfToWordIndicator);
            await Task.Delay(1000);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "Aceptar");
        }
        finally
        {
            DisableLoadingInButton(PdfToWord, PdfToWordIndicator);
        }
    }
}