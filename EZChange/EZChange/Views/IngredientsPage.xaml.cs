using EZChange.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EZChange.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientsPage : ContentPage
    {
        public IngredientsPage()
        {
            BindingContext = new IngredientsViewModel(new PageService());

            InitializeComponent();
        }

        async private void Button_SortBy_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayActionSheet(
                "Sort by",
                "Cancel",
                null,
                "%",
                "Number");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.ShowIngredientDetailPageCommand.Execute(e.Item);
        }

        private IngredientsViewModel ViewModel
        {
            get { return BindingContext as IngredientsViewModel; }
            set { BindingContext = value; }
        }
    }
}