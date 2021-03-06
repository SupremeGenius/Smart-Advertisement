using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

//Emgu库
using Emgu.CV;
using Emgu.CV.Structure;

//Face++库
using FaceppSDK;

namespace SmartAD_Winform
{
	
	public partial class SmartAD : Form
	{
		private static Age[] age = new Age[10];
		private static Gender[] gender = new Gender[10];
		private static bool DETECTED = false;
		private static Data data = new Data ( );
		private Thread Facepp;
		
		private MCvAvgComp[] facesDetected;
		private static HaarCascade haar = new HaarCascade ( "haarcascade_frontalface_alt2.xml" );
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
		}

		private void ProcessFrame ( object sender, EventArgs arg )
		{
			Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame ( );
			grayFrame = frame.Convert<Gray, Byte> ( );
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
                DetectResult res_ = fs.Detection_DetectImg(this.smallGrayFrame);
                DetectResult res = fs.Detection_DetectImg(System.Environment.CurrentDirectory + "\\" + fsFileName);
				if ( res.face.Count > 0 )
				{
					age[NUM] = res.face[0].attribute.age;
					gender[NUM] = res.face[0].attribute.gender;
					NUM++;
				}
			}
			if ( DETECTED == true )
				processingData ( );
		}

		public void processingData ( )
		{
			DETECTED = false;
			//首先分类Famale 和 male
			int ageLength = 0;
			for ( int i = 0 ; i < age.Length ; i++ )
			{
				if ( age[i] != null )
					++ageLength;
			}
			for ( int i = 0 ; i < ageLength ; i++ )
			{
				if ( gender[i].value == "Male" )
				{
					if ( age[i].value >= 50 )
					{
						data.male[4] += 1;
					}
					else if ( age[i].value >= 35 && age[i].value < 50 )
					{
						data.male[3] += 1;
					}
					else if ( age[i].value >= 20 && age[i].value < 35 )
					{
						data.male[2] += 1;
					}
					else if ( age[i].value >= 0 && age[i].value < 20 )
					{
						if ( age[i].value + age[i].range >= 20 )
							data.male[2] += 1;
						else
							data.male[1] += 1;
					}
				}
				else if ( gender[i].value == "Female" )
				{
					if ( age[i].value >= 50 )
					{
						data.female[4] += 1;
					}
					else if ( age[i].value >= 35 && age[i].value < 50 )
					{
						data.female[3] += 1;
					}
					else if ( age[i].value >= 20 && age[i].value < 35 )
					{
						data.female[2] += 1;
					}
					else if ( age[i].value >= 0 && age[i].value < 20 )
					{
						if ( age[i].value + age[i].range >= 20 )
							data.female[2] += 1;
						else
							data.female[1] += 1;
					}
				}
			}
			for ( int i = 0 ; i < 10 ; i++ )
			{
				age[i] = null;
				gender[i] = null;
			}
			ADFunction ( );
			int sum = 0;
			for ( int i = 0 ; i < 5 ; i++ )
			{
				sum += data.male[i];
				sum += data.female[i];
			}
// 			if ( sum > 0 )
// 				AdoLinkSql.SetData ( data );
			data.Clear ( );
		}


		//默认消费能力同等条件下从儿童到老年依次递增且女性大于男性
		public void ADFunction ( )
		{
			int[] Finally_Num = new int[5];
			int i = 0;
			String strName;
			String str;
			Random rd = new Random ( );
			//int num=rd.Next()%3+1;
			int num = 1;
			str = num.ToString ( ) + ".jpg";
			if ( !data.Empty ( ) )
			{
				for ( int j = 0 ; j < 5 ; j++ )
				{
					Finally_Num[j] = data.female[j] + data.male[j];
				}
			}
			i = Max_Num ( Finally_Num );
			switch ( i )
			{
				case 0:
					if ( data.female[0] >= data.male[0] )
					{
						//判断男女性别的人数大小，同等条件下默认女性消费能力高（下面同理）
						strName = "..\\PIC_AD\\Child\\Female\\";
						strName += str;
						Show_Image ( strName );
					}
					else
					{
						strName = "..\\PIC_AD\\Child\\Male\\";
						strName += str;
						Show_Image ( strName );
					}
					break;

				case 1:
					if ( data.female[1] >= data.male[1] )
					{
						strName = "..\\PIC_AD\\Teenager\\Female\\";
						strName += str;
						Show_Image ( strName );
					}
					else
					{
						strName = "..\\PIC_AD\\Teenager\\Male\\";
						strName += str;
						Show_Image ( strName );
					}
					break;

				case 2:
					if ( data.female[2] >= data.male[2] )
					{
						strName = "..\\PIC_AD\\Youth\\Female\\";
						strName += str;
						Show_Image ( strName );
					}
					else
					{
						strName = "..\\PIC_AD\\Youth\\Male\\";

						strName += str;
						Show_Image ( strName );
					}
					break;

				case 3:
					if ( data.female[3] >= data.male[3] )
					{
						strName = "..\\PIC_AD\\Middle\\Female\\";
						strName += str;
						Show_Image ( strName );
					}
					else
					{
						strName = "..\\PIC_AD\\Middle\\Male\\";
						strName += str;
						Show_Image ( strName );
					}
					break;

				case 4:
					if ( data.female[4] >= data.male[4] )
					{
						strName = "..\\PIC_AD\\Old\\Female\\";
						strName += str;
						Show_Image ( strName );
					}
					else
					{
						strName = "..\\PIC_AD\\Old\\Male\\";
						strName += str;
						Show_Image ( strName );
					}
					break;
			}
		}

		private static int Max_Num ( int[] a )
		{
			int i = 4;
			int max = a[i];
			for ( int j = 3 ; j >= 0 ; j-- )
			{
				if ( a[i] <= a[j] )
					i = j;
			}
			return i;
		}

		public void Show_Image ( String strPath )
		{
			//解决线程访问控件错误
			//this.Invoke((EventHandler)delegate{xxxx;})
			this.Invoke ( ( EventHandler ) delegate { this.ADImageBox.Load ( strPath ); } );
			this.Invoke ( ( EventHandler ) delegate { this.ADImageBox.Show ( ); } );
		}

	}
    public class Time
	{
		public int hour = new int ( );
		public int min = new int ( );
		public int sec = new int ( );
	}

	public class Data
	{
		public int[] male;
		public int[] female;
		public Time curTime = new Time ( );
		public Data ( )
		{
			male = new int[5];
			female = new int[5];
		}
		public bool Empty ( )
		{
			if ( male.Length == 0 && female.Length == 0 )
				return true;
			else return false;
		}
		public bool Clear ( )
		{
			for ( int i = 0 ; i < 5 ; i++ )
			{
				male[i] = 0;
				female[i] = 0;
			}
			male.Initialize ( );
			female.Initialize ( );
			if ( male.Length == 0 && female.Length == 0 )
			{
				return true;
			}
			else return false;
		}
	}
}
