using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise3
{
    public class MealSelector
    {
        private List<Meal> _meals;
        public MealSelector(List<Meal> meals)
        {
            _meals = meals;
        }
        public Meal GetPreferredMeal(string dietPlan)
        {
            //set initial value to all menu items
            var preferredMeals = _meals;
            foreach (var dietPlanCode in dietPlan)
            {
                //filter progressively as per diet plan
                preferredMeals = Filter[dietPlanCode](preferredMeals);
                if (preferredMeals.Count == 1)
                    break;
            }
            return preferredMeals.First();
        }

        Dictionary<char, Func<List<Meal>, List<Meal>>> Filter = new Dictionary<char, Func<List<Meal>, List<Meal>>>()
        {
            { 'C', GetHighestCarbMeals },
            { 'c', GetLowestCarbMeals },
            { 'P', GetHighestProteinMeals },
            { 'p', GetLowestProteinMeals },
            { 'F', GetHighestFatMeals },
            { 'f', GetLowestFatMeals },
        };

        private static List<Meal> GetHighestCarbMeals(List<Meal> meals)
        {
            var highestCarbValue = meals.Max(x => x.Carb);
            return meals.Where(x => x.Carb == highestCarbValue).ToList();
        }

        private static List<Meal> GetHighestProteinMeals(List<Meal> meals)
        {
            var highestProteinValue = meals.Max(x => x.Protein);
            return meals.Where(x => x.Protein == highestProteinValue).ToList();
        }

        private static List<Meal> GetHighestFatMeals(List<Meal> meals)
        {
            var highestFatValue = meals.Max(x => x.Fat);
            return meals.Where(x => x.Fat == highestFatValue).ToList();
        }

        private static List<Meal> GetLowestFatMeals(List<Meal> meals)
        {
            var lowestFatValue = meals.Min(x => x.Fat);
            return meals.Where(x => x.Fat == lowestFatValue).ToList();
        }

        private static List<Meal> GetLowestProteinMeals(List<Meal> meals)
        {
            var lowestProteinValue = meals.Min(x => x.Protein);
            return meals.Where(x => x.Protein == lowestProteinValue).ToList();
        }

        private static List<Meal> GetLowestCarbMeals(List<Meal> meals)
        {
            var lowestCarbValue = meals.Min(x => x.Carb);
            return meals.Where(x => x.Carb == lowestCarbValue).ToList();
        }
    }
}
