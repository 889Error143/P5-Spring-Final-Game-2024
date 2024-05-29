using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private int value = 1;
    public LevelLoader _LevelLoader;

    void start()
    {
        //_LevelLoader = GameObject.Find("Session Manager").GetComponent<LevelLoader>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _LevelLoader.UpdateItemsCollected(value);
            Destroy(this.gameObject);
        }
    }
}