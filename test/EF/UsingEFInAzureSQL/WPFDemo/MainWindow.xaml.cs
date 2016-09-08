using System;
using System.ComponentModel;
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
            //I don't update property, so activity means the name of activity here
            _activity = _context.Activities.OrderBy(a => a.Activity1).ToList();
            _location = _context.Locations.OrderBy(lo => lo.LocationName).ToList();
            _lodging = _context.Lodgings.OrderBy(l => l.LodgingName).ToList();
            //event and activity has a many-to-many relationship
            _event = _context.Events.Include("Activities").OrderBy(ev => ev.EventID).ToList();

            activityComboBox.ItemsSource = _activity;

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

        //Save changes
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //The BindingSource coodinate user action with entities.If a user edited data on the form,the bindingsource
            //automatically pushed that change into the entity, even the related entities
            _context.SaveChanges();
        }

        private void locationComboBox_DropDownClosed(object sender, EventArgs e)
        {
            eventListBox.Items.SortDescriptions.Add(new SortDescription("Location.LocationName", ListSortDirection.Ascending));
            eventListBox.Items.SortDescriptions.Add(new SortDescription("StartDate", ListSortDirection.Descending));
        }

        //Add new event
        private void btnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity addedActivity = activityComboBox.SelectedItem as Activity;

            if(addedActivity!=null)
            {
                var addedEvent = eventListBox.SelectedItem as Event;
                if(addedEvent!=null)
                {
                    addedEvent.Activities.Add(addedActivity);
                }
            }
        }
    }
}
