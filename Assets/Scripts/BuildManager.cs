using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject foundation;
    public BuildSytem bs;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bs.NewBuild(foundation);
        }
    }
}
