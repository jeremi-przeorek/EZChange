using EZChange.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EZChange.ViewModels
{
    public class IngredientsDetailPageViewModel : BaseViewModel
    {
        public IngredientsDetailPageViewModel(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }

        private Ingredient _ingredient;
        public Ingredient Ingredient
        {
            get => _ingredient;
            private set => SetValue(ref _ingredient, value);
        }
    }
}
