using Hotel.Entities.Guests;
using Hotel.Entities.Rooms;
using Hotel.Interfaces.Guests;
using Hotel.Repositories.Guests;
using Hotel.Windows.Booking;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel.Components.Rooms;

/// <summary>
/// Interaction logic for RoomViewUserControl1.xaml
/// </summary>
public partial class RoomViewUserControl1 : UserControl
{
    private readonly IGuestRepository _guestRepository;
    public RoomViewUserControl1()
    {
        InitializeComponent();
        this._guestRepository= new GuestRepository();
    }

    public void SetGuestData(Guest guest)
    {
        if(guest != null)
        {
            lbStartDate.Content= guest.StartDate.Date;
            lbEndDate.Content = guest.EndDate.Date;
            lbGuest.Content=guest.FirstName;
        }
    }

    public void SetData(Room room)
    {
        if (room.Status == "Pending")
        {
            brBookingStatus.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("yellow"));
        }
        else if (room.Status == "Bookked")
        {
            brBookingStatus.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("red"));
        }
        else
        {
            brBookingStatus.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("green"));


        }

        lbId.Content = room.Id;
        lbFloor.Content = room.Floor;
        lbRoomNo.Content = room.RoomNo;
        lbRoomType.Content = room.RoomType;
        lbPrice.Content = room.PricePerDay;
        tbDescription.Text= room.Description;
    }

    private void grMain_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Room room = new Room();
        room.PricePerDay =float.Parse(lbPrice.Content.ToString());
        room.Id=long.Parse(lbId.Content.ToString());
        
        BookinWindow bookinWindow = new BookinWindow(room);
        bookinWindow.ShowDialog();

        



    }
}
