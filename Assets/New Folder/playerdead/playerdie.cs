using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerdie : MonoBehaviour {
    public float secBeforeFade = 3;
    public float fadeTime;
    public Texture fadeTexture;
    bool fadeIn = false;
    private float tempTime;
    float time = 0.0f;
    public AudioClip die;
    // Use this for initialization
    void Start() {
        AudioSource.PlayClipAtPoint(die, transform.position);
        //  yield WaitForSeconds(secBeforeFade);(javascripts)
        StartCoroutine(Example());

        fadeIn = true;

    }


    IEnumerator Example()
    {
       
        yield return new WaitForSeconds(secBeforeFade);
      
    }





    // Update is called once per frame
    void Update() {
        if (fadeIn)
        {
            if (time < fadeTime) time += Time.deltaTime;
            tempTime = Mathf.InverseLerp(0, fadeTime, time);
        }

      //  if (tempTime >= 1.0) SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    void OnGUI()
    {
        if (fadeIn)
        {
            GUI.color = new Color() { a = tempTime };

           /* GUI.color = new Color()
            {
                a = 0.5f
            };*/

            // GUI.color.a = tempTime;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }
    }
}
