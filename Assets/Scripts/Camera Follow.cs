using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        // Calculate the target position
        Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);

        // Smoothly damp the camera's position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
