using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class UpdateController : MonoBehaviour, IUpdateable
{


    private bool eate = false;
    private int count = 0;
    public GameObject tail;
    List<Transform> objects = new List<Transform>();
    List<Vector3> vect = new List<Vector3>();
    private bool[] direction = { false, false, false, false };
    int dir;
    private int lifeCountt;
    private int eatedFood;
    private int levelCountt;
    private float step = 0.05f;
    public Text levelCount;
    public Text lifeCount;
    public Text eatedFoodCount;
    float x = 0;
    float y = 0;
    GameObject g;


    void Start()
    {

        // make Snake longer
        Vector3 v = transform.localPosition;
        for (int i = 0; i < 10; i++)
        {
            g = (GameObject)Instantiate(tail, new Vector3(v.x, v.y, 0), Quaternion.identity);
            objects.Insert(0, g.transform);
            
        }
        lifeCountt = 3;
        eatedFood = 0;
        levelCountt = 1;

    }

    void Update()
    {
        levelCount.text = Convert.ToString(levelCountt);
        lifeCount.text = Convert.ToString(lifeCountt);
        eatedFoodCount.text = Convert.ToString(eatedFood);

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

        if (direction[0] && v.x % 1 == 0)
        {
            dir = 1;
            y += speed;
            transform.Translate(x, y, 0);
            if (v.y > 76)
            {
                transform.Translate(x, y - 76, 0);
            }
        }
        else if (direction[0] && v.x % 1 != 0)
        {
            if (dir == -1)
            {
                float move = Math.Abs(v.x % 1);
                transform.Translate(x - move, y, 0);
            }
            if (dir == 1)
            {
                float move = 1 - Math.Abs(v.x % 1);
                transform.Translate(x + move, y, 0);
            }
        }

        if (direction[1] && v.x % 1 == 0)
        {
            dir = -1;
            y -= speed;
            transform.Translate(x, y, 0);
            if (v.y < 1)
            {
                transform.Translate(x, y + 76, 0);
            }
        }
        else if (direction[1] && v.x % 1 != 0)
        {
            if (dir == -1)
            {
                float move = Math.Abs(v.x % 1);
                transform.Translate(x - move, y, 0);
            }
            if (dir == 1)
            {
                float move = 1 - Math.Abs(v.x % 1);
                transform.Translate(x + move, y, 0);
            }
        }

        if (direction[2] && v.y % 1 == 0)
        {
            dir = 1;
            x += speed;
            transform.Translate(x, y, 0);
            if (v.x > 53)
            {
                transform.Translate(x - 53, y, 0);
            }
        }
        else if (direction[2] && v.y % 1 != 0)
        {
            if (dir == -1)
            {
                float move = Math.Abs(v.y % 1);
                transform.Translate(x, y - move, 0);
            }
            if (dir == 1)
            {
                float move = 1 - Math.Abs(v.y % 1);
                transform.Translate(x, y + move, 0);
            }
        }

        if (direction[3] && v.y % 1 == 0)
        {
            dir = -1;
            x -= speed;
            transform.Translate(x, y, 0);
            if (v.x < 1)
            {
                transform.Translate(x + 53, y, 0);
            }
        }
        else if (direction[3] && v.y % 1 != 0)
        {
            if (dir == -1)
            {
                float move = Math.Abs(v.y % 1);
                transform.Translate(x, y - move, 0);
            }
            if (dir == 1)
            {
                float move = 1 - Math.Abs(v.y % 1);
                transform.Translate(x, y + move, 0);
            }
        }
        // if Snake eate food we create tail and add to our transform list
        if (eate)
        {
            for (int j = 0; j < 20; j++)
            {
                if (direction[0])
                {
                    g = (GameObject)Instantiate(tail, new Vector3(v.x, v.y + 1, 0), Quaternion.identity);
                }
                if (direction[1])
                {
                    g = (GameObject)Instantiate(tail, new Vector3(v.x, v.y - 1, 0), Quaternion.identity);
                }
                if (direction[2])
                {
                    g = (GameObject)Instantiate(tail, new Vector3(v.x + 1, v.y, 0), Quaternion.identity);
                }
                if (direction[3])
                {
                    g = (GameObject)Instantiate(tail, new Vector3(v.x - 1, v.y, 0), Quaternion.identity);
                }

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


    void newTail()
    {

    }
    /// <summary>
    /// destroy food when snake eate it, and if snake eate some count of food call Tail() method
    /// </summary>
    /// <param name="food"></param>
    void OnTriggerEnter2D(Collider2D food)
    {
        if (food.name.StartsWith("foodPrefab"))
        {
            eate = true;
            Destroy(food.gameObject);
            count++;
            eatedFood++;
            SpawnFood.isAnyFood = false;
            if (count == 10)
            {
                Tail();
            }
        }
        else
        {
            for (int i = 11; i < eatedFood * 20; i++)
            {
                if (objects.First().localPosition == objects[i].localPosition)
                {
                    lifeCountt--;
                }
            }


        }
    }

    void Tail()
    {
        // destroy Snake Tail before grown speed
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        // grown speed after eating count food
        step += 0.05f;
        objects.Clear();
        count = 0;
        // level up
        levelCountt++;
    }
}

