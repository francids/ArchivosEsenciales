using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace ArchivosEsenciales.Services;

public class PdfService
{
	public static PdfDocument CompressPdf(string filePath)
	{
		PdfDocument document = PdfReader.Open(filePath, PdfDocumentOpenMode.Import);
		PdfDocument newDocument = new PdfDocument();
		foreach (PdfPage page in document.Pages)
		{
			newDocument.AddPage(page);
		}
		return newDocument;
	}
}
