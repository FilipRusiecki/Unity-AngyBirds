using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> availavlePlayers = new List<GameObject>();
    public List<enemy> enemies = new List<enemy>();
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnNewPlayer();
    }
    public void SpawnNewPlayer()
    {

        PlayerLauncher.instance.SetNewPlayer(availavlePlayers[0]);
        //camerafollow.instance.SetPlayer(PlayerLauncher.instance.player);
        availavlePlayers.RemoveAt(0);

    }

    public void PlayerFinished()
    {
        SpawnNewPlayer();
    }
    public void DestroyEnemy(enemy enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
    void Update()
    {
        
    }
}
