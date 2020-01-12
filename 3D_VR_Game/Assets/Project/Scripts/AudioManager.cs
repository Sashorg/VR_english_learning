using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource SoundEffect;

    public AudioClip[] bedroomClips;
    public AudioClip[] zooClips;
    public AudioClip[] bathroomClips;
    public AudioClip[] kitchenClips;
    public AudioClip[] phoneticsClips;

    public void ObjectSound(string Object) 
    {
        if(SettingsManager.room == "Bedroom" || SettingsManager.room == "Apartment")
        {
            foreach (AudioClip clip in bedroomClips)
                if (Object == clip.name)
                    SoundEffect.PlayOneShot(clip);
        }

        if (SettingsManager.room == "Kitchen" || SettingsManager.room == "Apartment")
        {
            foreach (AudioClip clip in kitchenClips)
                if (Object == clip.name)
                    SoundEffect.PlayOneShot(clip);
        }

        if (SettingsManager.room == "Bathroom" || SettingsManager.room == "Apartment")
        {
            foreach (AudioClip clip in bathroomClips)
                if (Object == clip.name)
                    SoundEffect.PlayOneShot(clip);
        }

        if (SettingsManager.room == "Zoo")
        {
            foreach (AudioClip clip in zooClips)
                if (Object == clip.name)
                    SoundEffect.PlayOneShot(clip);
        }

        if (SettingsManager.phonOrVoc == "Phonetics")
        {
            foreach (AudioClip clip in phoneticsClips)
                if (Object == clip.name)
                    SoundEffect.PlayOneShot(clip);
        }


    }

}
