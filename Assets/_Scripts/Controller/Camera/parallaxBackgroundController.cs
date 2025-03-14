using UnityEngine;

public class parallaxBackgroundController : MonoBehaviour
{
    private float startPos, lenght;
    public GameObject cam;
    public float parallaxEffect;

    void Awake()
    {
        cam = Camera.main.gameObject;
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(movement > startPos + lenght)
            startPos += lenght;
        else if (movement < startPos - lenght)
            startPos -= lenght;
        
    }
}
