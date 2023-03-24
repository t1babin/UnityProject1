using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject pauseText;
    public TMP_Text scoreText;
    bool countdown = false;
    float timer = 0;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        pauseText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxisRaw("horizontal");
        float speed = 10f;
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseText.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseText.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            countdown = true;
        }
        if (countdown)
        {
            if (timer < 3)
            {
                timer += Time.deltaTime;
                Debug.Log(timer);
            }
            else
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        score = score + 1;
        Debug.Log(score);
        float newX = Random.Range(-12, 12);
        float newZ = Random.Range(-5, 5);
        other.transform.position = new Vector3(newX, 11, newZ);
        scoreText.text = "Score: " + score;

    }
}