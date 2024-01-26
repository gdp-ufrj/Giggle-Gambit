using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Random;

public class GameControllerScript : MonoBehaviour
{
    public GameObject mainDialogueObj, buttonsObj,button1TextObj,button2TextObj,button3TextObj,itemImageObj,gachaScreenImageObj,gachaTextObj,gachaScreenObj;
    public GameObject scoreDialogueObj;
    public GachaObjectScriptableObject[] gachaItems;
    public GachaObjectScriptableObject currentItem;
    public int oldManScore = 0;
    public int loseThreshold, WinThreshold;
    private bool gachaScreenOn = true;

    private rollingTextTyperScript mainDialogueComponent;
    private Image gachaScreenImageComponent, itemImageComponent;

    private TextMeshProUGUI mainDialogueText,button1Text,button2Text,button3Text,gachaTextComponent,scoreDialogueText;
    // Start is called before the first frame update
    void Start()
    {
        mainDialogueComponent = mainDialogueObj.GetComponent<rollingTextTyperScript>();
        gachaScreenImageComponent = gachaScreenImageObj.GetComponent<Image>();
        itemImageComponent = itemImageObj.GetComponent<Image>();
        mainDialogueText=mainDialogueObj.GetComponent<TextMeshProUGUI>();
        button1Text = button1TextObj.GetComponent<TextMeshProUGUI>();
        button2Text = button2TextObj.GetComponent<TextMeshProUGUI>();
        button3Text = button3TextObj.GetComponent<TextMeshProUGUI>();
        scoreDialogueText = scoreDialogueObj.GetComponent<TextMeshProUGUI>();
        gachaTextComponent = gachaTextObj.GetComponent<TextMeshProUGUI>();
        gachaRoll();
        //gachaTextComponent.text = "I pulled " + currentItem.name + " from my bag!";
        //gachaScreenImageComponent.color = currentItem.itemColor;
        //itemImageObj.GetComponent<Image>().color = currentItem.itemColor;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))&&gachaScreenOn)
        {
            button1Text.text = currentItem.choice1Text.text;
            button2Text.text = currentItem.choice2Text.text;
            button3Text.text = currentItem.choice3Text.text;
            buttonsObj.SetActive(true);
            gachaScreenObj.SetActive(false);
            gachaScreenOn = false;
            mainDialogueComponent.finished = false;
        }
        else if ((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))&&mainDialogueComponent.finished&&!gachaScreenOn)
        {
            
            mainDialogueObj.SetActive(false);
            //buttonsObj.SetActive(true);
            gachaRoll();
            gachaScreenOn = true;
            gachaScreenObj.SetActive(true);
            //itemImageObj.GetComponent<Image>().color = currentItem.itemColor;
        }

        scoreDialogueText.text = oldManScore.ToString();
        if (oldManScore>=WinThreshold)
        {
            //insert win screen here
        }else if (oldManScore <= loseThreshold)
        {
            //insert lose screen here
        }



    }
    public void buttonPressed(int message)
    {
        
        switch (message)
        {
            case 1:
                mainDialogueText.text = currentItem.choice1Result.text;
                oldManScore += currentItem.choice1change;
                break;
            case 2:
                mainDialogueText.text = currentItem.choice2Result.text;
                oldManScore += currentItem.choice2Change;
                break;
            case 3:
                mainDialogueText.text = currentItem.choice3Result.text;
                oldManScore += currentItem.choice3change;
                break;
        }
        //gachaRoll();
        mainDialogueObj.SetActive(true);
        buttonsObj.SetActive(false);
    }

    public void gachaRoll()
    {
        currentItem = gachaItems[Random.Range(0, gachaItems.Length)];
        gachaScreenImageComponent.sprite = currentItem.ItemSprite;
        itemImageComponent.sprite = currentItem.ItemSprite;
        gachaTextComponent.text = "I pulled " + currentItem.name + " from my bag!";
    }
}
