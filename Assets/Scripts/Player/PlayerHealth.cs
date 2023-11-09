using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject jumpScene;
    public GameObject enemy;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            jumpScene.SetActive(true);
            enemy.SetActive(false);
            StartCoroutine("EndJumpScare");
        }
    }

    IEnumerator EndJumpScare()
    {
        yield return new WaitForSeconds(2.05f);
        jumpScene.SetActive(false);
        SceneManager.LoadScene("GameOver");
    }
}
