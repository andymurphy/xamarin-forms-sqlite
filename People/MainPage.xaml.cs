using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        public void OnNewButtonClicked(object sender, EventArgs args)
        {
            // clear the status message label on th UI
            statusMessage.Text = "Button pressed.";
            // Get the user input from the UI
            string input = newPerson.Text;
            // USe the method in the person repository to add a new person to the database using the user input
            App.PersonRepo.AddNewPerson(input);
            // Update the status message on the UI with the feedback from the database create in PersonRepository.cs
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public void OnGetButtonClicked(object sender, EventArgs args)
        {
            // clear the status message label on th UI
            statusMessage.Text = "";
            // List<Person> people = App.PersonRepo.GetAllPeople();
            List<Person> somePeople = App.PersonRepo.GetSomePeople();
            peopleList.ItemsSource = somePeople;
        }
    }
}
