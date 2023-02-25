using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance;
    [SerializeField] private RecipeSO _recipeSO;
    private string _recipeName;
    private int _currentRecipeIndex;
    private int _currentRecipeSteps;

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

    // Update is called once per frame
    void Update()
    {
        if (_recipeName != null)
        {
            for (int i = 0; i < _recipeSO.recipes.Count; i++)
            {
                if (_recipeName.ToUpper() == _recipeSO.recipes[i].name.ToUpper())
                {
                    _currentRecipeIndex = i;
                    _currentRecipeSteps = -1;
                    NextStep();
                    _recipeName = null;
                    break;
                }
                else
                {
                    Debug.Log("Recipe not Found");
                }
            }
        }
    }

    public void NextStep()
    {
        _currentRecipeSteps++;
        if (_currentRecipeSteps <= _recipeSO.recipes[_currentRecipeIndex].steps.Count)
        {
            SceneManager.LoadScene(_recipeSO.recipes[_currentRecipeIndex].steps[_currentRecipeSteps].sceneName);
        }
        else
        {
            SceneManager.LoadScene("END");
        }
    }

    public void button(string recipeName)
    {
        _recipeName = recipeName.ToUpper();
    }

    public IngredientSO getIngredientSO()
    {
        return _recipeSO.recipes[_currentRecipeIndex].steps[_currentRecipeSteps].Ingredient;
    }
}
