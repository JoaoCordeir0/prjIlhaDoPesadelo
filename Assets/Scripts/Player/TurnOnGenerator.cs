using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnOnGenerator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit, 5f))
        {
            if(hit.collider.tag == "Generator") 
            {
                if(Input.GetKeyDown(KeyCode.E)) 
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}
