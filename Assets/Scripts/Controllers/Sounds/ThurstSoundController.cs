using UnityEngine;

public class ThurstSoundController : MonoBehaviour
{
    
    private float currentDelay;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float delay;

    public void TryToPlay()
    {
        if(!audioSource.isPlaying && currentDelay <= 0f)
        {
            audioSource.Play();
            currentDelay = audioSource.clip.length + delay;
        }
        else 
        {
            currentDelay -= Time.deltaTime;
        }
    }
}
