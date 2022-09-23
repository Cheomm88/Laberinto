using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipScreenSelector : MonoBehaviour
{

    [SerializeField]
    SpaceShipScriptable[] naves;
    [SerializeField]
    Transform navesParent;

    int currentNave = 0;
    
    void Start()
    {
        GameDataPersistent.instance.selectedSpaceship = naves[currentNave];
    }


    public void NextNave()
    {
        navesParent.GetChild(currentNave).gameObject.SetActive(false);
        if (currentNave + 1 == navesParent.childCount)
        {
            
            currentNave = 0;
            navesParent.GetChild(currentNave).gameObject.SetActive(true);
            
        }
        else
        {
            currentNave++;
            navesParent.GetChild(currentNave).gameObject.SetActive(true);

        }


        GameDataPersistent.instance.selectedSpaceship = naves[currentNave];
    }

    public void PreviousNave()
    {
        navesParent.GetChild(currentNave).gameObject.SetActive(false);
        if (currentNave - 1 == -1)
        {
            currentNave = navesParent.childCount - 1;
            navesParent.GetChild(currentNave).gameObject.SetActive(true);
        }
        else
        {
            currentNave--;
            navesParent.GetChild(currentNave).gameObject.SetActive(true);
        }

        GameDataPersistent.instance.selectedSpaceship = naves[currentNave];
    }


    public void LoadGameLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
