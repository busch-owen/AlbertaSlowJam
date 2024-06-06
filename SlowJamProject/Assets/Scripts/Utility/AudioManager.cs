using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip)
    {
        if (_audioSource.isPlaying) { return; }
        _audioSource.PlayOneShot(clip);
    }

    public void StopSounds()
    {
        _audioSource.Stop();
    }
}
