using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using System.Collections.Generic;

namespace ArchivosEsenciales.Views;

public partial class PdfTools : Window
{
	public PdfTools(IReadOnlyList<IStorageFile> files)
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		AvaloniaXamlLoader.Load(this);
	}
}