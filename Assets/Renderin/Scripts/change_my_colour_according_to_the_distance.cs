using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_my_colour_according_to_the_distance : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject calibration_point;

    [SerializeField]
    public GameObject point;
    private void Update()
    {
        float distance = Vector3.Distance(this.transform.position, calibration_point.transform.position);
        var mr = point.GetComponent<Renderer>();
        //if distance is greater than 10
        if (distance > 13)
        {

            mr.material.color = new Color32(0, 102, 204, 255);
        }
        else if (distance > 8)
        {
            mr.material.color = new Color32(0, 255, 255, 255);
        }
        else if (distance > 5)
        {
            mr.material.color = new Color32(255, 255, 102, 255);
        }
        else if (distance > 2)
        {

            mr.material.color = new Color32(255, 153, 51, 255);
        }
        else if (distance > 0)
        {
            mr.material.color = new Color32(255, 20, 20, 255);
        }
        //change colour

        //this.transform.LookAt(calibration_point.transform.position);

    }
}
