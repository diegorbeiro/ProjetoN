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
    /// Interação lógica para Carrinho.xam
    /// </summary>
    public partial class Carrinho : Page
    {
        public Carrinho()
        {
            InitializeComponent();
        }

        private void Click_Voltar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Inicio());
        }

        private void Carrinho_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Carrinho());
        }
        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void Login_Voltar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Inicio());

        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void Carrinho_Voltar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Carrinho());

        }
    }
}
