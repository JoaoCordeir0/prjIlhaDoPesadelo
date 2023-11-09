using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnOnGenerator : MonoBehaviour
{
    private InterfaceController iController;

    [SerializeField]
    private GameObject cutsceneCamera;

    void Start()
    {
        iController = FindObjectOfType<InterfaceController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.tag == "Generator")
            {
                iController.itemText.text = "Pressione (E) para ligar o gerador e salvar a todos na ilha.";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    iController.itemText.text = null;
                    cutsceneCamera.SetActive(true);
                    StartCoroutine("EndCutscene");
                }
            }
            else if (hit.collider.tag == "FakeGenerator")
            {
                iController.itemText.text = "Ops parece que esse gerador não está funcionando.";
            }
        }
    }

    IEnumerator EndCutscene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("EndGame");
    }
}
