using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TescoSw_ProgramatorBE.Zaznamy
{
    internal class Zaznam
    {
        public string Model { get; private set; }
        public DateTime DatumProdeje { get; private set; }
        public double cena { get; private set; }
        public double Dph { get; private set; }

        public Zaznam(string model, DateTime datumProdeje, double cena, double dph)
        {
            Model = model;
            DatumProdeje = datumProdeje;
            this.cena = cena;
            Dph = dph;
        }
    }
}
