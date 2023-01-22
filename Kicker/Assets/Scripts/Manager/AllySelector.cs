using System;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AccumulationAllies))]
public class AllySelector : MonoBehaviour
{
    private List<Ally> allies;
    private List<Ally> oldAllies = new List<Ally>();
    private AccumulationAllies accumulationAllies => GetComponent<AccumulationAllies>();

    private bool isCanSelect;

    public event Action<int> OnStepsCountChanged;
    [SerializeField] private int stepsCount;
    private int stepsCountLeft;

    private void Awake()
    {
        accumulationAllies.OnChangentCountCharacters += UpdateAllies;
    }

    private void UpdateAllies()
    {
        allies = accumulationAllies.GetAllies();

        if (allies != null)
        {
            for (int i = 0; i < allies.Count; i++)
            {
                if (IsOldAlly(allies[i]) == false)
                {
                    allies[i].OnClick += Select;
                    allies[i].OnStartedAction += DoStep;
                }
            }
        }
    }

    private void Select(Ally ally)
    {
        if (isCanSelect == true && allies != null)
        {
            for (int i = 0; i < allies.Count; i++)
            {
                if (allies[i] == ally)
                {
                    allies[i].Select();
                }
                else
                {
                    allies[i].Deselect();
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            string[] layerNames = new string[] { "Ally", "AllyButton" };
            if (MousePositionInLayerCheker.CheckMousePosition(layerNames) != true)
            {
                Select(null);
            }
        }
    }

    private void DoStep()
    {
        stepsCountLeft -= 1;
        OnStepsCountChanged?.Invoke(stepsCountLeft);

        if (stepsCountLeft <= 0)
        {
            StopSelecte();
        }
    }

    private bool IsOldAlly(Ally ally)
    {
        for (int i = 0; i < oldAllies.Count; i++)
        {
            if(oldAllies[i] == ally)
            {
                return true;
            }
        }
        oldAllies.Add(ally);
        return false;
    }

    public void StartSelecte()
    {
        stepsCountLeft = stepsCount;
        OnStepsCountChanged?.Invoke(stepsCountLeft);

        isCanSelect = true;
    }

    public void StopSelecte()
    {
        Select(null);
        isCanSelect = false;
    }

    public int GetCountSteps()
    {
        return stepsCountLeft;
    }
}
