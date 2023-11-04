using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth = 3;

    [SerializeField]
    private Image bloodScreenImage = null;
    [SerializeField]
    private GameObject restartPanel;


    // Start is called before the first frame update
    void Start()
    {
        Color alpha = bloodScreenImage.color;
        alpha.a = 0;
        bloodScreenImage.color = alpha;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            playerHealth -= 1;

            if(playerHealth == 0)
            {
                restartPanel.SetActive(true);
                bloodScreenImage.gameObject.SetActive(false);
            }
            else
            {
                Color alpha = bloodScreenImage.color;
                alpha.a += 0.4f;
                bloodScreenImage.color = alpha;
            }       
        }
    }
}
