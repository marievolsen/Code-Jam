using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    //Based on https://www.youtube.com/watch?v=tEsuLTpz_DU

    [SerializeField] private AudioClip _clip;

    public void PlayClip()
    {
        SoundManager.Instance.PlaySound(_clip);
    }
}
