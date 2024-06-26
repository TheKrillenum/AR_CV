using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject rocket;
    public AudioSource audioSource;
    public AudioClip shootSound;

    public void Shoot()
    {
        Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, (gameObject.transform.position.z) - 1);
        Quaternion rotation = gameObject.transform.rotation;
        Instantiate(rocket, position, rotation);

        audioSource.clip = shootSound;
        audioSource.Play();
    }
}