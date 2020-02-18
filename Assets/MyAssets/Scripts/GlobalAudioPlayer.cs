using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton class for playing audio at location
/// Useful when the gameobject plays audio on death
/// and is destroyed
/// </summary>
public class GlobalAudioPlayer : MonoBehaviour {
    public static GlobalAudioPlayer Instance;

    public AudioSource templateAudioSource;

    void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    /// <summary>
    /// Plays audio clip at the location
    /// Destorys gameobject after 10 seconds
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="location"></param>
    public void PlayClipAt(AudioClip clip, Vector3 location, float volumeScale = 1f) {
        GameObject player = new GameObject("AudioPlayer");
        player.transform.position = location;
        AudioSource audioSource = player.AddComponent<AudioSource>();

        audioSource.volume = templateAudioSource.volume;
        audioSource.pitch = templateAudioSource.pitch;
        audioSource.panStereo = templateAudioSource.panStereo;
        audioSource.spatialBlend = templateAudioSource.spatialBlend;
        audioSource.reverbZoneMix = templateAudioSource.reverbZoneMix;
        audioSource.dopplerLevel = templateAudioSource.dopplerLevel;
        audioSource.spread = templateAudioSource.spread;
        audioSource.minDistance = templateAudioSource.minDistance;
        audioSource.maxDistance = templateAudioSource.maxDistance;

        audioSource.PlayOneShot(clip, volumeScale);
        Destroy(player, 10f);

    }
}