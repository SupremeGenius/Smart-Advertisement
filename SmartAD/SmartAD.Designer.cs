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
			this.captureImageBox = new Emgu.CV.UI.ImageBox();
			this.grayscaleImageBox = new Emgu.CV.UI.ImageBox();
			this.ADImageBox = new Emgu.CV.UI.ImageBox();
			this.startButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grayscaleImageBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ADImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// captureImageBox
			// 
			this.captureImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.captureImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
			this.captureImageBox.InitialImage = null;
			this.captureImageBox.Location = new System.Drawing.Point(457, 346);
			this.captureImageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.captureImageBox.Name = "captureImageBox";
			this.captureImageBox.Size = new System.Drawing.Size(183, 134);
			this.captureImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.captureImageBox.TabIndex = 1;
			this.captureImageBox.TabStop = false;
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
			this.ADImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ADImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
			this.ADImageBox.Location = new System.Drawing.Point(0, 0);
			this.ADImageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ADImageBox.Name = "ADImageBox";
			this.ADImageBox.Size = new System.Drawing.Size(640, 480);
			this.ADImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ADImageBox.TabIndex = 1;
			this.ADImageBox.TabStop = false;
			this.ADImageBox.WaitOnLoad = true;
			// 
			// startButton
			// 
			this.startButton.AutoSize = true;
			this.startButton.BackColor = System.Drawing.Color.Cornsilk;
			this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.startButton.ForeColor = System.Drawing.Color.White;
			this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
			this.startButton.Location = new System.Drawing.Point(0, -10);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(651, 502);
			this.startButton.TabIndex = 2;
			this.startButton.UseMnemonic = false;
			this.startButton.UseVisualStyleBackColor = false;
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
			((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grayscaleImageBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ADImageBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Emgu.CV.UI.ImageBox captureImageBox;
		private Emgu.CV.UI.ImageBox grayscaleImageBox;
		private Emgu.CV.UI.ImageBox ADImageBox;
		private System.Windows.Forms.Button startButton;
	}
}

