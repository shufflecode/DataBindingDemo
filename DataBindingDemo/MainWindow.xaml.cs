using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DataBindingDemo.Models;

namespace DataBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _dataContextDescription;

        public MainWindow()
        {
            InitializeComponent();

            //// Die zuweisung des Context der Einfachheit halber hier im Code Behind, 
            //// sonst gerne in App.xaml oder darin eingebundenen Resource Dictionaries
            DataContext = this;

            //// Demo Daten
            Table = new TableViewModel("Model 1", new List<TableEntry>()
            {
                new TableEntry() {
                    Lenght = 1,
                    Name = "StringVar",
                    VariableType = typeof(string)
                    
                } ,
                new TableEntry() {
                    Lenght = 3,
                    Name = "intvar",
                    VariableType = typeof(int)

                }
            });

            Table2 = new TableViewModel("Model 2", new List<TableEntry>()
            {
                new TableEntry() {
                    Lenght = 2,
                    Name = "Foo",
                    VariableType = typeof(int)

                } ,
                new TableEntry() {
                    Lenght = 3,
                    Name = "bar",
                    VariableType = typeof(int)

                }
            });

            DemoTitle = "Data Binding Demo 1";


        }

        public string DemoTitle { get; set; }

        public TableViewModel Table2 { get; set; }

        public TableViewModel Table { get; set; }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var ui = sender as ContentControl;
            DataContextDescription = ui?.DataContext.ToString();
        }


        public string DataContextDescription
        {
            get { return _dataContextDescription; }
            set
            {
                _dataContextDescription = value; 
                OnPropertyChanged();
                    
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
