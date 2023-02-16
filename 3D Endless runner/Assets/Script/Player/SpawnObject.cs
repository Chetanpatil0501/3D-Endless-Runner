using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] AssetReference[] assetReference;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < assetReference.Length; i++)
            {
                Addressables.LoadAssetAsync<GameObject>(assetReference[i]).Completed +=
                (asyncOperation) =>
                {
                    if (asyncOperation.Status == AsyncOperationStatus.Succeeded)
                    {
                        Instantiate(asyncOperation.Result);
                    }
                    else
                    {
                        Debug.LogError("Failed");
                    }
                };
            }
           
        }
    }

}
