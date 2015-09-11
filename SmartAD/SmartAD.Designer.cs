namespace SmartAD
{
	partial class SmartAD
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose ( bool disposing )
		{
			ReleaseData ( );
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent ( )
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartAD));
			this.grayscaleImageBox = new Emgu.CV.UI.ImageBox();
			this.ADImageBox = new Emgu.CV.UI.ImageBox();
			this.captureImageBox = new Emgu.CV.UI.ImageBox();
			this.VideoTextBox = new System.Windows.Forms.TextBox();
			this.PresentTextBox = new System.Windows.Forms.TextBox();
			this.startButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.grayscaleImageBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ADImageBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// grayscaleImageBox
			// 
			this.grayscaleImageBox.Location = new System.Drawing.Point(0, 0);
			this.grayscaleImageBox.Name = "grayscaleImageBox";
			this.grayscaleImageBox.Size = new System.Drawing.Size(0, 0);
			this.grayscaleImageBox.TabIndex = 2;
			this.grayscaleImageBox.TabStop = false;
			// 
			// ADImageBox
			// 
			this.ADImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
			this.ADImageBox.Location = new System.Drawing.Point(489, 13);
			this.ADImageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ADImageBox.Name = "ADImageBox";
			this.ADImageBox.Size = new System.Drawing.Size(139, 89);
			this.ADImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ADImageBox.TabIndex = 1;
			this.ADImageBox.TabStop = false;
			this.ADImageBox.WaitOnLoad = true;
			// 
			// captureImageBox
			// 
			this.captureImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.captureImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
			this.captureImageBox.InitialImage = null;
			this.captureImageBox.Location = new System.Drawing.Point(12, 104);
			this.captureImageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.captureImageBox.Name = "captureImageBox";
			this.captureImageBox.Size = new System.Drawing.Size(469, 361);
			this.captureImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.captureImageBox.TabIndex = 1;
			this.captureImageBox.TabStop = false;
			// 
			// VideoTextBox
			// 
			this.VideoTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.VideoTextBox.Location = new System.Drawing.Point(142, 42);
			this.VideoTextBox.Name = "VideoTextBox";
			this.VideoTextBox.Size = new System.Drawing.Size(100, 29);
			this.VideoTextBox.TabIndex = 2;
			this.VideoTextBox.Text = "Video";
			this.VideoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// PresentTextBox
			// 
			this.PresentTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.PresentTextBox.Location = new System.Drawing.Point(513, 109);
			this.PresentTextBox.Name = "PresentTextBox";
			this.PresentTextBox.Size = new System.Drawing.Size(100, 29);
			this.PresentTextBox.TabIndex = 3;
			this.PresentTextBox.Text = "Present";
			this.PresentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(513, 395);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(115, 33);
			startButton.TabIndex = 4;
			startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// SmartAD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Cornsilk;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(640, 478);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.PresentTextBox);
			this.Controls.Add(this.VideoTextBox);
			this.Controls.Add(this.captureImageBox);
			this.Controls.Add(this.ADImageBox);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.Name = "SmartAD";
			this.Text = "SmartAD";
			((System.ComponentModel.ISupportInitialize)(this.grayscaleImageBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ADImageBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Emgu.CV.UI.ImageBox grayscaleImageBox;
		private Emgu.CV.UI.ImageBox ADImageBox;
		private Emgu.CV.UI.ImageBox captureImageBox;
		private System.Windows.Forms.TextBox VideoTextBox;
		private System.Windows.Forms.TextBox PresentTextBox;
		private System.Windows.Forms.Button startButton;
	}
}

