using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kibblet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            FindObjectOfType<LifeCount>().KibbletLife();    
        }
        Debug.Log("RAT");
    }
}
