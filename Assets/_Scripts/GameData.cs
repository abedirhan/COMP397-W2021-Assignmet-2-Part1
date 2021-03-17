using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float health;
    public int coin;
    public float[] position;
    public int level;
    public bool[] destroyedCoinArray;

    public GameData()
    {
        health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().health;
        coin = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().coinCollected;
        level = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().currentLevel;
        destroyedCoinArray = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().destroyedCoinArray;



        position = new float[3];
        position[0] = GameObject.FindWithTag("Player").transform.position.x;
        position[1] = GameObject.FindWithTag("Player").transform.position.y;
        position[2] = GameObject.FindWithTag("Player").transform.position.z;
    }
}
