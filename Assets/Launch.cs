using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Launch : MonoBehaviour
{
    public List<GameObject> potion;
    public float speed = 400;
    public Vector3 forward;
    public Rigidbody player;
    int currentPotion = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forward = Camera.main.transform.forward;

        if (Input.GetKey(KeyCode.Alpha1)) currentPotion = 0;
        else if (Input.GetKey(KeyCode.Alpha2)) currentPotion= 1;

        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject p = Instantiate<GameObject>(potion[currentPotion]);
            p.transform.position = Camera.main.transform.position;
            Rigidbody pRb = p.GetComponent<Rigidbody>();
            pRb.angularVelocity = new Vector3(Random.value, Random.value, Random.value)*10;
            pRb.velocity = player.velocity + ((Camera.main.transform.forward) * speed);
          
        }
    }
}
