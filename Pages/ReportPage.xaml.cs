using Hotel.Components.Reports;
using Hotel.Components.Rooms;
using Hotel.Interfaces.Guests;
using Hotel.Repositories.Guests;
using Hotel.Utils;
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

namespace Hotel.Pages
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        private readonly IGuestRepository _guestRepository;
        public ReportPage()
        {
            InitializeComponent();
            this._guestRepository = new GuestRepository();
            
        }

        public async Task RefreshAsync()
        {
            stcDataGrid.Children.Clear();
            PagenationParams pagenationParams = new PagenationParams
            {
                PageNumber = 1,
                PageSize = 30
            };

            var guests = await _guestRepository.GetAllOnlyGuest(pagenationParams);
            int index = 0;
            foreach (var guest in guests)
            {

                ReportViewUserControl reportViewUserControl = new ReportViewUserControl();
                reportViewUserControl.SetData(guest,index++);
                reportViewUserControl.RefreshDelegate = RefreshAsync;
                stcDataGrid.Children.Add(reportViewUserControl);
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }
    }
}
