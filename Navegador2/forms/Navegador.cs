using System;
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
            this.InitBrowser();
        }

        private async Task webBrowser1Initizated()
        {
            await webBrowser1.EnsureCoreWebView2Async(null);
        }

        private async void InitBrowser()
        {
            await this.webBrowser1Initizated();
            webBrowser1.CoreWebView2.Navigate(this.urlBase);
        }
    }
}
