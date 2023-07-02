using Hotel.Components.BlackLists;
using Hotel.Components.Reports;
using Hotel.Interfaces.Guests;
using Hotel.Repositories.Guests;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
    /// Interaction logic for BlackListPage1.xaml
    /// </summary>
    public partial class BlackListPage1 : Page
    {
        private readonly IGuestRepository _guestRepository;
        public BlackListPage1()
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

            var guests = await _guestRepository.GetBlackList(pagenationParams);
            foreach (var guest in guests)
            {

                BlackListUserControl blackListUserControl = new BlackListUserControl();
                blackListUserControl.RefreshDelegate = RefreshAsync;
                blackListUserControl.SetData(guest);
                stcDataGrid.Children.Add(blackListUserControl);
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }
    }
}
