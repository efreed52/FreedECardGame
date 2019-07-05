using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardSpecs : MonoBehaviour
{
    public enum CardColor {red,green,blue,yellow}
    public enum CardRank {scout, cadet, lieut, major, general}
    public CardRank cardRank;
    public CardColor cardType;
    Image cardImage;
    colorManager ColorManager;
    public int baseStamina;
    public int curStamina;
    public int baseAttack, baseArmor, baseHp;
    private int curAttack, curArmor, curHp;
    public Text atk, def, hp;
    public int teamNumber;
    public int attackDistance;
    public GameObject navButtonParent;
    public GameObject activeCardButtonParent;
    public GameObject[] move1Buttons;
    public GameObject[] move2Buttons;
    public GameObject[] swapAllyButtons;
    public GameObject restButton, closeButton;
    public bool isPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        cardImage = this.gameObject.GetComponent<Image>();
        ColorManager = FindObjectOfType<colorManager>();        
        curStamina = baseStamina;
        curAttack = baseAttack;
        curArmor = baseArmor;
        curHp = baseHp;
        atk.text = curAttack.ToString();
        def.text = curArmor.ToString();
        hp.text = curHp.ToString();

        UpdateCardColor(0);
    }

    public void ResetStamina()
    {
        curStamina = baseStamina;
        this.gameObject.GetComponent<Button>().interactable = true;
        UpdateCardColor(0);
    }
    IEnumerator NavButtonsOn ()
    {
        navButtonParent.SetActive(true);
        activeCardButtonParent.SetActive(true);
        gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(.1f);
        foreach (GameObject move1BTN in move1Buttons)
        {
            if (move1BTN.GetComponent<moveCard>().newSpace != null && move1BTN.GetComponent<moveCard>().occupied == false)
            {
                move1BTN.GetComponent<Image>().enabled = true;
                move1BTN.GetComponent<Button>().enabled = true;
            }
        }
        foreach(GameObject swapBTN in swapAllyButtons)
        {
            if(swapBTN.GetComponent<moveCard>().swapAlly != null)
            {
                swapBTN.GetComponent<Image>().enabled = true;
                swapBTN.GetComponent<Button>().enabled = true;
            }
        }
        if (curStamina == 2)
        {
            foreach (GameObject move2BTN in move2Buttons)
            {
                if (move2BTN.GetComponent<moveCard>().newSpace != null && move2BTN.GetComponent<moveCard>().occupied == false)
                {
                    move2BTN.GetComponent<Image>().enabled = true;
                    move2BTN.GetComponent<Button>().enabled = true;
                }
            }
        }
        else
        {
            restButton.SetActive(false);
        }
        yield return null;
    }
    public void TurnOnNavButtons()
    {
        StartCoroutine(NavButtonsOn());        
    }
    public void TurnOffNavButtons()
    {
        foreach (GameObject move1BTN in move1Buttons)
        {
            move1BTN.GetComponent<Image>().enabled = false;
            move1BTN.GetComponent<Button>().enabled = false;
        }
        foreach (GameObject swapBTN in swapAllyButtons)
        {
            swapBTN.GetComponent<Image>().enabled = false;
            swapBTN.GetComponent<Button>().enabled = false;
        }
        foreach (GameObject move2BTN in move2Buttons)
        {
            move2BTN.GetComponent<Image>().enabled = false;
            move2BTN.GetComponent<Button>().enabled = false;
        }
        restButton.SetActive(true);
        navButtonParent.SetActive(false);
        activeCardButtonParent.SetActive(false);
    }
    public void UpdateCardColor(int staminaReduction)
    {
        string colorChange = cardType.ToString() + (curStamina - staminaReduction).ToString();
        curStamina -= staminaReduction;
        gameObject.GetComponent<Button>().interactable = true;
        if (curStamina == 0)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        if(cardType == CardColor.red)
        {
            switch (colorChange)
            {
                case "red2":
                    cardImage.color = ColorManager.red2;
                    break;
                case "red1":
                    cardImage.color = ColorManager.red1;
                    break;
                case "red0":
                    cardImage.color = ColorManager.red0;
                    break;
                default:
                    break;
            }
        }
        else if (cardType == CardColor.blue)
        {
            switch (colorChange)
            {
                case "blue2":
                    cardImage.color = ColorManager.blue2;
                    break;
                case "blue1":
                    cardImage.color = ColorManager.blue1;
                    break;
                case "blue0":
                    cardImage.color = ColorManager.blue0;
                    break;
                default:
                    break;
            }
        }
        else if (cardType == CardColor.green)
        {
            switch (colorChange)
            {
                case "green2":
                    cardImage.color = ColorManager.green2;
                    break;
                case "green1":
                    cardImage.color = ColorManager.green1;
                    break;
                case "green0":
                    cardImage.color = ColorManager.green0;
                    break;
                default:
                    break;
            }
        }
        else if (cardType == CardColor.yellow)
        {
            switch (colorChange)
            {
                case "yellow2":
                    cardImage.color = ColorManager.yellow2;
                    break;
                case "yellow1":
                    cardImage.color = ColorManager.yellow1;
                    break;
                case "yellow0":
                    cardImage.color = ColorManager.yellow0;
                    break;
                default:
                    break;
            }
        }
    }

}
