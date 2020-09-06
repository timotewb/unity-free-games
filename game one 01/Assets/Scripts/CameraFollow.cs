using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] float smoothSpeed;
    [SerializeField] Vector3 offset;
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float topLimit;
    [SerializeField] float bottomLimit;

    Vector2 screenHalfSizeWorldUniuts;
    // Start is called before the first frame update
    void Start()
    {
        // get half size of screen
        screenHalfSizeWorldUniuts = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,
            Camera.main.orthographicSize);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = targetTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Limit the Players transform 
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
        // always look at target
        //transform.LookAt(targetTransform);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit)); //top
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit)); //bottom
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit)); //left
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit)); //right   
    }
}
