using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise3
{
    public class Meal
    {
        public Meal(int id, int protein, int carb, int fat)
        {
            Id = id;
            Protein = protein;
            Carb = carb;
            Fat = fat;
            Calories = 5 * protein + 5 * carb + 9 * fat;
        }
        public int Id { get; }
        public int Protein { get; }
        public int Carb { get; }
        public int Fat { get; }
        public int Calories { get; }
    }
}
