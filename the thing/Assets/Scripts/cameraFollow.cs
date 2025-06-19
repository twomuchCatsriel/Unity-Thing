using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera cam;


    // Update is called once per frame
    void FixedUpdate()
    {
        cam.transform.position = new Vector3(transform.position.x + 4, transform.position.y, -10);
    }
}
