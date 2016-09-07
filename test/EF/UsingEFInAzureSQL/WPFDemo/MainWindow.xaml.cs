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
using UsingEFInAzureSQL;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BreakAwayEntities _context;
        private List<Activity> _activity;
        private List<Location> _location;
        private List<Lodging> _lodging;
        private List<Event> _event;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context = new BreakAwayEntities();
            _activity = _context.Activities.OrderBy(a => a.ActivityID).ToList();
            _location = _context.Locations.OrderBy(lo => lo.LocationName).ToList();
            _lodging = _context.Lodgings.OrderBy(l => l.LodgingName).ToList();
            _event = _context.Events.OrderBy(ev => ev.EventID).ToList();

            System.Windows.Data.CollectionViewSource locationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("locationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // locationViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource lodgingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lodgingViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // lodgingViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource eventViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("eventViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // eventViewSource.Source = [generic data source]
            locationViewSource.Source = _location;
            lodgingViewSource.Source = _lodging;
            eventViewSource.Source = _event;
        


        }
    }
}
