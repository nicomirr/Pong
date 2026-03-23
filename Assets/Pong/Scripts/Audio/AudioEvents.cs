using System;

namespace Pong.Audio
{
    public class AudioEvents
    {
        public static event Action<SFXType> PlaySFX;
        public static event Action<float> ChangeVolume;

        public static void RaisePlaySFX(SFXType SFX_type)
        {
            PlaySFX?.Invoke(SFX_type);
        }

        public static void RaiseChangeVolume(float volumeMod)
        {
            ChangeVolume?.Invoke(volumeMod);
        }
    }
}

