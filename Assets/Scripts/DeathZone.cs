using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    public GameObject DeathScreen;
    public GameObject counter;
    public Text text;
    public GameObject playerController;

    void Start()
    {
        counter.SetActive(true);
        DeathScreen.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            counter.SetActive(false);
            DeathScreen.SetActive(true);
            text.text = "YOUR SCORE IS: " + playerController.GetComponent<PlayerController>().BouncePoints.ToString();
        }
        if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }

    }
}
