using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSoundSwitcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var a in AudioManager.Instance.FootstepClips)
                if (a.name != other.GetComponentInChildren<AudioSource>(true).clip.name)
                {
                    other.GetComponentInChildren<AudioSource>(true).clip = a;
                    break;
                }
        }
    }
}
