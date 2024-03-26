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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Медицинская_лаборатория
{
    /// <summary>
    /// Логика взаимодействия для AssistantWindow.xaml
    /// </summary>
    public partial class AssistantWindow : Window
    {
        DispatcherTimer timer;
        private int _countSecond;
        public AssistantWindow()
        {
            InitializeComponent();
            _countSecond = 600;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        /// <summary>
        /// Событие тика таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            _countSecond--;
            TimerTBl.Text = string.Format("Таймер: 00:0{0}:{1}",
                _countSecond / 60, _countSecond % 60);
            if (_countSecond <= 120 && _countSecond > 0)
            {
                TimerTBl.Text = "Внимание! Осталось " +
                    _countSecond + " секунд";
                MessageBox.Show("Через 2 минуты произойдет выход" +
                    "из системы", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (_countSecond == 0)
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
                var mainWindow = new MainWindow(true);
                mainWindow.Show();
                this.Close();
            }
        }
        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
