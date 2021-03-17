using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*Game Name: Save the King 
 Unity game
 Authors Name: Ayhan SAGLAM--Khadka, Subarna Bijaya- Vu, Hieu Phong
 Date: 2021/02/10
*/
public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Slider slider;
    public int coinCollected;
    public Text coinText;
    public Transform level2SpawnPoint;
    public Transform winSpawnPoint;
    [SerializeField] public AudioSource coinAudio;
    [SerializeField] public AudioSource gameSound;
    [SerializeField] public AudioSource transition;
    public int currentLevel = 1;
    private CharacterController controller;
    public bool[] destroyedCoinArray =
                                        { false, false, false, false, false, false, false, false, false, false, false, false, false, false,
                                          false, false, false, false, false, false, false, false, false, false, false, false, false, false,false};




    // Start is called before the first frame update
    void Start()
    {
        coinCollected = 0;
        controller = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        gameSound.Play();
        updateConsumedCoins();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            health -= 20;
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        if (other.gameObject.tag == "coin")
        {
            destroyedCoinRecord(other.name);
            coinAudio.Play();

            //health should not be more than 100
            if (health < 100)
            {
                health += 5;
            }
            coinCollected += 1;
            coinText.text = coinCollected.ToString() + " Coins!";
            Destroy(other.gameObject);
            if (currentLevel == 1 && coinCollected >= 15)
            {
                gameSound.Stop();
                transition.Play();
                currentLevel = 2;
                Debug.Log("Moving to level2" + health);

                // turn controller off
                controller.enabled = false;
                // move the player to the spawnpoint
                GameObject.FindWithTag("Player").transform.position = level2SpawnPoint.position;
                // turn controller on
                controller.enabled = true;
                gameSound.Play();

            }
            else if (currentLevel == 2 && coinCollected >= 18)
            {
                gameSound.Stop();
                transition.Play();
                currentLevel = 3;
                Debug.Log("Moving to Home" + health);

                //turn controller off
                controller.enabled = false;
                // move the player to the spawnpoint
                GameObject.FindWithTag("Player").transform.position = winSpawnPoint.position;
                // turn controller on
                controller.enabled = true;
                gameSound.Play();
            }
            else if (currentLevel == 3 && coinCollected >= 19)
            {
                gameSound.Stop();
                SceneManager.LoadScene("GameWon");
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("You won the game");
            }
        }
    }

    private void destroyedCoinRecord(string coinName)
    {
        string[] names = coinName.Split('n');
        int coinNumber;

        bool success = Int32.TryParse(names[1], out coinNumber);
        if (success)
        {
            Debug.Log(coinNumber);
            destroyedCoinArray[coinNumber] = true;
        }
    }

    public void updateConsumedCoins()
    {
        for (int i = 0; i < 29; i++)
        {
            if (destroyedCoinArray[i])
            {
                Destroy(GameObject.Find("Coin" + i));
            }
        }
    }
}
