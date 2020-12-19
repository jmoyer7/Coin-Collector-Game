using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public List<string> myItems;

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private GameObject[] items;

    private float nextSpawnTime = 0.0f;
    public float spawnPeriod = 5f;

    public float fasterSpeed = 10f;
    public float slowerSpeed = 1f;

    private bool speedPower = false;
    private bool slowPower = false;
    private float nextTimeSpeed = 0f;
    private float nextTimeSlow = 0f;
    public float speedPeriod = 5f;

    private void Start()
    {
        myItems = new List<string>();
        SpawnCoin();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            string itemType = collision.gameObject.GetComponent<CollectibleScript>().itemType;
            print("we have collected a: " + itemType);
            myItems.Add(itemType);
            Destroy(collision.gameObject);

            if (itemType == "coin")
            {
                SpawnCoin();
                ScoreScript1.scoreTotal += 1;
            }
            else if (itemType == "speed")
            {
                GameObject.Find("Coin Collector").GetComponent<PlayerMovement>().moveSpeed = fasterSpeed;
                speedPower = true;
                nextTimeSpeed = Time.time + speedPeriod;
            }
            else if (itemType == "time")
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Protector");
                foreach (GameObject g in enemies)
                {
                    g.GetComponent<Wander>().speed = slowerSpeed;
                }

                slowPower = true;
                nextTimeSlow = Time.time + speedPeriod;
            }
            else if (itemType == "health")
            {
                GameObject.Find("LifeCounter").GetComponent<LifeCounter>().AddLife();
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            GameObject.Find("LifeCounter").GetComponent<LifeCounter>().LoseLife();
        }

    }

    private void SpawnCoin()
    {
        bool coinSpawned = false;

        while (!coinSpawned)
        {
            Vector3 coinPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-2f, 4f), 0f);
            if ((coinPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(coin, coinPosition, Quaternion.identity);
                coinSpawned = true;
            }
        }
    }

    private void SpawnItem()
    {
        bool ItemSpawned = false;

        while (!ItemSpawned)
        {
            Vector3 itemPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-2f, 4f), 0f);
            if ((itemPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(items[Random.Range(0, items.Length)], itemPosition, Quaternion.identity);
                ItemSpawned = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (speedPower)
        {

            if (Time.time > nextTimeSpeed)
            {
                speedPower = false;
                GameObject.Find("Coin Collector").GetComponent<PlayerMovement>().moveSpeed = GameObject.Find("Coin Collector").GetComponent<PlayerMovement>().baseMoveSpeed;

            }
        }

        if (slowPower)
        {
            if (Time.time > nextTimeSlow)
            {
                slowPower = false;

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Protector");
                foreach (GameObject g in enemies)
                {
                    g.GetComponent<Wander>().speed = g.GetComponent<Wander>().baseSpeed;
                }

            }
        }

        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnPeriod;
            SpawnItem();
        }
    }

}


