using System;
using System.Linq;
using System.Collections.Generic;

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
            Console.ReadKey(true);
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
            int[] output = new int[dietPlans.Length];
            int[] calories = new int[protein.Length];
            
            for(int i=0; i<protein.Length; i++)
            {
                calories[i] = fat[i]*9 + carbs[i]*5 + protein[i]*5;
            }

            for(int i=0;i<dietPlans.Length; i++)
            {
                string diet_plan = dietPlans[i];
                if(diet_plan.Length == 0)
                {
                    output[i]=0;  
                }
                else
                {
                    List<int> candidate = new List<int>();
                    for(int j=0;i<protein.Length;j++)
                    {
                        candidate.Add(j);
                    }
                    foreach(char ch in diet_plan)
                    {
                        switch(ch)
                        {
                            case 'P':   candidate = updatedCandidate(protein, candidate, 1);
                                        break;
                            case 'p':   candidate = updatedCandidate(protein, candidate, 0);
                                        break;
                            case 'C':   candidate = updatedCandidate(carbs, candidate, 1);
                                        break;
                            case 'c':   candidate = updatedCandidate(carbs, candidate, 0);
                                        break;
                            case 'F':   candidate = updatedCandidate(fat, candidate, 1);
                                        break;
                            case 'f':   candidate = updatedCandidate(fat, candidate, 0);
                                        break;
                            case 'T':   candidate = updatedCandidate(calories, candidate, 1);
                                        break;
                            case 't':   candidate = updatedCandidate(calories, candidate, 0);
                                        break;
                        }
                    }
                    output[i] = candidate[0];
                }
                return output;
            }
            throw new NotImplementedException();
        }
        public static List<int> updatedCandidate(int[] nutrients, List<int> index, int flag)
        {
            int element = arr[index[0]];

            if(index.Count>0)
            {
                if(flag == 1)
                {
                    for(int i =1;i<c_index.Count;i++)
                        if(element<nutrients[index[i]]) element = nutrients[index[i]];                          
                }
                else
                {
                    for(int i =1;i<index.Count;i++)
                        if(element>nutrients[index[i]]) element = nutrients[index[i]];
                }
            }
            else
            {
                return index;
            }
            List<int> temp = new List<int>();
            foreach(int i in index)
            {
                if(nutrients[i]==element)
                    temp.Add(i);
            }
            return temp;
        }
    }
}