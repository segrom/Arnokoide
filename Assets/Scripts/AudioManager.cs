using System;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private static AudioManager Instance; 

    private void Awake(){
        if(Instance!=null)Destroy(Instance.gameObject);
        Instance = this;
        foreach (Sound sound in sounds){
            var newsource = gameObject.AddComponent<AudioSource>();
            newsource.clip = sound.clip;
            newsource.volume = sound.volume;
            sound.source = newsource;
            sound.name = sound.name.ToLower();
        }
        DontDestroyOnLoad(this);
    }

    public static void PlaySound(string name){
        var sound = Instance.sounds.SingleOrDefault(s => s.name == name.ToLower());
        sound?.source.Play();
    }
}

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [HideInInspector]public AudioSource source;
    public float volume;
}