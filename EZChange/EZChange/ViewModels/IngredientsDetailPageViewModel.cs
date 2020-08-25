using EZChange.Models;
using EZChange.Models.TcpSocket;
using EZChange.Services_;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EZChange.ViewModels
{
    public class IngredientsDetailPageViewModel : BaseViewModel
    {
        public IngredientsDetailPageViewModel(
            Ingredient ingredient, IPageService pageService) : base(pageService)
        {
            Ingredient = ingredient;

            SetNewAmountCommand = new Command(SetNewAmount);
        }

        private Ingredient _ingredient;
        public Ingredient Ingredient
        {
            get => _ingredient;
            private set => SetValue(ref _ingredient, value);
        }

        private int _newAmount;
        public int NewAmount
        {
            get { return _newAmount; }
            set { SetValue(ref _newAmount, value); }
        }

        public ICommand SetNewAmountCommand { get; private set; }

        private void SetNewAmount()
        {
            var request = new TcpSocketRequest
            {
                TcpRequestType = TcpRequestType.ResetAmount,
                Target = Ingredient.Name,
                Value = NewAmount,
            };

            try
            {
                TcpSocketService.Send(request);
            }

            catch(Exception e)
            {
                _pageService.DisplayAlert("Error", e.Message.ToString(), "Ok");
            }

            Ingredient = TcpSocketService.GetResponse<Ingredient>();
        }
    }
}
