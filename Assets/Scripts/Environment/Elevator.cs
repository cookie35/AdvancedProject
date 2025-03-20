using System.Collections;
using UnityEngine;
  
// Movingplatform

public class Elevator : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 3f;
    private Vector3 target;

    void Start()
    {
        target = pointB.position;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA.position) ?  pointB.position : pointA.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);  // 플레이어를 플랫폼의 자식으로 설정
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.SetParent(null); // 부모 해제
        }
    }

}
