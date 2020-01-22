using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "child")
        {
            if(transform.parent.parent.childCount>2)
            FindObjectOfType<GameManager>().onPlayerDied();
        }
    }
}
