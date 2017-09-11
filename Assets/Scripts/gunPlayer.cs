using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class gunPlayer : MonoBehaviour {
    public int GameBullet = 35;
  public int bulletgame =500;

    public Text PointBullet;
    public Text bulletpoint;
    int heathplayer=100;
    public GameObject heathpanel;

    public Slider HeathBar;

    public float currentheath = 100;
    public Text heath;
  static  int hea=100;

    public Text point;
     int pointspider ;
    public Transform deadReplacement;
    private GameObject player;

    public float speed = 5;

    public GameObject panelboss;
    public GameObject panelguide;
    public GameObject canvaspoint;
    public GameObject win;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(true);
        HeathBar.maxValue = heathplayer;//=mau mac dinh
        HeathBar.value = currentheath;//mau hien tai
        HeathBar.minValue = 0;
       heathpanel.SetActive(false);
        panelboss.SetActive(false);
        panelguide.SetActive(false);
        canvaspoint.SetActive(true);
        win.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            panelboss.SetActive(true);
            canvaspoint.SetActive(false);
        }
        else {

            panelboss.SetActive(false);
            canvaspoint.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            panelguide.SetActive(true);
            canvaspoint.SetActive(false);
        }
        else
        {

            panelguide.SetActive(false);
            canvaspoint.SetActive(true);

        }

    }
    public void GetBullet(int bullet2)
    {
        GameBullet--;
        PointBullet.text = "Bullet:" + GameBullet.ToString();

    }
    public void GetBullet2(int bullet)
    {
        bulletgame-=bullet;
        bulletpoint.text = "|" + bulletgame.ToString();


    }

    public void Gethitplayer(int damge) {

        currentheath -= damge;
       
        HeathBar.value = currentheath;

       // heathpanel.SetActive(true);


        hea -= damge;
        heath.text = "" + hea.ToString();


        if (currentheath==0) {
            //  Instantiate(deadReplacement, transform.position, transform.rotation);  
            Instantiate(deadReplacement,transform.position,Quaternion.identity);
            
            player.SetActive(false);
        }



    }
    public void Engame() {

        Time.timeScale = 0.001f;


    }
    public void GetPoint()
    {
        pointspider+=10;
        point.text = "Scores:" + pointspider.ToString();

    }
    public Text pointbosscurrent;
    int damgeboss = 0;
    int damgecurrentboss = 6;
    public Text restboss;
   

    public void mission(int current)
    {

        damgecurrentboss -= current;
        pointbosscurrent.text = "" + damgecurrentboss.ToString();

        damgeboss += current;
        restboss.text = "" + damgeboss.ToString();

        if (damgeboss==6) {

            win.SetActive(true);
            canvaspoint.SetActive(false);
            Invoke("LoadScene",2);
        }


    }

    public void LoadScene() {


    }



}
