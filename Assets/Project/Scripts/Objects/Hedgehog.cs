using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hedgehog : MonoBehaviour
{
    [Header("Object params")]
    [SerializeField]
    private float rotationSmooth = 0.3f;


    private Rigidbody2D rb;
    private float smoothVel = 0.0f;
    private float spawnedScale = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Cache component
        //Save spawned scale
        spawnedScale = transform.localScale.x;

        //Set zero scale
        transform.localScale = Vector3.zero;
        //Make scale animation on spawned object
        transform.DOScale(spawnedScale, 0.1f);
    }

    private void FixedUpdate()
    {
        if (rb.angularVelocity < 5) //if angvel less 5
        {
            if (rb.rotation > 0.1f || rb.rotation < -0.1f) //Check if rotation in range
                rb.rotation = Mathf.SmoothDampAngle(rb.rotation, 0, ref smoothVel, rotationSmooth); //Rotate object
        }
    }

    public void AddRandomForce(float minForce, float maxForce)
    {
        //Adding up force
        rb.AddForce(new Vector2(Random.Range(-minForce, maxForce),Random.Range(minForce, maxForce) * 4));

        //Scale animation on clicked
        transform.DOScale(spawnedScale + 0.4f, 0.1f).OnComplete(() =>
        {
            transform.DOScale(spawnedScale, 0.1f);
        });
    }
}
