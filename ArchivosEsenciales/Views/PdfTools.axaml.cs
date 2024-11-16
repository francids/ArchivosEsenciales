using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using ArchivosEsenciales.Services;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.IO;

namespace ArchivosEsenciales.Views;

public partial class PdfTools : Window
{
	private readonly IReadOnlyList<IStorageFile> files;

	public PdfTools() : this(new List<IStorageFile>())
	{
		InitializeComponent();
	}

	public PdfTools(IReadOnlyList<IStorageFile> files)
	{
		InitializeComponent();
		this.files = files;
	}

	private void InitializeComponent()
	{
		AvaloniaXamlLoader.Load(this);
	}

	private void CloseWindow(object sender, RoutedEventArgs e) => Close();

	private async void SavePdfDialog(PdfDocument document, string name)
	{
		var topLevel = TopLevel.GetTopLevel(this);

		var filePickerOptions = new FilePickerSaveOptions
		{
			Title = "Guardar archivo PDF",
			SuggestedFileName = name,
			DefaultExtension = "pdf",
		};

		var savedFile = await topLevel!.StorageProvider.SaveFilePickerAsync(filePickerOptions);

		if (savedFile == null) return;
		using var stream = await savedFile.OpenWriteAsync();
		document.Save(stream);
	}

	private void CompressPdf(object sender, RoutedEventArgs e)
	{
		var filePath = files[0].Path.LocalPath;
		PdfDocument newDocument = PdfService.CompressPdf(filePath);

		string pdfCompressedName = Path.GetFileNameWithoutExtension(filePath) + "_compressed.pdf";
		SavePdfDialog(newDocument, pdfCompressedName);
	}
}
