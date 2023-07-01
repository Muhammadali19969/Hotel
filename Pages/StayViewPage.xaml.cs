using Hotel.Components.bookings;
using Hotel.Components.Rooms;
using Hotel.Interfaces.Guests;
using Hotel.Interfaces.Rooms;
using Hotel.Interfaces.StayView;
using Hotel.Repositories.Guests;
using Hotel.Repositories.Rooms;
using Hotel.Repositories.StayViewRepository;
using Hotel.Utils;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hotel.Pages;

/// <summary>
/// Interaction logic for StayViewPage.xaml
/// </summary>
public partial class StayViewPage : Page
{
    private readonly IRoomRepository _roomRepository;
    private readonly IGuestRepository _guestRepository;
    private readonly IStayViewRepository _stayViewRepository;
    public StayViewPage()
    {
        InitializeComponent();
        this._roomRepository = new RoomRepository();
        this._guestRepository = new GuestRepository();
        this._stayViewRepository = new StayViewRepository();
    }
    

    public async Task RefreshAsync()
    {
        wrpStayView.Children.Clear();
        PagenationParams pagenationParams = new PagenationParams
        {
            PageNumber = 1,
            PageSize = 20
        };

        var views = await _stayViewRepository.GetAllAsync(pagenationParams);

        foreach (var view in views)
        {

            BookingViewUserControl bookingViewUserControl = new BookingViewUserControl();
            bookingViewUserControl.SetData(view);
            bookingViewUserControl.RefreshDelegate = RefreshAsync;
            wrpStayView.Children.Add(bookingViewUserControl);
        }
    }

    private void btnRefresh_Click(object sender, RoutedEventArgs e)
    {

    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }
}
