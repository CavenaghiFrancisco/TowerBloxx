using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioButton : MonoBehaviour
{
    [SerializeField] private AudioSource dioSound;
    [SerializeField] private GameObject roadRollerDA;
    private bool dioAppeared;

    public void PlayAudio()
    {
        if (!dioAppeared)
        {
            dioSound.Play();
            roadRollerDA.AddComponent<Rigidbody>();
        }
    }
}
