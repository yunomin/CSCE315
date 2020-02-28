using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffects : MonoBehaviour
{

    public AudioSource jumpFX;
    public AudioSource oofFX;
    public AudioSource healFX;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpFX.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpFX.Stop();
        }
    }
    void OnCollisionEnter2D(Collision2D touched)//determines which buttons are pressed
    {
        if (touched.gameObject.tag == "Obstacle1") //play sound hurt
        {
            oofFX.Play();
        }
        if (touched.gameObject.tag == "healthRec") //play sound heal
        {
            healFX.Play();
        }
    }
}
