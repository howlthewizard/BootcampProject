using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Implementation : MonoBehaviour
{
    public GameObject buff_FX;
    public GameObject debuff_FX;
    public GameObject healing_FX;
    public GameObject lightning_FX;
    public GameObject fireball;
    public float buff_FX_Duration;
    //public List<GameObject> effect_Objects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //StartCoroutine("startBuff", effect_Objects[0]);
            StartCoroutine("startBuff", buff_FX);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine("startBuff", debuff_FX);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine("startBuff", healing_FX);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            sendProjectile(fireball);
        }

    }

    void sendProjectile(GameObject projectile)
    {
        Instantiate(projectile, transform.position, transform.rotation, null);
    }

    IEnumerator startBuff(GameObject effect_To_Start)
    {
        effect_To_Start.SetActive(true);
        yield return new WaitForSeconds(buff_FX_Duration);
        effect_To_Start.SetActive(false);
    }

}
