using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerGFX : MonoBehaviour
{
    
    public AIPath aiPath;
    Animator anim;
    private ParticleSystem dust;
    private float x, y, z;
    public GameObject particleObject;





    private void Awake()
    {

        anim = GetComponent<Animator>();
        dust = particleObject.GetComponent<ParticleSystem>();

    }


    // Update is called once per frame
    //We flip the sheep sprite to the correct rotation in accordination to desiredVelocity.
    // Animator starts and stops the running animation in accordination to desiredVelocity
    void Update()
    {

        anim.SetFloat("speed", aiPath.desiredVelocity.magnitude);


        if (anim.GetFloat("speed") != 0)
        {
            if (dust.isStopped)
            {
                dust.Play();
            }
            if (aiPath.desiredVelocity.x < 0f)
            {

                transform.localScale = new Vector3(-1f, 1f, 1f);

            }
            else if (aiPath.desiredVelocity.x > 0f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);

            }
            //else
            //{

            //}


            //if (aiPath.desiredVelocity.y >= 0.2f | aiPath.desiredVelocity.y <= -0.2f)
            //{

            //   // anim.SetFloat("speed", Mathf.Abs(aiPath.desiredVelocity.y));
            //    //canSeeHoleDigging = false;

            //}
           
            
        }
        else if(dust.isPlaying&& anim.GetFloat("speed")==0)
        {
            dust.Stop();
        }

      


    }

   

}
