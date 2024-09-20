using Wizardry.Data;

namespace Wizardry.Pages;

public partial class NewPerson : ContentPage
{
	private readonly ContextDb db;

	public NewPerson(ContextDb db)
	{
		InitializeComponent();
		this.db = db;
	}

    private async void Save_Clicked(object sender, EventArgs e)
    {
		string personsName = ForName.Text;
		if(personsName.Length > 3)
		{
			db.People.Add(new Models.Person { Name = personsName });
			db.SaveChanges();
			//await Shell.Current.GoToAsync("MainPage");
			//db.Entry(db.People.First()).Reload();

			await DisplayAlert("SAVED", "Person has been saved.", "OK");

			ForName.Text = string.Empty;
		}
    }
}