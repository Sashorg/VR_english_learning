using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource SoundEffect;

    public AudioClip ChairClip;
    public AudioClip GlassClip;
    public AudioClip ForkClip;

    public void ObjectSound(string Object)
    {
        if(Object == "chair" && ChairClip != null)
        {
            SoundEffect.PlayOneShot(ChairClip);
        }

        if (Object == "glass" && GlassClip != null)
        {
            SoundEffect.PlayOneShot(GlassClip);
        }

        if (Object == "fork" && ForkClip != null)
        {
            SoundEffect.PlayOneShot(ForkClip);
        }

    }

}
