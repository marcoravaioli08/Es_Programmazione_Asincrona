using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeneraParole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string lettere = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string parolaCorrente = "";
        private Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSorteggia_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}