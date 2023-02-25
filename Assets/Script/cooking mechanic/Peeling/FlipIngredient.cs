using UnityEngine;
using Peeling.Ingredient;

public class FlipIngredient : MonoBehaviour
{
    void flipIngredient()
    {
        IngredientHandler.instance.changeSide();
    }
}
