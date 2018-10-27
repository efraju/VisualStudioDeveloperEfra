namespace Forms
{
    partial class PlaylistForm
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
            this.cbPlaylists = new System.Windows.Forms.ComboBox();
            this.dgvTracks = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracks)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPlaylists
            // 
            this.cbPlaylists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlaylists.FormattingEnabled = true;
            this.cbPlaylists.Location = new System.Drawing.Point(171, 58);
            this.cbPlaylists.Name = "cbPlaylists";
            this.cbPlaylists.Size = new System.Drawing.Size(121, 24);
            this.cbPlaylists.TabIndex = 0;
            this.cbPlaylists.SelectedIndexChanged += new System.EventHandler(this.cbPlaylists_SelectedIndexChanged);
            // 
            // dgvTracks
            // 
            this.dgvTracks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTracks.Location = new System.Drawing.Point(12, 107);
            this.dgvTracks.Name = "dgvTracks";
            this.dgvTracks.RowTemplate.Height = 24;
            this.dgvTracks.Size = new System.Drawing.Size(776, 331);
            this.dgvTracks.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select a Playlist:";
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTracks);
            this.Controls.Add(this.cbPlaylists);
            this.Name = "PlaylistForm";
            this.Text = "PlaylistForm";
            this.Load += new System.EventHandler(this.PlaylistForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPlaylists;
        private System.Windows.Forms.DataGridView dgvTracks;
        private System.Windows.Forms.Label label1;
    }
}