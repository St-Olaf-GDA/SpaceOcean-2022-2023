using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] midRoutes;

    [SerializeField]
    private Transform[] leftRoutes;

    [SerializeField]
    private Transform[] rightRoutes;

    private int routeToGo;
    private float tParam = 0f;
    private Vector3 objectPosition;
    public float speedModifier;
    private bool coroutineAllowed;
    private IEnumerator coroutine;

    public CharacterController controller;
    public Animator animator;
    bool isRight = false;
    bool isLeft = false;
    bool isMid = true;
    //public string currentLane = "mid";

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.075f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        //we only call the function to start the player moving across the path if they aren't already in motion
        if (coroutineAllowed)
        {
            if (isMid)
            {
                coroutine = GoByTheRoute(midRoutes, routeToGo);
                StartCoroutine(coroutine);
            }
            else if (isRight)
            {
                coroutine = GoByTheRoute(rightRoutes, routeToGo);
                StartCoroutine(coroutine);
            }
            else if (isLeft)
            {
                coroutine = GoByTheRoute(leftRoutes, routeToGo);
                StartCoroutine(coroutine);
            }
        }
        
        //a lane swap immediately cancels the current coroutine and swaps the player to the other lane
        //the player's position along the current path is preserved so that they aren't reset to the beginning of the new path
        if (Input.GetKeyDown(KeyCode.D) && !isRight)
        {
            if (isMid)
            {
                isMid = false;
                isRight = true;
                animator.SetBool("isMid", false);
                animator.SetBool("isRight", true);
                StopCoroutine(coroutine);
                coroutineAllowed = true;
            }
            else
            {
                isMid = true;
                isLeft = false;
                animator.SetBool("isMid", true);
                animator.SetBool("isLeft", false);
                StopCoroutine(coroutine);
                coroutineAllowed = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && !isLeft)
        {
            if (isMid)
            {
                isMid = false;
                isLeft = true;
                animator.SetBool("isMid", false);
                animator.SetBool("isLeft", true);
                StopCoroutine(coroutine);
                coroutineAllowed = true;
            }
            else
            {
                isMid = true;
                isRight = false;
                animator.SetBool("isMid", true);
                animator.SetBool("isRight", false);
                StopCoroutine(coroutine);
                coroutineAllowed = true;
            }
        }
    }

    private IEnumerator GoByTheRoute(Transform[] routes, int routeNum)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNum].GetChild(0).position;
        Vector3 p1 = routes[routeNum].GetChild(1).position;
        Vector3 p2 = routes[routeNum].GetChild(2).position;
        Vector3 p3 = routes[routeNum].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;
            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            transform.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0;
        //speedModifier = speedModifier * 0.90f;
        routeToGo += 1;

        //if (routeToGo > routes.Length - 1)
        //{
        //    routeToGo = 0;
        //}
        coroutineAllowed = true;
    }
}
