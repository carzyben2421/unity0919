using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
   public AudioMixer mixer;
    public void SetVbgm(float value)
    {
        mixer.SetFloat("VBGM", value);
    }
}
