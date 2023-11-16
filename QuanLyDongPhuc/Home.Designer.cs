
namespace QuanLyDongPhuc
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pan_menu = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnCapPhat = new System.Windows.Forms.Button();
            this.btnDongPhuc = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnPhongBan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pan_top = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pan_body = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pan_menu.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pan_top.SuspendLayout();
            this.pan_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDangXuat.Font = new System.Drawing.Font("SVN-Nexa Rush Slab Black Shadow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 100);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(108, 45);
            this.btnDangXuat.TabIndex = 12;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // pan_menu
            // 
            this.pan_menu.BackColor = System.Drawing.Color.CadetBlue;
            this.pan_menu.Controls.Add(this.btnTimKiem);
            this.pan_menu.Controls.Add(this.btnCapPhat);
            this.pan_menu.Controls.Add(this.btnDongPhuc);
            this.pan_menu.Controls.Add(this.btnNhanVien);
            this.pan_menu.Controls.Add(this.btnPhongBan);
            this.pan_menu.Controls.Add(this.btnDangXuat);
            this.pan_menu.Controls.Add(this.panel3);
            this.pan_menu.Controls.Add(this.pictureBox1);
            this.pan_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_menu.Location = new System.Drawing.Point(0, 0);
            this.pan_menu.Name = "pan_menu";
            this.pan_menu.Size = new System.Drawing.Size(108, 450);
            this.pan_menu.TabIndex = 15;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Green;
            this.btnTimKiem.Font = new System.Drawing.Font("SVN-Rocker", 10F);
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTimKiem.Location = new System.Drawing.Point(0, 329);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 47);
            this.btnTimKiem.TabIndex = 16;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnCapPhat
            // 
            this.btnCapPhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCapPhat.Font = new System.Drawing.Font("SVN-Rocker", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapPhat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCapPhat.Location = new System.Drawing.Point(0, 281);
            this.btnCapPhat.Name = "btnCapPhat";
            this.btnCapPhat.Size = new System.Drawing.Size(108, 47);
            this.btnCapPhat.TabIndex = 0;
            this.btnCapPhat.Text = "CẤP PHÁT";
            this.btnCapPhat.UseVisualStyleBackColor = false;
            this.btnCapPhat.Click += new System.EventHandler(this.btnCapPhat_Click);
            // 
            // btnDongPhuc
            // 
            this.btnDongPhuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDongPhuc.Font = new System.Drawing.Font("SVN-Rocker", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongPhuc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDongPhuc.Location = new System.Drawing.Point(0, 235);
            this.btnDongPhuc.Name = "btnDongPhuc";
            this.btnDongPhuc.Size = new System.Drawing.Size(108, 47);
            this.btnDongPhuc.TabIndex = 0;
            this.btnDongPhuc.Text = "ĐỒNG PHỤC";
            this.btnDongPhuc.UseVisualStyleBackColor = false;
            this.btnDongPhuc.Click += new System.EventHandler(this.btnDongPhuc_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNhanVien.Font = new System.Drawing.Font("SVN-Rocker", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 144);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(108, 47);
            this.btnNhanVien.TabIndex = 0;
            this.btnNhanVien.Text = "NHÂN VIÊN";
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnPhongBan
            // 
            this.btnPhongBan.BackColor = System.Drawing.Color.Olive;
            this.btnPhongBan.Font = new System.Drawing.Font("SVN-Rocker", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhongBan.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPhongBan.Location = new System.Drawing.Point(0, 189);
            this.btnPhongBan.Name = "btnPhongBan";
            this.btnPhongBan.Size = new System.Drawing.Size(108, 47);
            this.btnPhongBan.TabIndex = 0;
            this.btnPhongBan.Text = "PHÒNG BAN";
            this.btnPhongBan.UseVisualStyleBackColor = false;
            this.btnPhongBan.Click += new System.EventHandler(this.btnPhongBan_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(108, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(692, 75);
            this.panel3.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(614, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "Đăng xuất";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(577, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pan_top
            // 
            this.pan_top.BackColor = System.Drawing.Color.CadetBlue;
            this.pan_top.Controls.Add(this.label1);
            this.pan_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_top.Location = new System.Drawing.Point(108, 0);
            this.pan_top.Name = "pan_top";
            this.pan_top.Size = new System.Drawing.Size(692, 46);
            this.pan_top.TabIndex = 15;
            this.pan_top.Paint += new System.Windows.Forms.PaintEventHandler(this.pan_top_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(480, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOME";
            // 
            // pan_body
            // 
            this.pan_body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_body.BackColor = System.Drawing.Color.PowderBlue;
            this.pan_body.Controls.Add(this.pictureBox3);
            this.pan_body.Location = new System.Drawing.Point(108, 42);
            this.pan_body.Name = "pan_body";
            this.pan_body.Size = new System.Drawing.Size(692, 408);
            this.pan_body.TabIndex = 16;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(692, 408);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pan_body);
            this.Controls.Add(this.pan_top);
            this.Controls.Add(this.pan_menu);
            this.Name = "Home";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Home_FormClosed);
            this.Load += new System.EventHandler(this.Home_Load);
            this.pan_menu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pan_top.ResumeLayout(false);
            this.pan_top.PerformLayout();
            this.pan_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pan_menu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pan_top;
        private System.Windows.Forms.Button btnCapPhat;
        private System.Windows.Forms.Button btnDongPhuc;
        private System.Windows.Forms.Button btnPhongBan;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel pan_body;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}