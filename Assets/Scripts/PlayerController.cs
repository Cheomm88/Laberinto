using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float heat = 1f;
    private float timerHeat = 0.0f;
    [SerializeField]
    GameObject prefabProjectile;
    // Start is called before the first frame update
    [SerializeField]
    GameObject prefabProjectileSpecial;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        transform.position += horizontalMovement * transform.right * Time.deltaTime * speed;

        if (Input.GetKeyUp(KeyCode.Space) && timerHeat == 0.0f)
        {
            Instantiate(prefabProjectile, transform.position + Vector3.up * 0.1f, Quaternion.identity);
            timerHeat = 1/heat;
        }
        if (Input.GetKeyUp(KeyCode.B) && timerHeat == 0.0f)
        {
            Instantiate(prefabProjectileSpecial, transform.position + Vector3.up * 0.1f, Quaternion.identity);
            timerHeat = 1 / heat;
        }

        if (timerHeat > 0.0f)
        {
            timerHeat -= Time.deltaTime;
        }
        else if (timerHeat < 0.0f)
        {
            timerHeat = 0.0f;
        }
    }
}
