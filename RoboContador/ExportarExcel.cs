using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelManager;

namespace RoboContador
{
    class ExportarExcel
    {
        public void Exportar(List<Aluno> listaFinal)
        {
            ExcelManager.ExcelManager.Export(listaFinal);
        }
    }
}
