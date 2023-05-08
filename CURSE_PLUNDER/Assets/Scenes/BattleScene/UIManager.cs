using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject VictoryUI;
    [SerializeField] GameObject KnockdownUI;
    [SerializeField] GameObject TimeoverUI;
    [SerializeField] GameObject CommandSelectUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)) {
            VictoryUI.SetActive(true);
        }

        CommandSelectUI.SetActive(PlayerControl.cmdselect_dialog);
    }
}
