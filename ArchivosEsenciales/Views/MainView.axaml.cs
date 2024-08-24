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

	private async void OnOpenFileDialogClick(object sender, RoutedEventArgs e)
	{
		var topLevel = TopLevel.GetTopLevel(this);
		
		// Start async operation to open the dialog.
		var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Selecciona un archivo",
			AllowMultiple = false,
			FileTypeFilter = new[] { FilePickerFileTypes.Pdf }
		});
	}
}
