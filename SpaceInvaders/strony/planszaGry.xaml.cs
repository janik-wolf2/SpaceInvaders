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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace SpaceInvaders.strony
{
    /// <summary>
    /// Logika interakcji dla klasy planszaGry.xaml
    /// </summary>
    public partial class planszaGry : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        int bulletTimer = 0;
        int liczbaZyc = 3;
        bool goLeft = false;
        bool goRight = false;
        bool strzlaj = false;


        public planszaGry()
        {
            InitializeComponent();
            statek.Source = new BitmapImage(new Uri("/resources/statek.png", UriKind.Relative));
            planszaCanvas.Focus();

            timer.Tick += petlaGry;
            timer.Interval = TimeSpan.FromMicroseconds(1000);
            timer.Start();
        }

        private void petlaGry(object? sender, EventArgs e)
        {
            foreach(var x in planszaCanvas.Children.OfType<Rectangle>())
            {
                if(x is Rectangle && (string)x.Tag == "pocisk")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);
                }
            }




            
        }

        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
            Keyboard.Focus(this);
        }


        public void HandleKeyPress(KeyEventArgs e)
        {
            

            if (e.Key == Key.Left && Canvas.GetLeft(statek) >= 0)
            {

                //statek.Margin = new Thickness(currentMargin.Left + 20, currentMargin.Top, currentMargin.Right, currentMargin.Bottom);
                Canvas.SetLeft(statek, Canvas.GetLeft(statek) - 20);
            }

            if (e.Key == Key.Right && Canvas.GetLeft(statek) < 770)
            {

                //statek.Margin = new Thickness(currentMargin.Left + 20, currentMargin.Top, currentMargin.Right, currentMargin.Bottom);
                Canvas.SetLeft(statek, Canvas.GetLeft(statek) + 20);
            }


            if (e.Key == Key.Space)
            {
                Rectangle pociskGracza = new Rectangle
                {
                    Tag = "pocisk",
                    Width = 5,
                    Height = 25,
                    Fill = Brushes.Red
                };


                Canvas.SetTop(pociskGracza, Canvas.GetTop(statek) - pociskGracza.Height);
                Canvas.SetLeft(pociskGracza, (Canvas.GetLeft(statek) - pociskGracza.Width / 2) + 35);

                planszaCanvas.Children.Add(pociskGracza);
            }

            goRight = false;
            goLeft = false;


        }
    }
}
