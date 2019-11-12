using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace RoboContador
{
    public class ConvertePDF
    {
        public string ExtrairTexto_PDF(string caminho)
        {
            using (PdfReader leitor = new PdfReader(caminho))
            {
                StringBuilder texto = new StringBuilder();
                for (int i = 1; i <= leitor.NumberOfPages; i++)
                {
                    texto.Append(PdfTextExtractor.GetTextFromPage(leitor, i));
                }
                return texto.ToString();
            }
        }
        public String algumaCoisa()
        {
            return null;
        }

    }
}
