using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    public GameObject prefab;

    private MeshRenderer renderer;

    public Material goodtogo;
    public Material NotSoGood;
    private BuildSytem buildSystem;
    private bool is_snapped = false;
    public bool is_foundation = false;

    //what can we snap to
    public List<string> SnappingTags = new List<string>();

    private void Start()
    {
        //there is only one buildsystem/manager
        buildSystem = GameObject.FindObjectOfType<BuildSytem>();

        //to put materials
        renderer = GetComponent<MeshRenderer>();
        ChangeColor();

    }

    public void Place()
    {
        Instantiate(prefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void ChangeColor()
    {
        if (is_snapped) renderer.material = goodtogo;
        else renderer.material = NotSoGood;

        if (is_foundation)
        {
            is_snapped = true;
            renderer.material = goodtogo;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i =0; i< SnappingTags.Count; i++)
        {
            if ((other.tag) == SnappingTags[i])
            {
                buildSystem.PauseBuilding(true);
                transform.position = other.transform.position;
                is_snapped = true;
                ChangeColor();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < SnappingTags.Count; i++)
        {
            if ((other.tag) == SnappingTags[i])
            {
                is_snapped = false;
                ChangeColor();

            }
        }

    }

    public bool GetSnapped()
    {
        return is_snapped;
    }
}
