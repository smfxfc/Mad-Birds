using UnityEngine;

public class Bird : MonoBehaviour
{
    // when mouse is clicked, change bird to red
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
