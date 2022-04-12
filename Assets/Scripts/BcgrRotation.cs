using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BcgrRotation : MonoBehaviour
{

    float speed = 1f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation.z = transform.rotation.z + target.transform.position.x / 2;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + target.transform.position.x / 4);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + target.transform.position.x / 4);
        //Quaternion.Euler(rotation);
        //rotation.z = transform.rotation.z;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), speed * Time.deltaTime);
    }
}
