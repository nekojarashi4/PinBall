using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessRegulator : MonoBehaviour {
    Material myMaterial;

    private float minEmission = 0.3f;
    private float magEmission = 2.0f;
    private int degree = 0;
    private int speed = 10;
    Color defaultColor = Color.white;
    private GameObject pinballscoretext;
    private string s;
    private GameObject sss;

    // Use this for initialization
    void Start () {
        
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
        }

        this.myMaterial = GetComponent<Renderer>().material;
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);

        this.pinballscoretext = GameObject.Find("PinBallScoreText");
        this.sss = GameObject.Find("Score");
    }
	
	// Update is called once per frame
	void Update () {
        if (this.degree >= 0)
        {
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
            myMaterial.SetColor("_EmissionColor", emissionColor);
            this.degree -= this.speed;

            s = sss.GetComponent<Score>().score.ToString();
            this.pinballscoretext.GetComponent<Text>().text = s;

        }
        
        

	}

    private void OnCollisionEnter(Collision collision)
    {
        this.degree = 180;
        Debug.Log("Scoreを加算");
        if(tag== "SmallStarTag")
        {
            sss.GetComponent<Score>().score += 1;
        }else if(tag== "LargeStarTag")
        {
            sss.GetComponent<Score>().score += 10;
        }else if(tag== "SmallCloudTag")
        {
            sss.GetComponent<Score>().score += 15;
        }else if(tag== "LargeCloudTag")
        {
            sss.GetComponent<Score>().score += 30;
        }

        
    }
}
