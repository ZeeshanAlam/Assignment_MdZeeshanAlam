using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject childPrefab;
    GameObject child;
    public Transform Left;
    public Transform Right;
    public Transform Up;
    public Transform Down;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "food")
        {
            Destroy(other.gameObject);
            FindObjectOfType<GameManager>().OnScore();
            FindObjectOfType<GameManager>().spawnFood();
            child = Instantiate(childPrefab,transform.parent);
            int childcount = transform.parent.childCount;
            /*if (transform.position.z == transform.parent.GetChild(childcount - 2).position.z)
            {
                if(transform.position.z> transform.parent.GetChild(childcount - 2).position.z)
                    child.transform.position = transform.parent.GetChild(childcount - 2).position + new Vector3(-0.5f,0,0);
                else
                    child.transform.position = transform.parent.GetChild(childcount - 2).position + new Vector3(0.5f, 0, 0);
            }
            else
            {
                child.transform.position = transform.parent.GetChild(childcount - 2).position + new Vector3(0, 0, -0.5f);
            }*/
            child.transform.position = transform.parent.GetChild(childcount - 2).position;
        }
        else if (other.transform.tag == "wall")
        {
            FindObjectOfType<GameManager>().onPlayerDied();
        }
    }
}
