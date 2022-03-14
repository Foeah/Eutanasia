using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientAsta
{
    /// <summary>
    /// Interaction logic for Pagina1.xaml
    /// </summary>
    public partial class Pagina1 : Page
    {
        public Pagina1()
        {
            InitializeComponent();
        }

        private void btn_CambiaPagina_Click(object sender, RoutedEventArgs e)
        {
            Client c;
            double budget;
            if (!txt_Budget.Equals(string.Empty) && !double.TryParse(txt_Budget.Text, out budget) && double.Parse(txt_Budget.Text) > 0)
            {
                c = new Client(double.Parse(txt_Budget.Text));
                c.Attivita();
            }
                //Main.Content = new Pagina1();   //capire perchè non va
        }
    }
}
