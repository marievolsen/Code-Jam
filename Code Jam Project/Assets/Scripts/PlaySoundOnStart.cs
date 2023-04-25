using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    //Based on https://www.youtube.com/watch?v=tEsuLTpz_DU

    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        SoundManager.Instance.PlaySound(_clip);
    }
}
