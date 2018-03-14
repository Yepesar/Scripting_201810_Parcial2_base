using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField]
    private GameObject enemigo;
    [SerializeField]
    private GameObject puntos;
    [SerializeField]
    private ControlPuntos c_puntos;

    private Player player;
    private int puntaje;
    private Enemy enemy;
    private int cont = 0;
	// Use this for initialization
	void Start ()
    {
        enemy = enemigo.GetComponent<Enemy>();
        enemy.Velocidad = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {

        puntaje = c_puntos.Puntos;

        cont++;
        if(cont == 150)
        {
            CrearEnemigo();
            cont = 0;
        }
	}

    private void CrearEnemigo()
    {
        int numero = Random.Range(0, 5);
        Mathf.Round(numero);
        GameObject clon_enemigo = Instantiate(enemigo, puntos.transform.GetChild(numero).transform.position, Quaternion.identity);
        AsigarTipo(clon_enemigo);
    }

    private void AsigarTipo(GameObject clon)
    {
        Enemy valores = clon.GetComponent<Enemy>();
        float numero = Random.Range(0, 10);

        if (puntaje < 200) // PRIMERA FASE
        {
            if (numero < 8.5f && numero != 0.5f)
            {
                valores.Tipo = "Debil";
                valores.AsignarValores();
            }

            if (numero > 9 && numero != 0.5f)
            {
                valores.Tipo = "Normal";
                valores.AsignarValores();
            }

            if(numero <= 0.5f)
            {
                valores.Tipo = "MiniBoss";
                valores.AsignarValores();
            }
        }

        if (puntaje > 200 && puntaje < 500) // SEGUNDA FASE
        {
            if (numero < 5.5f && numero > 1.5f)
            {
                valores.Tipo = "Debil";
                valores.AsignarValores();
            }

            if (numero > 3 && numero > 1.5f)
            {
                valores.Tipo = "Normal";
                valores.AsignarValores();
            }

            if (numero <= 1.5f)
            {
                valores.Tipo = "MiniBoss";
                valores.AsignarValores();
            }
        }

        if (puntaje >  500) // Tercera FASE
        {
            if (numero > 4f)
            {
                valores.Tipo = "Debil";
                valores.AsignarValores();
            }

            if (numero > 2.5f && numero < 4f)
            {
                valores.Tipo = "Normal";
                valores.AsignarValores();
            }

            if (numero < 2.5f && numero >= 0)
            {
                valores.Tipo = "MiniBoss";
                valores.AsignarValores();
            }
        }
    }
}
