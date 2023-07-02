using Hotel.Entities.Rooms;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Rooms;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hotel.Components.Rooms;

/// <summary>
/// Interaction logic for RoomShowUserControl.xaml
/// </summary>
public partial class RoomShowUserControl : UserControl
{
    private readonly IRoomRepository _roomRepository;

    public Func<Task> RefreshRoomShowDelegate { get; set; }
    

    public Room ClonRoom { get; set; }
    public RoomShowUserControl()
    {
        InitializeComponent();
        this._roomRepository = new RoomRepository();
    }

    public void SetData(Room room)
    {
        ClonRoom = room;    
        tbFloor.Text=room.Floor.ToString();
        tbRoomNo.Text=room.RoomNo.ToString();
        tbRoomType.Text=room.RoomType.ToString();
        tbPrice.Text=room.PricePerDay.ToString();

    }

    private void Button_BlackList_Click(object sender, RoutedEventArgs e)
    {
        if (tbPrice.IsReadOnly == true)
        {
            tbPrice.IsReadOnly = false;
            tbPrice.Background = Brushes.White;
        }

        else
        {
            tbPrice.IsReadOnly = true;
            tbPrice.Background = Brushes.Transparent;
        }
    }

    private async void Button_Delete_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Are you sure you want to delete ?", "Information", MessageBoxButton.OKCancel, MessageBoxImage.Information, MessageBoxResult.Cancel, MessageBoxOptions.None);
        if (result == MessageBoxResult.OK)
        {
            long id = ClonRoom.Id;
            var res =_roomRepository.DeleteAsync(id);
            if(res !=null )
            {
                await RefreshRoomShowDelegate();
                MessageBox.Show("Ma'lumot o'chirildi !");

            }
        }
    }
    private async void Button_Ok_Click(object sender, RoutedEventArgs e)
    {
        if (ClonRoom.PricePerDay != float.Parse(tbPrice.Text.ToString()))
        {


            ClonRoom.PricePerDay = float.Parse(tbPrice.Text.ToString());
            long id = ClonRoom.Id;
            float price = ClonRoom.PricePerDay;
            int res = await _roomRepository.UpdatePrice(id, price);
            if (res > 0)
            {
                await RefreshRoomShowDelegate();

                MessageBox.Show("Ma'lumot o'zgartirildi !");
            }
        }

    }

    private void tbPrice_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string text = textBox.Text;
        string filteredText = Regex.Replace(text, "[^0-9]+", "");

        if (text != filteredText)
        {
            int caretIndex = textBox.CaretIndex;
            textBox.Text = filteredText;
            textBox.CaretIndex = caretIndex > 0 ? caretIndex - 1 : 0;
        }
    }
}
