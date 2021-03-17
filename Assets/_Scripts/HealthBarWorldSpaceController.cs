using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Game Name: Save the King 
 Unity game
 Authors Name: Ayhan SAGLAM--Khadka, Subarna Bijaya- Vu, Hieu Phong
 Date: 2021/02/10
*/
public class HealthBarWorldSpaceController : MonoBehaviour
{
    public Transform playerCamera;

    void Start()
    {
        playerCamera = GameObject.Find("PlayerCam").transform;
    }


    void LateUpdate()
    {
        // billboard the healthBar
        transform.LookAt(transform.position + playerCamera.forward);
    }
}
