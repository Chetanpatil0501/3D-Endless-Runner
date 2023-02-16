using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoose : MonoBehaviour
{
    [SerializeField] GameObject _winLoosePanel;     //Win loose panel
    [SerializeField] TextMeshProUGUI _winLooseText; //Win loose title text
    [SerializeField] TextMeshProUGUI _FinalScore;       //Win loose panel score text
    [SerializeField] Score score;       //reference of score script
    [SerializeField] GameObject scoreobj; //In game UI score text

    public bool IsOver; //boolean for check if all players die or not

    public static WinLoose _instance = null;  //Singalton pattern
    

    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        _winLoosePanel.SetActive(false);
        IsOver = false;
    }

    private void FixedUpdate()
    {
        if (IsOver)
        {
            _winLoosePanel.SetActive(true);
            _winLooseText.text = "You loose";
            _winLooseText.color = Color.red;
            _FinalScore.gameObject.SetActive(false);
            Camera.main.GetComponent<_cameraFollow>().enabled = false;
            scoreobj.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player") && !IsOver)
        {
            _winLoosePanel.SetActive(true);
            _winLooseText.text = "You Win";
            _winLooseText.color = Color.green;
            _FinalScore.text = "Score : " + score.score.ToString();
            scoreobj.SetActive(false);
        }
    }


}
