using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataPersistent : MonoBehaviour
{

    public SpaceShipScriptable selectedSpaceship;
    public static GameDataPersistent instance;

    void Awake()
    {
        if (GameDataPersistent.instance == null)
        {
            GameDataPersistent.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
