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
        public Color Color => Color.Black;
    }
}
