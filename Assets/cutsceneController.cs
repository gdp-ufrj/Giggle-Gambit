using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneController : MonoBehaviour
{
    public GameObject sceneImg,oldManObj,DialogueBox,dialogueText;

    public Sprite[] frames;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (count==1)
            {
                dialogueText.GetComponent<TextMeshProUGUI>().text = "Alright, here we are, I’m so excited to meet the birthday boy! Funny, I don’t hear any kids or… Anyone else for that matter";
            }
            if (count==3)
            {
                oldManObj.SetActive(true);
                dialogueText.GetComponent<TextMeshProUGUI>().text = "'Make me laugh.'";
            }

            if (count>frames.Length-1)
            {
                SceneManager.LoadScene(1);
            }
            sceneImg.GetComponent<SpriteRenderer>().sprite = frames[count];
        }
    }
}
