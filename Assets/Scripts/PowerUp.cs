using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D lightSource;
    [SerializeField] private float visionPower;

    public void Activate() {
        lightSource.pointLightOuterRadius = visionPower;
    }
}
