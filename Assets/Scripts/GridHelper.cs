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
}
