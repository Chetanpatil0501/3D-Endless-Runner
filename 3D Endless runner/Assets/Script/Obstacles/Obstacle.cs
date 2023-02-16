using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerSpawn._instance._playerCount = 0;
            WinLoose._instance.IsOver = true;
            for (int i = 0; i < PlayerSpawn._instance._spawnSegment.Count; i++)
            {
                Destroy(PlayerSpawn._instance._spawnSegment[i].transform.gameObject);
                Camera.main.GetComponent<_cameraFollow>().enabled = false;
            }
            PlayerSpawn._instance._spawnSegment.Clear();
            
        }
        Destroy(collision.gameObject);

        StartCoroutine(ManagePlayer());
       
    }

    //This method will manage the list of player after destoying them
    IEnumerator ManagePlayer()
    {
        PlayerSpawn._instance._spawnSegment.Clear();
        GameObject[] SpawnCount = GameObject.FindGameObjectsWithTag("SpawnPlayer");

        for (int i = 0; i < SpawnCount.Length; i++)
        {
            PlayerSpawn._instance._spawnSegment.Add(SpawnCount[i].gameObject.transform);
            PlayerSpawn._instance._playerCount = SpawnCount.Length;
        }

        yield break;
    }
}
