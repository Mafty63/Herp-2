using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Developer/Recipe")]
public class RecipeSO : ScriptableObject
{
    [System.Serializable]
    public class recipe
    {
        public string name;
        [System.Serializable]
        public class step
        {
            public string sceneName;
            public IngredientSO Ingredient;
        }
        public List<step> steps = new List<step>();
    }

    public List<recipe> recipes = new List<recipe>();
}
