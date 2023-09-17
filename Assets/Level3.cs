using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
    public float playersEntered = 0;
    public float delay = 5;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(playersEntered);
        if (collision.gameObject.name == "Human" || collision.gameObject.name == "Cat")
        {
            playersEntered++;
            Destroy(collision.gameObject);
            if (playersEntered == 1)
            {
                Invoke("CompleteLevel", 2);
            }

            else if (playersEntered == 2)
            {
                CompleteLevel();
            }
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene("BlckOut3");
    }
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(7f);
        // DO STUFF AFTER 3 SECONDS
    }
}
