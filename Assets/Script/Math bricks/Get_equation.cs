using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Get_equation : MonoBehaviour
{
    //Protected
    [SerializeField] ParticleSystem _boomParticalPrefab;
    [SerializeField] TextMeshProUGUI _positivetextMesh;
    [SerializeField] TextMeshProUGUI _negativetextMesh;
    [SerializeField] string[] _randomString = {"+", "-", "/", "*"};
    
    //Private
    int sign, num;
   
    //Public variables
    public string _getText;
    public float value;



    private void Awake()
    {
        _boomParticalPrefab.Pause();
    }
    private void Start()
    {
        GenerateEq();
        _boomParticalPrefab.Pause();
    }

    //This function will auto generate math equation of bricks 
    void GenerateEq()
    {
        sign = Random.Range(0, 3);
        num = Random.Range(1, 5);
        _negativetextMesh.text = _randomString[sign] + num.ToString();
        if (PlayerSpawn._instance._playerCount < 20)
        {
            if (sign == 1 || sign == 2)
            {
                if (PlayerSpawn._instance._playerCount / num <= 0 || PlayerSpawn._instance._playerCount - num <= 0)
                {
                    sign = 3;
                    num = Random.Range(1, 5);
                    _positivetextMesh.text = _randomString[sign] + num.ToString();
                }
            }
        }

        if (PlayerSpawn._instance._playerCount > 20)
        {
            sign = Random.Range(0, 3);
            num = Random.Range(1, 5);
            _positivetextMesh.text = _randomString[sign] + num.ToString();
        }
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _boomParticalPrefab.transform.position = other.gameObject.transform.position;
            _boomParticalPrefab.Play();
            Destroy(gameObject, 3f);
        }
    }

}
