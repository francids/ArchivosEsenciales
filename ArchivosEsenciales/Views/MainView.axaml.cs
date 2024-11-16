using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;

namespace ArchivosEsenciales.Views;

public partial class MainView : UserControl
{
	public MainView()
	{
		AvaloniaXamlLoader.Load(this);
	}

	private async void OpenPdfDialog(object sender, RoutedEventArgs e)
	{
		var topLevel = TopLevel.GetTopLevel(this);

		var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Selecciona un archivo PDF",
			AllowMultiple = true,
			FileTypeFilter = new[] { FilePickerFileTypes.Pdf }
		});

		if (files.Count > 0)
		{
			// Open PdfTools window
			var pdfToolsWindow = new PdfTools(files);
			pdfToolsWindow.Show();
		}
	}

	private async void OpenImageDialog(object sender, RoutedEventArgs e)
	{
		var topLevel = TopLevel.GetTopLevel(this);

		var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Selecciona una imagen",
			AllowMultiple = false,
			FileTypeFilter = new[] { FilePickerFileTypes.ImageAll }
		});
	}
}
