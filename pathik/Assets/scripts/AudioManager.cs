using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip startclip;
    private AudioClip lastaudio;
    // Start is called before the first frame update
    void Start()
    {
        source.PlayOneShot(startclip);
    }
    public void playaudio(AudioClip clip)
    {
        source.Stop();
        lastaudio = clip;
        source.PlayOneShot(clip);
        lastaudio = clip;
    }
    public void repeat()
    {
        source.Stop();
        source.PlayOneShot(lastaudio);
    }

   
}
