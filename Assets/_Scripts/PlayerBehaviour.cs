using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*Game Name: Save the King 
 Unity game
 Authors Name: Ayhan SAGLAM -- Khadka, Subarna Bijaya -- Vu, Hieu Phong
 Date: 2021/02/10
*/
/// <summary>
/// Scripts related to main character movement and attacking
/// attacking is not implemented in this iteration but will be implemented here later
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controller;

    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;
    public AudioSource jumpAudio;


    [Header("Minimap")]
    public GameObject miniMap;

   

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        miniMap.SetActive(false);
        
    }

    // Update is called once per frame - once every 16.6666ms

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * maxSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            jumpAudio.Play();
        }

        if (Input.GetButton("Vertical"))
        {
            // walkAudio.Play();
            // Debug.Log("Player is walking");
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
       
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            // toggle minimap on and off
            miniMap.SetActive(!miniMap.activeInHierarchy);

        }

        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

   
}
