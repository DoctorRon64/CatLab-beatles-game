using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musicClipList;
    private AudioSource sourceMusic;

    private void Awake()
    {
        sourceMusic = GetComponent<AudioSource>();
    }

    public void PlayAudio(int _index)
    {
        sourceMusic.clip = musicClipList[_index];
        sourceMusic.Play();
    }

}
