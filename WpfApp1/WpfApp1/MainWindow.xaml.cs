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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TiltScroll? _tiltScrill;

        public MainWindow()
        {
            InitializeComponent();

            List<Detail> details = new List<Detail>()
            {
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa", true, false, "DDDDEEEEEEEEEEEEEEEDDDD", "EEEEEEEEEEEEe", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", true, false, "DDDDDEEEEEEEEEEEEEDDDDDDDDDDD", "EEEEEEEEEEEEEEEEEEEEEEE", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
                new("AAAAAAAAAAAAAAAa", true, false, "DDDDDDDD", "E", 10, 2.2, HHHHH.bb),
            };

            grid.ItemsSource = details;
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            _tiltScrill = new(grid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _tiltScrill?.Release(grid);
        }
    }

    public record Detail(string A, bool B, bool C, string D, string E, int F, double G, HHHHH H)
    {

    }

    public enum HHHHH
    {
        aaa, bb, cccc, dddddd,
    }
}
