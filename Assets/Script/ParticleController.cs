using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ParticleController : MonoBehaviour
{
    ParticleSystem ps;

    void Start()
    {
        ps = GameObject.Find("WhiteSmoke").GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        var rot = ps.rotationBySpeed;
        rot.enabled = true;
        var noise = ps.noise;
        noise.enabled = true;
        noise.quality = ParticleSystemNoiseQuality.High;
    }

    public void UpdateParticleBySliderValue(System.Single value)
    {
        if (ps != null)
        {
            var em = ps.emission;
            em.rateOverTime = value *150f;
            var rot = ps.rotationBySpeed;
            rot.range = new Vector2(0, value * 10f);
            var noise = ps.noise;
            noise.strength = value * 10f;
        }
    }


}
