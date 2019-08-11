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

namespace Form1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() // конструктор
        {
            InitializeComponent();
            new Presenter(this); // в Presenter передаємо силку на себе, щоб Presenter міг
                                 //  зв'язати нашу подію з тими методами оброблювачими що в ньому є
        }
        private EventHandler toHrnEvent = null; // поле яке зберігає посилання на метод-оброблювач

        public event EventHandler ToHrnEvent
        {
            add { toHrnEvent += value; }
            remove { toHrnEvent -= value; }
        }
        // при натиснесні на відповідно кнопку, буде викликатись відповідна подія, яка ініціює відповідний метод, лежачий в оброблювачах
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            toHrnEvent.Invoke(sender, e);
        }  
    }
}
