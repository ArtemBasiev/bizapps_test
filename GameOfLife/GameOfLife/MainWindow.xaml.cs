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
using System.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GetGameField GridWithLife;
        public int AutoGenFlag = 0;
        public int GenCount = 1;
        public MainWindow()
        {
            InitializeComponent();

           GridWithLife = new GetGameField();
            this.PlayingGrid.Children.Add(GridWithLife);
            this.GenerationCountLabel.Content = GenCount.ToString();

        }
        private void ButtonNextGen_Click(object sender, RoutedEventArgs e)
        {
            this.GridWithLife.NextGeneration();
            GenCount++;
            GenerationCountLabel.Content = GenCount.ToString();
        }

        private void AutoGeneration_Click(object sender, RoutedEventArgs e)
        {
            ButtonClear.IsEnabled = false;
            AutoGeneration.IsEnabled = false;
            new Thread(() =>
            {
                AutoGenFlag = 1;
                while (AutoGenFlag == 1)
                {
                    this.GridWithLife.NextGeneration();
                    GenCount++;
                    Action action = () =>
                    {

                        GenerationCountLabel.Content = GenCount.ToString();

                    };

                    this.Dispatcher.Invoke(action);
                    Thread.Sleep(100);
                  

                }
            }).Start();
            
          

        }

        private void StopAutoGeneration_Click(object sender, RoutedEventArgs e)
        {

            AutoGenFlag = 0;
            AutoGeneration.IsEnabled = true;
            ButtonClear.IsEnabled = true;
    
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            GridWithLife.ClearField();
            GenCount = 1;
            GenerationCountLabel.Content = GenCount.ToString();
                

        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Для расстановки одиночных клеток используйте клик левой кнопки мыши. Если необходимо нарисовать несколько клеток, удерживая правую кнопку мыши, ведите курсор по игровому полю.");
        }
      
    }
}
