using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IntegradorP
{
    /// <summary>
    /// Interação lógica para Cadastro.xam
    /// </summary>
    public partial class Cadastro : Page
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Click_Voltar(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "INSERT INTO usuario (nome,email, senha) VALUES (@nome, @email, @senha)";
                using (var cmdPontos = new MySqlCommand(sql, Conexdb.Conexao))
                {
                    cmdPontos.Parameters.AddWithValue("@email", tb_email);
                    cmdPontos.Parameters.AddWithValue("@nome", tb_nome);
                    cmdPontos.Parameters.AddWithValue("@senha", tb_senha);
                    cmdPontos.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
            }
            if (Check.IsChecked == true)
            {
                Estoque entrarEstoq = new Estoque();
                this.NavigationService.Navigate(entrarEstoq);
                MessageBox.Show("Cadastro Realizado Com Sucesso", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Você precisa aceitar os termos e condições para prosseguir.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void tb_email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
