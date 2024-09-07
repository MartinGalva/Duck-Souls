using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba_0 : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;


    private void Update()
    {
    if (Input.GetKey(KeyCode.W))
    {
    transform.Translate(Vector3.up * (movementSpeed * Time.deltaTime));
    }


    if (Input.GetKey(KeyCode.A))
    {
    transform.Translate(Vector3.left * (movementSpeed * Time.deltaTime));
    }


    if (Input.GetKey(KeyCode.D))
    {
    transform.Translate(Vector3.right * (movementSpeed * Time.deltaTime));
    }


    if (Input.GetKey(KeyCode.S))
    {
    transform.Translate(Vector3.down * (movementSpeed * Time.deltaTime));        }
    }

}
