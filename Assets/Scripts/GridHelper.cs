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
    public static bool HasMineAt(int x, int y)//La posicion de la celda
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
        if (HasMineAt(x + 1, y + 1)) count++; //arriba-derecha
        if (HasMineAt(x - 1, y + 1)) count++; //arriba-izquierda
        if (HasMineAt(x + 1, y - 1)) count++; //abajo-derecha
        if (HasMineAt(x - 1, y - 1)) count++; //abajo-izquierda

        //Una vez hechas las comprobaciones devolvemos el número de minas
        return count;
    }

    //Este metodo levanta una posicion en X e Y
    public static void FloodFillUncover(int x, int y, bool[,] visited) //Le pasamos una posicion 
    {
        //Solo debemos proceder si el punto (x,y) es valido (está dentro de la rejilla)
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            //Si ya he pasado por esta celda, el algoritmo de FFU no debe hacer nada
            if (visited[x, y])
            {
                //salimos del metodo si se cumple la condicion
                return;
            }
            //Si estoy aqui es que la celda no habia sido visitada
            //Y entonces cuento el numero de minas adyacentes a mi posicion (x,y)
            int adjacentMines = CountAdjacentMines(x, y);
            //Muestro en la celda, el numero de minas adyacentes(desde 0 hasya 8 maximo)
            cells[x, y].LoadTexture(adjacentMines);
            if (adjacentMines > 0)
            {
                return;
            }
            //Si esta celda no ha sido visitada y tampoco tiene minas adyacentes
            //Marcamos la celda actual como visitada
            visited[x, y] = true;
            //visito todas las celdas vecinas en Conectividad de la celda actual
            FloodFillUncover(x - 1, y, visited);
            FloodFillUncover(x + 1, y, visited);
            FloodFillUncover(x, y - 1, visited);
            FloodFillUncover(x, y + 1, visited);
        }
       
    }
}
