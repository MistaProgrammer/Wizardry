using Microsoft.EntityFrameworkCore;
using Wizardry.Data;
using Wizardry.Models;

namespace Wizardry
{
    public partial class MainPage : ContentPage
    {
        private readonly IDataManager _manager;

        public MainPage(IDataManager manager)
        {
            InitializeComponent();
            this._manager = manager;
            Peoples.ItemsSource = manager.GetAll();
            Shell.Current.Navigated += Current_Navigated;
        }

        private void Current_Navigated(object? sender, ShellNavigatedEventArgs e)
        {
            Peoples.ItemsSource = null;
            Peoples.ItemsSource = _manager.GetAll();
        }

        private async void Peoples_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int lookedForPersonID = ((Person)e.Item).Id;
            Person? lookedForPerson = _manager.GetByID(lookedForPersonID);

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
