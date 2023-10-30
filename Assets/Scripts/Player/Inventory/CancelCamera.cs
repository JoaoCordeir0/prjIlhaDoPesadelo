using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelCamera : MonoBehaviour
{
    private FirstPersonCamera mouseLook;
    private PlayerMovement playerController;

    private void OnEnable()
    {
        mouseLook = FindObjectOfType<FirstPersonCamera>();
        playerController = FindObjectOfType<PlayerMovement>();

        mouseLook.CancelCamera(false);
        playerController.CancelMove(false);
    }

    private void OnDisable()
    {
        mouseLook = FindObjectOfType<FirstPersonCamera>();
        playerController = FindObjectOfType<PlayerMovement>();

        mouseLook.CancelCamera(true);
        playerController.CancelMove(true);
    }
}
