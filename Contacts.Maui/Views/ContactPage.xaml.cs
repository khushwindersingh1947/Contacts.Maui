namespace Contacts.Maui.Views;
using Contacts.Maui.Models;
using System.Collections.ObjectModel;
public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadContacts();
    }



    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null) 
		{
			await Shell.Current.GoToAsync($"/{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
		}
    }

	//it runs many times
    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        ContactRepository.DeleteContact(contact.ContactId);

        LoadContacts();
    }

    private void LoadContacts() 
    {
        ObservableCollection<Contact> contacts = new(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }
}