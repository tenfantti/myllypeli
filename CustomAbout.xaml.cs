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

namespace AboutDialog
{
    /// <summary>
    /// About-dialogi ohjelmalle.
    /// </summary>
    public partial class CustomAbout : Window
    {
        /// <summary>
        /// Alustetaan dialogi
        /// </summary>
        public CustomAbout()
        {
            InitializeComponent();
            this.Title = "About";
        }

        /// <summary>
        /// Suljetaan dialogi.
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">klikkaustapahtuma</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
