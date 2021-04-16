using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/*Game Name: Return Home 
 Unity game
 Authors Name: Ayhan SAGLAM--Khadka, Subarna Bijaya- Vu, Hieu Phong
 Date: 2021/02/10
 Updated 2021/04/11
*/


/// <summary>
/// Everything related to sound will be written here
/// </summary>
public class VolumeSetter : MonoBehaviour
{
public AudioMixer mixer;
public void SetLevel(float sliderValue) 
{
    mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
}
}
