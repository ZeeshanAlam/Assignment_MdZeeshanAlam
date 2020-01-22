using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float step;
    public float frequency;
    float counter;
    public Vector3 newPos;

    bool horizontal = false;
    bool vertical = false;

    public void Right()
    {
        if (!horizontal)
        {
            changePos(1);
            horizontal = true;
            vertical = false;
        }
    }

    public void Left()
    {
        if (!horizontal)
        {
            changePos(2);
            horizontal = true;
            vertical = false;
        }
    }

    public void Up()
    {
        if (!vertical)
        {
            changePos(3);
            vertical = true;
            horizontal = false;
        }
    }

    public void Down()
    {
        if (!vertical)
        {
            changePos(4);
            vertical = true;
            horizontal = false;
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Right();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Left();
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Up();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Down();
        }
        counter += Time.deltaTime;
        if(counter >= frequency)
        {
            counter = 0;
            move();
        }
    }

    public void changePos(int index)
    {
        if(index == 1)
        {
            newPos = new Vector3(step, 0, 0);
        }
        else if (index == 2)
        {
            newPos = new Vector3(-step, 0, 0);
        }
        else if (index == 3)
        {
            newPos = new Vector3(0, 0, step);
        }
        else if (index == 4)
        {
            newPos = new Vector3(0, 0, -step);
        }
    }


    void move()
    {
        Vector3 parentPos = transform.GetChild(0).position;
        Vector3 prevPos;
        transform.GetChild(0).position = transform.GetChild(0).position + newPos;

        for (int i =1; i < transform.childCount; i++)
        {
            prevPos = transform.GetChild(i).position;
            transform.GetChild(i).position = parentPos;
            parentPos = prevPos;
        }
    }

}
