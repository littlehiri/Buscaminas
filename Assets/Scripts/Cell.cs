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

    //Creamos unas variables donde guardar la posicion de la celda concreta
    int x, y;
    void Start()
    {
        //Le decimos que hay un 15% de posibilidades de que haya una mina en esa celda
        //Si se cumple en este caso que ese valor sea menor que 0.15, hasMine será verdadero sino falso
        hasMine = (Random.value < 0.15);
        //Variables para recoger la posicion inicial de la celda
        x = (int)this.transform.position.x; //La posicion en x de esa celda concreta (La columna)       (int) lo usamos para transformar el float en numero entero
        y = (int)this.transform.position.y; //La posicion en y de esa celda concreta (Horizontal)
        GridHelper.cells[x, y] = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool Iscovered()
    {
        //Coge del SpriteRenderer de esa celda la textura que esta ahí puesta para saber si es un panel
        //o no. En caso de que sea un panel, será verdadero, y sino falso
        return GetComponent<SpriteRenderer>().sprite.texture.name == "panel";
    }
    public void LoadTexture(int adjacentCount)//Para pasarle el conteo de minas adayacentes
    {
        if (hasMine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;

        }
        else
        {//Adjacent count es el numero del array
            GetComponent<SpriteRenderer>().sprite = emptyTexture[adjacentCount];
            
        }
    }
    //Metodo para cuando pulsamos en una celda y soltamos el click del raton
    public void OnMouseUpAsButton()
    { //Si esa celda tiene una mina
        if (hasMine)
        {
            Debug.Log("Tiene mina");
            GridHelper.UncoverAllTheMines();
            //mostrar mensaje de game over
        }
        //Si no hay mina en esa celda
        else
        {
            //To do:
            /*Cmabiar la textura de la celda
             * descubrir toda el area sin minas alrededor de la celda destapada
             * comprobar si el juego ha terminado o no
             */
            int y = (int)this.transform.parent.position.y; //Obtenemos la Y del padre de este
            //Al metodo de abajo le pasamos la posicion de esta celda concreta
            //Cargamos la textura de minas adyacentes adecuada
            LoadTexture(GridHelper.CountAdjacentMines(x, y));

        }
    }
}
