using Wizardry.Data;

namespace Wizardry.Pages;

public partial class NewPerson : ContentPage
{
	private readonly IPeopleManager _manager;

	public NewPerson(IPeopleManager manager)
	{
		InitializeComponent();
		this._manager = manager;
	}

    private async void Save_Clicked(object sender, EventArgs e)
    {
		string personsName = ForName.Text;
		if(personsName.Length > 3)
		{
			_manager.Save(new Models.Person { Name = personsName });
			//await Shell.Current.GoToAsync("MainPage");
			//db.Entry(db.People.First()).Reload();

			await DisplayAlert("SAVED", "Person has been saved.", "OK");

			ForName.Text = string.Empty;
		}
    }
}