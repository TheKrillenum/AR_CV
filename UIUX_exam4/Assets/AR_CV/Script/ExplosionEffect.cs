using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private ParticleSystem _explosion;
    private MeshRenderer _mesh;
    private Renderer _renderer;
    private bool hitable;
    private int HitCount;

    public List<Material> mat;

    void Start()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
        _mesh = GetComponentInChildren<MeshRenderer>();
        _renderer = GetComponentInChildren<Renderer>();
        hitable = true;
        _renderer.material = mat[0];
        //HitCount = 0;
    }

    public void GetHit(int hit)
    {
        if (hit >= 4)
        {
            Explode();
        }
        else
        {
            if (hit > 0 && hit < 4)
            {
                _renderer.material = mat[hit];
            }
        }
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
        if (collision.gameObject.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);
            DestroySelf();
            //HitCount++;
            //GetHit(HitCount);
        }
    }
}
