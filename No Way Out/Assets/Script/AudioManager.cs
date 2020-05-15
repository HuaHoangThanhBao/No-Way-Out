using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioClip jump, error;
    static AudioSource source;

    private void Start()
    {
        jump = Resources.Load<AudioClip>("Click");
        error = Resources.Load<AudioClip>("Error");
        source = GetComponent<AudioSource>();
    }

    public static void PlayJumpSound(string clip)
    {
        switch (clip)
        {
            case "Click":
                source.PlayOneShot(jump);
                break;
            case "Error":
                source.PlayOneShot(error);
                break;
        }
    }
}
