using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YES : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("L1_Deck");
    }
}