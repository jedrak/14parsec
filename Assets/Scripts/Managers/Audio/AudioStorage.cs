using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioStorage : MonoBehaviour
{
    [SerializeField] private MusicTrack[] musicTracks;
    [SerializeField] private SoundTrack[] soundTracks;
    public static Dictionary<string, AudioClip> MusicList = new Dictionary<string, AudioClip>();
    public static Dictionary<string, AudioClip> SoundList = new Dictionary<string, AudioClip>();


    void Awake()
    {
        foreach(MusicTrack track in musicTracks)
        {
            MusicList.Add(track.name, track.clip);
        }
        foreach(SoundTrack track in soundTracks)
        {
            SoundList.Add(track.name, track.clip);
        }
    }
}

[Serializable]
public struct MusicTrack
{
    public string name;
    public AudioClip clip;
}

[Serializable]
public struct SoundTrack
{
    public string name;
    public AudioClip clip;
}