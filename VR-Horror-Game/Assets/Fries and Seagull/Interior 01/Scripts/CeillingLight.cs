#if UNITY_EDITOR
using Seagull.Interior_01.Utility.Inspector;
#endif

using System.Runtime.Serialization;
using Seagull.Interior_01.Utility;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
#endif

namespace Seagull.Interior_01
{


    public class CeilingLight : TurnOnAble
    {

        [SerializeField] float maxOnTime = 5f;
        [SerializeField] float maxOffTime = 0.5f;
        [SerializeField] float minOnTime = 1f;
        [SerializeField] float minOffTime = 0.1f;
        float currentTime = 7f;
        float randomOnTime = 5f;
        float randomOffTime = 0.1f;




        bool isLightOn = true;
        [YureiButton("Turn On")] public UnityEvent onTurnOn;
        [YureiButton("Turn Off")] public UnityEvent onTurnOff;

        [SerializeField] private MeshRenderer lightBoxRenderer;

        public void turnOn()
        {
            if (isLightOn)
            {
                if (currentTime >= randomOnTime)
                {
                    randomOffTime = Random.Range(minOffTime, maxOffTime);
                    lightBoxRenderer.material.EnableKeyword("_EMISSION");
                }
            }
            else
            {
                if (currentTime >= randomOffTime)
                {
                    randomOnTime = Random.Range(minOnTime, maxOnTime);
                    lightBoxRenderer.material.DisableKeyword("_EMISSION");
                }
            }
        }

        public void turnOff()
        {
            lightBoxRenderer.material.DisableKeyword("_EMISSION");
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(CeilingLight))]
    public class CeilingLightInspector : YureiInspector { }
#endif
}
