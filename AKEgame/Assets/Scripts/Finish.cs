using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            StartCoroutine(DelayCoroutine());          
        }
    }

    private IEnumerator DelayCoroutine()
    {
        SoundManager.PlaySound("Flag");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }
}
