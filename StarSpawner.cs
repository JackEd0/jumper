using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    private float timer = 0;
    public float maxTime = 10f;
    public float height = 20f;
    // default 1.7
    public float startX = 5f;
    public GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newStar = Instantiate(star);
        newStar.transform.position = transform.position + new Vector3(startX, height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newStar = Instantiate(star);
            newStar.transform.position = transform.position + new Vector3(startX, height, 0);
            Destroy(newStar, 50);

            GameObject newStar1 = Instantiate(star);
            newStar1.transform.position = transform.position + new Vector3(startX + 5f, height, 0);
            Destroy(newStar1, 50);

            GameObject newStar2 = Instantiate(star);
            newStar2.transform.position = transform.position + new Vector3(startX + 10f, height, 0);
            Destroy(newStar2, 50);

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
