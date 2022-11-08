using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject start;
    public GameObject end;
    public float monster_speed;
    bool isForward;

    public float health;
    void Start()
    {
        isForward = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x >= end.transform.localPosition.x)
        {
            isForward = false;
        }
        
        if(transform.localPosition.x <= start.transform.localPosition.x)
        {
            isForward = true;
        }
        
        if(isForward)
        {
            MoveToEnd();
        }
        else{
            MoveToStart();
        }
    }

    public void MoveToEnd()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, end.transform.localPosition, Time.deltaTime * monster_speed); 
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
    public void MoveToStart()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, start.transform.localPosition, Time.deltaTime * monster_speed); 
        transform.eulerAngles = new Vector3(0, 180, 0);

    }


}
