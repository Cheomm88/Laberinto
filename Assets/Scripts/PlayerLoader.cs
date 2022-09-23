using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject nave = Instantiate(GameDataPersistent.instance.selectedSpaceship.prefab);
        nave.transform.localScale *= 0.1f;
        nave.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
        nave.transform.position = new Vector3(0f, -2.45f, 0f);
        if (nave.GetComponent<PlayerController>() == null)
        {
            nave.AddComponent<PlayerController>();
        }

        nave.GetComponent<PlayerController>().speed = GameDataPersistent.instance.selectedSpaceship.speed;
        nave.GetComponent<PlayerController>().heat = GameDataPersistent.instance.selectedSpaceship.cadence;
    }

}
