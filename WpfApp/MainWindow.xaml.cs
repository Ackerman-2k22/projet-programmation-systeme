using System.Windows;
using Restaurant;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private RestaurantModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = new RestaurantModel();
        }

        private void AddTableButton_Click(object sender, RoutedEventArgs e)
        {
            float x = float.Parse(XTextBox.Text);
            float y = float.Parse(YTextBox.Text);
            Coordinate position = new Coordinate(x, y);
            
            int capacity = int.Parse(CapacityTextBox.Text);
            Table table = new Table(capacity,position);
            Row selectedRow = (Row)RowsComboBox.SelectedItem;
            selectedRow.AddTable(table);
        }
        
        private void AddRowButton_Click(objet sender, RoutedEventArgs e)
        {
            
            
    }
}