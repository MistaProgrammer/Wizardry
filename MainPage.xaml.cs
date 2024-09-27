using Microsoft.EntityFrameworkCore;
using Wizardry.Data;
using Wizardry.Models;

namespace Wizardry
{
    public partial class MainPage : ContentPage
    {
        private readonly ICarsManager _carManager;
        private readonly IPeopleManager _peopleManager;

        public MainPage(ICarsManager carsManager, IPeopleManager peopleManager)
        {
            InitializeComponent();
            _carManager = carsManager;
            _peopleManager = peopleManager;
            Peoples.ItemsSource = peopleManager.GetAll();
            Shell.Current.Navigated += Current_Navigated;
        }

        private void Current_Navigated(object? sender, ShellNavigatedEventArgs e)
        {
            Peoples.ItemsSource = null;
            Peoples.ItemsSource = _peopleManager.GetAll();
        }

        private async void Peoples_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int lookedForPersonID = ((Person)e.Item).Id;
            Person? lookedForPerson = _peopleManager.GetByID(lookedForPersonID);

            string cars = string.Empty;

            if (lookedForPerson.Cars != null)
            {
                foreach (Car c in lookedForPerson.Cars)
                {
                    cars += $"{c.Brand}, {c.Model}\n";
                }

                await DisplayAlert($"{lookedForPerson.Name}", cars, "OK");
            }
            else
            {
                await DisplayAlert($"{lookedForPerson.Name}", "Broke ass bum", "OK");
            }
        }
    }

}
