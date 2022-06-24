using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultBrigada
{
    class TListaJ : TLista
    {
        public TListaJ() { }

        public void crearLista(int Brigada, int ID, string Nombre)
        {
            Insertar(new TNodoJ(Brigada, ID, Nombre));
        }


        public bool BuscarBrigada(int nB)
        {
            TNodoJ p;
            bool aux = false;
            p = (TNodoJ)getPrimero();
            while (p != null)
            {
                if (p.getNBrigada() == nB)
                {
                    aux = true;
                    Cursor = p;
                    break;
                }
                p = (TNodoJ)p.PENodo;
            }
            return aux;
        }

        public int contarTrabajador(int nB)
        {
            TNodoJ p;
            TNodoTrabajador q;
            int aux = 0;

            BuscarBrigada(nB);
            p = (TNodoJ)getCursor();
            q = (TNodoTrabajador)p.TListaTrabajador.getPrimero();
            while (true)
            {
                if (q == p.TListaTrabajador.Ultimo)
                {
                    return aux;
                }
                else
                {
                    q = (TNodoTrabajador)q.PENodo;
                    aux++;
                }

            }
        }


        public TNodoJ getAnterior(int nB)
        {
            if (BuscarBrigada(nB))
                return (TNodoJ)getAntCursor();
            else
                return null;
        }


        public TNodoJ getPosterior(int nB)
        {
            if (BuscarBrigada(nB))
                return (TNodoJ)getProxCursor();
            else
                return null;
        }


        public void InsertarTrab(int nB, int i, string n, string o)
        {
            TNodoJ p = new TNodoJ();

            if (BuscarBrigada(nB))
                p = (TNodoJ)getCursor();
            p.TListaTrabajador.Insertar(new TNodoTrabajador(i, n, o));
        }


        public void EliminarTrab(int nB, int NId)
        {
            TNodoJ p;
            TNodoTrabajador q;
            BuscarBrigada(nB);
            p = (TNodoJ)getCursor();
            q = (TNodoTrabajador)p.TListaTrabajador.getPrimero();
            while (true)
            {
                if (q.ID == NId)
                {
                    p.TListaTrabajador.Cursor = q;
                    break;
                }
                else
                    q = (TNodoTrabajador)q.PENodo;
            }
            p.TListaTrabajador.Eliminar();
        }


        public void MostrarTrab(int nB, DataGridView dgv)
        {
            TNodoJ p;
            TNodoTrabajador q;
            int i, n, m;

            n = dgv.RowCount - 1;
            BuscarBrigada(nB);
            p = (TNodoJ)getCursor();
            q = (TNodoTrabajador)p.TListaTrabajador.getPrimero();
            m = contarTrabajador(nB);
            dgv.Rows.Clear();
            for (i = 0; i <= m; i++)
            {
                if (q == null)
                    break;
                else
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells[0].Value = q.getID();
                    dgv.Rows[i].Cells[1].Value = q.getNombre();
                    dgv.Rows[i].Cells[2].Value = q.getOficio();
                    q = (TNodoTrabajador)q.PENodo;
                }
            }
        }


        public bool EliminarLista()
        {
            if (getCursor() != null)
            {
                Eliminar();
                return true;
            }
            else return false;
        }
    }
}
