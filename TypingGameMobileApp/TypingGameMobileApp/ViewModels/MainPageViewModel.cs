using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TypingGameMobileApp.Views;
using Xamarin.Forms;

namespace TypingGameMobileApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        public MainPageViewModel()
        {
            
        }

        public ICommand StartButtonClicked
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new GamePage());
                });
            }
        }
    }
}
