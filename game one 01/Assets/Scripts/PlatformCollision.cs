using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    public ParticleSystem dust;
    private void OnTriggerEnter2D(Collider2D other){
        //Debug.Log("hit detected");
        dust.Play();
    }
}
