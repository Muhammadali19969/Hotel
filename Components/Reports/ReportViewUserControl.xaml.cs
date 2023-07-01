using Hotel.Entities.Guests;
using Hotel.Interfaces.Guests;
using Hotel.Repositories.Guests;
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

namespace Hotel.Components.Reports
{
    /// <summary>
    /// Interaction logic for ReportViewUserControl.xaml
    /// </summary>
    public partial class ReportViewUserControl : UserControl
    {
        private readonly IGuestRepository _guestRepository;
        public Guest guestCheck { get; set; }

        public Func<Task> RefreshDelegate { get; set; }

        public ReportViewUserControl()
        {
            InitializeComponent();
            this._guestRepository = new GuestRepository();
        }

        public void SetData(Guest guest,int index)
        {
            guestCheck = guest;
            if (index % 2 == 0)
            {
                brGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F2D8D8"));
            }
            if (guest.BlackList)
            {
                Path path = new Path();
                path.Data =Geometry.Parse("M7.77,20.589a3.012,3.012,0,0,1-2.137-.883L0,14.073l1.424-1.425,5.633,5.633a1.008,1.008,0,0,0,1.425,0L22.576,4.187,24,5.612,9.906,19.706A3.01,3.01,0,0,1,7.77,20.589Z");
                path.Fill = Brushes.Black;
                brCheck.Child = path;
            }
            lblFname.Content = guest.FirstName;
            lblLname.Content = guest.LastName;
            lblPassSeria.Content = guest.PassportSeria;
            lblPhoneNum.Content = guest.PhoneNo;
            lblFrom.Content = guest.StartDate;
            lblTo.Content = guest.EndDate;
            lblPrice.Content = guest.Payme;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_BlackList_Click(object sender, RoutedEventArgs e)
        {
            long id = guestCheck.Id;
            MessageBoxResult result = MessageBox.Show("Rostan ham o'chirishni hohlaysizmi?", "Information", MessageBoxButton.OKCancel, MessageBoxImage.Information, MessageBoxResult.Cancel, MessageBoxOptions.None);
            if (result == MessageBoxResult.OK)
            {
                var r =  _guestRepository.DeleteAsync(id);
                await RefreshDelegate();

            }
        }
    }
}
