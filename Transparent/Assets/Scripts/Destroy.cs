using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{

    bool mPressed;
    Collider beam;
    public GameObject beamColor, beam1;

    void Start()
    {
        //beamC = beamColor.GetComponent<Renderer>();
        beam = beam1.GetComponent<Collider>();
        beam.enabled = false;        
        mPressed = false;
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mPressed = true;
            StartCoroutine(FadeTo(1.0f, .1f));
            beam.enabled = true;
            
        }
        else if (Input.GetMouseButton(0))
        {
            beam.enabled = false;
            mPressed = false;
            StartCoroutine(FadeTo(0.0f, .3f));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            beam.enabled = false;
            mPressed = false;
            StartCoroutine(FadeTo(0.0f, .3f));
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && mPressed)
        {

            //gameObject.SetActive(true);

            Destroy(other.gameObject);

        }

    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && mPressed)
        {


            Destroy(other.gameObject);
        }

    }
    IEnumerator FadeTo(float aValue, float aTime)
    {
        yield return new WaitForSeconds(.1f);
        float alpha = beamColor.transform.GetComponent<Renderer>().material.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = beamColor.transform.GetComponent<Renderer>().material.color;
            newColor.a = Mathf.Lerp(alpha, aValue, t);
            beamColor.transform.GetComponent<Renderer>().material.color = newColor;
            yield return null;

            //if (beam.enabled == false)
            //{
            //    beam.enabled = true;
            //} else
            //{
            //    beam.enabled = false;
            //}
        }
    }

}
