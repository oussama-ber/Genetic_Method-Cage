using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class Brain : MonoBehaviour
{
    public int DNALength = 2;
    public float timeAlive;
    public float timeWalking;
    public DNA dna;
    public GameObject eyes;

    
    bool alive = true;
    bool seeGround = true;

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "dead")
        {
            alive = false;
            //wipe date, but if all of them die !! it's a bad idea !!!!!! 
            timeAlive = 0;
            timeWalking = 0;
            
        }
    }

    public void Init()
    {
        //initialise DNA
        //0 forward
        //1 left
        //2 right

        dna = new DNA(DNALength, 6);
        timeAlive = 0;
        alive = true;
    }


    void Update()
    {
        if (!alive) return;
        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 10, Color.red, 10);
        seeGround = false;
        RaycastHit hit;
        if (Physics.Raycast(eyes.transform.position, eyes.transform.forward * 10, out hit))
        {
            if (hit.collider.gameObject.tag == "platform")
            {
                seeGround = true;

            }
        }
        /*timeAlive = PopulationManager.elapsed;*/

        //read dna
        float turnAngle = 0;
        float move = 0;
        if (seeGround)
        {
            //maka v relative to character and always move forward
            if (dna.GetGene(0) == 0)
            {
              move = 1; 
              timeWalking += 1; 
            } 
            else if (dna.GetGene(0) == 1) turnAngle = -90;
            else if (dna.GetGene(0) == 2) turnAngle = 90;
        }
        else
        {
            if (dna.GetGene(1) == 0)
            {
                move = 1;
                timeWalking += 1;
            }
            else if (dna.GetGene(1) == 1) turnAngle = -90;
            else if (dna.GetGene(1) == 2) turnAngle = 90;
        }
        //move according
        this.transform.Translate(0, 0, move * 0.1f);
        this.transform.Rotate(0, turnAngle, 0);
    }

}

