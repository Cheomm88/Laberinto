using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speedProjectile = 2f;
    public Vector3 direction = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speedProjectile;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TopeBalas")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            SystemPoints.instance.AddPoints(10);
            EnemiesController.instance.CheckGameStatus();
            Destroy(gameObject);
        }
    }
}
