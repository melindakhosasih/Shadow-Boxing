using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tutorialManagerAdvanced : MonoBehaviour
{
    public List<GameObject> spheres;
    public bool triggered = false;
    public string mode = "All";

    private int move = 0;
    private List<List<int>> allMoveSelection;
    private List<int> moveSelection;
    
    public enum modes
    {
        All = 0,
        BlockOnly = 1,
        JabOnly = 2,
        HookOnly = 3,
        AttackOnly = 4
    }

    void Start()
    {
        allMoveSelection = new List<List<int>>();
        
        List<int> subList;

        //All
        subList = new List<int> {0, 1, 2, 3, 4, 5, 6};
        allMoveSelection.Add(subList);

        //Block Only
        subList = new List<int> {0, 1, 2};
        allMoveSelection.Add(subList);

        //Jab Only
        subList = new List<int> {0, 3, 4};
        allMoveSelection.Add(subList);

        //Hook Only
        subList = new List<int> {0, 5, 6};
        allMoveSelection.Add(subList);

        //Attack Only
        subList = new List<int> {0, 3, 4, 5, 6};
        allMoveSelection.Add(subList);
    }

    void Update()
    {
        modes modeEnum;

        if (Enum.TryParse(mode, out modeEnum))
        {
            int modeValue = (int)modeEnum;
            moveSelection = allMoveSelection[modeValue];
        }

        // print(move);
        if (triggered)
        {
            if(move == 0)
            {
                spheres[0].SetActive(false);
                spheres[1].SetActive(false);
            }
            next(move);
            move = chooseNextMove();
            triggered = false;
        }
    }

    int chooseNextMove()
    {
        return UnityEngine.Random.Range(0, moveSelection.Count);
    }

    public void trigger()
    {
        triggered = true;
    }

    void next(int move)
    {
        switch (move)
        {
            case 0:
                spheres[0].SetActive(true);
                spheres[1].SetActive(true);
                break;
            default:
                spheres[move + 1].SetActive(true);
                break;
        }
    }
}
