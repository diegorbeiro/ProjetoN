using MySql.Data.MySqlClient;
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

namespace IntegradorP
{
    /// <summary>
    /// Interação lógica para Finalizar.xam
    /// </summary>
    public partial class Finalizar : Page
    {
        public Finalizar()
        {
            InitializeComponent();
        }

        private void ContComp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void tb_nomes_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void tb_endereço_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tb_cep_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tb_telefone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_nome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Finali_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
