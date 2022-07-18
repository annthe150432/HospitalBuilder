using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraManagement : MonoBehaviour
{
    private Transform cam;
    private float dragSpeed = 0.6f;
    public bool Dragable = true;
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
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && Camera.main.orthographicSize < 10f) // forward
        {
            Camera.main.orthographicSize += 0.1f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && Camera.main.orthographicSize > 3f)// backwards
        {
            Camera.main.orthographicSize -= 0.1f;
        }
        if (Dragable && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
            float x = -Input.GetAxis("Mouse X") * dragSpeed;
            float y = -Input.GetAxis("Mouse Y") * dragSpeed;
            Vector3 move = new Vector3(x, y, 0);
            cam.Translate(move);
        }
    }
}
