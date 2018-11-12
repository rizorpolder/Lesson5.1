using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TPLWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");

            await TaskEx.TaskYieldAsync();

            //await Task.Delay(200);
            var result = await ComputeAsync().ConfigureAwait(false);

            Debug.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");

            await Result.Dispatcher;


            Debug.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");

            //if(Result.Dispatcher.CheckAccess())
            //{
            //    Result.Text = result;
            //}
            //else
            //Result.Dispatcher.Invoke(() =>
            //{
            //    Result.Text = result;
            //});

        }

        private static Task <string> ComputeAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Result";
            });
        }
    }
}
