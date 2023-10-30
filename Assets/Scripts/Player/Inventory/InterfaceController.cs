using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Text itemText;
    bool invActive;

    // Start is called before the first frame update
    void Start()
    {
        itemText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            invActive = !invActive;
            inventoryPanel.SetActive(invActive);
        }
            
        if(invActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
