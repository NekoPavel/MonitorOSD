using CSCore.Codecs;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorOSD
{
    public partial class OSDPopup : Form
    {
        public Color green = Color.FromArgb(255, 87, 154, 64);
        public Color red = Color.FromArgb(255, 172, 36, 32);
        public Color blue = Color.FromArgb(255, 43, 112, 170);
        public Color yellow = Color.FromArgb(255, 178, 108, 9);
        CSCore.IWaveSource soundSource;
        WasapiOut soundOut;
        int volume;
        public MMDevice _playbackDevice;
        SystemVolumeConfigurator systemVolume = new SystemVolumeConfigurator();
        public OSDPopup(MonitoringLookup lookup)
        {
            InitializeComponent();
            ViewInfo(lookup);
        }

        private void SoundOut_Stopped(object sender, PlaybackStoppedEventArgs e)
        {
            systemVolume.SetVolume(volume);
            systemVolume.ResetMute();
        }

        public void ViewInfo(MonitoringLookup lookup)
        {
            statusLabel.Text = GetStatus(lookup.status, lookup.isUnresponsive);
            nameLabel.Text = lookup.target;
            this.Text = lookup.target;
            if (lookup.status == 3)
            {
                lookup.currentStep += 1;
            }
            smoothProgressBar.Maximum = lookup.steps + 1;
            smoothProgressBar.Value = lookup.currentStep;
            stepsLabel.Text = $"Steg {lookup.currentStep} av {lookup.steps + 1}";
            stepsLabel.Parent = smoothProgressBar;
            currentStepLabel.Text = $" Steg {lookup.currentStep}: {lookup.currentStepName}";
            volume = systemVolume.GetVolume();
            systemVolume.SetVolume(100);
            systemVolume.SetMute(false);
            switch (lookup.status)
            {
                case 1:
                    if (lookup.isUnresponsive)
                    {
                        smoothProgressBar.ProgressBarColor = red;
                        Icon = SystemIcons.Error;
                        FlashWindow.Start(this, 200);
                        PlaySound(true);
                        break;
                    }
                    else
                    {
                        smoothProgressBar.ProgressBarColor = blue;
                        Icon = SystemIcons.Information;
                        break;
                    }
                case 2:
                    smoothProgressBar.ProgressBarColor = red;
                    Icon = SystemIcons.Error;
                    FlashWindow.Start(this, 200);
                    PlaySound(true);
                    break;
                case 3:
                    smoothProgressBar.ProgressBarColor = green;
                    Icon = SystemIcons.Information;
                    FlashWindow.Start(this, 1000);
                    PlaySound(false);
                    break;
                case 4:
                    smoothProgressBar.ProgressBarColor = yellow;
                    Icon = SystemIcons.Warning;
                    FlashWindow.Start(this, 200);
                    PlaySound(true);
                    break;
                default:
                    smoothProgressBar.ProgressBarColor = yellow;
                    Icon = SystemIcons.Warning;
                    FlashWindow.Start(this, 200);
                    PlaySound(true);
                    break;
            }
        }
        public void PlaySound(bool failed)
        {
            string filepath;
            if (failed)
            {
                filepath = @"\\dfs\gem$\Lit\IT-Service\Fabriken Solna\Pavels Program\hidden\error.wav";
            }
            else
            {
                filepath = @"\\dfs\gem$\Lit\IT-Service\Fabriken Solna\Pavels Program\hidden\success.wav";
            }
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
            soundOut = new WasapiOut() { Device = _playbackDevice };
            soundSource = CodecFactory.Instance.GetCodec(filepath);
            soundOut.Initialize(soundSource);
            soundOut.Play();
            soundOut.Stopped += SoundOut_Stopped;
        }
        public string GetStatus(int statusId, bool notResponding)
        {
            switch (statusId)
            {
                case 1:
                    if (notResponding)
                    {
                        return "Svarar inte";
                    }
                    else
                    {
                        return "Startad";
                    }
                case 2:
                    return "Misslyckades";
                case 3:
                    return "Lyckades";
                case 4:
                    return "Avbruten";
                default:
                    return "Okänt";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (soundOut != null)
            {
                soundOut.Stop();
            }
            this.Close();
        }

    }
}