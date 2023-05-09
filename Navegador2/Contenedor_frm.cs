using Navegador2.forms;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Navegador2
{
    public partial class Contenedor_frm : Form
    {
        private List<string> listaUrls;
        private int contador = 0;
        private int columnas;
        private int anchoPantalla = 1920;
        private int altoPantalla = 1040;
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

            NameValueCollection dictionaryUrls = ConfigurationManager.AppSettings;

            foreach(var url in dictionaryUrls)
            {
                var key = url;
                this.listaUrls.Add(ConfigurationManager.AppSettings[key.ToString()]);
            }

            if (this.listaUrls.Count % 2 != 0)
            {
                listaUrls.Add("https://www.google.com.ar");
            }

            this.Size = new Size(anchoPantalla, altoPantalla);
        }

        private void setearPaneles()
        {
            columnas = (this.listaUrls.Count / 2);
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
