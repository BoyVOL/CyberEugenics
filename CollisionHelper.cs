using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHelper : MonoBehaviour
{
    public static float cpaTime(Vector3 start1, Vector3 start2, Vector3 speed1, Vector3 speed2)
    {
        Vector3 dv = speed1 - speed2;

        float dv2 = Vector3.Dot(dv, dv);
        if (dv2 < Mathf.Epsilon)      // the  tracks are almost parallel
            return 0;             // any time is ok.  Use time 0.

        Vector3 w0 = start1 - start2;
        float cpatime = -Vector3.Dot(w0, dv) / dv2;

        return cpatime;             // time of CPA
    }
    public static float cpaDistance(Vector3 start1, Vector3 start2, Vector3 speed1, Vector3 speed2)
    {
        float ctime = cpaTime(start1, start2, speed1, speed2);
        Vector3 P1 = start1 + (ctime * speed1);
        Vector3 P2 = start2 + (ctime * speed2);

        return Vector3.Magnitude(P1 - P2);
    }
    private void Start()
    {
        DontDestroyOnLoad(this);
        if(Debug.isDebugBuild == true)
        {
            Debug.Log(cpaTime(new Vector3(1, 0), new Vector3(0, 0), new Vector3(-1, 1), new Vector3(0, 1)));
            Debug.Log(cpaTime(new Vector3(1, 0), new Vector3(0, 0), new Vector3(0, 1), new Vector3(0, 1)));
            Debug.Log(cpaTime(new Vector3(1, 0), new Vector3(0, 0), new Vector3(1, 1), new Vector3(0, 1)));
        }
    }
}
