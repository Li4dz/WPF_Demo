using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using WPF_Demo.View.Interface;
using WPF_Demo.ViewModel;
using WPF_Demo.ViewModel.Interface;

namespace WPF_Demo
{
    [Export(typeof(IRegistroPersonaView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class MainWindow : Window
    {
        RegistroPersonaViewModel oRegistroPersonaViewModel;
        public MainWindow()
        {
            InitializeComponent();
            oRegistroPersonaViewModel = new RegistroPersonaViewModel();
            this.DataContext = oRegistroPersonaViewModel;
        }

        [Import]
        IRegistroPersonaViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

    }
}
