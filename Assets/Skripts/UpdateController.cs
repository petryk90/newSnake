using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class UpdateController : MonoBehaviour, IUpdateable
{

    List<IUpdateable> objects = new List<IUpdateable>();
    private bool eate = false;
    private int count = 1;
    public GameObject tail;
    public IUpdateable obj;
    private bool[] direction = { false, false, false, false };
    int dir;
    float x = 0;
    float y = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction[0] = true;
            direction[1] = false;
            direction[2] = false;
            direction[3] = false;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction[0] = false;
            direction[1] = true;
            direction[2] = false;
            direction[3] = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction[0] = false;
            direction[1] = false;
            direction[2] = true;
            direction[3] = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction[0] = false;
            direction[1] = false;
            direction[2] = false;
            direction[3] = true;
        }

        float step = 0.2f;
        Move(step);
        //foreach (IUpdateable obj in objects)
        //{
        //    Move(step);
        //}
        
    }
    /// <summary>
    /// In this method we make our snake to move with some spped to another direction.
    /// </summary>
    /// <param name="speed">Speed for our Snake</param>
    public void Move(float speed)
    {
        x = 0;
        y = 0;

        if (direction[0] && transform.localPosition.x % 1 == 0)
        {
            dir = 1;
            y += speed;
            transform.Translate(x, y, 0);
            if (transform.localPosition.y > 80)
            {
                transform.Translate(x, y - 80, 0);
            }
        }
        else if (direction[0] && transform.localPosition.x % 1 != 0)
        {
            if (dir == -1)
            {
                float move = Math.Abs(transform.localPosition.x % 1);
                transform.Translate(x - move, y, 0);
            }
            if (dir == 1)
            {
                float move = 1 - Math.Abs(transform.localPosition.x % 1);
                transform.Translate(x + move, y, 0);
            }
        }

        if (direction[1] && transform.localPosition.x % 1 == 0)
        {
            dir = -1;
            y -= speed;
            transform.Translate(x, y, 0);
            if (transform.localPosition.y < 0)
            {
                transform.Translate(x, y + 80, 0);
            }
        }
        else if (direction[1] && transform.localPosition.x % 1 != 0)
        {
            if (dir == -1)
            {
                float move = Math.Abs(transform.localPosition.x % 1);
                transform.Translate(x - move, y, 0);
            }
            if (dir == 1)
            {
                float move = 1 - Math.Abs(transform.localPosition.x % 1);
                transform.Translate(x + move, y, 0);
            }
        }

        if (direction[2] && transform.localPosition.y % 1 == 0)
        {
            dir = 1;
            x += speed;
            transform.Translate(x, y, 0);
            if (transform.localPosition.x > 54)
            {
                transform.Translate(x - 54, y, 0);
            }
        }
        else if (direction[2] && transform.localPosition.y % 1 != 0)
        {
            if (dir == -1)
            {
                float move = Math.Abs(transform.localPosition.y % 1);
                transform.Translate(x, y - move, 0);
            }
            if (dir == 1)
            {
                float move = 1 - Math.Abs(transform.localPosition.y % 1);
                transform.Translate(x, y + move, 0);
            }
        }

        if (direction[3] && transform.localPosition.y % 1 == 0)
        {
            dir = -1;
            x -= speed;
            transform.Translate(x, y, 0);
            if (transform.localPosition.x < 0)
            {
                transform.Translate(x + 54, y, 0);
            }
        }
        else if (direction[3] && transform.localPosition.y % 1 != 0)
        {
            if (dir == -1)
            {
                float move = Math.Abs(transform.localPosition.y % 1);
                transform.Translate(x, y - move, 0);
            }
            if (dir == 1)
            {
                float move = 1 - Math.Abs(transform.localPosition.y % 1);
                transform.Translate(x, y + move, 0);
            }
        }
    }    

    void OnTriggerEnter2D(Collider2D food)
    {
        if (food.name.StartsWith("foodPrefab"))
        {
            eate = true;
            Destroy(food.gameObject);
            count++;
            SpawnFood.isAnyFood = false;
        }
    }
}

