using EZChange.Models;
using EZChange.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EZChange.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientsDetailsPage : ContentPage
    {
        public IngredientsDetailsPage(Ingredient ingredient)
        {
            BindingContext = new IngredientsDetailPageViewModel(ingredient);

            InitializeComponent();
        }
    }
}