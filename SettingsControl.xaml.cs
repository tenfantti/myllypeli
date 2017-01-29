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

namespace CustomSettingsDialog
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        private static Color nappulacolor = Colors.CadetBlue;
        private static Color lautacolor = Colors.White;
        private Color nappulanvari;
        private Color laudanvari;

        /// <summary>
        /// Alustetaan komponentti
        /// </summary>
        public SettingsControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Property nappulan värille
        /// </summary>
        public Color NappulaColor
        {
            get { return nappulacolor; }
            set { nappulacolor = value; }
        }

        /// <summary>
        /// Property pelilaudan värille
        /// </summary>
        public Color PelilautaColor
        {
            get { return lautacolor; }
            set { lautacolor = value; }
        }

        /// <summary>
        /// Tallentaa asetuksiin arvot.
        /// Tekee tarvittavat tarkistukset ja lisää ne settingseihin.
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">button painettu</param>
        private void Tallenna(object sender, RoutedEventArgs e)
        {
            if (!(nappulanvari.ToString().Equals("#00000000")))
            {
                NappulaColor = nappulanvari;
                Properties.Settings.Default.nappulan_vari = System.Drawing.Color.FromArgb(nappulanvari.A, nappulanvari.R, nappulanvari.G, nappulanvari.B);
            }
            if (!(laudanvari.ToString().Equals("#00000000")))
            {
                PelilautaColor = laudanvari;
                Properties.Settings.Default.pelilaudan_vari = System.Drawing.Color.FromArgb(laudanvari.A, laudanvari.R, laudanvari.G, laudanvari.B);
            }
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Sulkee ikkunan.
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">button pressed</param>
        private void Poistu(object sender, RoutedEventArgs e)
        {
            var ikkuna = Window.GetWindow(this);
            ikkuna.Close();
        }

        /// <summary>
        /// Jos nappulan väriä vaihdetaan 
        /// </summary>
        /// <param name="sender">color picker</param>
        /// <param name="e">color selected</param>
        private void nappulavari_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            nappulanvari = (Color)nappulavari.SelectedColor;
        }

        /// <summary>
        /// Jos lautapelin väriä muutetaan
        /// </summary>
        /// <param name="sender">color picker</param>
        /// <param name="e">color selected</param>
        private void pelialuevari_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            laudanvari = (Color)pelialuevari.SelectedColor;
        }
    }
}
