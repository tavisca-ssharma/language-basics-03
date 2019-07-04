﻿using System;
using System.Collections.Generic;
using System.Linq;
using Tavisca.Bootcamp.LanguageBasics.Exercise3;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
     static void Main(string[] args)
        {
            Test(
                 new[] { 3, 4 },
                 new[] { 2, 8 },
                 new[] { 5, 2 },
                 new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                 new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                 new[] { 3, 4, 1, 5 },
                 new[] { 2, 8, 5, 1 },
                 new[] { 5, 2, 4, 4 },
                 new[] { "tFc", "tF", "Ftc" },
                 new[] { 3, 2, 0 });
            Test(
                 new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                 new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                 new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                 new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                 new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });


        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {

            var meals = new List<Meal>();

            for (int i = 0; i < protein.Length; i++)
            {
                meals.Add(new Meal(i, protein[i], carbs[i], fat[i]));
            }

            var mealSelector = new MealSelector(meals);
            var mealSelections = new int[dietPlans.Length];
            for (int i = 0; i < dietPlans.Length; i++)
            {
                var dietPlan = dietPlans[i];
                var meal = mealSelector.GetPreferredMeal(dietPlan);
                mealSelections[i] = meal.Id;
            }
            return mealSelections;
        }
    }
}
