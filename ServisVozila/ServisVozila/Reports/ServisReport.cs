using iTextSharp.text;
using iTextSharp.text.pdf;
using ServisVozila.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace ServisVozila.Reports
{
    public class ServisReport
    {
        public byte[] Podaci { get; private set; }
        public ServisReport(List<servis> servisi)
        {
            Document pdfDokument = new Document(PageSize.A4, 50, 50, 20, 50);
            MemoryStream memStream = new MemoryStream();
            PdfWriter.GetInstance(pdfDokument, memStream).CloseStream = false;
            pdfDokument.Open();
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false);
            Font header = new Font(font, 12, Font.NORMAL, BaseColor.DARK_GRAY);
            Font naslov = new Font(font, 14, Font.BOLDITALIC, BaseColor.BLACK);
            Font tekst = new Font(font, 10, Font.NORMAL, BaseColor.BLACK);

            var logo = iTextSharp.text.Image.GetInstance(@"https://www.iconexperience.com/_img/o_collection_png/green_dark_grey/512x512/plain/wrench.png");

            logo.Alignment = Element.ALIGN_LEFT;
            logo.ScaleAbsoluteHeight(100);
            logo.ScaleAbsoluteWidth(100);
            pdfDokument.Add(logo);
            Paragraph p = new Paragraph("MPC, MEV " + DateTime.Now.ToString("dd.MM.yyyy"), header);
            pdfDokument.Add(p);

            p = new Paragraph("Popis servisa", naslov);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 30;
            p.SpacingBefore = 30;
            pdfDokument.Add(p);

            PdfPTable t = new PdfPTable(4);
            t.WidthPercentage = 100;
            t.SetWidths(new float[] { 2, 2, 2, 2 });
            t.AddCell(VratiCeliju("Opis Posla", tekst, BaseColor.LIGHT_GRAY, true));
            t.AddCell(VratiCeliju("Napomena", tekst, BaseColor.LIGHT_GRAY, true));
            t.AddCell(VratiCeliju("Cijena", tekst, BaseColor.LIGHT_GRAY, true));
            t.AddCell(VratiCeliju("Datum", tekst, BaseColor.LIGHT_GRAY, true));

            int i = 1;
            foreach (servis au in servisi)
            {
                t.AddCell(VratiCeliju(au.opisPosla, tekst, BaseColor.WHITE, false));
                t.AddCell(VratiCeliju(au.napomena, tekst, BaseColor.WHITE, false));
                t.AddCell(VratiCeliju(au.cijena.ToString(), tekst, BaseColor.WHITE, false));
                t.AddCell(VratiCeliju(au.datum.ToString(), tekst, BaseColor.WHITE, false));
            }

            pdfDokument.Add(t);

            p = new Paragraph("Cakovec " + DateTime.Now.ToString("dd.MM.yyyy"), header);
            p.Alignment = Element.ALIGN_RIGHT;
            p.SpacingBefore = 30;
            pdfDokument.Add(p);

            pdfDokument.Close();
            Podaci = memStream.ToArray();
        }

        private PdfPCell VratiCeliju(string labela, Font font, BaseColor boja, bool wrap)
        {
            PdfPCell c1 = new PdfPCell(new Phrase(labela, font));
            c1.BackgroundColor = boja;
            c1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            c1.Padding = 5;
            c1.NoWrap = wrap;
            return c1;
        }
    }
}