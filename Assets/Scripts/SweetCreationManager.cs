using System.Collections;
using System.Collections.Generic;
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
    private GameObject selectedBase;
    private GameObject pressedIngredient;
    private int ingredientCounter;


    private void Start()
    {
        //sets base panel to always be active first
        basePanel.SetActive(true);
        ingredientsPanel.SetActive(false);
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
        }
    }
    //NEXT BUTTON
    public void nextButton()
    {
        basePanel.SetActive(false);
        ingredientsPanel.SetActive(true);
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

    }
}
