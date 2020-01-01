using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_Rotation : MonoBehaviour
{
    Quaternion pos;

    float difference = 15f;
    // Update is called once per frame
    void Update()
    {


                Ray ray = new Ray(Camera.main.transform.position, (Camera.main.transform.forward));
                Quaternion Dir = Quaternion.LookRotation(ray.direction);
                pos.Set(this.transform.rotation.x, Dir.y, Dir.z, this.transform.rotation.w);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, pos, 0.6f * Time.deltaTime);

        
    }
}
