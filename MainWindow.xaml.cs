using AboutDialog;
using CustomSettingsDialog;
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

namespace GKOHarkka
{
    /// <summary>
    /// Pääikkuna ohjelmalle
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomSettingsDialog.SettingsControl sc = new CustomSettingsDialog.SettingsControl();

        /// <summary>
        /// Alustetaan pääikkuna
        /// ja asetetaan minimirajoitukset.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MinWidth = 650;
            MinHeight = 600;
            this.MouseMove += new MouseEventHandler(Ilmoitus);
            this.Title = "Myllypeli";
        }

        /// <summary>
        /// Näyttää virheilmoituksen jos on jotain vikaa liikkeissä.
        /// </summary>
        /// <param name="sender">window</param>
        /// <param name="e">näytetään virheilmoitus kun hiiri on ohjelman päällä</param>
        private void Ilmoitus(object sender, MouseEventArgs e)
        {
            try
            {
                virhelabel.Content = pelialue.Message;
            }
            catch(System.NullReferenceException)
            {
                virhelabel.Content = "";
            }

            pelialue.NappulaColor = sc.NappulaColor;
            pelialue.PelilautaColor = sc.PelilautaColor;

        }

        /// <summary>
        /// Saako suorittaa komennon,
        /// joka tässä aliohjelmassa on aina kyllä.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">command selected</param>
        private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// Saako tulostaa ohjelman
        /// </summary>
        /// <param name="sender">Command</param>
        /// <param name="e">command selected</param>
        private void CanExecutePrint(object sender, CanExecuteRoutedEventArgs e)
        {
            if (pelialue.NappuloidenLkm > 0)
            e.CanExecute = true;
        }

        /// <summary>
        /// Saako aloittaa uuden pelin.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">command selected</param>
        private void CanStartNewGame(object sender, CanExecuteRoutedEventArgs e)
        {
            if (pelialue.NappuloidenLkm <= 0) e.CanExecute = false;
            else e.CanExecute = true;
        }

        /// <summary>
        /// Saako lisätä uuden nappulan.
        /// Mahdollista vain jos pelilauta ei ole täynnä.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">command selected</param>
        private void CanExecuteAdd(object sender, CanExecuteRoutedEventArgs e)
        {
            if (pelialue.OnTaynna) e.CanExecute = false;
            else e.CanExecute = true;
        }

        /// <summary>
        /// Saako poistaa nappulan.
        /// Mahdollista jos nappuloita on ollenkaan laudalla
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">command selected</param>
        private void CanExecuteRemove(object sender, CanExecuteRoutedEventArgs e)
        {
            if (pelialue.NappuloidenLkm > 0 || pelialue.OnTaynna)
            e.CanExecute = true;
        }

        /// <summary>
        /// Saako siirtää nappulan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanExecuteMove(object sender, CanExecuteRoutedEventArgs e)
        {
            if (pelialue.OnTaynna) e.CanExecute = false;
            else if (pelialue.NappuloidenLkm > 0)
                e.CanExecute = true;
        }

        /// <summary>
        /// Aliohjelma tulostamiselle.
        /// Tulostaa pelialueen.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">suoritetaan tulostus</param>
        private void Print(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(pelialue, "Peli");
            }

        }

        /// <summary>
        /// Avataan About-dialogi.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">dialogin avaaminen</param>
        private void OpenAboutDialog(object sender, ExecutedRoutedEventArgs e)
        {
            CustomAbout ca = new CustomAbout();
            Nullable<bool> tulos = ca.ShowDialog();
            if (tulos == true)
            {
                ca.Close();
            }
        }

        /// <summary>
        /// Avataan asetukset-dialogi.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">asetusten avaaminen</param>
        private void OpenSettings(object sender, ExecutedRoutedEventArgs e)
        {
            CustomSettings cs = new CustomSettings();
            sc.NappulaColor = pelialue.NappulaColor;
            sc.PelilautaColor = pelialue.PelilautaColor;
            Nullable<bool> tulos = cs.ShowDialog();

            if (tulos == true)
            {
                pelialue.NappulaColor = sc.NappulaColor;
                pelialue.PelilautaColor = sc.PelilautaColor;
            }
        }

        /// <summary>
        /// Avataan nettisivut, jotka ohjaavat
        /// nettisivuille.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">sivun avaaminen</param>
        private void OpenWebsite(object sender, ExecutedRoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://users.jyu.fi/~jahasall/TIEA212/avustus.html");
        }

        /// <summary>
        /// Aliohjelma, joka käynnistää
        /// uuden pelin ja viestii sen pelilaudalle
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">uuden pelin käynnistys</param>
        private void NewGame(object sender, ExecutedRoutedEventArgs e)
        {
            pelialue.Lisays = false;
            pelialue.Muutos = false;
            pelialue.Poisto = false;
            sc.NappulaColor = Colors.CadetBlue;
            sc.PelilautaColor = Colors.White;
            virhelabel.Content = "";
            pelialue.NewGame();
        }

        /// <summary>
        /// Lisätään uusi nappula pelilaudalle.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">nappulan lisääminen</param>
        private void AddPiece(object sender, ExecutedRoutedEventArgs e)
        {
            pelialue.Lisays = true;
        }

        /// <summary>
        /// Poistetaan nappula pelilaudalta.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">nappulan poistaminen</param>
        private void RemovePiece(object sender, ExecutedRoutedEventArgs e)
        {
            pelialue.Poisto = true;
        }

        /// <summary>
        /// Siirretään nappula pelilaudalla.
        /// </summary>
        /// <param name="sender">command</param>
        /// <param name="e">nappulan siirtäminen</param>
        private void MovePiece(object sender, ExecutedRoutedEventArgs e)
        {
            pelialue.Muutos = true;
        }
    }
}
