using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float timer = 0;
    public float groundY = -0.5f;
    public float maxTime = 1;
    public GameObject coin;
    public GameObject grass;
    public GameObject mace;
    // default 0.9
    public float height;
    // default 1.7
    public float heightSky;
    public float startX = 15;
    public float grassXOffset = 5;
    public float maceXOffset = 8;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newCoin = Instantiate(coin);
        // newCoin.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        newCoin.transform.position = transform.position + new Vector3(startX, height, 0);
        GameObject newGrass = Instantiate(grass);
        newGrass.transform.position = transform.position + new Vector3(startX + grassXOffset, heightSky, 0);
        GameObject newMace = Instantiate(mace);
        newMace.transform.position = transform.position + new Vector3(startX + maceXOffset, groundY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newCoin = Instantiate(coin);
            newCoin.transform.position = transform.position + new Vector3(startX, height, 0);
            Destroy(newCoin, 50);

            GameObject newGrass = Instantiate(grass);
            newGrass.transform.position = transform.position + new Vector3(startX + grassXOffset, heightSky, 0);
            Destroy(newGrass, 50);

            GameObject newMace = Instantiate(mace);
            newMace.transform.position = transform.position + new Vector3(startX + maceXOffset, groundY, 0);
            Destroy(newMace, 50);

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
