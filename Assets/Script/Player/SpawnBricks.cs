
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnBricks : MonoBehaviour
{
    [SerializeField] AssetReference _brickPrefab;
    [SerializeField] Vector3 _position;


    // Update is called once per frame
    void Update()
    {
        _position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 20);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < 1; i++)
            {
                if (_position.z <= 95)
                {
                    spawn();
                }
               
            }
           
        }
    }

    void spawn()
    {
        
        Addressables.LoadAssetAsync<GameObject>(_brickPrefab).Completed +=
               (asyncOperation) =>
               {
                   if (asyncOperation.Status == AsyncOperationStatus.Succeeded)
                   {
                       Instantiate(asyncOperation.Result, _position, Quaternion.identity);
                   }
                   else
                   {
                       Debug.LogError("Failed");
                   }
               };
    }
}
