using System.Collections;
using System;
using System.Data;
using UnityEngine;
using TMPro;


public class SetEquation : MonoBehaviour
{

    string _count; 

    [SerializeField] TextMeshProUGUI _equation;
    [SerializeField]float _getcount;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            StartCoroutine(SpawnDestroy());   
        }
    }

   //This coroutine will work on player spawning and destoying with the math equation
    IEnumerator SpawnDestroy()
    {
        _count = PlayerSpawn._instance._playerCount + _equation.text;
        Debug.Log(_count);
        DataTable table = new DataTable();
        object result = table.Compute(_count, "");
        _getcount = Convert.ToSingle(result);

        int _toInt = Convert.ToInt32(_getcount);
        Debug.Log(_toInt);

        if (_toInt > PlayerSpawn._instance._playerCount)
        {
            PlayerSpawn._instance.spawnPlayer(_toInt);
        }

        if (_toInt < PlayerSpawn._instance._playerCount)
        {
            PlayerSpawn._instance.Destroy_player(_toInt);
        }

        if (_toInt <= 0 )
        {
            WinLoose._instance.IsOver = true;
        }
       
        yield break;
    }
   
}
