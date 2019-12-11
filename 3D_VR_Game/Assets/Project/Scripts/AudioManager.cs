using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource SoundEffect;

    public AudioClip[] objectClips;
    public AudioClip[] zooClips;
    public AudioClip[] phoneticsClips;

    public void ObjectSound(string Object) 
    {
        foreach(AudioClip clip in objectClips)
        {
            print(clip.name);
            if(Object == clip.name)
            {
                print("Played");
                SoundEffect.PlayOneShot(clip);
            }
                
        }

        foreach (AudioClip clip in zooClips)
        {
            if (Object == clip.name)
                SoundEffect.PlayOneShot(clip);
        }

        foreach (AudioClip clip in phoneticsClips)
        {
            if (Object == clip.name)
                SoundEffect.PlayOneShot(clip);
        }

    }

}
