using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MovingObject
{
    public AudioClip sound;
    public GameObject effect;
    //public Animation explosion;
    // Update is called once per frame
    void FixedUpdate()
    {
        movement(speed);
        //blip = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(sound, transform.position);
        //explosion = gameObject.GetComponent<Animation>(); //used a particle effect instead :(
        //explosion.Play();
        gameObject.SetActive(false); //remove fireball from screen
        GameManage.instance.DealDamage(); //reduce score
 
    }
}
