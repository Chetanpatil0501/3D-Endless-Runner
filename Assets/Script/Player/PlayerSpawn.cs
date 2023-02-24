
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerSpawn : MonoBehaviour
{
    //private variables
    GameObject SpawnedPlayer;

    //Public variables
    public Vector3 bounds;
    public static PlayerSpawn _instance = null;
    public int _playerCount = 1;
    public List<Transform> _spawnSegment = new List<Transform>();

    //Protected variables
    [SerializeField] int _countDifference = 1;
    [SerializeField] AssetReference _playerprefab;
   
    // Start is called before the first frame update
    void Start()
    {
        _countDifference = 1;
        _playerCount = 1;
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // This will update spawning position 
        bounds = new Vector3(gameObject.transform.position.x, transform.position.y, gameObject.transform.position.z); 
        
        
    }

    //This function is for spawning player prefabs
   public void spawnPlayer(int count)
    {
        
        _countDifference = Mathf.Abs(_playerCount - count);
        _playerCount += _countDifference;

        Quaternion spawnRot = Quaternion.identity;

        for (int i = 0; i < _countDifference; i++)
        {
            for (int j = 0; j < _countDifference; j++)
            {
                if (i%2 == 0)
                {
                    bounds.x += 0.02f;
                }
                if (i%2 != 0)
                {
                    bounds.x -= 0.02f;
                }

                bounds.z -= 0.04f;
            }
            if (count >= _playerCount)
            {
                Addressables.LoadAssetAsync<GameObject>(_playerprefab).Completed +=
               (asyncOperation) =>
               {
                   if (asyncOperation.Status == AsyncOperationStatus.Succeeded)
                   {
                       SpawnedPlayer = Instantiate(asyncOperation.Result, bounds, Quaternion.identity);
                       _spawnSegment.Add(SpawnedPlayer.transform);
                   }
                   else
                   {
                       Debug.LogError("Failed");
                   }
               };
            }
 
        }
    }

    //This function is for destroying player prefab
    public void Destroy_player(int count)
    {
        if (count <= 0)
        {
            Destroy(gameObject);
            count = 0;
        }

        if (count <= 0)
        {
            for (int i = 0; i < _spawnSegment.Count; i++)
            {
                Destroy(_spawnSegment[i].gameObject);
                
            }
            _spawnSegment.Clear();
        }
        if (count < _playerCount)
        {
            
            _playerCount = count;
            _countDifference = Mathf.Abs(_playerCount - count);

            for (int i = _playerCount; i < _spawnSegment.Count; i++)
            {
                Debug.Log(i);
                if (_spawnSegment[i].gameObject != null)
                {
                    Destroy(_spawnSegment[i].gameObject);
                    Debug.Log("destroy player");
                }
               
                if (i == _spawnSegment.Count -1)
                {
                    _spawnSegment.RemoveRange(_playerCount, _spawnSegment.Count - _playerCount);
                    Debug.Log("Elements removed");
                }
            }
          
           
        }

    }


  
}
