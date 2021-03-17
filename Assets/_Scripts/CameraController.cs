using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Game Name: Save the King 
 Unity game
 Authors Name: Ayhan SAGLAM--Khadka, Subarna Bijaya- Vu, Hieu Phong
 Date: 2021/02/10
 Updated 2021/03/15
*/



/// <summary>
/// Scripts related to controlling the third person perspective camera
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("Controls")]
    public Joystick joystick;
    public float controlSensitivity = 2.0f;
    /// <summary>
    /// Class variables are written here
    /// </summary>
    public float mouseSensitivity = 1000.0f;
    public Transform playerBody;

    private float XRotation = 0.0f;

    public bool paused=false;

    // Start is called before the first frame update
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // While pausing, return from this method
        if (paused)
        {
            return;
        }

        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        float mouseX = joystick.Horizontal * controlSensitivity;
        float mouseY = joystick.Vertical * controlSensitivity;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
