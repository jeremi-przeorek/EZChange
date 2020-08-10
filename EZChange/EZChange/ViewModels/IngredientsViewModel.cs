using EZChange.Models;
using EZChange.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
            var indg1 = new Ingredient { Name = "Wodka", ActualAmount = 120, MaxAmount = 500 };
            var indg2 = new Ingredient { Name = "Jim Beam", ActualAmount = 500, MaxAmount = 700 };
            var indg3 = new Ingredient { Name = "Blue Curacao", ActualAmount = 120, MaxAmount = 500 };
            var indg4 = new Ingredient { Name = "Chivas", ActualAmount = 50, MaxAmount = 500 };
            var indg5 = new Ingredient { Name = "Pepsi", ActualAmount = 250, MaxAmount = 2000 };
            var indg6 = new Ingredient { Name = "Sok", ActualAmount = 1900, MaxAmount = 2000 };
            #endregion

            Ingredients = new ObservableCollection<Ingredient>() { indg1, indg2, indg3 , indg4, indg5, indg6};
            SortPlaylistCommand = new Command(SortPlaylist);
        }
        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get => _ingredients;
            private set => SetValue(ref _ingredients, value);
        }

        public ICommand SortPlaylistCommand { get; private set; }
        
        private void SortPlaylist()
        {
            Ingredients = new ObservableCollection<Ingredient>(Ingredients.OrderBy(x => x.AmountPercentage));
        }
    }
}
