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
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void Button_Voltar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Inicio());
        }

        private void Cadastro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cadastro());
        }

        private void tb_email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());

        }
    }
}
