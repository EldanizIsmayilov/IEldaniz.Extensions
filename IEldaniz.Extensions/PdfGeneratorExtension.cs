using IEldaniz.Extensions.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEldaniz.Extensions
{
    public static class PdfGeneratorExtensions
    {
        // Add a section to the document
        public static Section AddSection(this Document document, PageFormat pageFormat, ObjectSetup setup = null)
        {
            Section section = document.AddSection();
            section.PageSetup = document.DefaultPageSetup.Clone();
            section.PageSetup.PageFormat = pageFormat;
            if (setup != null)
            {
                if (setup.Width != null)
                    section.PageSetup.PageWidth = setup.Width.Value;
                if (setup.Height != null)
                    section.PageSetup.PageHeight = setup.Height.Value;

                if (setup.Margin != null)
                {
                    section.PageSetup.TopMargin = string.Format("{0}cm", setup.Margin.Top);
                    section.PageSetup.LeftMargin = string.Format("{0}cm", setup.Margin.Left);
                    section.PageSetup.RightMargin = string.Format("{0}cm", setup.Margin.Right);
                    section.PageSetup.BottomMargin = string.Format("{0}cm", setup.Margin.Bottom);
                }
            }
            return section;
        }

        // Add a header paragraph to the section
        public static Paragraph AddText(this Section section, string headerText, TextStyle style = null)
        {
            Paragraph paragraph = section.AddParagraph();
            if (style != null)
            {
                paragraph.Format.Alignment = style.TextAlignment;
                if (style.Font != null)
                    paragraph.AddFormattedText(headerText, style.Font);
                else
                    paragraph.AddText(headerText);
            }
            else
                paragraph.AddText(headerText);

            return paragraph;
        }


        // Add a header paragraph to the section
        public static Paragraph AddText(this Paragraph paragraph, string headerText, TextStyle style = null)
        {
            if (style != null)
            {
                paragraph.Format.Alignment = style.TextAlignment;
                if (style.Font != null)
                    paragraph.AddFormattedText(headerText, style.Font);
                else
                    paragraph.AddText(headerText);
            }
            else
                paragraph.AddText(headerText);

            return paragraph;
        }

        // Add a header paragraph to the section
        public static void AddText(this Cell cell, string text, TextStyle style = null)
        {
            Paragraph paragraph = cell.AddParagraph();
            if (style != null)
            {
                paragraph.Format.Alignment = style.TextAlignment;
                if (style.Font != null)
                    paragraph.AddFormattedText(text, style.Font);
                else
                    paragraph.AddText(text);
            }
            else
                paragraph.AddText(text);
            paragraph.Format.LineSpacingRule = LineSpacingRule.AtLeast;
            paragraph.Format.LineSpacing = 17;

        }

        // Add a header paragraph to the section
        public static void AddText(this TextFrame frame, string headerText, TextStyle style = null)
        {
            Paragraph paragraphHeader = frame.AddParagraph();
            if (style != null)
            {
                paragraphHeader.Format.Alignment = style.TextAlignment;
                if (style.Font != null)
                    paragraphHeader.AddFormattedText(headerText, style.Font);
                else
                    paragraphHeader.AddText(headerText);
            }
            else
            {
                paragraphHeader.AddText(headerText);
            }
        }

        public static Table AddTable(this Section section, ParagraphFormat format = null, Borders borders = null)
        {
            Table table = section.AddTable();
            if (format != null)
                table.Format = format;
            if (borders != null)
                table.Borders = borders;
            return table;
        }
    }

}
