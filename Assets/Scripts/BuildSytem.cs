using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSytem : MonoBehaviour
{


    public Camera cam;
    public LayerMask layer;
    private GameObject previewGameObject = null;
    private Preview previewscript = null; 
    public float sticktolerance = 1.5f;
    public bool isBuilding = false;
    private bool pauseBuilding = false;

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.G) && isBuilding)
        {
            if(previewscript.GetSnapped())
            {
                StopBuilding();
            }
        }

       if (isBuilding)
        {
            if(pauseBuilding)
            {
                float mousex = Input.GetAxis("Mouse X");
                float mousey = Input.GetAxis("Mouse Y");
                if(Mathf.Abs(mousex)>sticktolerance || Mathf.Abs(mousey) > sticktolerance)
                {
                    pauseBuilding = false;
                }

            }
            else
            {
                DoBuildRay();
            }
        }
    }

    public void NewBuild (GameObject arg)
    {
        previewGameObject = Instantiate(arg,Vector3.zero,Quaternion.identity);
        previewscript = previewGameObject.GetComponent<Preview>();
        isBuilding = true;
    }
    public void CancelBuilding(bool condition)
    {
        Destroy(previewscript);
        previewscript = null;
        previewGameObject = null;
        isBuilding = false;
    }

    private void StopBuilding()
    {
        previewscript.Place();
        previewscript = null;
        previewGameObject = null;
        isBuilding = false;

    }

    public void PauseBuilding(bool _val)
    {
        pauseBuilding = _val;
    }

    private void DoBuildRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        //ignore build layer
        if(Physics.Raycast(ray,out hit, 100f,layer))
        {
            float y = hit.point.y + (previewGameObject.transform.localScale.y / 2f);
            Vector3 pos = new Vector3(hit.point.x, y, hit.point.z);
            previewGameObject.transform.position = pos;
        }
    }

}
