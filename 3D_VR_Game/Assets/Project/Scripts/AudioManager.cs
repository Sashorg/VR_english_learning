using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource SoundEffect;
    public AudioClip[] clips;
    //public AudioClip ChairClip;
    //public AudioClip PenClip;
    //public AudioClip BedClip;
    //public AudioClip BinClip;
    //public AudioClip ClockClip;
    //public AudioClip ClosetClip;
    //public AudioClip DoorClip;
    //public AudioClip GuitarClip;
    //public AudioClip LampClip;
    //public AudioClip LaptopClip;
    //public AudioClip MouseClip;
    //public AudioClip MugClip;
    //public AudioClip PhotoClip;
    //public AudioClip PlantClip;


    /* public void ObjectSound(string Object)
    {
        if(Object == "chair" && ChairClip != null)
        {
            SoundEffect.PlayOneShot(ChairClip);
        }

        if (Object == "pen" && PenClip != null)
        {
            SoundEffect.PlayOneShot(PenClip);
        }

        if (Object == "bed" && BedClip != null)
        {
            SoundEffect.PlayOneShot(BedClip);
        }

        if (Object == "bin" && BinClip != null)
        {
            SoundEffect.PlayOneShot(BinClip);
        }

        if (Object == "clock" && ClockClip != null)
        {
            SoundEffect.PlayOneShot(ClockClip);
        }

        if (Object == "closet" && ClosetClip != null)
        {
            SoundEffect.PlayOneShot(ClosetClip);
        }

        if (Object == "door" && DoorClip != null)
        {
            SoundEffect.PlayOneShot(DoorClip);
        }

        if (Object == "guitar" && GuitarClip != null)
        {
            SoundEffect.PlayOneShot(GuitarClip);
        }

        if (Object == "lamp" && LampClip != null)
        {
            SoundEffect.PlayOneShot(LampClip);
        }

        if (Object == "laptop" && LaptopClip != null)
        {
            SoundEffect.PlayOneShot(LaptopClip);
        }

        if (Object == "mouse" && MouseClip != null)
        {
            SoundEffect.PlayOneShot(MouseClip);
        }

        if (Object == "mug" && MugClip != null)
        {
            SoundEffect.PlayOneShot(MugClip);
        }

        if (Object == "photo" && PhotoClip != null)
        {
            SoundEffect.PlayOneShot(PhotoClip);
        }

        if (Object == "plant" && PlantClip != null)
        {
            SoundEffect.PlayOneShot(PlantClip);
        }

    }
    */

    public void ObjectSound(string Object) 
    {
        for(int i = 0; i < clips.Length; i++)
        {
            if(Object == clips[i].name)
            {
                SoundEffect.PlayOneShot(clips[i]);
            }
        }
    }

}
