using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using People.Models;

using Xamarin.Forms;

namespace People
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            // clear the status message label on th UI
            statusMessage.Text = "Button pressed.";
            // Get the user input from the UI
            string input = newPerson.Text;
            // USe the method in the person repository to add a new person to the database using the user input
            await App.PersonRepo.AddNewPersonAsync(input); // Added await here and async to the method header
            // Update the status message on the UI with the feedback from the database create in PersonRepository.cs
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            // clear the status message label on th UI
            statusMessage.Text = "";

            // Note the changes to async below
            //List<Person> somePeople = App.PersonRepo.GetAllPeople(); 
            var people = await App.PersonRepo.GetAllPeopleAsync();
            peopleList.ItemsSource = people;

        }
    }
}
