using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

            var itm = "";
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    itm = "Sapato";
                }
                else if (i == 1)
                {
                    itm = "Moletom";
                }
                else if (i == 2)
                {
                    itm = "Oculos";
                }
                else if (i == 3)
                {
                    itm = "Relógio";
                }

                Atualizar(itm);
            }
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

        private void AdicionaCarrinho(string item, double valor)
        {
            try
            {
                string sql = "SELECT Quantidade FROM compra WHERE NomeProduto = @item";
                var cmd = new MySqlCommand(sql, Conexdb.Conexao);

                cmd.Parameters.AddWithValue("@item", item);

                var total = 0;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var quantidade = reader["Quantidade"];
                        if (quantidade != DBNull.Value)
                        {
                            total = Convert.ToInt32(quantidade);
                        }
                    }
                }

                if (total > 0)
                {
                    int novaQuantidade = total - 1;

                    string sqlUpdate = "UPDATE compra SET Quantidade = @quantidade WHERE NomeProduto = @item";
                    using (var cmdUpdate = new MySqlCommand(sqlUpdate, Conexdb.Conexao))
                    {
                        cmdUpdate.Parameters.AddWithValue("@item", item);
                        cmdUpdate.Parameters.AddWithValue("@quantidade", novaQuantidade);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    MessageBox.Show("Quantidade do produto atualizada");
                }
                else
                {
                    MessageBox.Show("Não há quantidade suficiente para diminuir");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
            }

            Atualizar(item);
        }

        private void Atualizar(string item)
        {
            try
            {
                string sql = "SELECT Quantidade FROM compra WHERE NomeProduto = @item";
                var cmd = new MySqlCommand(sql, Conexdb.Conexao);

                cmd.Parameters.AddWithValue("@item", item);

                var total = 0;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var quantidade = reader["Quantidade"];
                        if (quantidade != DBNull.Value)
                        {
                            total = Convert.ToInt32(quantidade);
                        }
                    }
                }

                if (item == "Relógio")
                {
                    quant3.Content = total.ToString();
                }
                else if (item == "Moletom")
                {
                    quant1.Content = total.ToString();
                }
                else if (item == "Oculos")
                {
                    quant2.Content = total.ToString();
                }
                else if (item == "Sapato")
                {
                    quant.Content = total.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao acessar dados: " + ex.Message);
            }

        }
        private void AdicionaCarrinho(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var value = btn.Tag.ToString();
            AdicionaCarrinho(btn.Name, double.Parse(value));
            ((App)Application.Current).CarrinhoList.Add(new ItermCarrinho(btn.Name, double.Parse(value)));
        }

        private void Sapato_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var value = btn.Tag.ToString();
            AdicionaCarrinho(btn.Name, double.Parse(value));
            ((App)Application.Current).CarrinhoList.Add(new ItermCarrinho(btn.Name, double.Parse(value)));
        }

        private void Moletom_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var value = btn.Tag.ToString();
            AdicionaCarrinho(btn.Name, double.Parse(value));
            ((App)Application.Current).CarrinhoList.Add(new ItermCarrinho(btn.Name, double.Parse(value)));
        }

        private void Oculos_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var value = btn.Tag.ToString();
            AdicionaCarrinho(btn.Name, double.Parse(value));
            ((App)Application.Current).CarrinhoList.Add(new ItermCarrinho(btn.Name, double.Parse(value)));

        }

        private void Relógio_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var value = btn.Tag.ToString();
            AdicionaCarrinho(btn.Name, double.Parse(value));
            ((App)Application.Current).CarrinhoList.Add(new ItermCarrinho(btn.Name, double.Parse(value)));
        }
    }
}
