using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/*Game Name: Save the King 
 Unity game
 Authors Name: Ayhan SAGLAM--Khadka, Subarna Bijaya- Vu, Hieu Phong
 Date: 2021/02/10
*/
/// <summary>
/// Scripts related to enemy behavior is writen here
/// </summary>
public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public Slider enemyHealthSlider;
    [Range(0, 100)]
    public int enemyHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealthSlider = this.gameObject.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Main player as a target for enemies
        navMeshAgent.SetDestination(player.position);
    }

    public void TakeDamage(int damage)
    {
        enemyHealthSlider.value -= damage;
        enemyHealth -= damage;
        if (enemyHealth < 0)
        {
            //enemyHealthSlider.value = 0;
            enemyHealth = 0;
            Debug.Log("enemy dead");
            Destroy(this.gameObject);
        }
    }
}
