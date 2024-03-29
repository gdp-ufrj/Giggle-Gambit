using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Random;

public class GameControllerScript : MonoBehaviour
{
    public GameObject mainDialogueObj, buttonsObj,button1TextObj,button2TextObj,button3TextObj,itemImageObj,gachaScreenImageObj,gachaTextObj,gachaScreenObj;
    public GameObject scoreDialogueObj,pauseButtonObj,pauseScreenObj,progBarObj,OldManImgObject,clownImgObject;
    public GachaObjectScriptableObject[] gachaItems;
    public GachaObjectScriptableObject currentItem;
    public int oldManScore = 0;
    public int loseThreshold, WinThreshold;
    public Sprite[] oldManSprites;
    public Sprite[] clownSprites;
    public string[] neutralResponses;
    public string[] positiveResponses;
    public string[] negativeResponses;
    
    private bool gachaScreenOn = true;
    private bool isPaused = false;

    private rollingTextTyperScript mainDialogueComponent;
    private Image gachaScreenImageComponent, itemImageComponent,oldManImageComponent,clownImageComponent;
    private Slider progBarComponent;
    private int i;
    private int errorValue = 1;

    private TextMeshProUGUI mainDialogueText,button1Text,button2Text,button3Text,gachaTextComponent,scoreDialogueText;

    [SerializeField] private EventReference negativeSound;
    [SerializeField] private EventReference neutralSound;
    [SerializeField] private EventReference positiveSound;
    [SerializeField] private EventReference gameOverSound;
    // Start is called before the first frame update
    void Start()
    {
        mainDialogueComponent = mainDialogueObj.GetComponent<rollingTextTyperScript>();
        gachaScreenImageComponent = gachaScreenImageObj.GetComponent<Image>();
        itemImageComponent = itemImageObj.GetComponent<Image>();
        oldManImageComponent = OldManImgObject.GetComponent<Image>();
        clownImageComponent = clownImgObject.GetComponent<Image>();
        mainDialogueText=mainDialogueObj.GetComponent<TextMeshProUGUI>();
        button1Text = button1TextObj.GetComponent<TextMeshProUGUI>();
        button2Text = button2TextObj.GetComponent<TextMeshProUGUI>();
        button3Text = button3TextObj.GetComponent<TextMeshProUGUI>();
        scoreDialogueText = scoreDialogueObj.GetComponent<TextMeshProUGUI>();
        gachaTextComponent = gachaTextObj.GetComponent<TextMeshProUGUI>();
        progBarComponent = progBarObj.GetComponent<Slider>();
        progBarComponent.maxValue = WinThreshold;
        progBarComponent.minValue = loseThreshold;
        gachaRoll();
        //gachaTextComponent.text = "I pulled " + currentItem.name + " from my bag!";
        //gachaScreenImageComponent.color = currentItem.itemColor;
        //itemImageObj.GetComponent<Image>().color = currentItem.itemColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!isPaused)
        {
            pauseButtonFunction();
        }
        if ((Input.GetKeyDown(KeyCode.Space))&&gachaScreenOn&&!isPaused)
        {
            button1Text.text = currentItem.choice1Text.text;
            button2Text.text = currentItem.choice2Text.text;
            button3Text.text = currentItem.choice3Text.text;
            buttonsObj.SetActive(true);
            gachaScreenObj.SetActive(false);
            oldManImageComponent.sprite = oldManSprites[0];
            gachaScreenOn = false;
            mainDialogueComponent.finished = false;
        }
        else if ((Input.GetKeyDown(KeyCode.Space))&&mainDialogueComponent.finished&&!gachaScreenOn&&!isPaused)
        {
            
            mainDialogueObj.SetActive(false);
            //buttonsObj.SetActive(true);
            gachaRoll();
            gachaScreenOn = true;
            gachaScreenObj.SetActive(true);
            //itemImageObj.GetComponent<Image>().color = currentItem.itemColor;
        }

        //scoreDialogueText.text = oldManScore.ToString();
        progBarComponent.value = oldManScore;
        if (oldManScore>=WinThreshold&&mainDialogueComponent.finished)
        {
            SceneManager.LoadScene(3);
        }else if (oldManScore <= loseThreshold&&mainDialogueComponent.finished)
        {
            FMODUnity.RuntimeManager.PlayOneShot(gameOverSound);
            SceneManager.LoadScene(2);
        }



    }
    public void buttonPressed(int message)
    {
        
        switch (message)
        {
            case 1:
                //mainDialogueText.text = currentItem.choice1Result.text;
                //oldManScore += currentItem.choice1change;
                if (currentItem.choice1change<0)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(negativeSound);
                    oldManScore -= errorValue;
                    errorValue++;
                    mainDialogueText.text = negativeResponses[Random.Range(0, negativeResponses.Length)];
                    oldManImageComponent.sprite = oldManSprites[1];
                    
                } else if (currentItem.choice1change>0)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(positiveSound);
                    oldManScore += currentItem.choice1change;
                    mainDialogueText.text = positiveResponses[Random.Range(0, positiveResponses.Length)];
                    oldManImageComponent.sprite = oldManSprites[2];
                }
                else
                {
                    FMODUnity.RuntimeManager.PlayOneShot(neutralSound);
                    oldManScore += currentItem.choice1change;
                    mainDialogueText.text = neutralResponses[Random.Range(0, neutralResponses.Length)];
                    oldManImageComponent.sprite = oldManSprites[0];
                }
                break;
            case 2:
                //mainDialogueText.text = currentItem.choice2Result.text;
                oldManScore += currentItem.choice2Change;
                if (currentItem.choice2Change<0)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(negativeSound);
                    oldManScore -= errorValue;
                    errorValue++;
                    mainDialogueText.text = negativeResponses[Random.Range(0, negativeResponses.Length)];
                    oldManImageComponent.sprite = oldManSprites[1];
                } else if (currentItem.choice2Change>0)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(positiveSound);
                    oldManScore += currentItem.choice1change;
                    mainDialogueText.text = positiveResponses[Random.Range(0, positiveResponses.Length)];
                    oldManImageComponent.sprite = oldManSprites[2];
                }
                else
                {
                    FMODUnity.RuntimeManager.PlayOneShot(neutralSound);
                    oldManScore += currentItem.choice1change;
                    mainDialogueText.text = neutralResponses[Random.Range(0, neutralResponses.Length)];
                    oldManImageComponent.sprite = oldManSprites[0];
                }
                break;
            case 3:
                //mainDialogueText.text = currentItem.choice3Result.text;
                oldManScore += currentItem.choice3change;
                if (currentItem.choice3change<0)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(negativeSound);
                    oldManScore -= errorValue;
                    errorValue++;
                    mainDialogueText.text = negativeResponses[Random.Range(0, negativeResponses.Length)];
                    oldManImageComponent.sprite = oldManSprites[1];
                } else if (currentItem.choice3change>0)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(positiveSound);
                    oldManScore += currentItem.choice1change;
                    mainDialogueText.text = positiveResponses[Random.Range(0, positiveResponses.Length)];
                    oldManImageComponent.sprite = oldManSprites[2];
                }
                else
                {
                    FMODUnity.RuntimeManager.PlayOneShot(neutralSound);
                    oldManScore += currentItem.choice1change;
                    mainDialogueText.text = neutralResponses[Random.Range(0, neutralResponses.Length)];
                    oldManImageComponent.sprite = oldManSprites[0];
                }
                break;
        }
        //gachaRoll();
        mainDialogueObj.SetActive(true);
        buttonsObj.SetActive(false);
    }

    public void gachaRoll()
    {
        if (gachaItems.Length==0)
        {
            Application.Quit();
        }
        i = Random.Range(0, gachaItems.Length);
        currentItem = gachaItems[i];
        gachaScreenImageComponent.sprite = currentItem.ItemSprite;
        itemImageComponent.sprite = currentItem.ItemSprite;
        gachaTextComponent.text = "I pulled " + currentItem.name + " from my bag!";
        List<GachaObjectScriptableObject> itemList = gachaItems.ToList();
        itemList.RemoveAt(i);
        gachaItems = itemList.ToArray();
    }

    public void pauseButtonFunction()
    {
        pauseButtonObj.SetActive(false);
        pauseScreenObj.SetActive(true);
        isPaused = true;
    }

    public void resumeButtonFunction()
    {
        pauseButtonObj.SetActive(true);
        pauseScreenObj.SetActive(false);
        isPaused = false;
    }

    public void toMenuButtonFunction()
    {
        SceneManager.LoadScene(0);
    }

    public void exitButtonFunction()
    {
        Application.Quit();
    }
}
