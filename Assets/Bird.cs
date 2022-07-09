using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    
    // create adjustable launchPower variable in Unity
    [SerializeField] private float _launchPower = 500;

    private void Awake() 
    // set start position for later use in calculating launch direction/velocity
    {
        _initialPosition = transform.position;
    }

    private void Update()
    // check for bird position and reset if necessary
    {
        if (transform.position.y > 10)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // when mouse is clicked, change bird to red
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        
        // launch bird
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);

        // set gravity scale
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnMouseDrag() 
    {
        // convert mouse screen position into its equivalent position within game screen
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // update xy coords, but don't change z position 
        transform.position = new Vector3(newPosition.x, newPosition.y); 
    }
}
