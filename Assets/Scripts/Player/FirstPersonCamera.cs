using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    float sensitivityX = 2f;
    float sensitivityY = 2f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYMax = 90;

    /*float smoothRotx = 0;
    float smoothRoty = 0;

    float smoothCoefx = 0.005f;
    float smoothCoefy = 0.005f;*/

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    void Update()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        //smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
        //smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);
        //rotationX += smoothRotx;
        //rotationY += smoothRoty;

        rotationX += horizontalDelta;
        rotationY += verticalDelta;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYMax);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
