using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public static bool isAnyFood = false;


    void Start()
    {
        // Created first food after Game start.
        
    }

    void Update()
    {
        if (!isAnyFood)
        {
            Spawn();
        }
    }



    /// <summary>
    /// Create new foodPrefab in random position.
    /// </summary>
    public void Spawn()
    {
        int x = 0;
        int y = 0;
        // Random coordinates x and y.
        x = (int)Random.Range(1, 53);
        y = (int)Random.Range(1, 76);
        SpawnFood.isAnyFood = true;

        //foodPrefab.AddComponent<Rigidbody>();
        //foodPrefab.transform.position = new Vector3(x, y, 0);

        Instantiate(foodPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }
}
