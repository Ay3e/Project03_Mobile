using UnityEngine;

public class SweetCreationManager : MonoBehaviour
{
    //panels
    [SerializeField] private GameObject basePanel;
    [SerializeField] private GameObject ingredientsPanel;

    //arrays
    [SerializeField] private GameObject[] baseSprites;
    [SerializeField] private GameObject[] ingredientSprites;
    [SerializeField] private GameObject[] displayedIngredients;

    //other
    [SerializeField] private GameObject IngredientTypes;
    private GameObject selectedBase;
    private GameObject pressedIngredient;
    //private int ingredientCounter;

    private int creamCount;
    private int berryCount;
    private int sugarCount;
    private int chocolateCount;


    private void Start()
    {
        //sets base panel to always be active first
        basePanel.SetActive(true);
        ingredientsPanel.SetActive(false);
        IngredientTypes.SetActive(false);
    }

    private void Update()
    {
        //
        if (selectedBase == null)
        {
            selectedBase = baseSprites[0];
            selectedBase.SetActive(true);
        }
        else
        {
            for (int i = 0; i < baseSprites.Length; i++)
            {
                if (selectedBase == baseSprites[i])
                {
                    selectedBase.SetActive(true);
                }
                else
                {
                    baseSprites[i].SetActive(false);
                }
            }
            for (int i = 0; i < ingredientSprites.Length; i++)
            {
                if (pressedIngredient == ingredientSprites[i])
                {
                    pressedIngredient.SetActive(true);
                }
            }
        }
    }
    //NEXT BUTTON
    public void nextButton()
    {
        basePanel.SetActive(false);
        ingredientsPanel.SetActive(true);
        IngredientTypes.SetActive(true);
    }

    //BASE BUTTONS
    public void SpongeBaseButton()
    {
        selectedBase = baseSprites[0];
    }
    public void JellyBaseButton()
    {
        selectedBase = baseSprites[1];
    }

    //INGREDIENT BUTTONS
    public void BigBerryButton()
    {
        pressedIngredient = ingredientSprites[0];
        InstantiatePressedIngredient();
        berryCount++;
    }
    public void ChocoStickButton()
    {
        pressedIngredient = ingredientSprites[1];
        InstantiatePressedIngredient();
        chocolateCount++;
    }
    public void IceCreamButton()
    {
        pressedIngredient = ingredientSprites[2];
        InstantiatePressedIngredient();
        creamCount++;
    }
    public void BlueberriesButton()
    {
        pressedIngredient = ingredientSprites[3];
        InstantiatePressedIngredient();
    }
    public void ChocoLogoButton()
    {
        pressedIngredient = ingredientSprites[4];
        InstantiatePressedIngredient();
        chocolateCount++;
    }
    public void TripleBerriesButton()
    {
        pressedIngredient = ingredientSprites[5];
        InstantiatePressedIngredient();
        berryCount++;
    }
    public void SoyFlourButton()
    {
        pressedIngredient = ingredientSprites[6];
        InstantiatePressedIngredient();
    }

    // Dupilcate the ingredient
    private void InstantiatePressedIngredient()
    {
        if (pressedIngredient != null)
        {
            GameObject instantiatedIngredient = Instantiate(pressedIngredient, pressedIngredient.transform.position, pressedIngredient.transform.rotation);
            // You can perform additional operations on the instantiated ingredient
            Rigidbody instantiatedRigidbody = instantiatedIngredient.AddComponent<Rigidbody>();
            instantiatedRigidbody.mass = 1f;
            instantiatedRigidbody.drag = 0.5f;
        }
    }
}
