using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressHandler : MonoBehaviour
{
    public GameObject PlayerWonPanel;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            PlayerWonPanel.SetActive(true);
        }
    }
}
