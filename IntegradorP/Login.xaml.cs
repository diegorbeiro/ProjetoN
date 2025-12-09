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
            var emailExist = false;
            var senhaExist = false;
            try
            {
                string sql = "SELECT * FROM usuarios";
                var cmd = new MySqlCommand(sql, Conexdb.Conexao);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var email = reader.GetString("email");
                        var senha = reader.GetString("senha");

                        if (tb_emails.Text == email)
                        {
                            emailExist = true;
                        }

                        if (tb_senhas.Text == senha)
                        {
                            senhaExist = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
            }

            if (emailExist && senhaExist)
            {
                if (Check.IsChecked == true)
                {
                    MessageBox.Show("Login realizado com sucesso!");

                    this.NavigationService.Navigate(new Estoque());
                }
                else
                {
                    MessageBox.Show("Você precisa aceitar os termos e condições para prosseguir.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Email ou senha incorretos.");
            }

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
            try
            {
                string sql = "INSERT INTO usuario (nome,email, senha) VALUES (@nome, @email, @senha)";
                using (var cmdPontos = new MySqlCommand(sql, Conexdb.Conexao))
                {
                    cmdPontos.Parameters.AddWithValue("@email", tb_emails);
                    cmdPontos.Parameters.AddWithValue("@nome", tb_nomes);
                    cmdPontos.Parameters.AddWithValue("@senha", tb_senhas);
                    cmdPontos.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
            }
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());

        }

        private void tb_nome_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string sql = "INSERT INTO usuario (nome,email, senha) VALUES (@nome, @email, @senha)";
                using (var cmdPontos = new MySqlCommand(sql, Conexdb.Conexao))
                {
                    cmdPontos.Parameters.AddWithValue("@email", tb_emails);
                    cmdPontos.Parameters.AddWithValue("@nome", tb_nomes);
                    cmdPontos.Parameters.AddWithValue("@senha", tb_senhas);
                    cmdPontos.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
            }
        }

        private void tb_senha_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string sql = "INSERT INTO usuario (nome,email, senha) VALUES (@nome, @email, @senha)";
                using (var cmdPontos = new MySqlCommand(sql, Conexdb.Conexao))
                {
                    cmdPontos.Parameters.AddWithValue("@email", tb_emails);
                    cmdPontos.Parameters.AddWithValue("@nome", tb_nomes);
                    cmdPontos.Parameters.AddWithValue("@senha", tb_senhas);
                    cmdPontos.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
            }
        }
    }
}
