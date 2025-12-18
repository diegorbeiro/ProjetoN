using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            if (string.IsNullOrEmpty(cbItems.Text) || string.IsNullOrEmpty(tbQT.Text))
            {
                MessageBox.Show("Insira um valor");
                return;
            }

            string sqlInsert = "INSERT INTO compra (NomeProduto, Valor, Quantidade) VALUES (@nome,@valor, @qt)";
            var valor = 0.0;

            switch (cbItems.Text)
            {
                case "Sapato":
                    valor = 257.88;
                    break;

                case "Moletom":
                    valor = 95.99;
                    break;

                case "Oculos":
                    valor = 124.95;
                    break;

                case "Relógio":
                    valor = 149.95;
                    break;
            }

            try
            {
                using (var cmdInsert = new MySqlCommand(sqlInsert, Conexdb.Conexao))
                {
                    cmdInsert.Parameters.AddWithValue("@nome", cbItems.SelectionBoxItem);
                    cmdInsert.Parameters.AddWithValue("@qt", tbQT.Text);
                    cmdInsert.Parameters.AddWithValue("@valor", valor);

                    cmdInsert.ExecuteNonQuery();
                }
                MessageBox.Show("Produto cadastrado");
            }
            catch (Exception ex)
            {
                // trate o erro aqui (MessageBox, log, etc.)
            }


        }
    }
}
