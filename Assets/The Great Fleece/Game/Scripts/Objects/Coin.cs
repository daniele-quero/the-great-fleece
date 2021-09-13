using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float _maxRange = 15f;
    void Start()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        float distance = Vector3.Distance(transform.position, playerPos);
        StartCoroutine(LandingRoutine(distance));
    }

    private IEnumerator LandingRoutine(float distance)
    {
        yield return new WaitForSeconds(distance / 20);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<AudioSource>().Play();
        AlertGuardsInRange();
    }

    private void AlertGuardsInRange()
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard");

        foreach(var g in guards)
        {
            if(Vector3.Distance(transform.position, g.transform.position) <= _maxRange)
                g.GetComponent<EnemySenses>().NoiseHeard(transform.position);
        }
    }
}
