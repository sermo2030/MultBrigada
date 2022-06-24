using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultBrigada
{
    public partial class Form1 : Form
    {
        TListaJ list = new TListaJ();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNBrigada.Text = "";
            txtIdentificador.Text = "";
            txtNombre.Text = "";
            txtNBrigada.Focus();
            dgvLista.Rows.Clear();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtNBrigada.Text == "" || txtIdentificador.Text == "" || txtNombre.Text == "")
                MessageBox.Show("Débe llenar todos los campos para poder insertar!!!");
            else
                list.crearLista(int.Parse(txtNBrigada.Text), int.Parse(txtIdentificador.Text), txtNombre.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNBrigada.Text == "" || txtIdentificador.Text == "" || txtNombre.Text == "")
                MessageBox.Show("Seleccione los datos a eliminar!!!");
            else
            {
                list.BuscarBrigada(int.Parse(txtNBrigada.Text));
                list.EliminarLista();
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            TNodoJ p;
            p = (TNodoJ)list.getPrimero();
            txtNBrigada.Text = Convert.ToString(p.getNBrigada());
            txtIdentificador.Text = Convert.ToString(p.getID());
            txtNombre.Text = p.getNombre();
            dgvLista.Rows.Clear();
            list.MostrarTrab(int.Parse(txtNBrigada.Text), dgvLista);
            list.setCursor((TNodoJ)list.getPrimero());
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            TNodoJ p;
            p = (TNodoJ)list.getCursor();
            p = (TNodoJ)list.getProxCursor();
            txtNBrigada.Text = Convert.ToString(p.getNBrigada());
            txtIdentificador.Text = Convert.ToString(p.getID());
            txtNombre.Text = p.getNombre();
            dgvLista.Rows.Clear();
            list.MostrarTrab(int.Parse(txtNBrigada.Text), dgvLista);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            TNodoJ p;
            p = (TNodoJ)list.getCursor();
            p = (TNodoJ)list.getAntCursor();
            txtNBrigada.Text = Convert.ToString(p.getNBrigada());
            txtIdentificador.Text = Convert.ToString(p.getID());
            txtNombre.Text = p.getNombre();
            dgvLista.Rows.Clear();
            list.MostrarTrab(int.Parse(txtNBrigada.Text), dgvLista);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            TNodoJ p;
            p = (TNodoJ)list.getUltimo();
            txtNBrigada.Text = Convert.ToString(p.getNBrigada());
            txtIdentificador.Text = Convert.ToString(p.getID());
            txtNombre.Text = p.getNombre();
            dgvLista.Rows.Clear();
            list.MostrarTrab(int.Parse(txtNBrigada.Text), dgvLista);
            list.setCursor((TNodoJ)list.getUltimo());
        }

        private void btnDgvInsertar_Click(object sender, EventArgs e)
        {
            int index;
            index = dgvLista.CurrentRow.Index;
            list.InsertarTrab(int.Parse(txtNBrigada.Text), int.Parse(dgvLista.Rows[index].Cells[0].Value.ToString()), dgvLista.Rows[index].Cells[1].Value.ToString(), dgvLista.Rows[index].Cells[2].Value.ToString());
        }

        private void btnDgvEliminar_Click(object sender, EventArgs e)
        {
            TNodoJ p;

            int index;
            index = dgvLista.CurrentRow.Index;

            if (dgvLista.Rows[index].Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("La multilista esta vacia", "Mensaje ");
            }
            else
            {
                p = (TNodoJ)list.getCursor();
                list.EliminarTrab(int.Parse(txtNBrigada.Text), int.Parse(dgvLista.Rows[index].Cells[0].Value.ToString()));
            }
        }
    }
}
