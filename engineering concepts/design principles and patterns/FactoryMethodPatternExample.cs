using System;

namespace FactoryMethodPatternExample
{
    public interface IDocument
    {
        void Open();
        void Save();
    }

    public class WordDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Word document");
        public void Save() => Console.WriteLine("Saving Word document as .docx");
    }

    public class PdfDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening PDF document");
        public void Save() => Console.WriteLine("Saving PDF document as .pdf");
    }

    public class ExcelDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Excel document");
        public void Save() => Console.WriteLine("Saving Excel document as .xlsx");
    }

    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();

        public void ProcessDocument()
        {
            IDocument doc = CreateDocument();
            doc.Open();
            doc.Save();
        }
    }

    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new WordDocument();
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new PdfDocument();
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new ExcelDocument();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Creating Word Document ----");
            DocumentFactory wordFactory = new WordDocumentFactory();
            IDocument wordDoc = wordFactory.CreateDocument();
            wordDoc.Open();
            wordDoc.Save();

            Console.WriteLine();
            Console.WriteLine("---- Creating PDF Document ----");
            DocumentFactory pdfFactory = new PdfDocumentFactory();
            IDocument pdfDoc = pdfFactory.CreateDocument();
            pdfDoc.Open();
            pdfDoc.Save();

            Console.WriteLine();
            Console.WriteLine("---- Creating Excel Document ----");
            DocumentFactory excelFactory = new ExcelDocumentFactory();
            IDocument excelDoc = excelFactory.CreateDocument();
            excelDoc.Open();
            excelDoc.Save();

            Console.WriteLine();
            Console.WriteLine("---- Using ProcessDocument() helper method ----");
            DocumentFactory anotherWordFactory = new WordDocumentFactory();
            anotherWordFactory.ProcessDocument();
        }
    }
}
