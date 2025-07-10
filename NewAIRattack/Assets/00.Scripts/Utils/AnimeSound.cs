using UnityEngine;

public class AnimeSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    public void PlayAudio(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
