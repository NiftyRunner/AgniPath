using TMPro;
using UnityEngine;

public class PersonRescue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeToHold = 3f;
    [SerializeField] float timer;
    AudioSource personSource;
    bool increaseTimer;

    private void Awake()
    {
        personSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        personSource.Play();
        timer = 1f;
        increaseTimer = false;
        timerText.text = "";
    }

    private void Update()
    {
        if (increaseTimer)
        {
            timer += Time.deltaTime;
            timerText.text = Mathf.FloorToInt(timer % 60f).ToString();
        }

        if (timer >= timeToHold)
        {
            Debug.Log("Person Rescued");
            increaseTimer = false;
            timer = 1f;
            timerText.text = "";
            personSource.Stop();
            Destroy(this.gameObject);
            
        }
    }

    public void TouchedHands()
    {
        increaseTimer = true;
    }

    public void ReleasedHands()
    {
       increaseTimer = false;
       timer = 1f;
       timerText.text = "";
    }

}
