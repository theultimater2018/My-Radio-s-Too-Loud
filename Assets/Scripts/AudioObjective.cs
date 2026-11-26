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

    private void TurnOffObjective()
    {
        if (isActive == false)
        {
            if (audioSource.isPlaying != true)
            {
                audioSource.Stop();
            }
        }
    }

    private void TurnOnObjective()
    {
        if (isActive == true)
        {
            if (audioSource.isPlaying != true)
            {
                audioSource.Play();
            }
        }
    }

    private void OnEnable()
    {
        EventManager.onAudioInteract.AddListener(TurnOffObjective);
    }
    private void OnDisable()
    {
        EventManager.onAudioInteract.RemoveListener(TurnOffObjective);
    }
    // Update is called once per frame
    void Update()
    {
        TurnOnObjective();
    }
}
