using Hotel.Entities.Rooms;
using Hotel.Helpers;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Rooms;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Hotel.Windows.AddRoom;

/// <summary>
/// Interaction logic for AddRoom.xaml
/// </summary>
public partial class AddRoom : Window
{
    public Func<Task> CreateRefreshDelegate { get; set; }
    private readonly IRoomRepository _roomRepository;


    public AddRoom()
    {
        InitializeComponent();
        _roomRepository = new RoomRepository();
    }

    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
        var room = GetDataFromUI();
        if(room != null )
        {
            var result = await _roomRepository.CreateAsync(room);
            if (result > 0)
            {
                MessageBox.Show("Successfuly");
            }
        }
        else
        {
            MessageBox.Show("Ma'lumot to'liq kiritilmadi !");
        }

    }

    private Room? GetDataFromUI()
    {
        int index = (int)cmbRoomType.SelectedIndex;
        Room room = new Room();
        if (index == -1 || tbAmount.Text.Length == 0 || tbFloor.Text.Length == 0 || tbRoomNo.Text.Length == 0) 
        {
            return null;
        }
        else
        {
            room.RoomNo = short.Parse(tbRoomNo.Text);
            room.Floor = short.Parse(tbFloor.Text);

            if (index == 0) room.RoomType = "Lux";
            else if (index == 1) room.RoomType = "Delux";
            else if (index == 2) room.RoomType = "EconomClass";

            room.PricePerDay = float.Parse(tbAmount.Text);
            room.Description = new TextRange(rbDescription.Document.ContentStart, rbDescription.Document.ContentEnd).Text;
            room.CreatedAt = room.UpdatedAt = TimeHalper.GetDateTime();
            return room;
        }
        
    }

    private void tbRoomNo_TextChanged(object sender, TextChangedEventArgs e)
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

    private void tbFloor_TextChanged(object sender, TextChangedEventArgs e)
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

    private void tbAmount_TextChanged(object sender, TextChangedEventArgs e)
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
