using KKKKPPP.Data.Interfaces;
using KKKKPPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KKKKPPP.Data;
using KKKKPPP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace KKKKPPP.Controllers
{
    public class DBReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult DBReport()
        {
            ViewBag.Title = "Report creation";
            string[] files = Directory.GetFiles("QueryResults", "*.csv");
            DBReportViewModel obj = new DBReportViewModel
            {
                fileNames = files,
            };
            return View(obj);
        }

        [HttpPost]
        public FileStreamResult GenerateWord(string[] selFiles)
        {            
            // Creating a new document.
            WordDocument document = new WordDocument();
            //Adding a new section to the document.
            WSection section = document.AddSection() as WSection;
            //Set Margin of the section
            section.PageSetup.Margins.All = 72;
            //Set page size of the section
            section.PageSetup.PageSize = new Syncfusion.Drawing.SizeF(612, 792);

            //Create Paragraph styles
            WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
            style.CharacterFormat.FontName = "Times New Roman";
            style.CharacterFormat.FontSize = 11f;
            style.ParagraphFormat.BeforeSpacing = 0;
            style.ParagraphFormat.AfterSpacing = 8;
            style.ParagraphFormat.LineSpacing = 13.8f;

            style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;
            style.ApplyBaseStyle("Normal");
            style.CharacterFormat.FontName = "Times New Roman";
            style.CharacterFormat.FontSize = 16f;
            style.CharacterFormat.Bold = true;
            style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Black;
            style.ParagraphFormat.BeforeSpacing = 12;
            style.ParagraphFormat.AfterSpacing = 0;
            style.ParagraphFormat.Keep = true;
            style.ParagraphFormat.KeepFollow = true;
            style.ParagraphFormat.OutlineLevel = OutlineLevel.Level1;
            IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();


            WTextRange textRange;


            //Appends paragraph.
            paragraph = section.AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText("Отчет генеральной проверки картин в галерее") as WTextRange;
            //textRange.CharacterFormat.FontSize = 18f;
            //textRange.CharacterFormat.FontName = "Times New Roman";

            paragraph = section.AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.AfterSpacing = 12;
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText($"за {DateTime.Now.Year} год") as WTextRange;
            //textRange.CharacterFormat.FontSize = 18f;
            //textRange.CharacterFormat.FontName = "Times New Roman";

            foreach (var x in selFiles)
            {
                paragraph = section.AddParagraph();
                paragraph.ApplyStyle("Heading 1");
                paragraph.ParagraphFormat.AfterSpacing = 12;
                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
                textRange = paragraph.AppendText(x.Remove(x.Length-4, 4).Remove(0, 1 + x.IndexOf('\\'))) as WTextRange;

                IWTable wTable = section.AddTable();
                wTable.TableFormat.IsAutoResized = true;
                string csvtable = System.IO.File.ReadAllText(x);
                string[] rows = csvtable.Split('\n');
                wTable.ResetCells(rows.Length, rows[0].Split(';').Length);
                int Nrows = wTable.Rows.Count;
                int Ncells = wTable.Rows[0].Cells.Count;
                for (int y = 0; y < Nrows; y++)
                {
                    string[] cells = rows[y].Split(';');
                    //  table.Add(csvtable.Split('\n')[y].Split(';').ToList());
                    for (int z = 0; z < Ncells; z++)
                    {
                        paragraph = wTable[y, z].AddParagraph();
                        paragraph.ApplyStyle("Normal");
                        paragraph.ParagraphFormat.AfterSpacing = 0;
                        paragraph.ParagraphFormat.LineSpacing = 12f;
                        paragraph.AppendText(cells[z]);
                    }
                }
                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.AfterSpacing = 12;
                paragraph.ParagraphFormat.BeforeSpacing = 12;
            }

            ////Appends paragraph.
            //paragraph = section.AddParagraph();
            //paragraph.ParagraphFormat.FirstLineIndent = 36;
            //paragraph.BreakCharacterFormat.FontSize = 12f;
            //textRange = paragraph.AppendText("Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is in Bothell, Washington with 290 employees, several regional sales teams are located throughout their market base.") as WTextRange;
            //textRange.CharacterFormat.FontSize = 12f;

            ////Appends paragraph.
            //paragraph = section.AddParagraph();
            //paragraph.ParagraphFormat.FirstLineIndent = 36;
            //paragraph.BreakCharacterFormat.FontSize = 12f;
            //textRange = paragraph.AppendText("In 2000, AdventureWorks Cycles bought a small manufacturing plant, Importadores Neptuno, located in Mexico. Importadores Neptuno manufactures several critical subcomponents for the AdventureWorks Cycles product line. These subcomponents are shipped to the Bothell location for final product assembly. In 2001, Importadores Neptuno, became the sole manufacturer and distributor of the touring bicycle product group.") as WTextRange;
            //textRange.CharacterFormat.FontSize = 12f;

            //paragraph = section.AddParagraph();
            //paragraph.ApplyStyle("Heading 1");
            //paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
            //textRange = paragraph.AppendText("Product Overview") as WTextRange;
            //textRange.CharacterFormat.FontSize = 16f;
            //textRange.CharacterFormat.FontName = "Calibri";





            section.AddParagraph();

            //Saves the Word document to  MemoryStream
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            stream.Position = 0;

            //Download Word document in the browser
            return File(stream, "application/msword", "Sample.docx");
        }
    }
}
