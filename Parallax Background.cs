using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;
    private Vector2 startPosition;
    private float startZ;


    
    float zDistancefromTarget => transform.position.z - followTarget.position.z;

    float ClipingPlane => (cam.transform.position.z + (zDistancefromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float ParallaxFactor => Mathf.Abs(zDistancefromTarget) / ClipingPlane;

    Vector2 CameraMoveSinceStart => (Vector2)cam.transform.position - startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startPosition + CameraMoveSinceStart * ParallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startZ);
    }
}
