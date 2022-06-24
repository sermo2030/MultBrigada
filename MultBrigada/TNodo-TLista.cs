using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultBrigada
{
    class TNodo
    {
        public TNodo PENodo; //Enlace
        public TNodo()
        {
            PENodo = null;
        }
    }


    //Nodo jefe de brigada hereda de Nodo
    class TNodoJ : TNodo
    {
        private int ID;                  //Identificador
        private int NBrigada;            //Numero del jefe de brigada
        private string Nombre;           //Nombre del jefe de brigada
        public TLista TListaTrabajador;  //TListaTrabajador es de tipo TLista

        public TNodoJ() { }              //Constructor

        public TNodoJ(int nbrig, int id, string nombrigada) //Constructor que recibe tres parametros
        {
            NBrigada = nbrig;
            ID = id;
            Nombre = nombrigada;
            TListaTrabajador = new TLista();   //Crea una lista 
        }

        //Devuelve el identificador de la brigada
        public int getID()
        {
            return ID;
        }

        //Devuelve el Nombre del jefe de brigada
        public string getNombre()
        {
            return Nombre;
        }

        //Devuelve el numero del jefe de brigada
        public int getNBrigada()
        {
            return NBrigada;
        }


    } //Fin de la clase TNodoJ


    class TLista
    {
        public TNodo Primero;
        public TNodo Ultimo;
        public TNodo Cursor;


        public TLista()           //Constructor
        {
            Primero = null;
            Ultimo = null;
            Cursor = null;
        }

        public void inicializar()  //Inicializa los valores
        {
            Primero = null;
            Ultimo = null;
            Cursor = null;
        }

        public bool Vacia()
        {
            if (Primero == null)
                return true;
            else
                return false;
        }

        public void Insertar(TNodo nodo)
        {
            if (Vacia())
            {
                Primero = nodo;
                Ultimo = nodo;
                Cursor = nodo;
            }
            else
            {
                Ultimo.PENodo = nodo;
                Ultimo = nodo;
                Cursor = nodo;
            }
            nodo.PENodo = Primero;  //Apuntamos el nodo al primero

        }

        public TNodo Eliminarprimero()
        {
            if (Vacia())
                return null;
            else
            {
                if (Primero == Ultimo)
                    inicializar();
                else
                {
                    if (Cursor == Primero)
                    {
                        Cursor = getProxCursor();
                        Primero = Primero.PENodo;
                        Ultimo.PENodo= Primero;

                    }

                }
                return Primero;
            }

        }

        public TNodo Eliminar()
        {
            TNodo VTemp;
            if (Cursor == null)
                return null;
            else
            {
                if (Cursor == Primero)
                    return Eliminarprimero();
                else
                {
                    VTemp = getAntCursor();
                    VTemp.PENodo = Cursor.PENodo;
                    if (Cursor == Ultimo)
                        Ultimo = VTemp;
                    Cursor = VTemp.PENodo;
                    return Cursor;
                }
            }
        }


        public TNodo getPrimero()
        {
            return Primero;
        }


        public TNodo getUltimo()
        {
            return Ultimo;
        }


        public TNodo getCursor()
        {
            return Cursor;
        }


        public TNodo getProxCursor()
        {
            if (Cursor != null)
                return Cursor.PENodo;
            else
                return null;

        }

        public TNodo getAntCursor()
        {
            TNodo VTemp;
            if ((Cursor != null))
            {
                VTemp = Primero;
                while (VTemp.PENodo != Cursor)
                    VTemp = VTemp.PENodo;
                return VTemp;
            }
            else
                return Ultimo;  //Apuntamos al ultimo nodo

        }

        public void setCursor(TNodo p)
        {
            Cursor = p;
        }

    }
}
