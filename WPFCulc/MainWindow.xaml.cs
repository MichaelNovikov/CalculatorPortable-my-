using CalculatorPortable;
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

namespace WPFCulc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalcPresenter calcPresenter;
        Label display;
        Label opLabel;

        public MainWindow()
        {
            InitializeComponent();

            calcPresenter = new CalcPresenter(new Validator(), new FuncSelector(new Calculator()));

            display = App.Current.MainWindow.FindName("mainLabel") as Label;
            opLabel = App.Current.MainWindow.FindName("operatorLabel") as Label;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string textV = display.Content.ToString(),  textVOp = opLabel.Content.ToString();

            calcPresenter.Present(ref textV, ref textVOp, b.Content.ToString());

            display.Content = textV;
            opLabel.Content = textVOp;
        }
    }
}
