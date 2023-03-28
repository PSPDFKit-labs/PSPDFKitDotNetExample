using PSPDFKit;
using PSPDFKit.Providers;


internal class Program
{
    private static void Main(string[] args)
    {
        PSPDFKit.Sdk.InitializeTrial();
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        var fileProvider = new FileDataProvider(baseDir + "firstDocument.pdf");
        var documentToEdit = new Document(fileProvider);

        
        documentToEdit.ImportDocumentJson(new FileDataProvider(baseDir + "instant.json"));
        
        documentToEdit.Save(new DocumentSaveOptions { flattenAnnotations = true });
        
        var documentEditor = documentToEdit.CreateDocumentEditor();
        documentEditor.ImportDocument(0, DocumentEditor.IndexPosition.AfterIndex, new FileDataProvider("secondDocument.pdf"));
        var filepath = baseDir + "documentEditorOutput.pdf";
        documentEditor.SaveDocument(new FileDataProvider(filepath));

        string outputJsonFileName = baseDir + "output.json";
        documentToEdit.ExportDocumentJson(new FileDataProvider(outputJsonFileName));
    }
}