using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsCamController : MonoBehaviour
{
    public float SensX;
    public float SensY;

    public Transform playerOri;
    public Transform CamHolder;

    float xRot;
    float yRot;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;    
    }
    
    void Update()
    {
        transform.position = CamHolder.transform.position;

        float MouseX = Input.GetAxisRaw("Mouse X") * SensX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * SensY;

        yRot += MouseX;
        xRot -= MouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        playerOri.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
