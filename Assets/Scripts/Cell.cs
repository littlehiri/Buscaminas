using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    //Variable que nos permite conocer si un panel tiene una mina o no
    public bool hasMine;
    //Array en el que guardamos todas las imagenes que corresponden a que no hay una mina en esa celda al pulsar sobre ella
    public Sprite[] emptyTexture;
    //Necesitamos la imagen de que hay una mina
    public Sprite mineTexture;
    // Start is called before the first frame update
    void Start()
    {
        //Le decimos que hay un 15% de posibilidades de que haya una mina en esa celda
        //Si se cumple en este caso que ese valor sea menor que 0.15, hasMine ser� verdadero sino falso
        hasMine = (Random.value < 0.15);
        //Variables para recoger la posicion inicial de la celda
        int x = (int)this.transform.position.x; //La posicion en x de esa celda concreta (La columna)       (int) lo usamos para transformar el float en numero entero
        int y = (int)this.transform.position.y; //La posicion en y de esa celda concreta (Horizontal)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool Iscovered()
    {
        //Coge del SpriteRenderer de esa celda la textura que esta ah� puesta para saber si es un panel
        //o no. En caso de que sea un panel, ser� verdadero, y sino falso
        return GetComponent<SpriteRenderer>().sprite.texture.name == "panel";
    }
    public void LoadTexture(int adjacentCount)//Para pasarle el conteo de minas adayacentes
    {
        if (hasMine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;

        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptyTexture[adjacentCount];
            
        }
    }
    //Metodo para cuando pulsamos en una celda y soltamos el click del raton
    public void OnMouseUpAsButton()
    { //Si esa celda tiene una mina
        if (hasMine)
        {
            Debug.Log("Tiene mina");
        }
        //Si no hay mina en esa celda
        else
        {
            //To do:
            /*Cmabiar la textura de la celda
             * descubrir toda el area sin minas alrededor de la celda destapada
             * comprobar si el juego ha terminado o no
             */
        }
    }
}