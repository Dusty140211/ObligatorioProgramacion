using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    internal class ComparadorPagoPorMontoTotal : IComparer<Pago>
    {
        public int Compare(Pago x, Pago y)
        { 
            double montoX = x.CalcularMontoConBeneficioORecargo();
            double montoY = y.CalcularMontoConBeneficioORecargo();

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
