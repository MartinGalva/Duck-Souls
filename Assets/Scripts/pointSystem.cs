using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PointSytem : MonoBehaviour
{
    public static PointSytem Instance;
    public TextMeshProUGUI textPoints;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3; 
    public Color color;
    private int points = 0;


    public void AddingPoints(int quantity)
    {
        points += quantity;
        UpdateUI();
    }


    public void SubstractingPoints(int quantity)
    {
        points -= quantity;
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (points < 0)
        {
            points = 0;
        }


        textPoints.text = "Coins: " + points.ToString();

        if (points == 1)
        {
            //coin1.GetComponent<Image>();
        }
    }


    private void Awake()
    {
        

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
