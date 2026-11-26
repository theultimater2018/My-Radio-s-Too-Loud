using UnityEngine;

public class AudioObjective : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isActive != true)
        {
            isActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            if (audioSource.isPlaying != true)
            {
                audioSource.Play();
            }
        }
        if (isActive == false)
        {
            if (audioSource.isPlaying != true)
            {
                audioSource.Stop();
            }

        }
    }
}
