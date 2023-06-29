using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;

public class SweetCreationManager : MonoBehaviour
{
    //panels
    [SerializeField] private GameObject basePanel;
    [SerializeField] private GameObject ingredientsPanel;

    //arrays
    [SerializeField] private GameObject[] baseSprites;
    [SerializeField] private GameObject[] ingredientSprites;
    [SerializeField] private GameObject[] recipeBookBaseSprites;

    //other
    [SerializeField] private GameObject ingredientTypes;
    [SerializeField] private GameObject recipePanel;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject finishButton;
    [SerializeField] private TextMeshProUGUI toppingsLeftCounter;
    private GameObject _selectedBase;
    private GameObject _pressedIngredient;
    
    private int _maxTopping = 3;

    private int _creamCount;
    private int _berryCount;
    private int _sugarCount;
    private int _chocolateCount;

    private void Start()
    {
        //sets base panel to always be active first
        _selectedBase = baseSprites[0];
        basePanel.SetActive(true);
        ingredientsPanel.SetActive(false);
        ingredientTypes.SetActive(false);
        nextButton.SetActive(true);
        finishButton.SetActive(false);
    }

    private void Update()
    {
        for (int i = 0; i < baseSprites.Length; i++)
        {
            if (_selectedBase == baseSprites[i])
            {
                _selectedBase.SetActive(true);
            }
            else
            {
                baseSprites[i].SetActive(false);
            }
        }
        for (int i = 0; i < ingredientSprites.Length; i++)
        {
            if (_pressedIngredient == ingredientSprites[i])
            {
                _pressedIngredient.SetActive(true);
            }
        }
        if (_maxTopping <= 0)
        {
            _pressedIngredient = null;
            _maxTopping = 0;
        }
        toppingsLeftCounter.text = "TOPPINGS LEFT " + _maxTopping;
        ChangeBaseToDiscovered();
    }
    //NEXT BUTTON
    public void NextButton()
    {
        basePanel.SetActive(false);
        ingredientsPanel.SetActive(true);
        ingredientTypes.SetActive(true);
        nextButton.SetActive(false);
        finishButton.SetActive(true);
    }

    //FINISH BUTTON
    public void FinishButton()
    {
        SceneManager.LoadScene(0);
    }

    //RECIPE BOOK BUTTON
    public void RecipeBookButton()
    {
        recipePanel.SetActive(!recipePanel.activeSelf);
    }

    //BASE BUTTONS
    public void SpongeBaseButton()
    {
        _selectedBase = baseSprites[0];
    }
    public void JellyBaseButton()
    {
        _selectedBase = baseSprites[1];
        PlayerPrefs.SetInt("SelectedBase", 1);
    }

    //DISCOVER NEW BASES
    private void ChangeBaseToDiscovered()
    {
        //Sponge cake to Short cake
        if(_selectedBase == baseSprites[0] && _creamCount>= 1 && _berryCount >= 1)
        {
            _selectedBase = baseSprites[2];
            recipeBookBaseSprites[2].GetComponent<SpriteRenderer>().color = Color.white;
        }
        //Sponge cake to Cream puff
        if (_selectedBase == baseSprites[0] && _creamCount >= 1 && _sugarCount >= 1)
        {
            _selectedBase = baseSprites[3];
            recipeBookBaseSprites[3].GetComponent<SpriteRenderer>().color = Color.white;
        }
        //Sponge cake to Chocolate cake
        if (_selectedBase == baseSprites[0] && _chocolateCount >=2)
        {
            _selectedBase = baseSprites[4];
            recipeBookBaseSprites[4].GetComponent<SpriteRenderer>().color = Color.white;
        }
        //Jelly to Pudding
        if (_selectedBase == baseSprites[1] && _sugarCount>=1 && _creamCount>=1)
        {
            _selectedBase = baseSprites[5];
            recipeBookBaseSprites[5].GetComponent<SpriteRenderer>().color = Color.white;
        }
        //Jelly to Ice Cream
        if (_selectedBase == baseSprites[1] && _creamCount >= 2)
        {
            _selectedBase = baseSprites[6];
            recipeBookBaseSprites[6].GetComponent<SpriteRenderer>().color = Color.white;
        }
       
    }

    //INGREDIENT BUTTONS
    public void BigBerryButton()
    {
        _pressedIngredient = ingredientSprites[0];
        InstantiatePressedIngredient();
        if(_maxTopping > 0)
        {
            _berryCount++;
        }

        _maxTopping--;
    }
    public void ChocoStickButton()
    {
        _pressedIngredient = ingredientSprites[1];
        InstantiatePressedIngredient();
        if (_maxTopping > 0)
        {
            _chocolateCount++;
        }
        _maxTopping--;
    }
    public void IceCreamButton()
    {
        _pressedIngredient = ingredientSprites[2];
        InstantiatePressedIngredient();
        if (_maxTopping > 0)
        {
            _creamCount++;
        } 
        _maxTopping--;
    }
    public void BlueberriesButton()
    {
        _pressedIngredient = ingredientSprites[3];
        InstantiatePressedIngredient();
        _maxTopping--;
    }
    public void ChocoLogoButton()
    {
        _pressedIngredient = ingredientSprites[4];
        InstantiatePressedIngredient();
        if (_maxTopping > 0)
        {
            _chocolateCount++;
        }
        _maxTopping--;
    }
    public void TripleBerriesButton()
    {
        _pressedIngredient = ingredientSprites[5];
        InstantiatePressedIngredient();
        if (_maxTopping > 0)
        {
            _berryCount++;
        }
        _maxTopping--;
    }
    public void SoyFlourButton()
    {
        _pressedIngredient = ingredientSprites[6];
        InstantiatePressedIngredient();
        if (_maxTopping > 0)
        {
            _sugarCount++;
        }
        _maxTopping--;
    }

    // DUPLICATE THE INGREDIENTS
    private void InstantiatePressedIngredient()
    {
        if (_maxTopping <= 0)
        {
            _pressedIngredient = null;
        }
        if (_pressedIngredient != null)
        {
            GameObject instantiatedIngredient = Instantiate(_pressedIngredient, _pressedIngredient.transform.position, _pressedIngredient.transform.rotation);
        }
    }
}
