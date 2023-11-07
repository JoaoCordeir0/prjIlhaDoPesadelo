using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth = 3;

    [SerializeField]
    private Image bloodScreenImage = null;

    public GameObject jumpScene;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        BloodScreenImage();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            playerHealth -= 1;

            if (playerHealth == 0)
            {
                BloodScreenImage();
                jumpScene.SetActive(true);
                enemy.SetActive(false);
                StartCoroutine("EndJumpScare");
                //SceneManager.LoadScene("GameOver");
            }
            else
            {
                Color alpha = bloodScreenImage.color;
                alpha.a += 0.4f;
                bloodScreenImage.color = alpha;
            }
        }
    }

    IEnumerator EndJumpScare()
    {
        yield return new WaitForSeconds(2.05f);
        jumpScene.SetActive(false);
        SceneManager.LoadScene("GameOver");
    }

    private void BloodScreenImage()
    {
        Color alpha = bloodScreenImage.color;
        alpha.a = 0;
        bloodScreenImage.color = alpha;
    }
}
