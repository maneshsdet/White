using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using OpenQA.Selenium;
using System;
using System.IO;

namespace CommonComponents
{
    public static class PdfHelper
    {
        public static string data;
        public static string PdfRead(string file)
        {

            PdfReader pdfReader = new PdfReader(file);
            PdfDocument pdfDocument = new PdfDocument(pdfReader);

            try
            {
                for (int page = 1; page <= pdfDocument.GetNumberOfPages(); page++)
                {
                    ITextExtractionStrategy extractionStrategy = new SimpleTextExtractionStrategy();
                    data = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(page), extractionStrategy);
                    return data;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error in PDF Read");
            }

            return null;
        }

        public static void ValidatePDFs(IWebDriver _driver, string filename, string content)
        {
            try
            {
                foreach (var file in new DirectoryInfo(@Constants.Properties["DefaultDirectory"]).GetFiles("*.pdf"))
                {
                    string pdfdata = PdfHelper.PdfRead(@file.ToString());
                    if (file.Name.Contains(filename) && file.Length > 0)
                    {
                        Assertions.Contains(file.Length.ToString(), file.Length.ToString(), "PDF with Size of - " + file.Length + " is available", "Exams", "PDF validation", _driver);
                        Assertions.Contains(pdfdata, content, "PDF contains - " + content, "Exams", "PDF validation", _driver);
                    }
                    else if (file.Length > 0)
                        Assertions.Contains(file.Length.ToString(), file.Length.ToString(), file.Name + " with Size of - " + file.Length + " is available", "Print Exams", "PDF validation", _driver);
                    else
                        Assertions.Equals(0, file.Length, file.Name + " Size is " + file.Length, "Print Exams", "PDF validation", _driver);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
