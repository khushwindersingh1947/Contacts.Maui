using Contacts.Maui.Models;
using System.Security.Cryptography;

namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void contactCtrl_OnSave(object sender, EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact { 
            Name = contactCtrl.Name,
            Phone = contactCtrl.Phone,
            Email = contactCtrl.Email,
            Address = contactCtrl.Address
        });
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

        private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}