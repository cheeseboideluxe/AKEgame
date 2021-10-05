using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpMungko, walkMungko, attackMungko1;
    static AudioSource audioSrc;

    void Start()
    {
        jumpMungko = Resources.Load<AudioClip>("Jump_MM");
        walkMungko = Resources.Load<AudioClip>("Walking_MM");
        attackMungko1 = Resources.Load<AudioClip>("Attack1_MM");

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
        }
    }
}
