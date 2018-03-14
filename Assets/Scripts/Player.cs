using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int moveCount;
    [SerializeField]
    private Rigidbody bala;
    [SerializeField]
    private float velocidad_bala;
    [SerializeField]
    private float velocidad_movimiento;
    [SerializeField]
    private Text vida_UI;

    private int cont;
    private int vida = 100;
    private int puntos;
    private bool disparar = false;
    private bool paralizar;
    private int cont_P = 0;
    private bool desactivar = false;
    private int cont_D = 0;
    public int Puntos { get { return puntos; } set { puntos = value; } }

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        vida_UI.text = "Vida: " + vida;

        if (Input.GetKey(KeyCode.LeftArrow) && paralizar != true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1,transform.position.y),velocidad_movimiento * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && paralizar != true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1, transform.position.y), velocidad_movimiento * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && desactivar != true)
        {
            disparar = true;
        }

        if(disparar)
        {
            cont++;
            if(cont == 50)
            {
                Shoot();
                cont = 0;
                disparar = false;
            }
        }

        if (paralizar)
        {
            cont_P++;
            if (cont_P == 50)
            {
                cont_P = 0;
                paralizar = false;
            }
        }

        if (desactivar)
        {
            cont_D++;
            if (cont_D == 50)
            {
                cont_D = 0;
                desactivar = false;
            }
        }
    }

    private void Shoot()
    {

        Rigidbody clon = Instantiate(bala, new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
        clon.AddForce(Vector3.up * velocidad_bala, ForceMode.Impulse);

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;

        if(obj.tag == "Bala")
        {
            vida -= 10;
            Destroy(obj);
        }


        if (obj.tag == "Bala_P")
        {
            vida -= 10;
            Destroy(obj);
            paralizar = true;
        }


        if (obj.tag == "Bala_D")
        {
            vida -= 10;
            Destroy(obj);
            desactivar = true;
        }
    }
}