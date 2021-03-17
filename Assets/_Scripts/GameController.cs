using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GUI = UnityEngine.GUI;
/*Game Name: Save the King 
 Unity game
 Authors Name: Ayhan SAGLAM--Khadka, Subarna Bijaya- Vu, Hieu Phong
 Date: 2021/02/10
*/
/// <summary>
/// Scripts related to controlling the flow of the game
/// Not implemented anywhere now but will be implemented in future iterations
/// </summary>
public class GameController : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Start"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
