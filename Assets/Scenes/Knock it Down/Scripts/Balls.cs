using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    //back to start point
    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        //initial ball postion
        spawnPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Resetter"))
        //{
        //    RepoitionBall();
        //}
        
    }

    public void RepoitionBall()
    {
        //this.gameObject.SetActive(false);
        //transform.position = spawnPos;
        //this.GetComponent<Animator>().enabled = true;
        //gameObject.SetActive(true);
        //StartCoroutine(SetReadyToShoot());

    } 
    
    IEnumerator SetReadyToShoot()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        //GameManager.instance.readyToShoot = true;


    }
}
