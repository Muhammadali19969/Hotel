using Hotel.Components.Rooms;
using Hotel.Entities.Rooms;
using Hotel.Interfaces.Guests;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Guests;
using Hotel.Repositories.Rooms;
using Hotel.Utils;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hotel.Pages
{
    /// <summary>
    /// Interaction logic for ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : Page
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IGuestRepository _guestRepository;
        public ReservationPage()
        {
            InitializeComponent();
            this._roomRepository = new RoomRepository();
            this._guestRepository =  new GuestRepository();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync(); 
        }
        public async Task RefreshAsync()
        {
            wrpRooms.Children.Clear();
            PagenationParams pagenationParams = new PagenationParams
            {
                PageNumber = 1,
                PageSize = 20
            };

            var rooms = await _roomRepository.GetAllAsync(pagenationParams);

            foreach (var room in rooms)
            {

                RoomViewUserControl1 roomViewUserControl = new RoomViewUserControl1();
                roomViewUserControl.SetData(room);
                var guest = await _guestRepository.GetByGuest(room.Id);
                roomViewUserControl.SetGuestData(guest);
                roomViewUserControl.RefreshDelegate = RefreshAsync;
                wrpRooms.Children.Add(roomViewUserControl);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
