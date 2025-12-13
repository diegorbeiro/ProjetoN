using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interação lógica para Page1.xam
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Atras_Voltar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }




        private void Login_Voltar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Inicio());
        }

        private void Carrinho_Voltar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Carrinho());
        }

        private void Button_Voltar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void Carrinho_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void cp1_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var value = btn.Tag.ToString();


            ((App)Application.Current).CarrinhoList.Add(new ItermCarrinho(btn.Name, double.Parse(value)));
            MessageBox.Show("Produto Adicionado");
        }

        private void AdicionaCarrinho(string item, string valor)
        {
            try
            {
                string sql = "INSERT INTO compra (NomeProduto,Valor,Quantidade) VALUES (@item,@valor,@quantidade)";
                using (var cmdPontos = new MySqlCommand(sql, Conexdb.Conexao))
                {
                    cmdPontos.Parameters.AddWithValue("@item", item);
                    cmdPontos.Parameters.AddWithValue("@valor", valor);
                    cmdPontos.Parameters.AddWithValue("@quantidade", 1);
                    cmdPontos.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
