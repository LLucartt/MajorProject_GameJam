using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple2DTargetScanner : MonoBehaviour
{
    public float scanFrequency; //in seconds
    public float scanRadius = 15; //in world units
    private float scanFrequencyCounter = 5; //counter for time between scans

    public string[] targetTagArray; //array of tags of GameObjects to include

    //delegate event to notify subscribed scripts
    public delegate void TargetHit(Transform target);
    public event TargetHit OnTargetHit;

    public Color editorCircleColor = Color.green; //circle colour for editor
    public bool scannerEnabled = true; //enable or disable scanner (or you can just enable/disable script if you prefer)

    // Update is called once per frame
    void FixedUpdate()
    {
        //if not enabled, return to stop code below from running.
        if (!scannerEnabled)
            return;

        //counter to track time between scans
        scanFrequencyCounter += Time.deltaTime;
        //once counter reaches the total time we set between scans, we scan for target and reset counter to zero.
        if (scanFrequencyCounter >= scanFrequency)
        {
            scanFrequencyCounter = 0;
            //using Physics2D we will draw a circle and use a 2d raycast to see what objects are within it.
            //Targets must have collider for raycast to return or it won't be detected with this method.
            RaycastHit2D[] raycastHit2D = Physics2D.CircleCastAll(this.transform.position, scanRadius, Vector2.right, scanRadius * 2f);
            //if we hit any targets, notify listeners that need this info
            //make sure to check if OnTargetHit is null or not in case no subscribers (but if no subscribers, why using this at all? ;) )
            if (raycastHit2D.Length > 0 && OnTargetHit != null)
            {
                for(int i = 0; i < raycastHit2D.Length; i++)
                {
                    //Important note: if you have a lot of target scanners running at once, for performance it might be better to just scan based on
                    //layers rather than compare gameobject tags.
                    for (int t = 0; t < targetTagArray.Length; t++)
                    {
                        if (raycastHit2D[i].transform.CompareTag(targetTagArray[t]))
                        {
                            //delgate event
                            OnTargetHit(raycastHit2D[i].transform);
			    //break out of both loops after first hit
                            i = raycastHit2D.Length + 1;
                            break;
                        }
                    }
                }
            }
        }

    }
  }
