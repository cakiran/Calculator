using MahApps.Metro.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalculatorView : MetroWindow
    {
        public CalculatorView()
        {
            InitializeComponent();
            CalculatorFrameViewModel calculatorFrameViewModel = new CalculatorFrameViewModel();
            this.DataContext = calculatorFrameViewModel;
        }

       
    }
}
