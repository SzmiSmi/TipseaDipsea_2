using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fishPrefab;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    private GameObject thisTarget;
    private GameObject thisTarget2;
    private Vector3 fishDirection;
    private Quaternion lookRotation;
    private Quaternion lookRotation2;

    private float timer = 0.0f;
    private float spawnRate;
    public float bpm = 105.0f;

    public AudioSource positiveSound;
    public AudioSource positiveSound2;
    public AudioClip positiveSoundClip;
    public AudioClip positiveSoundClip2;

    public GameObject FloatingTextPrefab; 

    private float textDestroyTime;
    private Color fishColor;
    private Color fishColor2;

    
    private Color[] colors = new Color[5];

    void Start()
    {
        spawnRate = 4*60/bpm;
        fishDirection = target1.transform.position - transform.position;
        lookRotation = Quaternion.LookRotation(fishDirection);
        
        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
        colors[3] = Color.yellow;
        colors[4] = Color.black;
    }
    public void ShowFloatingText()
    {

        // Instantiate the text popup at the specified position
        var generatedText = Instantiate(FloatingTextPrefab, transform.position + new Vector3(0,0,-20), Quaternion.LookRotation(new Vector3(0,0,1)));
        generatedText.GetComponent<TextMesh>().text = ColorSaidByText();
        generatedText.GetComponent<TextMesh>().color = colors[Random.Range(0,colors.Length)];
        textDestroyTime = spawnRate;
        Destroy(generatedText, textDestroyTime);
    }

    private string ColorSaidByText()
    {
        if(fishColor.Equals(colors[0]))
        {
            return "Red";
        }
        else if(fishColor.Equals(colors[1]))
        {
            return "Green";
        }
        else if(fishColor.Equals(colors[2]))
        {
            return "Blue";
        }
        else if(fishColor.Equals(colors[3]))
        {
            return "Yellow";
        }
        else
        {
            return "Black";
        }
    }



    // Update is called once per frame
    void Update()
    {
        if(timer<spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            int targetNo = Random.Range(0,4);
            
            if(targetNo == 0) thisTarget = target1;
            else if(targetNo == 1) thisTarget = target2;
            else if(targetNo == 2) thisTarget = target3;
            else thisTarget = target4;
            fishDirection = thisTarget.transform.position - transform.position;
            lookRotation = Quaternion.LookRotation(fishDirection);

            GameObject fish = Instantiate(fishPrefab, transform.position, lookRotation);
            Swim swimControl = fish.GetComponent<Swim>();
            OnCollision collisionControl = fish.GetComponent<OnCollision>();
            if(swimControl!= null) 
            {
                swimControl.SetTarget(thisTarget);
                swimControl.SetBpm(bpm);
                collisionControl.SetAudioSource(positiveSound);
                collisionControl.SetAudioClip(positiveSoundClip);
                fishColor = colors[Random.Range(0,colors.Length)];
                swimControl.SetColor(fishColor);
            }
            ShowFloatingText();

            int targetNo2 = (targetNo+1)%4;
            if(targetNo2 == 0) thisTarget2 = target1;
            else if(targetNo2 == 1) thisTarget2 = target2;
            else if(targetNo2 == 2) thisTarget2 = target3;
            else thisTarget2 = target4;
            fishDirection = thisTarget2.transform.position - transform.position;
            lookRotation2 = Quaternion.LookRotation(fishDirection);

            GameObject fish2 = Instantiate(fishPrefab, transform.position, lookRotation2);
            Swim swimControl2 = fish2.GetComponent<Swim>();
            OnCollision collisionControl2 = fish2.GetComponent<OnCollision>();
            if(swimControl!= null) 
            {
                swimControl2.SetTarget(thisTarget2);
                swimControl2.SetBpm(bpm);
                collisionControl2.SetAudioSource(positiveSound);
                collisionControl2.SetAudioClip(positiveSoundClip);
                fishColor2 = colors[Random.Range(0,colors.Length)];
                swimControl2.SetColor(fishColor2);
            }

            timer = 0;
            
        }
        
    }
}
