using UnityEngine;
using UnityEngine.InputSystem;

public class AudioSelector : MonoBehaviour
{
    [SerializeField] private AudioSource audioSelected = null;
    private void SetAudioSource(AudioSource targetAudio)
    {
        audioSelected = targetAudio;
        Debug.Log(targetAudio + " has been set as the active audio.");
    }
    private void TurnOffObjective()
    {
        if (audioSelected.isPlaying == false)
        {
            audioSelected.Stop();
            Debug.Log(audioSelected + " has been turned off.");
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        TurnOffObjective();
    }

    private void OnEnable()
    {
        EventManager.onNearObjective += SetAudioSource;
    }

    private void OnDisable()
    {
        EventManager.onNearObjective -= SetAudioSource;
    }
}
