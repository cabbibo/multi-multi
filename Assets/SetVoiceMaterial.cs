using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

    public class SetVoiceMaterial : MonoBehaviour {
        public Renderer mouth;

        private RealtimeAvatarVoice _voice;
        private float _mouthSize;

        private Vector3 _startPosition;

        void Awake() {
            // Get a reference to the RealtimeAvatarVoice component
            _voice = GetComponent<RealtimeAvatarVoice>();
        }

        void Update() {
            // Use the current voice volume (a value between 0 - 1) to calculate the target mouth size (between 0.1 and 1.0)
            float targetMouthSize = Mathf.Lerp(0.001f, 1.0f, _voice.voiceVolume);

            // Animate the mouth size towards the target mouth size to keep the open / close animation smooth
            _mouthSize = Mathf.Lerp(_mouthSize, targetMouthSize, 30.0f * Time.deltaTime);
            mouth.material.SetFloat("_Voice", _mouthSize );

        }
    }


