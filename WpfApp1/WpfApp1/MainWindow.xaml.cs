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
            var source = PresentationSource.FromVisual(grid);
            ((HwndSource)source)?.AddHook(Hook);
        }

        const int WM_MOUSEHWHEEL = 0x020E;

        private IntPtr Hook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_MOUSEHWHEEL:
                    int tilt = (short)HIWORD(wParam);
                    OnMouseTilt(tilt);
                    return (IntPtr)1;
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// Gets high bits values of the pointer.
        /// </summary>
        private static int HIWORD(IntPtr ptr)
        {
            unchecked
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    var val64 = ptr.ToInt64();
                    return (short)((val64 >> 16) & 0xFFFF);
                }
                var val32 = ptr.ToInt32();
                return (short)((val32 >> 16) & 0xFFFF);
            }
        }

        /// <summary>
        /// Gets low bits values of the pointer.
        /// </summary>
        private static int LOWORD(IntPtr ptr)
        {
            unchecked
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    var val64 = ptr.ToInt64();
                    return (short)(val64 & 0xFFFF);
                }

                var val32 = ptr.ToInt32();
                return (short)(val32 & 0xFFFF);
            }
        }

        private void OnMouseTilt(int tilt)
        {
            if (Mouse.DirectlyOver is not UIElement element) return;

            ScrollViewer scrollViewer = element is ScrollViewer viewer ? viewer : FindParent<ScrollViewer>(element);

            if (scrollViewer == null)
                return;

            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + tilt);
        }

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject is T parent)
                return parent;
            else
                return FindParent<T>(parentObject);
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
