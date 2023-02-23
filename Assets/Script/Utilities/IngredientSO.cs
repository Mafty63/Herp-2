using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Developer/Ingredient Handler")]
public class IngredientSO : ScriptableObject
{
    public string ingredientName;
    public uint id;


    #region Slicing
    public GameObject[] slicedMaterial = new GameObject[5];
    [HideInInspector] public bool sliced;
    //max 4
    [HideInInspector] public uint totalSliced;
    #endregion


    #region Mixing
    public GameObject smoothMaterial;
    #endregion

}
