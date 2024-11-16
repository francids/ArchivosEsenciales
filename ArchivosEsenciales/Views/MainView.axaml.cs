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

		var filePickerOptions = new FilePickerOpenOptions
		{
			Title = "Selecciona un archivo PDF",
			AllowMultiple = true,
			FileTypeFilter = [FilePickerFileTypes.Pdf],
		};

		var pickedFiles = await topLevel!.StorageProvider.OpenFilePickerAsync(filePickerOptions);

		if (pickedFiles.Count > 0)
		{
			var pdfToolsWindow = new PdfTools(pickedFiles);
			((Window)VisualRoot!).Hide();
			pdfToolsWindow.Closed += (sender, e) => ((Window)VisualRoot!).Show();
			pdfToolsWindow.Show();
		}
	}

	private async void OpenImageDialog(object sender, RoutedEventArgs e)
	{
		var topLevel = TopLevel.GetTopLevel(this);

		var filePickerOptions = new FilePickerOpenOptions
		{
			Title = "Selecciona una imagen",
			AllowMultiple = false,
			FileTypeFilter = [FilePickerFileTypes.ImageAll],
		};

		var pickedFiles = await topLevel!.StorageProvider.OpenFilePickerAsync(filePickerOptions);

		if (pickedFiles.Count > 0)
		{
			// TODO: Implement image tools
		}
	}
}
