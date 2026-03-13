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

        // Metodo eseguito ogni volta che l'utente clicca sul tasto "Sorteggia"
        private void BtnSorteggia_Click(object sender, RoutedEventArgs e)
        {
            // Controllo di sicurezza: se il TextBox è totalmente vuoto
            if (TxtLength.Text == "")
            {
                // Mostra un avviso all'utente
                MessageBox.Show("Il campo lunghezza è vuoto! Inserisci un numero.");
                return;
            }

            // Prova a convertire il testo in numero (int) e verifica che sia maggiore di zero
            if (int.TryParse(TxtLength.Text, out int lunghezzaScelta) && lunghezzaScelta > 0)
            {
                // Prende la lettera che appare a video in questo esatto momento
                string letteraSorteggiata = LetteraCorrente.Text;

                // Aggiunge la lettera alla parola che stiamo costruendo
                parolaInCorso += letteraSorteggiata;

                // Aggiorna l'interfaccia per mostrare la parola che si sta costruendo
                ParolaCorrente.Text = "Parola in corso: " + parolaInCorso;

                // Controlla se la parola ha raggiunto la lunghezza specificata dall'utente
                if (parolaInCorso.Length >= lunghezzaScelta)
                {
                    // Aggiunge la parola completata nella ListBox
                    LstParole.Items.Add(parolaInCorso);

                    // Svuota poterne iniziare una nuova
                    parolaInCorso = "";

                    // Reset della label
                    ParolaCorrente.Text = "Parola in corso: ";

                    MessageBox.Show("Parola completata e salvata!");
                }
            }
            else
            {
                // Scatta se l'utente ha scritto lettere nel TextBox o numeri minori/uguali a zero
                MessageBox.Show("Inserisci una lunghezza valida (maggiore di 0)!");
            }
        }
    }
}