using EZChange.Models;
using EZChange.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EZChange.ViewModels
{
    class IngredientsViewModel : BaseViewModel
    {
        public IngredientsViewModel()
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

            ShowIngredientDetailPageCommand = new Command<Ingredient>(vm => ShowIngredientDetailPage(vm));
            DisplaySortByOptionsCommand = new Command(DisplaySordByOptions);
        }

        public IngredientsViewModel(IPageService pageService) : this()
        {
            _pageService = pageService;
        }

        private IPageService _pageService;
        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get => _ingredients;
            private set => SetValue(ref _ingredients, value);
        }

        public ICommand ShowIngredientDetailPageCommand { get; private set; }
        public ICommand DisplaySortByOptionsCommand { get; private set; }

        private void ShowIngredientDetailPage(Ingredient ingredient)
        {
            _pageService.PushAsync(new IngredientsDetailsPage(ingredient));
        }

        private void SortIngredientsBy(string key)
        {
            Ingredients = new ObservableCollection<Ingredient>(
                Ingredients.OrderBy(a => a.GetType().GetProperty(key).GetValue(a, null)).
                ToList());
        }

        private async void DisplaySordByOptions()
        {
            PropertyInfo[] props = typeof(Ingredient).GetProperties();
            List<string> tempProps = new List<string>();

            foreach(var prop in props)
            {
                tempProps.Add(prop.Name);
            }

            var propsToDisplay = tempProps.ToArray();
            var response = await _pageService.DisplayActionSheet("Sort by", "Cancel", null, propsToDisplay);
            SortIngredientsBy(response);
        }
    }
}
