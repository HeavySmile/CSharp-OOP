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
using AngouriMath;

namespace Task_1
{
    /// <summary>
    /// Static class for math expression storage for further usage
    /// </summary>
    public static class MemoryStore
    {
        private static string memorizedString;

        public static string MemorizedString
        {
            get { return memorizedString; }
            set { memorizedString = value; }
        }
    }

    /// <summary>
    /// Enum type for operations
    /// </summary>
    // Not really needed considering my implementation
    public enum Operations
    {
        Addition = '+',
        Subtraction = '-',
        Multiplication = 'x',
        Division = '/',
        Exp,
        Sin,
        Cos,
        SquareRoot,
        Log,
        Dec,
        MemoryStore,
        MemoryClear,
        MemoryAdd,
        MemorySubtract
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds digit to displayBar depending on a sender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (displayBar.Text == "0") displayBar.Text = button.Content.ToString();
            else displayBar.Text += button.Content;
        }
        /// <summary>
        /// Adds operator to displayBar depending on a sender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            displayBar.Text += button.Content;
        }
        /// <summary>
        /// Parses current math expression in displayBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            string buffer = displayBar.Text.Replace((char)Operations.Multiplication, '*');

            // AngouriMath NuGet Package allows to parse math expressions containing multiple operations
            Entity expr = buffer;
            displayBar.Text = ((double)expr.EvalNumerical()).ToString();
        }
        /// <summary>
        /// Clears displayBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            displayBar.Text = "0";
        }
        /// <summary>
        /// Clears last action in display bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClearLast_Click(object sender, RoutedEventArgs e)
        {
            if (displayBar.Text.Length == 0 || displayBar.Text.Length == 1) displayBar.Text = "0";
            else displayBar.Text = displayBar.Text.Remove(displayBar.Text.Length - 1, 1);
        }
        /// <summary>
        /// Executes exponent function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExp_Click(object sender, RoutedEventArgs e)
        {
            EqualButton_Click(sender, e);
            displayBar.Text = Math.Exp(Double.Parse(displayBar.Text)).ToString();
        }
        /// <summary>
        /// Executes sin function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSin_Click(object sender, RoutedEventArgs e)
        {
            EqualButton_Click(sender, e);
            displayBar.Text = Math.Sin(Double.Parse(displayBar.Text)).ToString();
        }
        /// <summary>
        /// Executes cos function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCos_Click(object sender, RoutedEventArgs e)
        {
            EqualButton_Click(sender, e);
            displayBar.Text = Math.Cos(Double.Parse(displayBar.Text)).ToString();
        }
        /// <summary>
        /// Executes square root function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            EqualButton_Click(sender, e);
            displayBar.Text = Math.Sqrt(Double.Parse(displayBar.Text)).ToString();
        }
        /// <summary>
        /// Executes logarithm function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLog_Click(object sender, RoutedEventArgs e)
        {
            EqualButton_Click(sender, e);
            displayBar.Text = Math.Log(Double.Parse(displayBar.Text)).ToString();
        }
        /// <summary>
        /// Executes 1/x function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDec_Click(object sender, RoutedEventArgs e)
        {
            EqualButton_Click(sender, e);
            displayBar.Text = (1 / Double.Parse(displayBar.Text)).ToString();
        }
        /// <summary>
        /// Stores current displayBard content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMemoryStore_Click(object sender, RoutedEventArgs e)
        {
            EqualButton_Click(sender, e);
            MemoryStore.MemorizedString = displayBar.Text;
        }
        /// <summary>
        /// Recalls stored content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMemoryRecall_Click(object sender, RoutedEventArgs e)
        {
            if (MemoryStore.MemorizedString != "") displayBar.Text = MemoryStore.MemorizedString;
        }
        /// <summary>
        /// Clears stored content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMemoryClear_Click(object sender, RoutedEventArgs e)
        {
            MemoryStore.MemorizedString = "";
        }
        /// <summary>
        /// Adds current displayBar content to stored one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMemoryAdd_Click(object sender, RoutedEventArgs e)
        {
            EqualButton_Click(sender, e);
            string buffer = MemoryStore.MemorizedString + Operations.Addition + displayBar.Text;

            Entity expr = buffer;
            MemoryStore.MemorizedString = ((double)expr.EvalNumerical()).ToString();
        }
        /// <summary>
        /// Substracts current displayBar content from stored one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMemorySubstract_Click(object sender, RoutedEventArgs e)
        {
            EqualButton_Click(sender, e);
            string buffer = MemoryStore.MemorizedString + Operations.Subtraction + displayBar.Text;

            Entity expr = buffer;
            MemoryStore.MemorizedString = ((double)expr.EvalNumerical()).ToString();
        }
        /// <summary>
        /// Exits application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOff_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
