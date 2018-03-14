using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody bulletGO;
    [SerializeField]
    private Rigidbody bala_paralizadora;
    [SerializeField]
    private Rigidbody bala_desactivadora;

    [SerializeField]
    private float shootSpeed;
    [SerializeField]
    private string tipo; //Debil , Normal , MiniBoss


    private ControlPuntos sin;
    private int vida;
    private float velocidad;
    private int puntaje;
    private bool startedShoot;
    private RaycastHit rayInfo;
    private bool disparar;
    private int cont = 0;

    public int Puntaje { get { return puntaje; } set { puntaje = value; } }
    public float Velocidad { get { return velocidad; } set { velocidad = value; } }
    public string Tipo { get { return tipo; } set { tipo = value; } }

    // Use this for initialization

    private void Start()
    {
        if (bulletGO == null)
        {
            enabled = false;
        }

        sin = GameObject.FindWithTag("MainCamera").GetComponent<ControlPuntos>();
        AsignarValores();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if(vida <= 0)
        {
            sin.Puntos += puntaje;
            Destroy(gameObject);
        }


      /*  Debug.DrawLine(transform.position, transform.position + (Vector3.down * 1000F), Color.black);
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out rayInfo, 1000F) && !startedShoot)
        {
            if (rayInfo.collider.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
            {
                disparar = true;
            }
        }*/


        if(Vector2.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= 30)
        {
            disparar = true;
        }

        if(disparar)
        {
            cont++;
            if(cont == 30)
            {
                print("Shooting");
                startedShoot = true;
                Shoot();
                StartCoroutine(ToggleShootCR());
            }
        }

        Moverse(Velocidad);
    }

    private IEnumerator ToggleShootCR()
    {
        yield return new WaitForSeconds(4F);
        startedShoot = false;
    }

    private void Shoot()
    {
        int num = Random.Range(1, 4);
        Mathf.Round(num);

        if (num == 1)
        {
            Rigidbody bulletInstance = Instantiate(bulletGO, transform.position + (Vector3.down * 2.5F), transform.rotation);
            bulletInstance.AddForce((transform.up * -1F) * shootSpeed, ForceMode.Impulse);
        }

        if (num == 2)
        {
            Rigidbody bulletInstance = Instantiate(bala_paralizadora, transform.position + (Vector3.down * 2.5F), transform.rotation);
            bulletInstance.AddForce((transform.up * -1F) * shootSpeed, ForceMode.Impulse);
        }

        if (num == 3)
        {
            Rigidbody bulletInstance = Instantiate(bala_desactivadora, transform.position + (Vector3.down * 2.5F), transform.rotation);
            bulletInstance.AddForce((transform.up * -1F) * shootSpeed, ForceMode.Impulse);
        }


    }

    private void Moverse(float velocidad)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - 1), velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bala")
        {
            vida -= 2;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Death")
        {
            SceneManager.LoadScene("test");
        }
    }


    public void AsignarValores()
    {
        if(Tipo == "Debil")
        {
            Velocidad = 3;
            vida = 2;
            puntaje = 20;
        }

        if (Tipo == "Normal")
        {
            Velocidad = 2;
            vida = 4;
            puntaje = 50;
        }

        if (Tipo == "MiniBoss")
        {
            Velocidad = 0.5f;
            vida = 8;
            puntaje = 80;
        }
    }
}