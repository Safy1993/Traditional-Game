using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CanType
{
    normal,
    life,
    bomb
}

public class Can : MonoBehaviour
{
    public bool hasFallen;
    //public bool isBombCan;
    private int blastForce = 1000;
    private int blastRaduis = 20;

    public CanType type;

    //public bool isLifeCan;
    public bool hasColided;
    public GameObject fx;
    public GameObject blastFX;
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
            hasFallen = true;
            GameManager.instance.GroundFallenCheck();
            UIManager.instance.UpdateScore();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasColided == true)
        {
            return;
        }
        if (collision.gameObject.name == "Ball")
        {
            hasColided = true;
            switch (type)
            {


                case CanType.bomb:
                    

                        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRaduis);

                        foreach (Collider c in colliders)
                        {
                            Rigidbody rb = c.GetComponent<Rigidbody>();
                            if (rb != null)
                            {
                                rb.AddExplosionForce(blastForce, transform.position, blastRaduis, 4, ForceMode.Impulse);
                            }



                            Instantiate(blastFX, transform.position, Quaternion.identity);
                        }
                        break;


                case CanType.life: 
                    {

                        GameManager.instance.AddExtraBall(1);
                        fx.SetActive(true);


                    }
                    break;
            }


        }


    }
}
