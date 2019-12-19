using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hp = 100;
    public Slider hpslider;

    public Text textTacos;
    public int TacosCount;
    public int TacosTotal;

    public Text textTime;
    public float gameTime;

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "陷阱")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpslider.value = hp;
        }

        if (other.tag == "Tacos")
        {
            TacosCount++;
            textTacos.text = "Tacos : " + TacosCount + " / " + TacosTotal;
            Destroy(other.gameObject);
        }

        if (other.name =="終點" && TacosCount == TacosTotal)
        {
            print("過關");
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpslider.value = hp;
        }
    }

    private void Start()
    {
        TacosTotal = GameObject.FindGameObjectsWithTag("Tacos").Length;
        textTacos.text = "Tacos : 0 / " + TacosTotal;
    }

    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        textTime.text = gameTime.ToString("F2");
    }
}
