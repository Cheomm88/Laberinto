using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Naves", menuName = "Naves/Player", order = 1)]

public class SpaceShipScriptable : ScriptableObject
{
    [SerializeField]
    string nameSpaceShip = "Nave1";

    public float speed = 1f;
    public float cadence = 2f;
    public float shield = 1f;

    public GameObject prefab;
}
