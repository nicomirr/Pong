using Pong.Audio;
using TMPro;
using UnityEngine;

namespace Pong.UI
{
    public class Options : MonoBehaviour
    {       
        [SerializeField] private TextMeshProUGUI _volumeText;

        private void Start()
        {
            UpdateVolumeText();
        }

        public void ChangeVolumePressed(float volumeMod)
        {
            AudioEvents.RaiseChangeVolume(volumeMod);
            AudioEvents.RaisePlaySFX(SFXType.UI_Click);

            UpdateVolumeText();
        }        

        private void UpdateVolumeText()
        {
            float volume = AudioPlayer.CurrentVolume * 100;
            volume = Mathf.Round(volume);
            _volumeText.text = volume.ToString();

            
        }
    }
}

