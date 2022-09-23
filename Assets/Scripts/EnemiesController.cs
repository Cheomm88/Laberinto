using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiesController : MonoBehaviour
{
    public Vector3 direction = Vector3.left;
    [SerializeField]
    GameObject projectilEnemy;

    float timer = 1f;
    [Serializable]
    public class EnemiesList
    {
        public GameObject[] enemies;
    }

    public EnemiesList[] enemiesList;

    public static EnemiesController instance;
    void Awake()
    {
        if (EnemiesController.instance == null)
        {
            EnemiesController.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public bool EstaEnPrimeraFila(GameObject enemigoQueChoca)
    {
        bool esPrimeraFila = false;
        for(int x = 0; x < enemiesList.Length; x++)
        {
            if (enemiesList[x].enemies[0] == enemigoQueChoca)
            {
                esPrimeraFila = true;
            }
        }

        return esPrimeraFila;
    }

    public void CheckGameStatus()
    {
        int aliveEnemies = 0;
        for (int x = 0; x < enemiesList.Length; x++) // recorre enemiesList
        {
            for (int y = 0; y < enemiesList[x].enemies.Length; y++)
            {
                if (enemiesList[x].enemies[y].activeSelf == true)
                {
                    aliveEnemies++;
                }
            }
        }

        if(aliveEnemies == 0)
        {

            Debug.Log("Partida ganada");
        }

    }
    private void Move()
    {
        for (int x = 0; x < enemiesList.Length; x++) // recorre enemiesList
        {
            for (int y = 0; y < enemiesList[x].enemies.Length; y++)
            {
                enemiesList[x].enemies[y].transform.position += direction;
            }
        }

        direction.y = 0f;
    }
    void PrintArray()
    {
        for (int x = 0; x < enemiesList.Length; x++) // recorre enemiesList
        {
            for (int y = 0; y < enemiesList[x].enemies.Length; y++)
            {
                if (enemiesList[x].enemies[y].activeSelf == true) //activo ese elemento
                {
                    Debug.Log(enemiesList[x].enemies[y].name);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Move();
            timer = 1f;
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
               
        }
    }

    void DeleteLastOne()
    {
        int lastX = enemiesList.Length - 1;
        int lastY = enemiesList[lastX].enemies.Length - 1;
        bool foundLastActive = false;
        //Aqui irá el nuevo bucle que calcula la última x e y activa
        for (int x = 0; x < enemiesList.Length; x++) // recorre enemiesList
        {
            for (int y = 0; y < enemiesList[x].enemies.Length; y++)
            {
                if (enemiesList[x].enemies[y].activeSelf == false && foundLastActive == false) // Al encontrar uno desactivado para la búsqueda
                {
                    foundLastActive = true;
                    Debug.Log("Encontrado primero no activo x = " + lastX + " y = " + lastY);
                }
                else if (enemiesList[x].enemies[y].activeSelf == true && foundLastActive == false)
                {
                    lastX = x;
                    lastY = y;
                }

            }
        }

        //Desactiva el enemigo colocado en la posición x e y
        enemiesList[lastX].enemies[lastY].SetActive(false);

    }

    void Attack()
    {
        //Primero selecciono una columna aleatoria
        int randomCol = UnityEngine.Random.Range(0, enemiesList.Length);
        GameObject[] columnaAttack = enemiesList[randomCol].enemies;

        // Buscar en la columna el último activo.
        int row = -1;
        for (int y = 0; y < columnaAttack.Length; y++)
        {
            if (columnaAttack[y].activeSelf == true)
            {
                row = y;
            }
        }
        //Llamamos a atacar en el enemigo.
        if (row != -1)
        {
            columnaAttack[row].GetComponent<Enemy>().Attack(projectilEnemy);
        }
        
    }

    public void ChocaEnTopeIzquierda()
    {
        direction = Vector3.right/2f;
        direction += Vector3.down/3f;
    }

    public void ChocaEnTopeDerecha()
    {
        direction = Vector3.left/2f;
        direction += Vector3.down/3f;
    }
}
