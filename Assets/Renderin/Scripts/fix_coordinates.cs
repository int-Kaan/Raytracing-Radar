using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_coordinates : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player_object;


    // Update is called once per frame
    void Update()
    {
        this.transform.position = player_object.transform.position;
        this.transform.rotation = player_object.transform.rotation;
    }
}
