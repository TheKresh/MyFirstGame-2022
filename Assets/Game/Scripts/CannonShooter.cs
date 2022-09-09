using UnityEngine;

// Ha a beallitott ertek nem nulla, akkor adott idokozonkent letrehoz egy lovedeket

public class CannonShooter : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] GameObject bullet;
    [SerializeField] float starttimebetween;
    
    float timebetween;

    void Start()
    {
        timebetween = starttimebetween;
    }

    void Update()
    {
        if (timebetween <= 0)
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = startPos.position;
            timebetween = starttimebetween;
        }
        else
            timebetween -= Time.deltaTime;
    }
}
