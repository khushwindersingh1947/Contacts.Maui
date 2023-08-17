namespace Contacts.Maui.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
	}

    private void btnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void btnEditContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }

}