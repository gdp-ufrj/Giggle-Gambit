using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonFunction()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButtonFunction()
    {
        Application.Quit();
    }
}
