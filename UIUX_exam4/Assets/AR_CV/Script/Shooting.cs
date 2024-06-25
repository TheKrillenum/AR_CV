using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject rocket;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Shoot()
    {
        Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, (gameObject.transform.position.z) - 1);
        Quaternion rotation = gameObject.transform.rotation;
        Instantiate(rocket, position, rotation);
    }
}
