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

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> AllActivities = new List<Activity>();
        List<Activity> selectedActivity = new List<Activity>();
        List<Activity> filteredActivity = new List<Activity>();

        decimal selectedTotalCost = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create some Activity code
            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Land,
                Cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Air,
                Cost = 200m
            };

            //Add to list
            AllActivities.Add(l1);
            AllActivities.Add(l2);
            AllActivities.Add(l3);
            AllActivities.Add(w1);
            AllActivities.Add(w2);
            AllActivities.Add(w3);
            AllActivities.Add(a1);
            AllActivities.Add(a2);
            AllActivities.Add(a3);




            //display in listbox

            lbxProducts.ItemsSource = AllActivities;
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //figure out what is selected
            Activity selectedActivities = lbxProducts.SelectedItem as Activity;

            //null check
            if(selectedActivities != null)
            {
                // move item from left to right
                AllActivities.Remove(selectedActivities);
                selectedActivity.Add(selectedActivities);


                //refresh the screen
                refreshScreen();

                selectedTotalCost += selectedActivities.Cost;
            }

            tblkTotal.Text = selectedTotalCost.ToString();



        }

        private void refreshScreen()
        {
            lbxProducts.ItemsSource = null;
            lbxProducts.ItemsSource = AllActivities;

            lbxCarts.ItemsSource = null;
            lbxCarts.ItemsSource = selectedActivity;
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            //figure out what is selected
            Activity selectedActivities = lbxCarts.SelectedItem as Activity;

            //null check
            if (selectedActivities != null)
            {
                // move item from left to right
                AllActivities.Add(selectedActivities);
                selectedActivity.Remove(selectedActivities);

                //refresh the screen
                refreshScreen();

                selectedTotalCost -= selectedActivities.Cost;

            }
            tblkTotal.Text = selectedTotalCost.ToString();
        }

        //handles all radiobutton clicks
        private void RbAll_Click(object sender, RoutedEventArgs e)
        {
            filteredActivity.Clear();

            if(rbAll.IsChecked == true)
            {
                //show all Activites
                refreshScreen();
            }
            else if (rbLand.IsChecked == true)
            {
                //show all Land
                foreach (Activity activity in AllActivities)
                {
                    if(activity.TypeOfActivity == ActivityType.Land )
                    {
                        filteredActivity.Add(activity);
                        lbxProducts.ItemsSource = null;
                        lbxProducts.ItemsSource = filteredActivity;
                    }
                }

            }
            else if (rbWater.IsChecked == true)
            {
                //show all Water
                foreach (Activity activity in AllActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Water)
                    {
                        filteredActivity.Add(activity);
                        lbxProducts.ItemsSource = null;
                        lbxProducts.ItemsSource = filteredActivity;
                    }
                }
            }
            else if (rbAir.IsChecked == true)
            {
                //show all Air
                foreach (Activity activity in AllActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Air)
                    {
                        filteredActivity.Add(activity);
                        lbxProducts.ItemsSource = null;
                        lbxProducts.ItemsSource = filteredActivity;
                    }
                }
            }

        }

        
        private void LbxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selectedActivities = lbxProducts.SelectedItem as Activity;
            if (selectedActivities != null)
            {
                tbxDescription.Text = selectedActivities.Description;
            }

        }

        private void TbxDescription_SelectionChanged(object sender, RoutedEventArgs e)
        {
           

        }
    }
}
