using Hotel.Interfaces.StayView;
using Hotel.Repositories.StayViewRepository;
using Hotel.ViewModels.Bookings;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hotel.Components.bookings;

/// <summary>
/// Interaction logic for BookingViewUserControl.xaml
/// </summary>
public partial class BookingViewUserControl : UserControl
{
    public BookingView booking { get; set; }

    public Func<Task> RefreshDelegate { get; set; }

    private readonly IStayViewRepository _stayViewRepository;
    public BookingViewUserControl()
    {
        InitializeComponent();
        this._stayViewRepository = new StayViewRepository();
    }
    public void SetData(BookingView view)
    {
        lbRoomType.Content=view.RoomType;
        lblFirstName.Content = view.FirstName;
        lblLastName.Content = view.LastName;
        lblPhoneNo.Content = view.PhoneNum;
        lblAmount.Content = view.Payme;
        lblRoomNumber.Content = view.RoomNo;
        lblFrom.Content = view.StartDate;
        lblTo.Content = view.EndDate;
        lblId.Content=view.Id;
        booking = view;
    }

    private async void Payme_Click(object sender, RoutedEventArgs e)
    {
        long id = booking.Id;
        long guest_id = booking.GuestId;
        var result_room = await _stayViewRepository.DeleteAsync(id);
        var result_guest = await _stayViewRepository.SetGuest(guest_id);
        await RefreshDelegate();
    }
}
