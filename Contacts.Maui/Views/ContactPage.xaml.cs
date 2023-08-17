namespace Contacts.Maui.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();

		List<Contact> contacts = new() { 
			new Contact {Name="John Doe", Email="aoe@email.com"},
			new Contact {Name="Jahn Aoe", Email="boe@email.com"},
			new Contact {Name="Jehn Boe", Email="coe@email.com"},
			new Contact {Name="Jrhn Coe", Email="doe@email.com"}
		};

		listContacts.ItemsSource = contacts;
	}

	public class Contact 
	{
		public string Name { get; set; }
		public string Email { get; set; }

	}

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null) 
		{
			await Shell.Current.GoToAsync(nameof(EditContactPage));
		}
    }

	//it runs many times
    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }
}