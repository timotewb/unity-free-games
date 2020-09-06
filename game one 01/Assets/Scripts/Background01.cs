using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background01 : MonoBehaviour
{
    [SerializeField] int direction;
    // Update is called once per frame
    void Update()
    {
        float parallaxSpeed = Mathf.Clamp01(Mathf.Abs(Camera.main.transform.position.z / transform.position.z)) * direction;
        transform.position = new Vector3(transform.position.x + parallaxSpeed * Time.deltaTime, transform.position.y, transform.position.z) ;
    }
}
