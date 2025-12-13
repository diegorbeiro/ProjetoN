using System.Configuration;
using System.Data;
using System.Windows;

namespace IntegradorP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public List<ItermCarrinho> CarrinhoList = new List<ItermCarrinho>();
    }

    public class ItermCarrinho
    {
        public string Item { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }

        public ItermCarrinho(string item, double valor)
        {
            Item = item;
            Valor = valor;
        }
    }
}
