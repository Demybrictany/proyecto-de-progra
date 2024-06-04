using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class FACTURA //Se unieron 2 clases
    {
        public string NOMBRE;
        public int NIT;
        public string FECHA;
        public string HORA;

        public FACTURA(string nombre, int nit, string fecha, string hora)
        {
            NOMBRE = nombre;
            NIT = nit;
            FECHA = fecha;
            HORA = hora;
        }
    }

    public class BOMBAS 
    {
        public string BOMBA;
        public decimal GALONES;

        public BOMBAS(string bomba, decimal galones)
        {
            BOMBA = bomba;
            GALONES = galones;
        }
    }
}
