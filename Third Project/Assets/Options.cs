using UnityEngine.Audio;
using UnityEngine;

public class Options : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void volumeEdit(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }

    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void Quality(int index)
    {
        QualitySettings.SetQualityLevel(index + 1);
    }
}
