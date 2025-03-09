using Aspose.Pdf;
using CommunityToolkit.Maui.Storage;

namespace ArchivosEsenciales.Services;

public static class PdfService
{
    public static async Task ConvertToWord(string filePath)
    {
        using var cts = new CancellationTokenSource();
        var token = cts.Token;
        var pdf = new Document(filePath);
        using var stream = new MemoryStream();
        await pdf.SaveAsync(stream, SaveFormat.DocX, token);

        var fileName = Path.GetFileNameWithoutExtension(filePath);
        await FileSaver.Default.SaveAsync(fileName + ".docx", stream, token);
    }

    public static async Task ConvertToPptx(string filePath)
    {
        using var cts = new CancellationTokenSource();
        var token = cts.Token;
        var pdf = new Document(filePath);
        using var stream = new MemoryStream();
        await pdf.SaveAsync(stream, SaveFormat.Pptx, token);

        var fileName = Path.GetFileNameWithoutExtension(filePath);
        await FileSaver.Default.SaveAsync(fileName + ".pptx", stream, token);
    }
}