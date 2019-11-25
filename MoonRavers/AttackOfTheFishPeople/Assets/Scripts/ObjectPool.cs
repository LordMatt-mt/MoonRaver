using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public static ObjectPool sharedInstance;
    public List<GameObject> pooledBullets;
    public GameObject bulletToPool;
    public int amountOfBullets;
    

    void Awake()
    {
        sharedInstance = this;
    }

    // Use this for initialization
    void Start () {

        
        pooledBullets = new List<GameObject>();
        for (int i = 0; i < amountOfBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(bulletToPool);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            //2
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        //3
        return null;
    }

    // Update is called once per frame
    void Update () {
        
    }
}
