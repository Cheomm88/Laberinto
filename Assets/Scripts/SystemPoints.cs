using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemPoints : MonoBehaviour
{
    public static SystemPoints instance;
    [SerializeField]
    Text textPoints;

    int points = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (SystemPoints.instance == null)
        {
            SystemPoints.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddPoints(int puntosQueDaEnemigo)
    {
        points += puntosQueDaEnemigo;
        textPoints.text = "Points : " + points.ToString();
    }
 

}
