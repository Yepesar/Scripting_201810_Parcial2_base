using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlPuntos : MonoBehaviour {

   [SerializeField]
    private Text texto;

    private int puntos;

    public int Puntos { get { return puntos; } set { puntos = value; } }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        texto.text = "Puntos: " + puntos;

	}
}
