namespace Co_Caro
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.flpBanCo = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn10 = new System.Windows.Forms.RadioButton();
            this.btn15 = new System.Windows.Forms.RadioButton();
            this.btn12 = new System.Windows.Forms.RadioButton();
            this.txtKhac = new System.Windows.Forms.TextBox();
            this.btnKhac = new System.Windows.Forms.RadioButton();
            this.pnKichThuoc = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnButton = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnLose = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.pnPlayer = new System.Windows.Forms.Panel();
            this.lbO = new System.Windows.Forms.Label();
            this.lbX = new System.Windows.Forms.Label();
            this.pnCheck = new System.Windows.Forms.Panel();
            this.chkO = new System.Windows.Forms.CheckBox();
            this.chkX = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnTySo = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbTiSo = new System.Windows.Forms.Label();
            this.chkBot = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkBotFirst = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnKichThuoc.SuspendLayout();
            this.pnButton.SuspendLayout();
            this.pnPlayer.SuspendLayout();
            this.pnCheck.SuspendLayout();
            this.pnTySo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flpBanCo
            // 
            this.flpBanCo.Location = new System.Drawing.Point(14, 118);
            this.flpBanCo.Name = "flpBanCo";
            this.flpBanCo.Size = new System.Drawing.Size(146, 117);
            this.flpBanCo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(26, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kích thước bàn cờ";
            // 
            // btn10
            // 
            this.btn10.AutoSize = true;
            this.btn10.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.Location = new System.Drawing.Point(30, 38);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(69, 21);
            this.btn10.TabIndex = 2;
            this.btn10.TabStop = true;
            this.btn10.Text = "10x10";
            this.btn10.UseVisualStyleBackColor = true;
            // 
            // btn15
            // 
            this.btn15.AutoSize = true;
            this.btn15.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn15.Location = new System.Drawing.Point(140, 38);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(69, 21);
            this.btn15.TabIndex = 3;
            this.btn15.TabStop = true;
            this.btn15.Text = "15x15";
            this.btn15.UseVisualStyleBackColor = true;
            // 
            // btn12
            // 
            this.btn12.AutoSize = true;
            this.btn12.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn12.Location = new System.Drawing.Point(30, 65);
            this.btn12.Name = "btn12";
            this.btn12.Size = new System.Drawing.Size(69, 21);
            this.btn12.TabIndex = 4;
            this.btn12.TabStop = true;
            this.btn12.Text = "12x12";
            this.btn12.UseVisualStyleBackColor = true;
            // 
            // txtKhac
            // 
            this.txtKhac.Location = new System.Drawing.Point(161, 64);
            this.txtKhac.Name = "txtKhac";
            this.txtKhac.Size = new System.Drawing.Size(61, 22);
            this.txtKhac.TabIndex = 5;
            this.txtKhac.Text = "Khác";
            this.txtKhac.TextChanged += new System.EventHandler(this.txtKhac_TextChanged);
            this.txtKhac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKhac_KeyDown);
            this.txtKhac.Leave += new System.EventHandler(this.txtKhac_Leave);
            // 
            // btnKhac
            // 
            this.btnKhac.AutoSize = true;
            this.btnKhac.Font = new System.Drawing.Font("Corbel", 8.25F);
            this.btnKhac.Location = new System.Drawing.Point(139, 68);
            this.btnKhac.Name = "btnKhac";
            this.btnKhac.Size = new System.Drawing.Size(17, 16);
            this.btnKhac.TabIndex = 6;
            this.btnKhac.TabStop = true;
            this.btnKhac.UseVisualStyleBackColor = true;
            this.btnKhac.CheckedChanged += new System.EventHandler(this.btnKhac_CheckedChanged);
            // 
            // pnKichThuoc
            // 
            this.pnKichThuoc.Controls.Add(this.btnStart);
            this.pnKichThuoc.Controls.Add(this.label1);
            this.pnKichThuoc.Controls.Add(this.btnKhac);
            this.pnKichThuoc.Controls.Add(this.btn10);
            this.pnKichThuoc.Controls.Add(this.txtKhac);
            this.pnKichThuoc.Controls.Add(this.btn15);
            this.pnKichThuoc.Controls.Add(this.btn12);
            this.pnKichThuoc.Location = new System.Drawing.Point(12, 12);
            this.pnKichThuoc.Name = "pnKichThuoc";
            this.pnKichThuoc.Size = new System.Drawing.Size(303, 100);
            this.pnKichThuoc.TabIndex = 7;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(237, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 59);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Bắt Đầu";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnButton
            // 
            this.pnButton.Controls.Add(this.label6);
            this.pnButton.Controls.Add(this.label5);
            this.pnButton.Controls.Add(this.label4);
            this.pnButton.Controls.Add(this.label3);
            this.pnButton.Controls.Add(this.btnReload);
            this.pnButton.Controls.Add(this.btnTiepTuc);
            this.pnButton.Controls.Add(this.btnContinue);
            this.pnButton.Controls.Add(this.btnLose);
            this.pnButton.Controls.Add(this.btnPause);
            this.pnButton.Location = new System.Drawing.Point(28, 12);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(322, 88);
            this.pnButton.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Pause/Start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Dừng chơi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Reset điểm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tiếp tục";
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(251, 21);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(41, 43);
            this.btnReload.TabIndex = 6;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnTiepTuc
            // 
            this.btnTiepTuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTiepTuc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTiepTuc.BackgroundImage")));
            this.btnTiepTuc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTiepTuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiepTuc.ForeColor = System.Drawing.Color.White;
            this.btnTiepTuc.Location = new System.Drawing.Point(178, 20);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(41, 43);
            this.btnTiepTuc.TabIndex = 5;
            this.btnTiepTuc.UseVisualStyleBackColor = false;
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnContinue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContinue.BackgroundImage")));
            this.btnContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(27, 22);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(41, 43);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnLose
            // 
            this.btnLose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLose.BackgroundImage")));
            this.btnLose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLose.ForeColor = System.Drawing.Color.White;
            this.btnLose.Location = new System.Drawing.Point(111, 20);
            this.btnLose.Name = "btnLose";
            this.btnLose.Size = new System.Drawing.Size(42, 42);
            this.btnLose.TabIndex = 2;
            this.btnLose.UseVisualStyleBackColor = false;
            this.btnLose.Click += new System.EventHandler(this.btnLose_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPause.BackgroundImage")));
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Location = new System.Drawing.Point(25, 24);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(42, 40);
            this.btnPause.TabIndex = 1;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // pnPlayer
            // 
            this.pnPlayer.Controls.Add(this.lbO);
            this.pnPlayer.Controls.Add(this.lbX);
            this.pnPlayer.Controls.Add(this.pnCheck);
            this.pnPlayer.Location = new System.Drawing.Point(643, 26);
            this.pnPlayer.Name = "pnPlayer";
            this.pnPlayer.Size = new System.Drawing.Size(138, 74);
            this.pnPlayer.TabIndex = 9;
            // 
            // lbO
            // 
            this.lbO.AutoSize = true;
            this.lbO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbO.ForeColor = System.Drawing.Color.Black;
            this.lbO.Location = new System.Drawing.Point(7, 41);
            this.lbO.Name = "lbO";
            this.lbO.Size = new System.Drawing.Size(109, 24);
            this.lbO.TabIndex = 1;
            this.lbO.Text = "PLAYER O";
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbX.ForeColor = System.Drawing.Color.Black;
            this.lbX.Location = new System.Drawing.Point(6, 8);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(108, 24);
            this.lbX.TabIndex = 0;
            this.lbX.Text = "PLAYER X";
            // 
            // pnCheck
            // 
            this.pnCheck.Controls.Add(this.chkO);
            this.pnCheck.Controls.Add(this.chkX);
            this.pnCheck.Location = new System.Drawing.Point(105, 4);
            this.pnCheck.Name = "pnCheck";
            this.pnCheck.Size = new System.Drawing.Size(39, 67);
            this.pnCheck.TabIndex = 10;
            // 
            // chkO
            // 
            this.chkO.AutoSize = true;
            this.chkO.Location = new System.Drawing.Point(12, 40);
            this.chkO.Name = "chkO";
            this.chkO.Size = new System.Drawing.Size(18, 17);
            this.chkO.TabIndex = 3;
            this.chkO.UseVisualStyleBackColor = true;
            this.chkO.CheckedChanged += new System.EventHandler(this.chkO_CheckedChanged);
            // 
            // chkX
            // 
            this.chkX.AutoSize = true;
            this.chkX.Location = new System.Drawing.Point(12, 8);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(18, 17);
            this.chkX.TabIndex = 2;
            this.chkX.UseVisualStyleBackColor = true;
            this.chkX.CheckedChanged += new System.EventHandler(this.chkX_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Fuchsia;
            this.label2.Location = new System.Drawing.Point(62, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "TỈ SỐ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pnTySo
            // 
            this.pnTySo.Controls.Add(this.label9);
            this.pnTySo.Controls.Add(this.pictureBox2);
            this.pnTySo.Controls.Add(this.label2);
            this.pnTySo.Controls.Add(this.pictureBox1);
            this.pnTySo.Controls.Add(this.lbTiSo);
            this.pnTySo.Location = new System.Drawing.Point(354, 14);
            this.pnTySo.Name = "pnTySo";
            this.pnTySo.Size = new System.Drawing.Size(283, 93);
            this.pnTySo.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(217, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 29);
            this.label9.TabIndex = 19;
            this.label9.Text = "15";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(139, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lbTiSo
            // 
            this.lbTiSo.AutoSize = true;
            this.lbTiSo.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTiSo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbTiSo.Location = new System.Drawing.Point(61, 29);
            this.lbTiSo.Name = "lbTiSo";
            this.lbTiSo.Size = new System.Drawing.Size(82, 46);
            this.lbTiSo.TabIndex = 13;
            this.lbTiSo.Text = "0:0";
            // 
            // chkBot
            // 
            this.chkBot.AutoSize = true;
            this.chkBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBot.ForeColor = System.Drawing.Color.Red;
            this.chkBot.Location = new System.Drawing.Point(421, 26);
            this.chkBot.Name = "chkBot";
            this.chkBot.Size = new System.Drawing.Size(105, 21);
            this.chkBot.TabIndex = 12;
            this.chkBot.Text = "AUTOBOT";
            this.chkBot.UseVisualStyleBackColor = true;
            this.chkBot.CheckedChanged += new System.EventHandler(this.chkBot_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Kha Đẹp Trai";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Bản Quyền thuộc dzìa";
            // 
            // chkBotFirst
            // 
            this.chkBotFirst.AutoSize = true;
            this.chkBotFirst.Location = new System.Drawing.Point(421, 56);
            this.chkBotFirst.Name = "chkBotFirst";
            this.chkBotFirst.Size = new System.Drawing.Size(82, 21);
            this.chkBotFirst.TabIndex = 4;
            this.chkBotFirst.Text = "Bot First";
            this.chkBotFirst.UseVisualStyleBackColor = true;
            this.chkBotFirst.CheckedChanged += new System.EventHandler(this.chkBotFirst_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(793, 728);
            this.Controls.Add(this.pnTySo);
            this.Controls.Add(this.pnPlayer);
            this.Controls.Add(this.pnButton);
            this.Controls.Add(this.flpBanCo);
            this.Controls.Add(this.pnKichThuoc);
            this.Controls.Add(this.chkBot);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkBotFirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnKichThuoc.ResumeLayout(false);
            this.pnKichThuoc.PerformLayout();
            this.pnButton.ResumeLayout(false);
            this.pnButton.PerformLayout();
            this.pnPlayer.ResumeLayout(false);
            this.pnPlayer.PerformLayout();
            this.pnCheck.ResumeLayout(false);
            this.pnCheck.PerformLayout();
            this.pnTySo.ResumeLayout(false);
            this.pnTySo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBanCo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton btn10;
        private System.Windows.Forms.RadioButton btn15;
        private System.Windows.Forms.RadioButton btn12;
        private System.Windows.Forms.TextBox txtKhac;
        private System.Windows.Forms.RadioButton btnKhac;
        private System.Windows.Forms.Panel pnKichThuoc;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnButton;
        private System.Windows.Forms.Button btnLose;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Panel pnPlayer;
        private System.Windows.Forms.Panel pnCheck;
        private System.Windows.Forms.CheckBox chkO;
        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.Label lbO;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnTySo;
        private System.Windows.Forms.Label lbTiSo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnTiepTuc;
        private System.Windows.Forms.CheckBox chkBot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkBotFirst;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer2;
    }
}

