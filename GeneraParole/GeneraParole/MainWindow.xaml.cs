using System;
using System.Threading.Tasks;
using System.Windows;

namespace GeneraParole
{
    public partial class MainWindow : Window
    {
        private string parolaInCorso = "";
        private const string Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Random rnd = new Random();
        private bool staRuotando = true;

        public MainWindow()
        {
            InitializeComponent();
            AvviaRotazioneLettere();
        }

        //Fa ruotare le lettere senza bloccare il programma
        private async void AvviaRotazioneLettere()
        {
            while (staRuotando)
            {
                // Sceglie una lettera a caso
                char letteraCasuale = Alfabeto[rnd.Next(Alfabeto.Length)];

                // La mostra a video
                LetteraCorrente.Text = letteraCasuale.ToString();

                // Aspetta 100 millisecondi 
                await Task.Delay(100);
            }
        }

        private void BtnSorteggia_Click(object sender, RoutedEventArgs e)
        {
            //Prima controlliamo se è vuoto (molto importante per il tuo requisito)
            if (TxtLength.Text == "")
            {
                MessageBox.Show("Il campo lunghezza è vuoto! Inserisci un numero.");
                return;
            }

            // Proviamo a convertire in numero e verifichiamo che sia > 0
            if (int.TryParse(TxtLength.Text, out int lunghezzaScelta) && lunghezzaScelta > 0)
            {
                string letteraSorteggiata = LetteraCorrente.Text;
                parolaInCorso += letteraSorteggiata;
                ParolaCorrente.Text = "Parola in corso: " + parolaInCorso;

                if (parolaInCorso.Length >= lunghezzaScelta)
                {
                    LstParole.Items.Add(parolaInCorso);
                    parolaInCorso = "";
                    ParolaCorrente.Text = "Parola in corso: ";
                    MessageBox.Show("Parola completata e salvata!");
                }
            }
            else
            {
                MessageBox.Show("Inserisci una lunghezza valida (maggiore di 0)!");
            }
        }
    }
}