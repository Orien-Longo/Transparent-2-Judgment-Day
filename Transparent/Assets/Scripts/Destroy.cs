using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{

    bool mPressed;
    Collider beam;
    public GameObject beamColor, beam1;
    int mpress, deathCount;

    void Start()
    {
        //beamC = beamColor.GetComponent<Renderer>();
        beam = beam1.GetComponent<Collider>();
        beam.enabled = false;        
        mPressed = false;
        mpress = 0;
        deathCount = 0;
    }


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && mpress < 1 && !mPressed)
        {
            mPressed = true;
            StartCoroutine(FadeTo(1.0f, .1f));
            beam.enabled = true;
            mpress++;
            
        }
        else if (Input.GetMouseButton(0))
        {
            beam.enabled = false;
            mPressed = false;
            StartCoroutine(FadeTo(0.01f, 1f));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            beam.enabled = false;
            mPressed = false;
            StartCoroutine(FadeTo(0.01f, 1f));
            mpress = 0;

        }
        if (deathCount > 2)
        {
            Application.LoadLevel("LichWins");
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if ((other.gameObject.CompareTag("Player1")|| other.gameObject.CompareTag("Player2")|| other.gameObject.CompareTag("Player3")) && mPressed)
        {

            //gameObject.SetActive(true);

            Destroy(other.gameObject);
            deathCount++;

        }

    }

    void OnTriggerStay(Collider other)
    {

        if ((other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2") || other.gameObject.CompareTag("Player3")) && mPressed)
        {


            Destroy(other.gameObject);
            deathCount++;
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
