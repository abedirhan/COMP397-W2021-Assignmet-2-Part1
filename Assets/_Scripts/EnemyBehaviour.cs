using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Main player as a target for enemies
        navMeshAgent.SetDestination(player.position);
    }
}
