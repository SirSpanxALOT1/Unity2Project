using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{


    [Tooltip("Remaining player lives.")]
    private int _playerLives = 3;


    [SerializeField, Tooltip("Where the player will re-spawn.")]
    private Transform _respawnPostion;


    static public GameSessionManager Instance;


    //string levelMap01;


    void Awake()
    {
        // the GameSessionManager is a Singleton
        // store this as the instance of this object
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {


    }


    public void onPlayerDeath(GameObject player)
    {
        if (_playerLives <= 0)
        {
            // player is out of lives
            GameObject.Destroy(player.gameObject);
            Debug.Log("Game over!");
        }
        else
        {
            // use a life to respawn the player
            _playerLives--;


            // reset health
            HealthManager playerHealth = player.GetComponent<HealthManager>();
            if (playerHealth)
                playerHealth.Reset();


            if (_respawnPostion)
                player.transform.position = _respawnPostion.position;


            Debug.Log("Player lives remaining: " + _playerLives);
        }
    }


    public int GetCoins() { return PickUpItem.s_objectsCollected; }


    public int GetLives() { return _playerLives; }


}