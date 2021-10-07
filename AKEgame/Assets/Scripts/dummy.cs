using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dummy : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("l1_Deck");
    }
}