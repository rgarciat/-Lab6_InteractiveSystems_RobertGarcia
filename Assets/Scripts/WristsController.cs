using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WristsController : MonoBehaviour
{
    public Text whatYouHave;
    //public Text whatGlassHave;

    private bool youHaveSomething = false;

    //Prefabs that we're going to instantiate:
    public GameObject IcePrefab;
    public GameObject LemonPrefab;
    public GameObject OrangeJuicePrefab;
    public GameObject StrawberryJuicePrefab;
    public GameObject GlassPrefab;

    //objects that we're going to use:
    GameObject ice;
    GameObject lemon;
    GameObject strawberryJuice;
    GameObject orangeJuice;

    private int objectTaken;
    private Vector3 origialPosition;
    private void Start()
    {
        objectTaken = 0;
        youHaveSomething = false;

    }
    private void Update()
    {
        //Ice
        if (objectTaken == 1)
        {
            GameObject.Find("Ice").transform.position = this.transform.position;
        }

        //Lemon
        if (objectTaken == 2)
        {
            GameObject.Find("Lemon").transform.position = this.transform.position;
        }

        //Orange
        if (objectTaken == 3)
        {
            GameObject.Find("Strawberry juice").transform.position = this.transform.position;
        }

        //Strawberry
        if (objectTaken == 4)
        {
            GameObject.Find("Orange juice").transform.position = this.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
 
        if (other.CompareTag("Ice") && !youHaveSomething)
        {
            whatYouHave.text = "Ice";
            youHaveSomething = true;
            origialPosition = GameObject.Find("Ice").transform.position;
            objectTaken = 1;
            //current = Instantiate(IcePrefab, this.transform.position, Quaternion.identity); //si esta linea (32) y la siguiente (33) funcionan bien, copiar y pegar para todos los ifs. No puedo probarlo yo porque la aplicación que utilizaba para tener la camara del movil en el ordena no me funciona.
            //current.tag = "PickedUp";

            SoundManager.PlaySound("grab"); //we reproduce the grab sound
        }
        /*else if (other.CompareTag("Ice") && whatYouHave.text.IndexOf("Ice") != -1)
        {
            whatYouHave.text = "Nothing";
            youHaveSomething = false;

            SoundManager.PlaySound("leave");
        }*/
        else if (other.CompareTag("Lemon") && !youHaveSomething)
        {
            whatYouHave.text = "Lemon";
            youHaveSomething = true;
            origialPosition = GameObject.Find("Lemon").transform.position;
            objectTaken = 2;

            SoundManager.PlaySound("grab");
        }/*
        else if (other.CompareTag("Lemon") && whatYouHave.text.IndexOf("Lemon") != -1)
        {
            whatYouHave.text = "Nothing";
            youHaveSomething = false;

            SoundManager.PlaySound("leave");
        }*/
        else if (other.CompareTag("Strawberry juice") && !youHaveSomething)
        {
            whatYouHave.text = "Strawberry juice";
            youHaveSomething = true;
            origialPosition = GameObject.Find("Strawberry juice").transform.position;
            objectTaken = 3;

            SoundManager.PlaySound("grab");
        }/*
        else if (other.CompareTag("Strawberry juice") && whatYouHave.text.IndexOf("Strawberry juice") != -1)
        {
            whatYouHave.text = "Nothing";
            youHaveSomething = false;

            SoundManager.PlaySound("leave");
        }*/
        else if (other.CompareTag("Orange juice") && !youHaveSomething)
        {
            whatYouHave.text = "Orange juice";
            youHaveSomething = true;
            origialPosition = GameObject.Find("Orange juice").transform.position;
            objectTaken = 4;

            SoundManager.PlaySound("grab");
        }/*
        else if (other.CompareTag("Orange juice") && whatYouHave.text.IndexOf("Orange juice") != -1)
        {
            whatYouHave.text = "Nothing";
            youHaveSomething = false;

            SoundManager.PlaySound("leave");
        }*/
        else if (other.CompareTag("Glass") && youHaveSomething) //in case you enter the glass collider and have something on your hand, then you leave the object in the glass.
        {
            //whatGlassHave.text = "Glass has " + whatYouHave.text;
            Glass.glass.UpdateGlass(whatYouHave);
            whatYouHave.text = "Nothing";

            //return Ice
            if (objectTaken == 1)
            {
                GameObject.Find("Ice").transform.position = origialPosition;
            }

            //Return Lemon
            if (objectTaken == 2)
            {
                origialPosition = GameObject.Find("Lemon").transform.position = origialPosition;
            }

            //Return Orange
            if (objectTaken == 3)
            {
                GameObject.Find("Strawberry juice").transform.position = origialPosition;
            }

            //Return Strawberry
            if (objectTaken == 4)
            {
                GameObject.Find("Orange juice").transform.position = origialPosition;
            }

            
            youHaveSomething = false;
            objectTaken = 0;



            SoundManager.PlaySound("put");
        }
    }
}
