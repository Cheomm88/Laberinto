using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Attack(GameObject projectilPrefab)
    {
        Instantiate(projectilPrefab, transform.position - Vector3.down, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TopeIzquierda")
        {
            EnemiesController.instance.ChocaEnTopeIzquierda();
        }

        if (collision.gameObject.tag == "TopeDerecha")
        {
            EnemiesController.instance.ChocaEnTopeDerecha();
        }
    }
}
