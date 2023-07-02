using Hotel.Pages;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Hotel;

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

    private void rbDashboard_Click(object sender, RoutedEventArgs e)
    {
        rbSettings.IsChecked = false;
        DashboardPage dashboardPage = new DashboardPage();  
        PageNavigator.Content=dashboardPage;
    }

    private void rbReservation_Click(object sender, RoutedEventArgs e)
    {
        rbSettings.IsChecked = false;
        ReservationPage reservationPage = new ReservationPage();
        PageNavigator.Content = reservationPage;
    }

    private void PageNavigator_Navigated(object sender, NavigationEventArgs e)
    {

    }

    
    private void rbStayView_Click(object sender, RoutedEventArgs e)
    {
        rbSettings.IsChecked = false;
        StayViewPage stayViewPage = new StayViewPage();
        PageNavigator.Content = stayViewPage;
    }

    private void rbReport_Click(object sender, RoutedEventArgs e)
    {
        rbSettings.IsChecked = false;
        ReportPage reportPage = new ReportPage();
        PageNavigator.Content = reportPage;
    }

   

    private void rbBlackList_Click(object sender, RoutedEventArgs e)
    {
        rbSettings.IsChecked = false;
        BlackListPage1 blackListPage1 = new BlackListPage1();
        PageNavigator.Content = blackListPage1;
    }

    private void rbSettings_Click(object sender, RoutedEventArgs e)
    {
        rbDashboard.IsChecked = false;
        rbReservation.IsChecked = false;
        rbStayView.IsChecked = false;
        rbBlackList.IsChecked = false;
        rbReport.IsChecked = false;
        rbAbout.IsChecked = false;
        AddRoomPage addRoomPage = new AddRoomPage();
        PageNavigator.Content = addRoomPage;
    }

    private void rbAbout_Click(object sender, RoutedEventArgs e)
    {
        rbSettings.IsChecked = false;
        AboutPage aboutPage = new AboutPage();
        PageNavigator.Content = aboutPage;
    }

    

}
