using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void OnClickStartButton()
    {
        StartCoroutine(StartButtonRoutine());
    }

    private IEnumerator StartButtonRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("2Opening Cutsccene");
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}

