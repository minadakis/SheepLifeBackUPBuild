using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerGFX : MonoBehaviour
{
    
    public AIPath aiPath;
    Animator anim;
    public bool canSeeHoleDigging;
    private ParticleSystem dust;
    public float x, y, z;
    public GameObject particleObject;





    private void Awake()
    {

        anim = GetComponent<Animator>();
        canSeeHoleDigging = true;

        dust = particleObject.GetComponent<ParticleSystem>();

    }


    // Update is called once per frame
    //We flip the dog sprite to the correct rotation in accordination to desiredVelocity.
    // Animator starts and stops the running animation in accordination to desiredVelocity
    void Update()
    {

      

        if (aiPath.desiredVelocity.x < 0f)
        {

            transform.localScale = new Vector3(-1f, 1f, 1f);
            anim.SetFloat("speed", Mathf.Abs(aiPath.desiredVelocity.x));
            canSeeHoleDigging = false;






        }
        else if (aiPath.desiredVelocity.x > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            anim.SetFloat("speed", Mathf.Abs(aiPath.desiredVelocity.x));
            canSeeHoleDigging = false;

        }
        else {
            anim.SetFloat("speed", Mathf.Abs(aiPath.desiredVelocity.x));
            canSeeHoleDigging = false;
        }


        if ( aiPath.desiredVelocity.y >= 0.2f | aiPath.desiredVelocity.y <= -0.2f)
        {
           
            anim.SetFloat("speed", Mathf.Abs(aiPath.desiredVelocity.y));
            canSeeHoleDigging = false;
           
        }


        if (aiPath.desiredVelocity.x == 0 & aiPath.desiredVelocity.y == 0)
        {
            
            canSeeHoleDigging = true;
            var emission = dust.emission;
            emission.enabled = false;
        }
        else
        {

            var emission = dust.emission;
            emission.enabled = true;
        }


    }

   

}
