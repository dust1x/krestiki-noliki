using System.Windows.Controls;
using System.Windows;
using System;

namespace fifteen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int XWins { get; set; }
        public int OWins { get; set; }
        private bool IsButtonEnabled = true;
        string X = "X";
        string O = "O";

        static int count = 0;
        static int draw = 0;
        string[,] values = new string[3, 3];
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            XWins = 0;
            OWins = 0;
            foreach (UIElement c in LayoutGrid.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            draw++;
            count++;
            if (count % 2 != 0)
            {
                ((Button)e.OriginalSource).Content = "X";
                ((Button)e.OriginalSource).IsEnabled = false;
            }
            else
            {
                ((Button)e.OriginalSource).Content = "O";
                ((Button)e.OriginalSource).IsEnabled = false;
            }
            int x = IsWin();

            switch (x)
            {
                case 1:
                    MessageBox.Show("Игрок за крестик победил!");
                    XWins++;                  
                    break;
                case 2:
                    MessageBox.Show("Игрок за нолик победил!");
                    OWins++;
                    break;

                case 3:
                    MessageBox.Show("Ничья");
                    IsButtonEnabled = false;
                    break;
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            draw = 0;
            foreach (UIElement c in LayoutGrid.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Content = "";
                    ((Button)c).IsEnabled = true;
                }
            }
        }
        private int IsWin()
        {
            UIElement element = new UIElement();

            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    element = GetChildren(LayoutGrid, i, j);
                    if (element is Button)
                        values[i - 1, j] = ((Button)element).Content.ToString();
                }
            }




            if ((X == button0.Content.ToString()) && (X == button1.Content.ToString()) && (X == button2.Content.ToString()))
                return 1;
            else if ((X == button0.Content.ToString()) && (X == button3.Content.ToString()) && (X == button6.Content.ToString()))
                return 1;
            else if ((X == button6.Content.ToString()) && (X == button7.Content.ToString()) && (X == button8.Content.ToString()))
                return 1;
            else if ((X == button2.Content.ToString()) && (X == button5.Content.ToString()) && (X == button8.Content.ToString()))
                return 1;
            else if ((X == button0.Content.ToString()) && (X == button4.Content.ToString()) && (X == button8.Content.ToString()))
                return 1;
            else if ((X == button2.Content.ToString()) && (X == button4.Content.ToString()) && (X == button6.Content.ToString()))
                return 1;
            else if ((X == button1.Content.ToString()) && (X == button4.Content.ToString()) && (X == button7.Content.ToString()))
                return 1;
            else if ((X == button3.Content.ToString()) && (X == button4.Content.ToString()) && (X == button5.Content.ToString()))
                return 1;

            if ((O == button0.Content.ToString()) && (O == button1.Content.ToString()) && (O == button2.Content.ToString()))
                return 2;
            else if ((O == button0.Content.ToString()) && (O == button3.Content.ToString()) && (O == button6.Content.ToString()))
                return 2;
            else if ((O == button6.Content.ToString()) && (O == button7.Content.ToString()) && (O == button8.Content.ToString()))
                return 2;
            else if ((O == button2.Content.ToString()) && (O == button5.Content.ToString()) && (O == button8.Content.ToString()))
                return 2;
            else if ((O == button0.Content.ToString()) && (O == button4.Content.ToString()) && (O == button8.Content.ToString()))
                return 2;
            else if ((O == button2.Content.ToString()) && (O == button4.Content.ToString()) && (O == button6.Content.ToString()))
                return 2;
            else if ((O == button1.Content.ToString()) && (O == button4.Content.ToString()) && (O == button7.Content.ToString()))
                return 2;
            else if ((O == button3.Content.ToString()) && (O == button4.Content.ToString()) && (O == button5.Content.ToString()))
                return 2;

            else if (draw == 9)
                return 3;

            else return 0;

        }

        private static UIElement GetChildren(Grid grid, int row, int column)
        {

            foreach (UIElement child in grid.Children)
            {
                if (Grid.GetRow(child) == row & Grid.GetColumn(child) == column)
                {
                    return child;

                }
            }
            return null;
        }
    }
}