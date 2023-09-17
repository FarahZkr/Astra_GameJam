using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public float playersEntered = 0;
    public float delay = 5;
    public string sceneToTp = "BlackedOut2";
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
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 8)
        {
            playersEntered++;
            Debug.Log(playersEntered);
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
        SceneManager.LoadScene(sceneToTp);
    }
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(7f);
        // DO STUFF AFTER 3 SECONDS
    }
}
