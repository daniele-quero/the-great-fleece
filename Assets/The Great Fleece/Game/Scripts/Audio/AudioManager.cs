using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    [SerializeField]
    private AudioSource _bgMusic, _rainSFX;

    [SerializeField]
    private AudioClip[] _footstepClips;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Missing GameManager");

            return _instance;
        }
    }

    public AudioClip[] FootstepClips { get => _footstepClips; }

    private void Awake()
    {
        _instance = this;
    }

    public void PlayBgMusic()
    {
        _bgMusic.PlayDelayed(0.8f);
    }
}
