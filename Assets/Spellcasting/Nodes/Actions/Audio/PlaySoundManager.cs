using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundManager : MonoBehaviour
{
  public static PlaySoundManager Instance;
  public int maxSoundInstances = 10;
  public AudioSource audioSourcePrefab;
  private AudioSource[] audioSourcePool;
  public AudioClip[] instruments;
  private int poolIndex = 0;
  private void Awake()
  {
    Instance = this;
    audioSourcePool = new AudioSource[maxSoundInstances];
    for (int i = 0; i < maxSoundInstances; i++)
    {
      audioSourcePool[i] = Instantiate(audioSourcePrefab, transform);
    }
  }

  private void Update()
  {
    poolIndex = 0;
  }

  public void PlaySound(Vector3 _position, float _volume, float _pitch, float _instrument)
  {
    int instrumentIndex = Mathf.FloorToInt(_instrument) % instruments.Length;
    AudioClip instrument = instruments[instrumentIndex];
    AudioSource source = audioSourcePool[poolIndex++];
    source.transform.position = _position;
    source.volume = _volume;
    source.pitch = _pitch;
    if (!source.isPlaying || instrument != source.clip)
    {
      source.Stop();
      source.clip = instrument;
      source.Play();
    }
  }
}
