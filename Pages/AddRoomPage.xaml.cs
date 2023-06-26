using Hotel.Entities.Rooms;
using Hotel.Entities.RoomTypes;
using Hotel.Enums.RoomType;
using Hotel.Helpers;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Rooms;
using Hotel.Windows.Booking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Hotel.Pages
{
    /// <summary>
    /// Interaction logic for AddRoomPage.xaml
    /// </summary>
    public partial class AddRoomPage : Page
    {
        public readonly IRoomRepository _roomRepository;

        public AddRoomPage()
        {
            InitializeComponent();
            this._roomRepository = new RoomRepository();
          


        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            var room = GetDataFromUI();
            
            var result = await _roomRepository.CreateAsync(room);
            if (result > 0)
            {
                MessageBox.Show("Successfuly");
            }
            
            

        }

        private Room GetDataFromUI()
        {
            int index = (int)cmbRoomType.SelectedIndex;
            Room room = new Room();
            room.RoomNo = short.Parse(tbRoomNo.Text);
            room.Floor = short.Parse(tbFloor.Text);

            if (index == 0) room.RoomType = "Lux";
            else if (index == 1) room.RoomType = "Delux";
            else if (index == 2) room.RoomType = "EconomClass";

            room.PricePerDay=float.Parse(tbAmount.Text);
            room.Description= new TextRange(rbDescription.Document.ContentStart, rbDescription.Document.ContentEnd).Text;
            room.CreatedAt=room.UpdatedAt = TimeHalper.GetDateTime();
            return room;
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
}
