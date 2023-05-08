using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial used: https://www.youtube.com/watch?v=tLyj02T51Oc&ab_channel=Epitome

public class AudioManager : MonoBehaviour
{
    //A private instance of the AudioManager
    private static AudioManager instance;
    //Property that will allow us to get/set the instance from somewhere else
    public static AudioManager Instance
    {
        //used to check for an existing instance
        get
        {
            //If we dont have one
            if(instance == null)
            {
                //we start by looking for one
                instance = FindObjectOfType<AudioManager>();
                //if it still cannot find one, it creates a new
                if(instance == null)
                {
                    instance = new GameObject("Create AudioManager", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }
            //returns the instance at the end of the get
            return instance;
        }
        //We make set private so the AudioManager cannot be set from any other script.
        private set
        {
            instance = value; 
        }
    }

    //Fields that will spawn the different audiosources, we create one for each track to enable the cross fading
    private AudioSource musicSource;
    private AudioSource musicSource2;
    private AudioSource sfxSource;

    //Determines is the first source is playing
    private bool firstSourcePlaying;

    private void Awake()
    {
        //makes sure not to destroy the instance
        DontDestroyOnLoad(this.gameObject);

        //create the audio sources and save them as to be used as references
        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource2 = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();

        //Makes sure that the tracks loop
        musicSource.loop = true;
        musicSource2.loop = true;
    }

    //creates a function to play the music, which is assible from outside the script
    public void PlayMusic(AudioClip musicClip)
    {
        //Detemine which source is active
        AudioSource activeSource = (firstSourcePlaying) ? musicSource : musicSource2;

        //Plays the music and makes sure volume is set to 1
        activeSource.clip = musicClip;
        activeSource.volume = 1;
        activeSource.Play();
    }

    //Makes it possible to transistion between the tracks
    //Put in the float to set the transitionTime if not defined
    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        //Detemine which source is active
        AudioSource activeSource = (firstSourcePlaying) ? musicSource : musicSource2;
        StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));
    }
    public void PlayMusicWithCrossFade(AudioClip musicClip, float transitionTime = 1.0f)
    {
        //Determines which source is active
        AudioSource activeSource = (firstSourcePlaying) ? musicSource : musicSource2;
        AudioSource newSource = (firstSourcePlaying) ? musicSource2 : musicSource;

        //Swaps the source
        firstSourcePlaying = !firstSourcePlaying;

        //Sets the field and then starts the crossfade coroutine
        newSource.clip = musicClip;
        newSource.Play();
        StartCoroutine(UpdateMusicWithCrossFade(activeSource, newSource, transitionTime);
    }
    //Coroutine to control volume
    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
    {
        //Checks if the activeSource is active and playing and if not forces it to
        if (!activeSource.isPlaying)
            activeSource.Play();

        float t = 0.0f;

        //fade out
        for (t = 0; t < transitionTime; t+= Time.deltaTime)
        {
            //starts at 1 and gets reduced every second
            activeSource.volume = (1 - (t / transitionTime));
            yield return null;
        }

        //Stop the current track, changes it out and plays again.
        activeSource.Stop();
        activeSource.clip = newClip;

        //fade in
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            //once the transistion time is done, the volume is gonna equal 1
            activeSource.volume = (t / transitionTime);
            yield return null;
        }
    }
    private IEnumerator UpdateMusicWithCrossFade(AudioSource original, AudioSource newSource, float transitionTime)
    {
        float t = 0.0f;

        //Same principal as before, but start one at zero and the other at 1
        for (t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            original.volume = (1 - (t / transitionTime));
            newSource.volume = (t / transitionTime);
            yield return null;
        }
    }

    //same thing as PlayMusic but for the sfx
    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    //Makes it possible to change the volume externaly
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicSource2.volume = volume;
    }
    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    //Makes it possible to toggle off externally
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        musicSource2.mute = !musicSource2.mute
    }
    public void ToggleSfx()
    {
        sfxSource.mute = !sfxSource.mute;
    }
}
