using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DataBindingDemo.Controls
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl
    {
        public static readonly DependencyProperty TableProperty = DependencyProperty.Register("Table", typeof(object), typeof(TableView), new PropertyMetadata(default(object)));

        public TableView()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;

        }


        public object Table
        {
            get { return (object) GetValue(TableProperty); }
            set { SetValue(TableProperty, value); }
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var control = (FrameworkElement) sender;
            if (control == null) return;

            var main = DataContext as MainWindow;
            if (main != null)
                main.DataContextDescription = control?.DataContext.ToString();
        }
    }
}
