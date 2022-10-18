using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera_movement : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    private float speed = 2.0f;


    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float sensitivity = 20f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
    const string yAxis = "Mouse Y";

    void Update()
    {
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat; //Quaternions seem to rotate more consistently than EulerAngles. Sensitivity seemed to change slightly at certain degrees using Euler. transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0);

        ///////////
        ///
        /*       if (Input.GetKey(KeyCode.W))
               {
                   transform.Translate(Vector3.forward * Time.deltaTime * speed);
               }
               if (Input.GetKey(KeyCode.S))
               { 
                   transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
               }
               if (Input.GetKey(KeyCode.A)) { 
                   transform.Rotate(0, -1, 0);
               }
               if (Input.GetKey(KeyCode.D))
               {
                   transform.Rotate(0, 1, 0);
               }*/


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(0, -1, 0);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(0, 1, 0);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }




    }
}
