using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class ComparadorPagosPorMonto : IComparer<Pago>
    {
        public int Compare(Pago x, Pago y)
        {
            double montoX = 0;
            double montoY = 0;

           
            if (x is PagoRecurrente prX)
            {
                montoX = prX.Monto; 
            }
            else if (x is PagoUnico puX)
            {
                montoX = puX.Monto;
            }

            // Pago Y
            if (y is PagoRecurrente prY)
            {
                montoY = prY.Monto;
            }
            else if (y is PagoUnico puY)
            {
                montoY = puY.Monto;
            }

            // Orden descendente (mayor a menor)
            if (montoX > montoY)
                return -1;
            else if (montoX < montoY)
                return 1;
            else
                return 0;
        }
    }

}