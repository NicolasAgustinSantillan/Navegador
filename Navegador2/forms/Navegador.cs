using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador2.forms
{
    public partial class Navegador : Form
    {
        private string urlBase;
        public Navegador(string url, ref Panel panel)
        {
            InitializeComponent();
            this.urlBase = url;

            panel.DataBindings.Add("Size", this, "Size", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Navegador_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(urlBase);
        }
    }
}
