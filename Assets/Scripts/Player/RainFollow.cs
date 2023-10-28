using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollow : MonoBehaviour
{
    private float rainSmoothSpeed = .2f;
    public Transform player;
    Vector3 currentPlayerPos;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        currentPlayerPos = new Vector3(player.localPosition.x, player.localPosition.y + 20, player.localPosition.z);
        transform.position = Vector3.SmoothDamp(transform.position, currentPlayerPos, ref velocity, rainSmoothSpeed);
    }
}
