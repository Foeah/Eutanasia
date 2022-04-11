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

namespace ClientAsta2
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_conferma_Click(object sender, RoutedEventArgs e)
        {
            Client c;
            double budget;
            if (!txt_budget.Text.Equals(string.Empty) && double.TryParse(txt_budget.Text, out budget) && double.Parse(txt_budget.Text) > 0)
            {
                c = new Client(double.Parse(txt_budget.Text));
                c.Attivita();
                Lbl_Errore.Content = string.Empty;
                Main.Content = new PaginaSceltaAsta(c.Budget, c.Stream);
                Scompari.Children.Clear();
            }
            else
            {
                Lbl_Errore.Content = "Valore Impossibile!!!";
            }
        }
    }
}
