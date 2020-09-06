using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRotatePlatforms : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    float rotate = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate >= 360)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rotate = 0;
        }
        else
        {
            rotate += rotationSpeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotate);
    }
}
