using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpMungko, walkMungko, attackMungko1, deathNormal, deathBouncer, deathNimble, idleBouncer, deathMungko, flagSound;
    static AudioSource audioSrc;

    void Start()
    {
        jumpMungko = Resources.Load<AudioClip>("Jump_MM");
        walkMungko = Resources.Load<AudioClip>("Walking_MM");
        attackMungko1 = Resources.Load<AudioClip>("Attack1_MM");
        deathNormal = Resources.Load<AudioClip>("Death_NormalRat");
        deathBouncer = Resources.Load<AudioClip>("Death_BouncerRat");
        deathNimble = Resources.Load<AudioClip>("Death_NimbleRat");
        idleBouncer = Resources.Load<AudioClip>("Idle_BouncerRat");
        deathMungko = Resources.Load<AudioClip>("Death_MM");
        flagSound = Resources.Load<AudioClip>("Flag");

        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump_MM":
                audioSrc.PlayOneShot(jumpMungko);
                break;
            case "Walking_MM":
                audioSrc.PlayOneShot(walkMungko);
                break;
            case "Attack1_MM":
                audioSrc.PlayOneShot(attackMungko1);
                break;
            case "Death_NormalRat":
                audioSrc.PlayOneShot(deathNormal);
                break;
            case "Death_BouncerRat":
                audioSrc.PlayOneShot(deathBouncer);
                break;
            case "Death_NimbleRat":
                audioSrc.PlayOneShot(deathNimble);
                break;
            case "Idle_BouncerRat":
                audioSrc.PlayOneShot(idleBouncer);
                break;
            case "Death_MM":
                audioSrc.PlayOneShot(deathMungko);
                break;    
            case "Flag":
                audioSrc.PlayOneShot(flagSound);
                break;  
        }
    }
}
