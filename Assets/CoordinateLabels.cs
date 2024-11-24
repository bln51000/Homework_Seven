using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] //these scripts run even when you are not playing the game
public class CoordinateLabels : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<TextMeshPro>();//gets reference
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying){//if game is not currently in game mode
            DisplayCoordinates();//only runs in the scene/edit mode
            UpdateObjectName();
        }
        
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);//mono behavior gives baseline functionality, such as transform
        //points to game object it is associated of; trying to access the position of the tile here
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);//why do we want y to show up on the label instead of z?

        label.text = coordinates.x + ", " + coordinates.y;
        
    }

    void UpdateObjectName(){
        transform.parent.name = coordinates.ToString();//transofmr is the text, parent of the text is the tile, so setting the name of the tile here
    }
}
