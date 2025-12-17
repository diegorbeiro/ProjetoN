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
    /// Interação lógica para Estoque.xam
    /// </summary>
    public partial class Estoque : Page
    {
        public Estoque()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());

        }

        private void CAR_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Carrinho());

        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            string sqlUpdate = "UPDATE compra SET NomeProduto = @nome, Quantidade = @qt WHERE NomeProduto = @item";
            using (var cmdUpdate = new MySqlCommand(sqlUpdate, Conexdb.Conexao))
            {
                cmdUpdate.Parameters.AddWithValue("@nome", cbItems.SelectionBoxItem);
                cmdUpdate.Parameters.AddWithValue("@qt", tbQT.Text);
                cmdUpdate.Parameters.AddWithValue("@item", cbItems.SelectionBoxItem);
                cmdUpdate.ExecuteNonQuery();
            }
        }
    }
}
