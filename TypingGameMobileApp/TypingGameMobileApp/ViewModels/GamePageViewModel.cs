using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TypingGameMobileApp.Helpers;
using TypingGameMobileApp.Views;
using Xamarin.Forms;

namespace TypingGameMobileApp.ViewModels
{
    public class GamePageViewModel : BindableObject
    {
		private string typedText;

		public string TypedText
        {
			get { return typedText; }
			set { typedText = value; OnPropertyChanged(); }
		}

        public GamePageViewModel()
        {
            _ = ReLoadWordAsync();
        }

        public ICommand KeyButtonClicked
        {
            get
            {
                return new Command(async (x) =>
                {
                    if (TypedText == "Type the word.....")
                    {
                        TypedText = string.Empty;
                    }

                    string alpha = x.ToString();


                    if (alpha == "space")
                    {
                        if (TypedText == CurrentWord)
                        {
                            TypedText = string.Empty;
                            TypeWordCount = TypeWordCount + 1;

                            if (TypeWordCount == TotalWordCount)
                            {
                                gameCancellationTokenSource.Cancel();
                                decimal wpm = TotalWordCount / (TimeCount * 1.0m / 60);
                                bool result = await App.Current.MainPage.DisplayAlert("", $"You wpm: {wpm.ToString("0")}. Do you want to retype?", "yes", "return to home");

                                if (result)
                                {
                                    _ = ReLoadWordAsync();
                                }
                                else
                                {
                                    await App.Current.MainPage.Navigation.PopAsync();
                                }

                                return;
                            }

                            CurrentWord = currentTypedTexts[TypeWordCount];
                            return;
                        }
                        else
                        {
                            TypedText += " ";
                        }
                    }
                    else if (alpha == "backspace")
                    {
                        if (typedText.Length == 0)
                        {
                            TypedText = "Type the word.....";
                            return;
                        }

                        TypedText = TypedText.Substring(0, TypedText.Length - 1);
                    }
                    else
                    {
                        TypedText += alpha;
                    }

                    if (TypedText.Length > CurrentWord.Length || CurrentWord.Substring(0, TypedText.Length) != TypedText)
                    {
                        TypeSpaceColor = "Red";
                    }
                    else
                    {
                        TypeSpaceColor = "Transparent";
                    }
                });
            }
        }

        public ICommand ReStartGameButtonClick 
        { 
            get
            {
                return new Command(() =>
                {
                    _ = ReLoadWordAsync();
                });
            } 
        }

        private string currentWord;

        public string CurrentWord
        {
            get { return currentWord; }
            set { currentWord = value; OnPropertyChanged(); }
        }

        private int typeWordCount;

        public int TypeWordCount
        {
            get { return typeWordCount; }
            set { typeWordCount = value; OnPropertyChanged(); }
        }

        private string typeSpaceColor;

        public string TypeSpaceColor
        {
            get { return typeSpaceColor; }
            set { typeSpaceColor = value; OnPropertyChanged(); }
        }

        public int TotalWordCount { get; set; } = 5;

        private string[] currentTypedTexts;

        private CancellationTokenSource gameCancellationTokenSource = new CancellationTokenSource();

        async Task ReLoadWordAsync()
        {
            gameCancellationTokenSource.Cancel();
            TimeCount = 0;

            TypedText = "Type the word.....";
            TypeSpaceColor = "Transparent";
            IsStarted = false;
            TypeWordCount = 0;

            for (int i = 3; i >= 0; i--)
            {
                await Task.Delay(1000);
                CurrentWord = i.ToString();
            }

            gameCancellationTokenSource = new CancellationTokenSource();
            currentGameCount++;
            currentTypedTexts = TextGeneratorHelper.RandomWords(TotalWordCount);
            CurrentWord = currentTypedTexts[TypeWordCount];

            IsStarted = true;


            await StartGame(gameCancellationTokenSource.Token, currentGameCount);
        }

        private bool isStarted;

        public bool IsStarted
        {
            get { return isStarted; }
            set { isStarted = value; OnPropertyChanged(); }
        }

        int currentGameCount = 0;
        private int timeCount;

        public int TimeCount
        {
            get { return timeCount; }
            set { timeCount = value; OnPropertyChanged(); }
        }

        async Task StartGame(CancellationToken cancellationToken, int gameCount)
        {
            if (!cancellationToken.IsCancellationRequested && gameCount == currentGameCount)
            {
                await Task.Delay(1000);
                TimeCount = TimeCount + 1;
                await StartGame(cancellationToken, gameCount);
            }
            else
            {
                TimeCount = 0;
            }
        }
    }
}
