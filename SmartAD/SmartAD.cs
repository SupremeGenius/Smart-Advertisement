using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

//Emgu Libary
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;

//Face++ Libary
using FaceppSDK;
using System.Collections.Generic;

namespace SmartAD
{
	public partial class SmartAD : Form
	{
		private static Age[] age = new Age[10];
		private static Gender[] gender = new Gender[10];
		//private static bool DETECTED = false;
		private Thread Facepp;

		//检测数据
		private CascadeClassifier Classifier
			= new CascadeClassifier( "haarcascade_frontalface_alt2.xml" );
		private Rectangle[] facesDetected2;
		private List<Rectangle> facesRectangle;

		//private bool ThreadFlag = true;
		public FaceService fs = new FaceService ( "ab81149f089f3d4b7562018b07ec8621", "QhfloTcg57Ce4vImf19_4gdihV8dxKOm" );
		private string fsFileName = "DECT.JPG";
		private Capture _capture = null;
		private bool _captureInProgress = false;

		private Image<Gray, byte> grayFrame;
		private Image<Gray, byte> smallGrayFrame;

		public object DataTime { get; private set; }

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
			Image<Bgr, byte> frame = _capture.QueryFrame().ToImage<Bgr,byte>();
			grayFrame = frame.Convert<Gray, byte> ( );
			smallGrayFrame = grayFrame.PyrDown ( );

			captureImageBox.Image = frame;
			facesDetected2 = null;
			int now = DateTime.Now.Millisecond;
			facesDetected2 = Classifier.DetectMultiScale 
				(smallGrayFrame,1.1,10,new Size ( 20, 20 ),Size.Empty );
			facesRectangle.AddRange ( facesDetected2 );
			now = DateTime.Now.Millisecond - now;

				//处理灰度小图
				//if ( ThreadFlag )
				//{
				Facepp = new Thread ( new ThreadStart ( FaceppThread ) );
				Facepp.Start ( );
				Facepp.Join ( );
			//}
		}

		private void ReleaseData ( )
		{
			if ( _capture != null )
				_capture.Dispose ( );
		}

		private void startButton_Click ( object sender, EventArgs e )
		{
			//startButton.Visible = false;

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
			int DECTEDNUM = 0;

			foreach ( Rectangle face in facesDetected2)
			{
				smallGrayFrame.ROI = face;
				Image<Gray, byte> roiImage = new Image<Gray, byte> ( face.Size );
				smallGrayFrame.Copy ( roiImage, smallGrayFrame );
				roiImage.Save ( fsFileName );
				DetectResult result =
				fs.Detection_DetectImg ( Environment.CurrentDirectory + "\\" + fsFileName );
				for ( DECTEDNUM = 0 ; DECTEDNUM < result.face.Count ; DECTEDNUM++ ) 
				{
					age[DECTEDNUM] = result.face[DECTEDNUM].attribute.age;
					gender[DECTEDNUM] = result.face[DECTEDNUM].attribute.gender;
				}
			}
			
			//if ( DETECTED == true )
			//processingData ( );
		}
	}
}