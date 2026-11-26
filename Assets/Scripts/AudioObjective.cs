using UnityEngine;

public class AudioObjective : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnOnObjective();
    }

    private void TurnOnObjective()
    {
        if (audioSource.isPlaying != true)
        {
            audioSource.Play();
            Debug.Log(audioSource + "has been turned on.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.onNearObjective?.Invoke(audioSource);
        }
        //Play any voicelines/SFX for getting close to the item
    }
}
