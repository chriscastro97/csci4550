using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    public AudioSource Yatta;
    public Image customImage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = true;
        }

        if (customImage.enabled == true)
        {
            Yatta.Play();
        }
    }
}
