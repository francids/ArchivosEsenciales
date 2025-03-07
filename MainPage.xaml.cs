namespace ArchivosEsenciales;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnPdfButtonClicked(object sender, EventArgs e)
    {
        try
        {
            var pdfFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, [".pdf"] },
                    { DevicePlatform.macOS, [".pdf"] },
                }
            );
            var options = new PickOptions()
            {
                PickerTitle = "Selecciona uno o más archivos PDF",
                FileTypes = pdfFileType,
            };

            var pickedFiles = await FilePicker.Default.PickMultipleAsync(options);
            if (pickedFiles.Any())
            {
                await DisplayAlert("Título", "Mensaje", "Cancelar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "Aceptar");
        }
    }

    private async void OnImageButtonClicked(object sender, EventArgs e)
    {
        try
        {
            var imgFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, [".jpg", ".png", ".webp"] },
                    { DevicePlatform.macOS, [".jpg", ".png", ".webp"] },
                }
            );
            var options = new PickOptions()
            {
                PickerTitle = "Selecciona la imagen",
                FileTypes = imgFileType,
            };

            var pickedFile = await FilePicker.Default.PickAsync(options);
            if (pickedFile != null)
            {
                await DisplayAlert("Título", "Mensaje", "Cancelar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "Aceptar");
        }
    }
}