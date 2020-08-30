using EZChange.Models;
using EZChange.Models.TcpSocket;
using EZChange.Services_;
using EZChange.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace EZChange.ViewModels
{
    class IngredientsViewModel : BaseViewModel
    {
        public IngredientsViewModel(IPageService pageService) : base(pageService)
        {
            #region GenerateDummyIngredients
            var indg1 = new Ingredient { Name = "Wodka", ActualAmount = 120 };
            var indg2 = new Ingredient { Name = "Jim Beam", ActualAmount = 500 };
            var indg3 = new Ingredient { Name = "Blue Curacao", ActualAmount = 120 };
            var indg4 = new Ingredient { Name = "Chivas", ActualAmount = 50 };
            var indg5 = new Ingredient { Name = "Pepsi", ActualAmount = 250 };
            var indg6 = new Ingredient { Name = "Sok", ActualAmount = 1900 };
            #endregion

            Ingredients = new ObservableCollection<Ingredient>() { indg1, indg2, indg3, indg4, indg5, indg6 };

            IngredientsUnfilter = Ingredients;

            ShowIngredientDetailPageCommand = new Command<Ingredient>(vm => ShowIngredientDetailPage(vm));
            DisplaySortByOptionsCommand = new Command(DisplaySordByOptions);
            DisplaySettingsPageCommand = new Command(DisplaySettingsPage);
            RefreshIngredientsListCommand = new Command(RefreshIngredientsList);
            TextChangedInSearchBarCommand = new Command<string>(TextChangedInSearchBar);
        }

        public string Title => "Amounts list";

        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get => _ingredients;
            private set => SetValue(ref _ingredients, value);
        }

        public ObservableCollection<Ingredient> IngredientsUnfilter { get; set; }

        private string searchBarText;

        public string SearchBarText
        {
            get { return searchBarText; }
            set
            {
                searchBarText = value;
                TextChangedInSearchBar(value);
            }
        }


        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetValue(ref _isRefreshing, value); }
        }

        public ICommand ShowIngredientDetailPageCommand { get; private set; }
        public ICommand DisplaySortByOptionsCommand { get; private set; }
        public ICommand RefreshIngredientsListCommand { get; private set; }
        public ICommand DisplaySettingsPageCommand { get; private set; }
        public ICommand TextChangedInSearchBarCommand { get; private set; }

        private void ShowIngredientDetailPage(Ingredient ingredient)
        {
            base._pageService.PushAsync(
                new IngredientsDetailsPage(
                    new IngredientsDetailPageViewModel(
                        ingredient, base._pageService)));
        }

        private ObservableCollection<Ingredient> Sort(
            ObservableCollection<Ingredient> ingredients, string key)
        {
            return new ObservableCollection<Ingredient>(
                ingredients.OrderBy(a => a.GetType().GetProperty(key).GetValue(a, null)).
                ToList());
        }

        private async void DisplaySordByOptions()
        {
            PropertyInfo[] props = typeof(Ingredient).GetProperties();
            List<string> tempProps = new List<string>();

            foreach (var prop in props)
            {
                tempProps.Add(prop.Name);
            }

            var propsToDisplay = tempProps.ToArray();
            var response = await _pageService.DisplayActionSheet("Sort by", "Cancel", null, propsToDisplay);
            if (response != "Cancel")
            {
                Ingredients = Sort(Ingredients, response);
            }
        }

        private async void DisplaySettingsPage()
        {
            await _pageService.PushAsync(new SettingsPage());
        }

        private void RefreshIngredientsList()
        {
            var request = new TcpSocketRequest
            {
                TcpRequestType = TcpRequestType.GetIngredientAmount,
                Target = "All",
                Value = 0,
            };

            try
            {
                TcpSocketService.Send(request);
                Ingredients = new ObservableCollection<Ingredient>(
                    TcpSocketService.GetResponse<IEnumerable<Ingredient>>());
                IngredientsUnfilter = Ingredients;
            }
            catch (Exception e)
            {
                _pageService.DisplayAlert("Erro", e.Message.ToString(), "Ok");
            }

            IsRefreshing = false;
        }

        private void TextChangedInSearchBar(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Ingredients = new ObservableCollection<Ingredient>(
                    IngredientsUnfilter.Where(x => x.Name.StartsWith(input)));
            }
            else
            {
                Ingredients = IngredientsUnfilter;
            }
        }
    }
}
