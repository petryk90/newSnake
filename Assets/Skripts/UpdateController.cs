using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class UpdateController : MonoBehaviour, IUpdateable
{

    //List<IUpdateable> objects = new List<IUpdateable>();
    private bool eate = false;
    private int count = 0;
    public GameObject tail;
    List<Transform> objects = new List<Transform>();
    GameObject[] gameObjects = new GameObject[30];
    private bool[] direction = { false, false, false, false };
    int dir;
    int n = 0;
    private float step = 0.05f;
    float x = 0;
    float y = 0;
    GameObject g;

    void Start()
    {
        Vector3 v = transform.localPosition;
        for (int i = 0; i < 10; i++)
        {
            g = (GameObject)Instantiate(tail, v, Quaternion.identity);
            objects.Insert(0, g.transform);
        }
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


        Move(step);



    }
    /// <summary>
    /// In this method we make our snake to move with some spped to another direction.
    /// </summary>
    /// <param name="speed">Speed for our Snake</param>
    public void Move(float speed)
    {
        Vector3 v = transform.localPosition;


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
            if (transform.localPosition.y < 1)
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
            if (transform.localPosition.x < 1)
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

        if (eate)
        {
            for (int i = 0; i < 20; i++)
            {
                g = (GameObject)Instantiate(tail, v, Quaternion.identity);
                gameObjects[i] = g;
                n += 20;
                objects.Insert(0, g.transform);
            }
            eate = false;
        }
        else if (objects.Count > 0)
        {
            objects.Last().localPosition = v;
            objects.Insert(0, objects.Last());
            objects.RemoveAt(objects.Count - 1);
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
            if (count == 3)
            {
                Tail();
            }
        }
    }

    void Tail()
    {
        foreach (GameObject objf in GameObject.FindGameObjectsWithTag("snakeTailPrefab(Clone)"))
        {
            Destroy(objf);
        }
        //for (int i = 0; i < gameObjects.Length; i++)
        //{
        //    Destroy(gameObjects[i]);
        //}
        step += 0.05f;
        objects.Clear();
        count = 0;
    }
}

