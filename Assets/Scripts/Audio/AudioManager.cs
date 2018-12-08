using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public Sound[] sounds;

    public Sound[] m_KillSounds;

    private IEnumerator m_IE_ValueChange;
    private int m_Index;
    void Awake()
    {

        m_Index = 0;

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
        }
        // foreach (Sound s in m_KillSounds)
        // {
        //     s.source = gameObject.AddComponent<AudioSource>();
        //     s.source.clip = s.clip;
        //     s.source.volume = s.volume;
        //     s.source.loop = s.loop;
        //     s.source.pitch = s.pitch;
        // }
        Play(Constants.BGM_Scriabin_Vers_la_Flamme);

    }

    public void Play(string name, float pitch)
    {
        if (name == "Null")
            return;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sounds: " + name + " is not found!");
        }
        s.source.pitch = pitch;
        s.source.Play();
    }
    public void Play(string name)
    {
        if (name == "Null")
            return;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sounds: " + name + " is not found!");
        }
        // s.source.pitch = pitch;
        s.source.Play();
    }
    public void Stop(string name)
    {
        if (name == "Null")
            return;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sounds: " + name + " is not found!");
        }
        // s.source.pitch = pitch;
        s.source.Stop();
    }
    public void PlayOnce(string name)
    {
        if (name == "Null")
            return;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sounds: " + name + " is not found!");
        }
        // s.source.pitch = pitch;
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }

    }
    public void ValueChange(string name, float value, float time)
    {
        if (name == "Null")
            return;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sounds: " + name + " is not found!");
        }
        // s.source.pitch = pitch;
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
        if (m_IE_ValueChange != null)
        {
            StopCoroutine(m_IE_ValueChange);
            m_IE_ValueChange = null;
        }
        m_IE_ValueChange = IE_ValueChange(s, value, time);
        StartCoroutine(m_IE_ValueChange);
    }
    IEnumerator IE_ValueChange(Sound sound, float value, float time)
    {
        while (Mathf.Abs(sound.volume - value) > 0.1f)
        {
            yield return new WaitForEndOfFrame();
            float volume = sound.volume;
            sound.volume = Mathf.Lerp(volume, value, time);
        }
        sound.volume = value;
    }
    public void VolumeChange(string name, float value)
    {
        if (name == "Null")
            return;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sounds: " + name + " is not found!");
        }
        // s.source.pitch = pitch;
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
        s.source.volume = value;

    }
    public void PlayByAudioIndex(int index)
    {
        m_KillSounds[index].source.Play();
    }
    public void PlayByAudioIndex()
    {
        m_KillSounds[m_Index].source.Play();

        m_Index++;
        if (m_Index > m_KillSounds.Length - 1)
        {
            m_Index = 0;
        }
    }


}
