using Wizardry.Data;
using Wizardry.Models;

namespace Wizardry.Pages;

public partial class NewCar : ContentPage
{
	private readonly ICarsManager _carManager;
    private readonly IPeopleManager _peopleManager;

    public NewCar(ICarsManager carsManager, IPeopleManager peopleManager)
	{
		InitializeComponent();

		_carManager = carsManager;
        _peopleManager = peopleManager;

		forFuel.ItemsSource = (System.Collections.IList)Enum.GetValues(typeof(Fuel)).Cast<Fuel>();

		forUser.ItemsSource = (System.Collections.IList)_peopleManager.GetAll();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		forUser.ItemsSource = null;
        forUser.ItemsSource = (System.Collections.IList)_peopleManager.GetAll();
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        _carManager.Save(new Car { Brand = forBrand.Text, Model = forModel.Text, Fuel = (Fuel)forFuel.SelectedItem, Driver = (Person)forUser.SelectedItem });

        DisplayAlert($"{((Person)forUser.SelectedItem).Name}'s new car has been saved.", forBrand.Text + " " + forModel.Text, "OK");
    }
}