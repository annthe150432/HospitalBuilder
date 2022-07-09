using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    private Transform cam;
    private float dragSpeed = 0.6f;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            Camera.main.orthographicSize += 0.1f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            Camera.main.orthographicSize -= 0.1f;
        }
        if (Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
            float x = -Input.GetAxis("Mouse X") * dragSpeed;
            float y = -Input.GetAxis("Mouse Y") * dragSpeed;
            Vector3 move = new Vector3(x, y, 0);
            cam.Translate(move);
        }
    }
}