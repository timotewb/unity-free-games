using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject thePlayer;
    PlayerMovement movementScript;
    // Start is called before the first frame update
    void Start()
    {
        //get speed from movement script
        //GameObject thePlayer = GameObject.Find("Player");
        movementScript = thePlayer.GetComponent<PlayerMovement>();
        //movementScript.speed;

        Transform[] children = GetComponentsInChildren<Transform>();
        // print out the speed for each child

        foreach (Transform child in transform)
        {
            float distanctFromPlayer = (playerTransform.transform.position.z - child.position.z);
            float velocity = (movementScript.moveSpeed / distanctFromPlayer);
            if (Mathf.Infinity == velocity)
            {
                velocity = 0;
            }
            print(child.name + " DFP: " + distanctFromPlayer + " V: " + velocity);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Transform child in transform)
        {
            float distanctFromPlayer = (playerTransform.transform.position.z - child.position.z);
            float speedChange = (movementScript.moveSpeed / distanctFromPlayer);
            if (Mathf.Infinity == speedChange)
            {
                speedChange = 0;
            }
            float directionX = Input.GetAxisRaw("Horizontal");
            float velocity = (speedChange) * directionX;
            child.Translate(Vector2.right * velocity * Time.deltaTime);
        }
    }
}
