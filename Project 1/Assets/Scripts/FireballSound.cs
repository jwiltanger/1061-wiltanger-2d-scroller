using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSound : MonoBehaviour
{
    public AudioSource blip;
    // Start is called before the first frame update
    public void Start()
    {
        blip = GetComponent<AudioSource>();
        blip.Play();
    }

}
