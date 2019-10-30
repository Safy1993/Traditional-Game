using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CanType
{
    normal,
    life,
    bomb
}

public class Cans : MonoBehaviour
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
    public GameObject lifeFx;
    public GameObject duseFX;

    bool once;

    Vector3 originalPos;
    //public ParticleSystem MuzzuleFlash;
    //MuzzuleFlash.Play();

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsMoved()
    {
        return (transform.position - originalPos).magnitude > 0.2f;


    }





    //private void OnTriggerEnter(Collider other)
    //{


    //}
    private void OnCollisionEnter(Collision collision)
    {
    //    if (hasColided == true)
    //    {
    //        return;
    //    }

    //    if (collision.collider.CompareTag("Finish"))
    //    {
    //        hasFallen = true;
    //        GameManagers.instance.GroundFallenCheck();
    //        UIManagers.instance.UpdateScore();
    //    }

        if (collision.gameObject.name == "Ball")
        {
            hasColided = true;
            switch (type)
            {


                case CanType.bomb:

                    if (!once)
                    {
                        once = true;
                        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRaduis);
                    

                        foreach (Collider c in colliders)
                        {
                            Rigidbody rb = c.GetComponent<Rigidbody>();
                            if (rb != null)
                            {
                                rb.AddExplosionForce(blastForce, transform.position, blastRaduis, 4, ForceMode.Impulse);
                            }
                            
                        }
                        Instantiate(blastFX, transform.position, Quaternion.identity);

                    }
                    break;



                case CanType.life:
                    {

                        GameManagers.instance.AddExtraBall(1);
                        Instantiate(lifeFx, transform.position, Quaternion.identity);
                        fx.SetActive(true);


                    }
                    break;
                case CanType.normal:
                    {
                        if (!once)
                        {
                            once = true;

                            Instantiate(duseFX, transform.position, Quaternion.identity);
                        }

                    }
                    break;
            }


        }


    }
}
