namespace QuanLyThuVien
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.In = new System.Windows.Forms.Button();
            this.Out = new System.Windows.Forms.Button();
            this.dnhap = new System.Windows.Forms.TextBox();
            this.mkhau = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu:";
            // 
            // In
            // 
            this.In.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.In.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.In.Location = new System.Drawing.Point(96, 210);
            this.In.Name = "In";
            this.In.Size = new System.Drawing.Size(92, 39);
            this.In.TabIndex = 2;
            this.In.Text = "Đăng nhập";
            this.In.UseVisualStyleBackColor = false;
            this.In.Click += new System.EventHandler(this.In_Click);
            // 
            // Out
            // 
            this.Out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Out.Location = new System.Drawing.Point(292, 210);
            this.Out.Name = "Out";
            this.Out.Size = new System.Drawing.Size(92, 39);
            this.Out.TabIndex = 3;
            this.Out.Text = "Thoát";
            this.Out.UseVisualStyleBackColor = false;
            this.Out.Click += new System.EventHandler(this.Out_Click);
            // 
            // dnhap
            // 
            this.dnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dnhap.Location = new System.Drawing.Point(177, 70);
            this.dnhap.Multiline = true;
            this.dnhap.Name = "dnhap";
            this.dnhap.Size = new System.Drawing.Size(207, 29);
            this.dnhap.TabIndex = 4;
            // 
            // mkhau
            // 
            this.mkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mkhau.Location = new System.Drawing.Point(177, 133);
            this.mkhau.Multiline = true;
            this.mkhau.Name = "mkhau";
            this.mkhau.PasswordChar = '*';
            this.mkhau.Size = new System.Drawing.Size(207, 29);
            this.mkhau.TabIndex = 5;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 261);
            this.Controls.Add(this.mkhau);
            this.Controls.Add(this.dnhap);
            this.Controls.Add(this.Out);
            this.Controls.Add(this.In);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(543, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(543, 300);
            this.Name = "Form3";
            this.Text = "LOGIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button In;
        private System.Windows.Forms.Button Out;
        private System.Windows.Forms.TextBox dnhap;
        private System.Windows.Forms.TextBox mkhau;
    }
}