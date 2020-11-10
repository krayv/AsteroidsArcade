using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag(TagsAndLayers.AudioSource).GetComponent<AudioSource>();
    }
    public void Play()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
