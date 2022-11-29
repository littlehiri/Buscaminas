using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase tipo helper, un script que nos sirve de apoyo pero no depende de MonoBehaviour
public class GridHelper : MonoBehaviour
{
    //Variable para conocer el ancho y alto de la rejilla
    public static int w = 15; //Ancho de la malla       static significa que solo habra por ejemplo en este caso un ancho y un alto de 
    public static int h = 15; //Alto de la malla
    //Un Array donde guardar todas las celdas de nuestro juego
    /*Aqui el ordenador crea una malla en el que hace los calculos.
     * [,] = [x,y] [,,] = [x,y,z]
     */
    public static Cell[,] cells = new Cell[w, h]; //Al ser static tambien me permite acceder
    //Metodo para destapar todas las minas
    public static void UncoverAllTheMines()
    {
        //Bucle para recorrer el array de las celdas y que vaya destapando las minas que haya en esta rejilla
        foreach (Cell c in cells)
        {
            if (c.hasMine)
            {
                //llamar al metodo que carga la textura de la mina
                c.LoadTexture(0);
            }
        }
    }
    //Metodo para saber si hay una mina en una posicion dada
    public static bool HasMine(int x, int y)//La posicion de la celda
    {
        //Si estas condiciones se cumplen estaremos dentro de la rejilla
        if(x >= 0 && y >= 0 && x < w && y < h)
        {
            //vemos que celda hemos seleccionado y guardamos su posicion en una variable
            Cell cell = cells[x, y];
            return cell.hasMine;
            //No hay posibilidad de ser mina
        }
        else
        {
            return false;
        }
        //Si las condiciones de arriba no se 
    }
    //Metodo par contar las minas adyacentes a una celda (minas alrededor de una celda
    public static int CountAdjacentMines (int x, int y) //La posicion de la celda
    {
        //Contador de minas
        int count = 0;

        //8 casos adyacentes en los que contariamos una mina si la hubiese
        //usaremos el método para saber si hay una mina en una posicion dada(celda dada)
        if (HasMineAt(x + 1, y)) count++; //medio-derecha
        if (HasMineAt(x - 1, y)) count++; //medio-izquierda
        if (HasMineAt(x, y + 1)) count++; //medio-arriba
        if (HasMineAt(x, y - 1)) count++; //medio-abajo
        if (HasMineAt(x + 1, y + 1)) count++;
    }
}
