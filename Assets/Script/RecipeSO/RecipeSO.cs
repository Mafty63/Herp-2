using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Developer/Recipe")]
public class RecipeSO : ScriptableObject
{
    public enum stepEnum
    {
        Filtering,
        Mixing,
        Peeling,
        Slicing,
        Smoothing,
        Stiring
    }
    [System.Serializable]
    public class recipe
    {
        public string name;
        [System.Serializable]
        public class step
        {
            public stepEnum stepName;
            public IngredientSO Ingredient;
        }
        public List<step> steps = new List<step>();
    }

    public List<recipe> recipes = new List<recipe>();

}
