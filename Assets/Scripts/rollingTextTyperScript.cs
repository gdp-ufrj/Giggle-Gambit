using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rollingTextTyperScript : MonoBehaviour
{
    public float letterPause = 0.2f;
    public string message;
    TextMeshProUGUI textComp;
    public bool toFinish = false;
    public bool finished = false;

    // Use this for initialization
    void Start()
    {
        /*textComp = GetComponent<TextMeshProUGUI>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());*/
    }

    private void OnEnable()
    {
        finished = false;
        toFinish = false;
        textComp = GetComponent<TextMeshProUGUI>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))&&!toFinish&&!finished)
        {
            toFinish = true;
        }
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            if (toFinish)
            {
                textComp.text = message;
                finished = true;
                toFinish = false;
                yield break;
            }
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        finished = true;
    }
}
