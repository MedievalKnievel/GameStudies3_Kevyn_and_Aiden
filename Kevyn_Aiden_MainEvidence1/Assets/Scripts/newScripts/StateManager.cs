using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState {Normal, Thrown, Pulled}

public class StateManager : MonoBehaviour
{



    public Material materialOne, materialTwo, materialThree;

    private MeshRenderer meshRenderer;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetState(WeaponState newState)
    {
        switch(newState)
        {
            case WeaponState.Normal:
            meshRenderer.material = materialOne;
            print("Normal state");
            break;
            case WeaponState.Thrown:
            meshRenderer.material = materialTwo;
            print("Thrown state");
            break;
            case WeaponState.Pulled:
            meshRenderer.material = materialThree;
            print("Pull state");
            break;
        }
    }
}