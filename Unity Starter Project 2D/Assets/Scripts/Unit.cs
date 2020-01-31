using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Transform target;
    public float speed = 2;
    Vector3[] path;
    int targetIndex;
    public bool canRequestPath = true;
    float waitTime;

    void FixedUpdate()
    {
        waitTime = Vector3.Distance(transform.position, target.position) / 50;
        if (canRequestPath)
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
            StartCoroutine(PathRequestDelay(waitTime));
        }
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        if (path.Length > 0)
        {
            Vector3 currentWaypoint = path[0];
            while (true)
            {
                if (transform.position == currentWaypoint)
                {
                    targetIndex++;
                    if (targetIndex >= path.Length)
                    {
                        yield break;
                    }
                    currentWaypoint = path[targetIndex];
                }

                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.fixedDeltaTime);
                yield return null;
            }
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator PathRequestDelay(float time)
    {
        canRequestPath = false;
        yield return new WaitForSecondsRealtime(time);
        canRequestPath = true;
    }
}
