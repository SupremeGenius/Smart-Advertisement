using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

//Emgu Libary
using Emgu.CV;
using Emgu.CV.Structure;

//Face++ Libary
using FaceppSDK;

namespace SmartAD
{

	public partial class SmartAD : Form
	{
		private static Age[] age = new Age[10];
		private static Gender[] gender = new Gender[10];
		private static bool DETECTED = false;
		private Thread Facepp;

		private MCvAvgComp[] facesDetected;
		
		//检测数据
		//private static HaarCascade haar = new HaarCascade ( "haarcascade_frontalface_alt2.xml" );
		private bool ThreadFlag = true;
		public FaceService fs = new FaceService ( "2affcadaeddd18f422375adc869f3991", "EsU9hmgweuz8U-nwv6s4JP-9AJt64vhz" );
		private string fsFileName = "DECT.JPG";
		private Capture _capture = null;
		private bool _captureInProgress = false;

		private Image<Gray, Byte> grayFrame;
		private Image<Gray, Byte> smallGrayFrame;

		public SmartAD ( )
		{
			InitializeComponent ( );
			try
			{
				_capture = new Capture ( );
				_capture.ImageGrabbed += ProcessFrame;
			}
			catch ( NullReferenceException excpt )
			{
				MessageBox.Show ( excpt.Message );
			}

			//初始化训练数据
		}

		private void ProcessFrame ( object sender, EventArgs arg )
		{
			Image<Bgr, byte> frame = _capture.RetrieveBgrFrame ( );
			grayFrame = frame.Convert<Gray, byte> ( );
			smallGrayFrame = grayFrame.PyrDown ( );

			captureImageBox.Image = frame;

			//处理灰度小图
			if ( ThreadFlag )
			{
				Facepp = new Thread ( new ThreadStart ( FaceppThread ) );
				Facepp.Start ( );
				Facepp.Join ( );
			}
		}

		private void ReleaseData ( )
		{
			if ( _capture != null )
				_capture.Dispose ( );
		}

		private void startButton_Click ( object sender, EventArgs e )
		{
			startButton.Visible = false;

			if ( _capture != null )
			{
				if ( _captureInProgress )
				{  //stop the capture
					startButton.Text = "Start";
					_capture.Pause ( );
				}
				else
				{
					//start the capture
					startButton.Text = "Stop";
					_capture.Start ( );
				}

				_captureInProgress = !_captureInProgress;
				// 				Thread T = new Thread ( new ThreadStart ( ADFunction ) );
				// 				T.Start ( );
			}
		}

		public void FaceppThread ( )
		{
			facesDetected = smallGrayFrame.DetectHaarCascade (
				haar,
				1.1,
				10,
				Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
				new Size ( 20, 20 ) )[0];
			int NUM = 0;
			for ( int i = 0 ; i < facesDetected.Length ; i++ )
			{
				MCvAvgComp f = facesDetected[i];
				DETECTED = true;
				this.smallGrayFrame.ROI = f.rect;
				Image<Gray, Byte> roiImage = new Image<Gray, Byte> ( f.rect.Size );
				this.smallGrayFrame.Copy ( roiImage, smallGrayFrame );
				fsFileName = "DECT.jpg";
				roiImage.Save ( fsFileName );
				DetectResult res = fs.Detection_DetectImg ( System.Environment.CurrentDirectory + "\\" + fsFileName );
				if ( res.face.Count > 0 )
				{
					age[NUM] = res.face[0].attribute.age;
					gender[NUM] = res.face[0].attribute.gender;
					NUM++;
				}
			}
			//if ( DETECTED == true )
			//processingData ( );
		}
		
	}
}