using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePoints : MonoBehaviour
{
    public float hits;

    public GameObject Player;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            hits++;
            Player.GetComponent<PlayerController>().BouncePointCounter(1);
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        Debug.Log("yo");
        yield return new WaitForSeconds(5);
        Debug.Log("YOO");
        Destroy(gameObject);
    }
}
