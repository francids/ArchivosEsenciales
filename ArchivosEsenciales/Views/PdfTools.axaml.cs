using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Collections.Generic;
using System.IO;

namespace ArchivosEsenciales.Views;

public partial class PdfTools : Window
{
	private IReadOnlyList<Files> files;

	public PdfTools(IReadOnlyList<IStorageFile> files)
	{
		InitializeComponent();
		this.files = ConvertToFiles(files);
	}

	private void InitializeComponent()
	{
		AvaloniaXamlLoader.Load(this);
	}

	private void CloseWindow(object sender, RoutedEventArgs e)
	{
		Close();
	}

	private async void SavePdfDialog(PdfDocument document, string name)
	{
		var topLevel = TopLevel.GetTopLevel(this);

		var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
		{
			Title = "Guardar archivo PDF",
			SuggestedFileName = name,
			DefaultExtension = "pdf",
		});

		if (file is not null)
		{
			document.Save(file.Path.LocalPath);
		}
	}

	private void CompressPdf(object sender, RoutedEventArgs e)
	{
		PdfDocument document = PdfReader.Open(files[0].File.Path.LocalPath, PdfDocumentOpenMode.Import);
		PdfDocument newDocument = new PdfDocument();
		foreach (PdfPage page in document.Pages)
		{
			newDocument.AddPage(page);
		}

		// Save the document
		string pdfCompressedName = Path.GetFileNameWithoutExtension(files[0].File.Path.LocalPath);
		pdfCompressedName += "_compressed.pdf";
		SavePdfDialog(newDocument, pdfCompressedName);
	}

	private IReadOnlyList<Files> ConvertToFiles(IReadOnlyList<IStorageFile> files)
	{
		List<Files> convertedFiles = new List<Files>();
		foreach (var file in files)
		{
			convertedFiles.Add(new Files(file));
		}
		return convertedFiles;
	}
}

public class Files
{
	public IStorageFile File { get; }

	public Files(IStorageFile file)
	{
		File = file;
	}
}
