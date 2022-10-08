using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_create : MonoBehaviour
{
    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    [SerializeField]
    public GameObject point_prefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 25; i++)
            {
                hit_and_create();
            }

        }
    
                //StartCoroutine(WaitAndPrint());
    }


    private IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(3f);
        hit_and_create();
    }
    public void hit_and_create()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        Vector3 forward_vector = transform.TransformDirection(Vector3.forward);
        forward_vector.x = forward_vector.x + Random.Range(-0.1f, 0.1f);
        forward_vector.y = forward_vector.y + Random.Range(-0.1f, 0.1f);
        forward_vector.z = forward_vector.z + Random.Range(-0.1f, 0.1f);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, forward_vector, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);


            Debug.Log("Did Hit");

            var point = hit.point;
            //GameObject ramdomized_point;
            //var randomized_point = point;
            /*            for (int i = 0; i < 10; i++)
                        {
                            randomized_point.x = randomized_point.x + Random.Range(-0.3f, 0.3f);
                            randomized_point.y = randomized_point.y + Random.Range(-0.3f, 0.3f);
                            randomized_point.z = randomized_point.z + Random.Range(-0.3f, 0.3f);
                            ramdomized_point = Instantiate(point_prefab, randomized_point, hit.transform.rotation);
                            ramdomized_point.GetComponent<change_my_colour_according_to_the_distance>().calibration_point = this.gameObject;
                        }*/

            //exact point
            var created_point = Instantiate(point_prefab, point, hit.transform.rotation);
            var points_script = created_point.GetComponent<change_my_colour_according_to_the_distance>();
            points_script.calibration_point = this.gameObject;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }



    // Apply a force to a rigidbody in the Scene at the point
    // where it is clicked.

    // The force with which the target is "poked" when hit.
    /*float pokeForce;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null)
                {
                    Debug.Log("Did Hit");
                    //hit.rigidbody.AddForceAtPosition(ray.direction * pokeForce, hit.point);
                }
            }
        }
    }*/

}
