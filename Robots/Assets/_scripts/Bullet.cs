using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int velocity;
    public int range;

    Vector3 startPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
          
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * velocity);
        if (Vector3.Distance(startPoint, transform.position) > range) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().AddExplosionForce(10000, transform.position, 3, 1,ForceMode.Impulse);
        Invoke("Destroy", 1);
        //Destroy(gameObject);
        
    }

    public void openFire()
    {
        
    }
        
}
