using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float startDelay = 2;
    public float repeatRate = 2;
    public GameObject obstaclePrefab;
    public GameObject resourcePrefab;
    private Vector3 obs_SpawnPos = new Vector3(25, 0, 0);
    private Vector3 res_SpawnPos = new Vector3(25, 1, 0);
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnResources", startDelay, repeatRate+1);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(this.obstaclePrefab, obs_SpawnPos, this.obstaclePrefab.transform.rotation);
        }
    }

    void SpawnResources()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(this.resourcePrefab, res_SpawnPos, this.resourcePrefab.transform.rotation);
        }
    }
}
