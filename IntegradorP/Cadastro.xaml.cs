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

        private void Click_Avançar(object sender, RoutedEventArgs e)
        {
            if (tb_confSenha.Text != tb_senha.Text)
            {
                MessageBox.Show("VALIDE DADOS", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var campos = new (string nomeCampo, string valor, string mensagemErro)[]
            {
                (tb_email.Text, "EMAIL", "O campo EMAIL não pode ser vazio!"),
                (tb_nome.Text, "NOME", "O campo NOME não pode estar vazio!"),
                (tb_senha.Text, "SENHA", "O campo SENHA não pode estar vazio!")
            };

            foreach (var campo in campos)
            {
                if (string.IsNullOrEmpty(campo.valor))
                {
                    MessageBox.Show(campo.mensagemErro);
                    return;
                }
            }
            try
                {
                    string sql = "INSERT INTO usuarios (email,nome,senha) VALUES (@email,@nome,@senha)";
                    using (var cmdPontos = new MySqlCommand(sql, Conexdb.Conexao))
                    {
                        cmdPontos.Parameters.AddWithValue("@email", tb_email.Text);
                        cmdPontos.Parameters.AddWithValue("@nome", tb_nome.Text);
                        cmdPontos.Parameters.AddWithValue("@senha", tb_senha.Text);
                        cmdPontos.ExecuteNonQuery();
                    }
                }

                catch (Exception ex)
                {
                }

            if (Check.IsChecked == true)
            {
                Login entrarEstoq = new Login();
                this.NavigationService.Navigate(entrarEstoq);
                MessageBox.Show("Cadastro Realizado Com Sucesso", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Você precisa aceitar os termos e condições para prosseguir.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Click_Voltar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void tb_email_TextChanged(object sender, TextChangedEventArgs e)
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
        }
    }
}
