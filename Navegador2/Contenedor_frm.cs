using Navegador2.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Navegador2
{
    public partial class Contenedor_frm : Form
    {
        private List<string> listaUrls;
        private int links = 0;
        private int contador = 0;
        private int columnas;
        private int anchoPantalla;
        private int altoPantalla = 1039;
        public Contenedor_frm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetearUrls();
            setearPaneles();
        }

        private void SetearUrls()
        {
            listaUrls = new List<string>();

            using (StreamReader leer = new StreamReader(@"./urls.txt"))
            {
                while (!leer.EndOfStream)
                    listaUrls.Add(leer.ReadLine());

                links = listaUrls.Count;

                if (links % 2 != 0)
                {
                    listaUrls.Add("https://www.google.com.ar");
                    links++;
                }
            }
            using (StreamReader leer = new StreamReader(@"./resolucionPantallaSoloAncho(ejemplo-1920).txt"))
            {
                while (!leer.EndOfStream)
                    anchoPantalla = Convert.ToInt32(leer.ReadLine());
            }

            this.Size = new Size(anchoPantalla, altoPantalla);
        }

        private void setearPaneles()
        {
            columnas = (links / 2);
            this.tableLayoutPanel1.ColumnCount = columnas;

            for (int i = 0; i < columnas; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

                this.tableLayoutPanel1.Controls.Add(panelGenerico(new System.Windows.Forms.Panel()), i, 0);
                this.tableLayoutPanel1.Controls.Add(panelGenerico(new System.Windows.Forms.Panel()), i, 1);
            }
        }

        private Panel panelGenerico(Panel panel)
        {
            panel = new Panel();
            panel.BackColor = System.Drawing.Color.WhiteSmoke;
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Name = "panel1";
            panel.Size = new System.Drawing.Size((anchoPantalla / columnas), (altoPantalla / 2));
            panel.TabIndex = 0;
            panel.Margin = new System.Windows.Forms.Padding(0);

            Navegador Frm = new Navegador(listaUrls[contador], ref panel);
            contador++;

            Frm.TopLevel = false;
            panel.Controls.Add(Frm);
            Frm.Show();

            return panel;
        }
    }
}
