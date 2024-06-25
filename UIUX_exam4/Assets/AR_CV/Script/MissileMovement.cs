using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    private float movementSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
    }

    public IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
}
