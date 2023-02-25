using System.Collections.Generic;
using UnityEngine;

public class MaterialOrder : MonoBehaviour
{
    public static MaterialOrder instance;
    [SerializeField] private MaterialSO _materialSO;
    [SerializeField] private Transform _spawnUIPoint;
    private string _currentMaterialName;
    private GameObject _currentMaterial;
    private List<int> _randomIndexContainer = new List<int>();
    private int _randomNumber;
    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
        // Start is called before the first frame update
    }

    void Start()
    {
        for (int i = 0; i < _materialSO.numberOfMaterialNeeded; i++)
        {
            do
            {
                _randomNumber = Random.Range(0, _materialSO.materialList.Count);
            }
            while (_randomIndexContainer.Contains(_randomNumber));
            _randomIndexContainer.Add(_randomNumber);
        }
        _currentMaterialName = _materialSO.materialList[_randomIndexContainer[0]].materialName;
        _currentMaterial = Instantiate(_materialSO.materialList[_randomIndexContainer[0]].materialUIPrefab, _spawnUIPoint.position, Quaternion.identity);
        _currentMaterial.transform.SetParent(_spawnUIPoint, false);
        _randomIndexContainer.RemoveAt(0);
    }


    public void nextMaterial()
    {
        if (_randomIndexContainer.Count >= 1)
        {
            Destroy(_currentMaterial);
            _currentMaterialName = _materialSO.materialList[_randomIndexContainer[0]].materialName;
            _currentMaterial = Instantiate(_materialSO.materialList[_randomIndexContainer[0]].materialUIPrefab, _spawnUIPoint.position, Quaternion.identity);
            _currentMaterial.transform.SetParent(_spawnUIPoint, false);
            _randomIndexContainer.RemoveAt(0);
        }
        else
        {
            SceneHandler.instance.NextStep();
        }
    }

    public string getCurrentMaterialName()
    {
        return _currentMaterialName.ToUpper();
    }
}
