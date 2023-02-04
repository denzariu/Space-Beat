using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    //private enum targetType { basic, harmful };

    [SerializeField]
    private GameObject[] targetPrefab;
    [SerializeField]
    private GameObject[] spawnPrefab;
    [SerializeField]
    private float spawnTime = 2f;
    private float spawnTimeCopy;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float rangeX = 0f;
    [SerializeField]
    private float rangeZ = 0f;

    private float randX;
    private float randZ;

    [SerializeField]
    private bool isAsteroid;

    [SerializeField]
    private float offset = 0.45f;

    [SerializeField]
    private bool rotated;

    private float time;

    public string spawnString;
    private int spawnIndex = 0;
    private bool wasNotSpawned = true;

    private int i;

    public void changeString (string str)
    {
        str = Regex.Replace(str, @"\s", "");
        spawnString = str;
    }

    void Start()
    {
        time = Time.time;
        if (isAsteroid)
        {
            spawnTimeCopy = spawnTime;
            spawnTime = spawnTimeCopy + Random.Range(0, spawnTimeCopy);
        }

    }

    void Update()
    {

        if (time + spawnTime < Time.time + offset)
        {
            time = Time.time + offset;

            // Hardcoded only for preview purposes
            if ((i != 0 & i != 2) || isAsteroid)
            {
                if (rotated)
                {
                    GameObject temp = Instantiate(targetPrefab[i], new(transform.position.x + randX * rangeX, transform.position.y, transform.position.z + randZ * rangeZ), Quaternion.Euler(0, 90, 0));
                    temp.GetComponent<Rigidbody>().mass = speed;
                }
                else
                {
                    GameObject temp = Instantiate(targetPrefab[i], new(transform.position.x + randX * rangeX, transform.position.y, transform.position.z + randZ * rangeZ), Quaternion.identity);
                    temp.GetComponent<Rigidbody>().mass = speed;
                }
            }
            else if (i == 2 && !isAsteroid)
            {

                if (rotated)
                {
                    GameObject temp = Instantiate(targetPrefab[0], new(transform.position.x + randX * rangeX, transform.position.y, transform.position.z + randZ * rangeZ), Quaternion.Euler(0, 90, 0));
                    temp.GetComponent<Rigidbody>().mass = speed;
                }
                else
                {
                    GameObject temp = Instantiate(targetPrefab[0], new(transform.position.x + randX * rangeX, transform.position.y, transform.position.z + randZ * rangeZ), Quaternion.identity);
                    temp.GetComponent<Rigidbody>().mass = speed;
                }
            }
            // ---

            wasNotSpawned = true;

            if (isAsteroid)
                spawnTime = spawnTimeCopy + Random.Range(0, spawnTimeCopy * 3);
        }

        else if (wasNotSpawned && time + spawnTime - 0.35f < Time.time + offset )
        {
            randX = Random.value;
            randZ = Random.value; 
            wasNotSpawned = false;

            if (!isAsteroid)
            {
                if (spawnIndex < spawnString.Length)
                    i = (int)(spawnString[spawnIndex++] - '0');
                else
                    i = 0;
                Instantiate(spawnPrefab[i], new(transform.position.x + randX * rangeX, transform.position.y - 5, transform.position.z + randZ * rangeZ), Quaternion.identity);
            }
            else
            {
                i = Random.Range(0, targetPrefab.Length);
                Instantiate(spawnPrefab[0], new(transform.position.x + randX * rangeX, transform.position.y - 5, transform.position.z + randZ * rangeZ), Quaternion.identity);
            }
        }
    }
}
