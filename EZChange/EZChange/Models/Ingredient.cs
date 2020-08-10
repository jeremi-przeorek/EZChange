using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EZChange.Models
{
    class Ingredient
    {
        public string Name { get; set; }
        public int ActualAmount { get; set; }
        public int MaxAmount { get; set; }
        public double AmountPercentage
        {
            get => (double)ActualAmount / MaxAmount; 
        }
        public Color Color
        {
            get
            {
                return new Color(1 - AmountPercentage, 0.50, 0.50);
            }
        }
    }
}
