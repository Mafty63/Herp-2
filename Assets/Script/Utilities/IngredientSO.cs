using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Developer/Ingredient Handler")]
public class IngredientSO : ScriptableObject
{
    public string ingredientName;
    public uint id;


    #region Slicing
    public List<GameObject> slicingMaterial = new List<GameObject>();
    [HideInInspector] public bool sliced;
    //max 4
    [HideInInspector] public int totalSliced;
    #endregion

    #region Mixing
    public GameObject mixingMaterial;
    #endregion

    #region Smooth
    public List<GameObject> smoothingMaterial = new List<GameObject>();
    [HideInInspector] public bool smoothing;
    [HideInInspector] public int totalSmothing;
    #endregion

    #region Peeling
    public List<GameObject> peelingMaterialSide1 = new List<GameObject>();
    public List<GameObject> peelingMaterialSide2 = new List<GameObject>();
    public GameObject skinPrefab;
    [HideInInspector] public bool peeled;
    [HideInInspector] public int totalPeeled;
    #endregion

}
