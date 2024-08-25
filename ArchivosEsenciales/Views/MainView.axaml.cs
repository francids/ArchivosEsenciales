using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using Avalonia.Platform.Storage;

namespace ArchivosEsenciales.Views;

public partial class MainView : UserControl
{
	public MainView()
	{
		InitializeComponent();
	}

	private async void openPdfDialog(object sender, RoutedEventArgs e)
	{
		var topLevel = TopLevel.GetTopLevel(this);

		var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Selecciona un archivo PDF",
			AllowMultiple = true,
			FileTypeFilter = new[] { FilePickerFileTypes.Pdf }
		});
	}

	private async void openImageDialog(object sender, RoutedEventArgs e)
	{
		var topLevel = TopLevel.GetTopLevel(this);

		var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Selecciona una imagen",
			AllowMultiple = true,
			FileTypeFilter = new[] { FilePickerFileTypes.ImageAll }
		});
	}
}
