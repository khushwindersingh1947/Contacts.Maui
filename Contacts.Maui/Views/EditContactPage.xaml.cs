using Contacts.Maui.Models;
namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
	private Models.Contact _contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

	public string ContactId 
	{ 
		set 
		{ 
			_contact = ContactRepository.GetContactById(int.Parse(value));
			if (_contact != null)
			{
				entryName.Text = _contact.Name;
				entryEmail.Text = _contact.Email;
				entryPhone.Text = _contact.Phone;
				entryAddress.Text = _contact.Address;
			}
		} 
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
		if (nameValidator.IsNotValid) 
		{
			DisplayAlert("Error", "Name is required.", "Ok");
			return;
		}

        if (emailValidator.IsNotValid)
        {
			foreach (var error in emailValidator.Errors)
			{
				DisplayAlert("Error", error.ToString(), "Ok");
				return;
			}
        }


        _contact.Name = entryName.Text;
		_contact.Email = entryEmail.Text;
		_contact.Address = entryAddress.Text;
		_contact.Phone = entryPhone.Text;

		ContactRepository.UpdateContact(_contact.ContactId, _contact);
		Shell.Current.GoToAsync("..");
    }
}