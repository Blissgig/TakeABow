using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.IO;

namespace Take_A_Bow
{
    public partial class TABA : Form
    {
        #region Private Members
            private KinectSensor TABSensor;
            private bool IsAudioPlaying = false;
        #endregion


        public TABA()
        {
            InitializeComponent();
        }

        private void TABA_Load(object sender, EventArgs e)
        {
            SensorStart();
        }

        private void SensorStart()
        {
            try
            {
                foreach (var potentialSensor in KinectSensor.KinectSensors)
                {
                    if (potentialSensor.Status == KinectStatus.Connected)
                    {
                        this.TABSensor = potentialSensor;
                        break;
                    }
                }

                if (null != this.TABSensor)
                {
                    // Turn on the skeleton stream to receive skeleton frames
                    this.TABSensor.SkeletonStream.Enable();

                    // Add an event handler to be called whenever there is new color frame data
                    this.TABSensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;

                    // Start the sensor!
                    try
                    {
                        this.TABSensor.Start();
                    }
                    catch (IOException)
                    {
                        this.TABSensor = null;
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, could not find a Kinect Device", "Kinect Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void SensorStop()
        {
            try
            {
                if (null != this.TABSensor)
                {
                    this.TABSensor.Stop();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);                              
            }
        }

        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            try
            {
                Skeleton[] skeletons = new Skeleton[0];

                using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
                {
                    if (skeletonFrame != null)
                    {
                        skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                        skeletonFrame.CopySkeletonDataTo(skeletons);
                    }
                }

                if (skeletons.Length != 0)
                {
                    foreach (Skeleton skel in skeletons)
                    {
                        if (skel.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            this.CheckBow(skel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void CheckBow(Skeleton skeleton)
        {
            try
            {
                if (IsAudioPlaying == false) //No need to suck CPU cycles if the audio is playing
                {
                    //Only activate if the user is not too close to sensor
                    if (skeleton.Joints[JointType.HipCenter].Position.Z > 1.6)
                    {
                        float delta = Math.Abs(skeleton.Joints[JointType.HipCenter].Position.Y - skeleton.Joints[JointType.ShoulderCenter].Position.Y);

                        if (delta < 0.21999)
                        {
                            IsAudioPlaying = true;
                            PlayApplause();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void PlayApplause()
        {
            try
            {
                Random objRandom = new Random();
                UnmanagedMemoryStream RandomSound = Properties.Resources.Crickets;
                byte bRandom = Convert.ToByte(objRandom.Next(0, 4));

                switch (bRandom)
                {
                    case 0:
                        RandomSound = Properties.Resources.Crickets;
                        break;

                    case 1:
                        RandomSound = Properties.Resources.Applauding_People_Sound;
                        break;

                    case 2:
                        RandomSound = Properties.Resources.Crowd_Applause;
                        break;

                    case 3:
                        RandomSound = Properties.Resources.Polite_Applause;
                        break;

                    case 4:
                        RandomSound = Properties.Resources.Small_Room;
                        break;
                }


                System.Media.SoundPlayer ApplausePlayer = new System.Media.SoundPlayer(RandomSound);  //Properties.Resources.Crickets);

                ApplausePlayer.PlaySync(); //To insure that the varaible IsPlaying doesn't get reset until the sound completes, as opposed to .Play()
                IsAudioPlaying = false;    //only attempt a new sound when this one has stopped
                ApplausePlayer = null;
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void TABA_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABTrayIcon.Dispose();
            SensorStop();
        }

        private void cmdStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                //Note: yes it is baf form to use the caption as the switch variable.  I know.
                if (cmdStartStop.Text.ToString().Equals("Stop Sensor"))
                {
                    SensorStop();
                    cmdStartStop.Text = "Start Sensor";
                }
                else
                {
                    SensorStart();
                    cmdStartStop.Text = "Stop Sensor";
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void lnkSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.lnkSource.LinkVisited = true;

                System.Diagnostics.Process.Start("http://www.adamfrank.com/performer/performer.htm");
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void TAQBTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void TABA_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
            }
        }

        private void LogException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
