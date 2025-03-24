using SpaceInvaders.strony;
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

namespace SpaceInvaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            glownyFrame.Navigate(new menuGlowne());
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (glownyFrame.Content is planszaGry gamePage)
            {
                gamePage.HandleKeyPress(e);
            }
        }
    }
}