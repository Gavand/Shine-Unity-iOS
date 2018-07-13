using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private const float START_POS_X = -4f;
    private const float START_POS_Y = -5f;

    public static MapGenerator instance;

    public GameObject tokenPrefab;
    public GameObject slugEnemyPrefab;
    public GameObject birdyEnemyPrefab;
    private GameObject tilePrefab;

    public GameObject[] sections;
    public float spawnTimer;

    private Vector3 currentPos;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }


    // Use this for initialization
    void Start()
    {
        currentPos.x = START_POS_X;
        currentPos.y = START_POS_Y;
        currentPos.z = 0;

        tilePrefab = DifficultySettings.tile;

        // Generate starting platform
        for (int i = 0; i < 3; i++)
        {
            Instantiate(tilePrefab, currentPos, Quaternion.Euler(0, 0, 0));
            currentPos.x += 3;
        }

        InvokeRepeating("generateSection", 0.0f, spawnTimer);
    }

    void generateSection()
    {
        int randomIndex = Random.Range(0, sections.Length);
        //Instantiate(sections[randomIndex], currentPos, Quaternion.Euler(0, 0, 0));

        Transform[] children = sections[randomIndex].GetComponentsInChildren<Transform>();
        GameObject toInstantiate;
        foreach (Transform child in children)
        {
            toInstantiate = null;
            if (child.name.Contains(tokenPrefab.GetComponent<Identifier>().prefabName))
            {
                toInstantiate = tokenPrefab;
            }
            else if (child.name.Contains(slugEnemyPrefab.GetComponent<Identifier>().prefabName))
            {
                toInstantiate = slugEnemyPrefab;
            }
            else if (child.name.Contains(birdyEnemyPrefab.GetComponent<Identifier>().prefabName))
            {
                toInstantiate = birdyEnemyPrefab;
            }
            else if (child.name.Contains(tilePrefab.GetComponent<Identifier>().prefabName))
            {
                toInstantiate = tilePrefab;
            }

            if (toInstantiate != null)
            {
                Instantiate(toInstantiate, currentPos + child.position, Quaternion.Euler(0, 0, 0));
            }
        }

        currentPos.x += 9;
    }
}
