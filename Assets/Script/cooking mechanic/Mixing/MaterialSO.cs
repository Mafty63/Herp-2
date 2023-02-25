using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Material Mixing", menuName = "Developer/Material Mixing")]
public class MaterialSO : ScriptableObject
{
    [System.Serializable]
    public class Material
    {
        public string materialName;
        public GameObject materialUIPrefab;
    }
    public List<Material> materialList = new List<Material>();
    public int numberOfMaterialNeeded;
}
