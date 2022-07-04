using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeToggle : MonoBehaviour
{
    
    [SerializeField]
    private string parameterName;

    [SerializeField]
    private Toggle audioToggle;

    [SerializeField]
    private AudioMixer audioMixer;

    private float audioDB;
    
    // Start is called before the first frame update
    void Start()
    {
        audioToggle.isOn = PlayerPrefs.GetInt(parameterName) == 1 ? true : false;
        audioMixer.GetFloat(parameterName, out audioDB);
        audioMixer.SetFloat(parameterName, audioToggle.isOn ? audioDB : -80);
        audioToggle.onValueChanged.AddListener(ToggleAudio);
    }

    void ToggleAudio(bool isOn) {
        if (isOn) {
            audioMixer.SetFloat(parameterName, audioDB);
        } else {
            audioMixer.SetFloat(parameterName, -80);
        }

        PlayerPrefs.SetInt(parameterName, isOn ? 1 : 0);
    }

    
}
