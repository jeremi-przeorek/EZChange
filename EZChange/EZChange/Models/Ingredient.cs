using Xamarin.Forms;

namespace EZChange.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int ActualAmount { get; set; }
        public Color Color => Color.Black;
    }
}
