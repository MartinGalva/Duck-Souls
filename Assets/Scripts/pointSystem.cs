using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PointSytem : MonoBehaviour
{
    public static PointSytem Instance;
    public TextMeshProUGUI textPoints;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    private Color color;
    private int points = 0;
    private Image imagen1;
    private Image imagen2;
    private Image imagen3;


    void Start() {
        imagen1 = coin1.GetComponent<Image>();
        imagen2 = coin2.GetComponent<Image>();
        imagen3 = coin3.GetComponent<Image>();
    }

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
           cambiarAlpha1();
        }
        if (points == 2)
        {
           cambiarAlpha2();
        }
        if (points == 3)
        {
           cambiarAlpha3();
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

    public void cambiarAlpha1() {
        Color nuevoColor = imagen1.color;
        nuevoColor.a = 1f;
        imagen1.color = nuevoColor;
    }

    public void cambiarAlpha2() {
        Color nuevoColor = imagen2.color;
        nuevoColor.a = 1f;
        imagen2.color = nuevoColor;
    }

    public void cambiarAlpha3() {
        Color nuevoColor = imagen3.color;
        nuevoColor.a = 1f;
        imagen3.color = nuevoColor;
    }
}
