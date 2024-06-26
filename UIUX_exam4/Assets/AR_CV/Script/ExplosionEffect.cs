using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionEffect : MonoBehaviour
{
    private ParticleSystem _explosion;
    private MeshRenderer _mesh;
    private bool hitable;

    public TabButtonAR tabButtonAR;
    public Button XO;
    public AudioSource audioSource;
    public AudioClip explosionSound;




    void Start()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
        _mesh = GetComponentInChildren<MeshRenderer>();
        hitable = true;
    }

    public void Explode()
    {
        if (hitable)
        {
            _explosion.Play();
            _mesh.enabled = false;
            StartCoroutine(DestroySelf());
            hitable = false;
        }
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(_explosion.main.startLifetime.constantMax);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        tabButtonAR.SetAvailable();
        XO.enabled = true;
        XO.gameObject.SetActive(true);   
        audioSource.clip = explosionSound;
        audioSource.Play();
        Explode();
    }
}
