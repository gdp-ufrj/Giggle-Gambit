using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScreenScript : MonoBehaviour
{
    public void returnToMenuButtonFunction()
    {
        SceneManager.LoadScene(0);
    }
}
