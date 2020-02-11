using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.IO;

namespace Bsoft.PDF
{
    public class PDFGenerator
    {
        //private static readonly PDFGenerator instance = new PDFGenerator();

        //public static PDFGenerator Instance
        //{
        //    get
        //    {
        //       // FontFactory.RegisterDirectories();              //Required for supporting font-family style in HTML.
        //        return PDFGenerator.instance;
        //    }
        //}

        public static void GeneratePDFromHtml(string html, string outFile)
        {
            GeneratePDFromHtml(html, outFile, new StyleSheet(), false, "");
        }

        public static void GeneratePDFromHtml(string html, string outFile, StyleSheet sc, bool pageNumber, string footerHtml)
        {
            try
            {
                Document document = new Document(PageSize.A4, 30, 30, 30, footerHtml == null ? 30 : 80);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outFile, FileMode.Create));
                writer.PageEvent = new PolsPdfPageEventHandler() { footerHTML = footerHtml };
                HTMLWorker worker = new HTMLWorker(document);

                document.Open();

                worker.StartDocument();
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(html), sc);

                // Enumerate the elements, adding each one to the Document...
                foreach (var htmlElement in parsedHtmlElements)
                    document.Add(htmlElement as IElement);

                worker.EndDocument();
                worker.Close();
                document.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static void CombineMultiplePDFs(string[] fileNames, string outFile)
        {
            int pageOffset = 0;
            ArrayList master = new ArrayList();
            int f = 0;
            Document document = null;
            PdfCopy writer = null;
            while (f < fileNames.Length)
            {
                // we create a reader for a certain document
                PdfReader reader = new PdfReader(fileNames[f]);
                reader.ConsolidateNamedDestinations();
                // we retrieve the total number of pages
                int n = reader.NumberOfPages;
                pageOffset += n;
                if (f == 0)
                {
                    // step 1: creation of a document-object
                    document = new Document(reader.GetPageSizeWithRotation(1));
                    // step 2: we create a writer that listens to the document
                    writer = new PdfCopy(document, new FileStream(outFile, FileMode.Create));
                    // step 3: we open the document
                    document.Open();
                }
                // step 4: we add content
                for (int i = 0; i < n; )
                {
                    ++i;
                    if (writer != null)
                    {
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        writer.AddPage(page);
                    }
                }
                PRAcroForm form = reader.AcroForm;
                if (form != null && writer != null)
                {
                    writer.CopyAcroForm(reader);
                }
                f++;
            }
            // step 5: we close the document
            if (document != null)
            {
                document.Close();
            }
        }

        private class PolsPdfPageEventHandler : PdfPageEventHelper
        {
            public string footerHTML { get; set; }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                if (footerHTML == null || footerHTML.Length == 0)
                    return;
                PdfPCell footerCell = new PdfPCell();
                footerCell.Border = PdfPCell.NO_BORDER;
                var footerHtmlElements = HTMLWorker.ParseToList(new StringReader(footerHTML), null);
                foreach (var footerElement in footerHtmlElements)
                {
                    footerCell.AddElement(footerElement as IElement);
                }
                PdfPTable footerArea = new PdfPTable(1);
                footerArea.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                footerArea.AddCell(footerCell);
                footerArea.WriteSelectedRows(
                  0, -1,  // first/last row; -1 flags all write all rows
                  document.LeftMargin,   // left offset
                  document.BottomMargin - 2,  //bottom offset
                  writer.DirectContent
                );
            }
        }
    }
}