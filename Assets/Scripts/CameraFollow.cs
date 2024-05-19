using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothnessRateX, smoothnessRateY;

    void Start() {
        
    }

    void Update() {
        
    }

    private void FixedUpdate() {
        Vector3 playerPos = playerTransform.position;
        Vector3 cameraPos = transform.position;
        // cameraPos.x = Mathf.Lerp(cameraPos.x, playerPos.x, smoothnessRateX);
        // cameraPos.y = Mathf.Lerp(cameraPos.y, playerPos.y, smoothnessRateY); // for better smooth movement change
        cameraPos.x = Mathf.Lerp(cameraPos.x+0.3f, playerPos.x+0.3f, smoothnessRateX);
        cameraPos.y = Mathf.Lerp(cameraPos.y+0.15f, playerPos.y+0.15f, smoothnessRateY); 
        transform.position = cameraPos;
    }
}
