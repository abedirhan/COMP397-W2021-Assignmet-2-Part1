using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Game Name: Save the King 
 Unity game
 Authors Name: Ayhan SAGLAM--Khadka, Subarna Bijaya- Vu, Hieu Phong
 Date: 2021/02/10
*/
public class GameManage : MonoBehaviour
{
    public void SaveGame()
    {
        SaveSystem.SaveGame();
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();

        GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = false;

        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().health = data.health;
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().coinCollected = data.coin;
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().coinText.text = data.coin.ToString() + " Coins!";
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().destroyedCoinArray = data.destroyedCoinArray;
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().currentLevel = data.level;


        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        Debug.Log(position);
    
        GameObject.FindWithTag("Player").transform.position = position;
        GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().updateConsumedCoins();

    }
}
