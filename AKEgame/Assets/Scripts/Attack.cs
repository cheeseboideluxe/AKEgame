using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            NormalRatControls.isAttacking = true;
            
            BouncerRat.isAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            NormalRatControls.isAttacking = false;
           
            BouncerRat.isAttacking = false;
        }
    }
}
