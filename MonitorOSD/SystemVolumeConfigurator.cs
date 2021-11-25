using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCore.CoreAudioAPI;

namespace MonitorOSD

{
    public class SystemVolumeConfigurator
    {
        private readonly MMDeviceEnumerator _deviceEnumerator = new MMDeviceEnumerator();
        private readonly MMDevice _playbackDevice;
        private readonly MMDevice _defaultPlaybackDevice;
        private readonly bool defaultMuted;
        private readonly bool muted;

        public SystemVolumeConfigurator()
        {
            foreach (var device in MMDeviceEnumerator.EnumerateDevices(DataFlow.Render, DeviceState.Active))
            {
                try
                {
                    if (device.FriendlyName.Contains("Speaker") || device.FriendlyName.Contains("Högtalare"))
                    {
                        _playbackDevice = device;
                    }
                }
                catch (Exception)
                {
                }
            }
            _defaultPlaybackDevice = _deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, CSCore.CoreAudioAPI.Role.Multimedia);
            defaultMuted = AudioEndpointVolume.FromDevice(_defaultPlaybackDevice).GetMute();
            muted = AudioEndpointVolume.FromDevice(_playbackDevice).GetMute();
        }

        public int GetVolume()
        {
            return (int)(AudioEndpointVolume.FromDevice(_playbackDevice).MasterVolumeLevelScalar * 100);
        }

        public void SetVolume(int volumeLevel)
        {
            if (volumeLevel < 0 || volumeLevel > 100)
                throw new ArgumentException("Volume must be between 0 and 100!");

            AudioEndpointVolume.FromDevice(_playbackDevice).MasterVolumeLevelScalar = volumeLevel / 100.0f;
        }
        public void SetMute(bool muted)
        {
            Guid eventContext = new Guid();
            AudioEndpointVolume.FromDevice(_playbackDevice).SetMute(muted, eventContext);
            AudioEndpointVolume.FromDevice(_defaultPlaybackDevice).SetMute(muted, eventContext);
        }
        public void ResetMute()
        {
            Guid eventContext = new Guid();
            AudioEndpointVolume.FromDevice(_defaultPlaybackDevice).SetMute(defaultMuted, eventContext);
            AudioEndpointVolume.FromDevice(_playbackDevice).SetMute(muted, eventContext);
        }
        
        public bool GetMute()
        {
            return AudioEndpointVolume.FromDevice(_playbackDevice).GetMute();
        }
    }
}
