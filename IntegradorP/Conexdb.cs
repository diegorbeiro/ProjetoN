using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntegradorP
{
    public class Conexdb
    {
        public static MySqlConnection? Conexao { get; private set; }

        public static void AbrirConexao()
        {
            try
            {
                if (Conexao == null)
                {
                    Conexao = new MySqlConnection("server=localhost;user=root;pwd=root;database=logins");
                    Conexao.Open();
                }
            }
            catch (Exception ex)
            {
                Conexao = null;
                MessageBox.Show(ex.ToString());
            }
        }

        public static void FecharConexao()
        {
            if (Conexao != null && Conexao.State == System.Data.ConnectionState.Open)
                Conexao.Close();
        }
    }
}
