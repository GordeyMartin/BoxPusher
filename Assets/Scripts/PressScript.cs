using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressScript : MonoBehaviour
{
    public LayerMask UnwalkableLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            MultiplePress.totalPresses++;

            other.gameObject.layer = Mathf.RoundToInt(Mathf.Log(UnwalkableLayer.value, 2));

            gameObject.SetActive(false);
        }
    }

}
