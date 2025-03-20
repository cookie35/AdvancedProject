using UnityEngine;

// 발걸음 소리와 뮤직 존 

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepClips;
    private AudioSource audioSource;
    private Rigidbody rigidbody;
    public float footstepThreshold;  // 발자국 소리가 나는 속도 임계값
    public float footstepRate;  // 발자국 소리 재생 간격
    private float footstepTime;  // 마지막 발자국 소리 시간

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Mathf.Abs(rigidbody.velocity.y) < 0.1f)  // y축 속도가 거의 0이면(뛰지 않거나 공중에 x)
        {
            if (rigidbody.velocity.magnitude > footstepThreshold)  // 속도가 임계값을 넘으면 
            {
                if (Time.time - footstepTime > footstepRate)  // 발자국 소리 간격이 되면
                {
                    footstepTime = Time.time;  // 발자국 소리 시간 갱신 
                    if (footstepClips.Length > 0)  //  발자국 소리 배열에 클립이 있는지 확인
                    {
                        audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
                        // 배열에 있는 클립 중 무작위로 하나를 선택하여 재생
                    }

                }
            }
        }

    }
}
