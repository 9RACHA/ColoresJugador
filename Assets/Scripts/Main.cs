using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //Lista de materiales o colores creados desde Unity 
    public List<Material> listaColores;

    // List<Jugador> listaJugadores = new List<Jugador>();

    public GameObject jugador;

    private Vector3 posicionAleatoria;

    private Vector3 posicionInicial;

    //la posicionInicial pude no declararse al principio y a posteriori obtenerla mediante player.position

    //Con unicamente un bucle for no permitia esperar los 5 s para ello es necesario las coroutines

        /*
        //Construir un objeto
        for (int y = 0; y < 1; y++) {
            for (int x = 0; x < 1; x++) {
                GameObject Jugador = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                Jugador.AddComponent<Rigidbody>();
                Jugador.transform.position = new Vector3(x, y, 0);

                //Se instancia el prefab
                Instantiate(jugador, new Vector3(x, y, 0), Quaternion.identity);
                Debug.Log("Jugador Creado");

                //Crear un jugador cada 5 segundos con posicion aleatoria y color aleatorio. Con un maximo de 6 players en total

                //Coroutine para esperar los 5 S

                //Metodo para que spawnee
            }
        } */
    

    // Start is called before the first frame update
    void Start()
    {
        if (jugador == null)
        {
            Debug.Log("Prefab jugador no asigando");
        }

        posicionInicial = jugador.transform.position;   //La variable posicionInicial sera igual al gameobject jugador con el atributo posicion

        StartCoroutine(JugadorSpawn()); //Se comienza una Corrutina para ello creo un metodo
    }

        //metodo de tipo IEnumerator para comenzar la corrutina
        public IEnumerator JugadorSpawn() { 

            int limite = 0; // limite tipo int sera 0

            while (limite < 6) //Bucle while mientras limite sea menor que 6
            {
                yield return new WaitForSeconds(5f);    //Hace que se repita cada 5 s

                if (limite > 0) //Si el limite es mayor a 0
                {
                    //RandomRange
                    posicionInicial.x = Random.Range(-8f, 8f);  //La posicionInicial de la variable x sera igual al un numero aleatorio entre -8 y 8
                    posicionInicial.z = Random.Range(-7f, 9f); 
                }

                posicionAleatoria = new Vector3(posicionInicial.x, posicionInicial.y, posicionInicial.z); //la variable y no es necesaria modificarla
                JugadorSpawn(jugador); //el metodo jugadorSpawn del gameobject jugador
                limite ++; //Se incrementa 1 cada vez que se recorra necesario para que no se genere un bucle infinito
            }
        }

        //Metodo para generar un color aleatorio a un jugador
        public void ColorJugador(GameObject JugadorNuevo){
                int numeroAleatorio = Random.Range(0, listaColores.Count);
                JugadorNuevo.gameObject.GetComponent<Renderer>().material = listaColores[numeroAleatorio];  //Probe tambien con colores en vez de material sin exito
                listaColores.RemoveAt(numeroAleatorio); //Lo elimina de la lista
        }

        //Metodo que genera el spawn del jugador
        //Se crea un GameObject nuevo que sera un clon del gameObject jugador 
        public void JugadorSpawn(GameObject player){ 
        GameObject newPlayer = Instantiate(player, posicionAleatoria, Quaternion.identity); //Crea un nuevo GameObject y lo instancia con las variables asignadas
        ColorJugador(newPlayer);
        Debug.Log("Nuevo Jugador");
    }
}

        


