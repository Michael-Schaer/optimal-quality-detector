using UnityEngine;

public class CameraDistanceDependantObject : MonoBehaviour
{
    public float distance = 35f;

    private float timer = 0f;

    private const float TIMER_PERIOD = 0.2f;
    private const float CHANGE_TIMEOUT = 1f;
	
	void Update ()
    {
	    if(Time.time > timer)
        {
            timer = Time.time + TIMER_PERIOD;
            CheckDistance();
        }
	}

    private void CheckDistance()
    {
        if(Vector3.Distance(Camera.main.transform.position, gameObject.transform.position) > distance)
        {
            ChangeObjectStatus(false);
        }
        else
        {
            ChangeObjectStatus(true);
        }
    }

    private void ChangeObjectStatus(bool status)
    {
        if (gameObject.activeSelf != status)
        {
            gameObject.SetActive(status);
            timer = Time.time + CHANGE_TIMEOUT;
        }
    }
}
