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
using static System.Net.Mime.MediaTypeNames;

namespace SpaceInvaders.strony
{
    /// <summary>
    /// Logika interakcji dla klasy planszaGry.xaml
    /// </summary>
    public partial class planszaGry : Page
    {
        public planszaGry()
        {
            InitializeComponent();
            statek.Source = new BitmapImage(new Uri("/resources/statek.png", UriKind.Relative));
            MessageBox.Show("xdd");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
            Keyboard.Focus(this);
        }


        public void HandleKeyPress(KeyEventArgs e)
        {
            Thickness currentMargin = statek.Margin;

            if (e.Key == Key.Right && currentMargin.Left < 778)
            {
                statek.Margin = new Thickness(currentMargin.Left + 20, currentMargin.Top, currentMargin.Right, currentMargin.Bottom);
            }

            if (e.Key == Key.Left && currentMargin.Left > 0)
            {
                statek.Margin = new Thickness(currentMargin.Left - 20, currentMargin.Top, currentMargin.Right, currentMargin.Bottom);
            }
        }
    }
}
