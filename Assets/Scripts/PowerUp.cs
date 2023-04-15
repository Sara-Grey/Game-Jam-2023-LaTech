using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D lightSource;
    [SerializeField] private float visionPower = 3f;

    public void Activate() {
        lightSource.pointLightOuterRadius = visionPower;
    }
}
