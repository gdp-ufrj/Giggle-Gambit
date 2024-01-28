using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class cutsceneController : MonoBehaviour
{
    public GameObject sceneImg,oldManObj,DialogueBox,dialogueText;

    public Sprite[] frames;

    private int count = 0;
    [SerializeField] private EventReference doorKnock;
    [SerializeField] private EventReference doorOpen;
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
                FMODUnity.RuntimeManager.PlayOneShot(doorKnock);
                dialogueText.GetComponent<TextMeshProUGUI>().text = "Alright, here we are, I’m so excited to meet the birthday boy! Funny, I don’t hear any kids or… Anyone else for that matter";
            }else if (count==2)
            {
                FMODUnity.RuntimeManager.PlayOneShot(doorOpen);
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
