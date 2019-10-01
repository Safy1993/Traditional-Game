using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
   public bool hasFallen;
   public bool isBombCan;
    private int blastForce=1000;
    private int blastRaduis = 20;
    //public ParticleSystem MuzzuleFlash;
    //MuzzuleFlash.Play();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Resetter"))
        {
            hasFallen=true;
            GameManager.instance.GroundFallenCheck();
            UIManager.instance.UpdateScore();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isBombCan)
        {
            if (collision.gameObject.name=="Ball")
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position,blastRaduis);
                foreach (Collider c in colliders)
                {
                    Rigidbody rb = c.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(blastForce, transform.position, blastRaduis, 4, ForceMode.Impulse);
                    }

                }
            }
         
        }
    }
}
