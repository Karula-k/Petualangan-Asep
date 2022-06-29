using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect: MonoBehaviour
{
    private float length, starpost;
    public GameObject cam;
    public float parralaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        starpost = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float tempt = (cam.transform.position.x * (1 - parralaxEffect));
        float dist = (cam.transform.position.x * parralaxEffect);

        transform.position = new Vector3(starpost + dist, transform.position.y, transform.position.z);

        if (tempt > starpost + length) starpost += length;
        else if (tempt < starpost - length) starpost -= length;
    }
}
