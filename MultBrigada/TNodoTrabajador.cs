using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultBrigada
{
    class TNodoTrabajador : TNodo
    {
        public int ID;
        public string Nombre;
        public string Oficio;

        public TNodoTrabajador(int iden, string nomb, string oficio)
        {
            ID = iden;
            Nombre = nomb;
            Oficio = oficio;
        }

        public int getID()
        {
            return ID;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public string getOficio()
        {
            return Oficio;
        }
    }
}
