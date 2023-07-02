using Hotel.Components.Rooms;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Rooms;
using Hotel.Utils;
using Hotel.Windows.AddRoom;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hotel.Pages;


public partial class AddRoomPage : Page
{
    public readonly IRoomRepository _roomRepository;

    public AddRoomPage()
    {
        InitializeComponent();
        this._roomRepository = new RoomRepository();
    }


    public async Task RefreshAsync()
    {
        stcRoomData.Children.Clear();
        PagenationParams pagenationParams = new PagenationParams
        {
            PageNumber = 1,
            PageSize = 30
        };

        var rooms = await _roomRepository.GetAllAsync(pagenationParams);

        foreach (var room in rooms)
        {

            RoomShowUserControl roomShowUserControl = new RoomShowUserControl();
            roomShowUserControl.SetData(room);
            roomShowUserControl.RefreshRoomShowDelegate = RefreshAsync;
            

            stcRoomData.Children.Add(roomShowUserControl);
        }
    }

    private async void Button_Add_Room_Click(object sender, RoutedEventArgs e)
    {
        AddRoom addRoom = new AddRoom();
        addRoom.ShowDialog();
        await  RefreshAsync();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }
}
