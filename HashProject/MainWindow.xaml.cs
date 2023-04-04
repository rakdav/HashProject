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

namespace HashProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    struct TInfo
    {
        public string phone;
        public string fio;
    }
    struct THashItem
    {
        public TInfo info;
        public bool empty; // признак занятости
        public bool visit; // признак посещения
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
