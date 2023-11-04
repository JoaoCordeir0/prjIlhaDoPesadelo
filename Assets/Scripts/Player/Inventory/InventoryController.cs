using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Objects[] slots;
    public Image[] slotImage;
    public int[] slotAmount;
    private InterfaceController iController;

    [SerializeField]
    private GameObject flashlight;

    [SerializeField]
    private Text taskMessage;

    // Start is called before the first frame update
    void Start()
    {
        iController = FindObjectOfType<InterfaceController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if(Physics.Raycast(ray, out hit, 5f))
        {
            if(hit.collider.tag == "Object")
            {
                iController.itemText.text = "Pression (E) para coletar a " + hit.transform.GetComponent<ObjectType>().objectType.itemName;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(hit.transform.GetComponent<ObjectType>().objectType.itemName == "Flashlight")
                    {
                        flashlight.transform.gameObject.SetActive(true);
                        taskMessage.text = "Ache o mapa que se encontra na cabana.";
                    }

                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i] == null || slots[i].name == hit.transform.GetComponent<ObjectType>().objectType.name) 
                        {
                            slots[i] = hit.transform.GetComponent<ObjectType>().objectType;
                            slotAmount[i]++;
                            slotImage[i].sprite = slots[i].itemSprite;

                            Destroy(hit.transform.gameObject);
                            break;
                        }
                    }
                }
                
            }
            else if (hit.collider.tag != "Object")
            {
                iController.itemText.text = null;
            }
        }
    }
}
