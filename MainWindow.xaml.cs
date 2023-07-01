using Hotel.Pages;
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

namespace Hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DashboardPage dashboardPage = new DashboardPage();
            PageNavigator.Content = dashboardPage;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void bntMaximize_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState==WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState= WindowState.Minimized;
        }

        private void brDragable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void rbAddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoomPage addRoomPage = new AddRoomPage();
            PageNavigator.Content=addRoomPage;
            

        }

        private void rbDashboard_Click(object sender, RoutedEventArgs e)
        {
            DashboardPage dashboardPage = new DashboardPage();  
            PageNavigator.Content=dashboardPage;
        }

        private void rbReservation_Click(object sender, RoutedEventArgs e)
        {
            
            ReservationPage reservationPage = new ReservationPage();
            PageNavigator.Content = reservationPage;
        }

        private void PageNavigator_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void rbEmptyRooms_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rbStayView_Click(object sender, RoutedEventArgs e)
        {
            StayViewPage stayViewPage = new StayViewPage();
            PageNavigator.Content = stayViewPage;
        }

        private void rbReport_Click(object sender, RoutedEventArgs e)
        {
            ReportPage reportPage = new ReportPage();
            PageNavigator.Content = reportPage;
        }
    }
    
    }

