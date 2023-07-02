using Hotel.Entities.Guests;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hotel.Components.BlackLists;

/// <summary>
/// Interaction logic for BlackListUserControl.xaml
/// </summary>
public partial class BlackListUserControl : UserControl
{
    public Func<Task> RefreshDelegate { get; set; }
    public BlackListUserControl()
    {
        InitializeComponent();
    }

    public void SetData(Guest guest)
    {
        lblFname.Content = guest.FirstName;
        lblLname.Content = guest.LastName;
        lblPassSeria.Content = guest.PassportSeria;
        lblPhoneNum.Content = guest.PhoneNo;
        lblPrice.Content = guest.Payme;
        lblFrom.Content = guest.StartDate;
        lblTo.Content = guest.EndDate;
    }
}
