using UnityEngine;

public class Player : MonoBehaviour
{
    public float Playerspeed = 500;
    public float directionalspeed = 20;
    public AudioClip Scoreup;
    public AudioClip Damage;
    public GameObject SceneManager;

    void Update()
    {
   
#if UNITY_EDITOR || UNITY_STANDALONE ||UNITY_WEBPLAYER

        float moveHorizontal = Input.GetAxis("Horizontal");

        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f), gameObject.transform.position.y, gameObject.transform.position.z), directionalspeed * Time.deltaTime);

#endif


        GetComponent<Rigidbody>().velocity = Vector3.forward * Playerspeed * Time.deltaTime;


        // MOBILE CONTROLS
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
    
    


    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "score")
        {
            GetComponent<AudioSource>().PlayOneShot(Scoreup, 1.0f);
        }


        if (other.gameObject.tag == "triangle")
        {
            GetComponent<AudioSource>().PlayOneShot(Damage, 1.5f);
            SceneManager.GetComponent<App_Initialize>().GameOver();
        }
    }
}
