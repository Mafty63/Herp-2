using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Developer/Ingredient Handler")]
public class IngredientSO : ScriptableObject
{
    public string ingredientName;
    public uint id;
    public GameObject[] slicedMaterial = new GameObject[5];
    public bool sliced;

    //max 4
    public uint totalSliced;

}
