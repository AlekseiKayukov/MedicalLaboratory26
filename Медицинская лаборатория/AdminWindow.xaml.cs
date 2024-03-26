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
using Медицинская_лаборатория.Data;

namespace Медицинская_лаборатория
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MedicalLaboratoryEntities DB = new MedicalLaboratoryEntities();
        DispatcherTimer timer;
        private int _countSecond;
        public AdminWindow()
        {
            InitializeComponent();
            HistoryLV.ItemsSource = DB.HistoryEnter.ToList();
            FilteringLogin.ItemsSource = DB.HistoryEnter
                .Select(i => i.User.Login).Distinct().ToList();
            _countSecond = 600;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        /// <summary>
        /// Запуск таймера
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
        /// <summary>
        /// Сортировка по дате
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortingDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable<HistoryEnter> sortedEquipment;
            if (SortingDate.SelectedIndex == 0)
            {
                sortedEquipment = DB.HistoryEnter.OrderByDescending(u => u.Date);
            }
            else
            {
                if (SortingDate.SelectedIndex == 1)
                {
                    sortedEquipment = DB.HistoryEnter.OrderBy(u => u.Date);
                }
                else
                {
                    sortedEquipment = DB.HistoryEnter;
                }
            }
            HistoryLV.ItemsSource = sortedEquipment.ToList();
        }

        private void FilteringLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HistoryLV.ItemsSource = DB.HistoryEnter.Where
               (r => r.User.Login == FilteringLogin.SelectedItem.ToString()).ToList();
        }
    }
}
