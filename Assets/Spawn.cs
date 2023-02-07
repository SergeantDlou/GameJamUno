using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    bool smacked = false;
    
    public Spawnables spawnables;
    // Start is called before the first frame update

    private void Awake()
    {
        name = this.gameObject.name;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (smacked)
        { 
            Destroy(this.gameObject);
            this.enabled= false;
        } 
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!smacked)
        {
            if (collision.gameObject.name == "Terrain")
            {
                if (this.tag == "Mushroom")
                {
                    GameObject t = Instantiate(spawnables.spawnables[0]);
                    t.transform.position = new Vector3(this.transform.position.x,collision.transform.position.y + 1.5f,this.transform.position.z);
                    smacked = true;
                }
                else if (this.tag == "Bounce") 
                {
                    GameObject t = Instantiate(spawnables.spawnables[1]);
                    t.transform.position = this.transform.position + new Vector3(1.5f, 0, 1.5f);
                    t.transform.position = new Vector3(t.transform.position.x, collision.transform.position.y, t.transform.position.z);
                    smacked = true;
                }
            }
        }
    }
}
