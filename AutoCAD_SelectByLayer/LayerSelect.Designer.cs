using System;
using System.Collections.Generic;

namespace AutoCAD_SelectByLayer
{
    partial class LayerSelect
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
            this.Add_button = new System.Windows.Forms.Button();
            this.Remove_button = new System.Windows.Forms.Button();
            this.Clear_button = new System.Windows.Forms.Button();
            this.Close_Button = new System.Windows.Forms.Button();
            this.layer_listBox = new System.Windows.Forms.ListBox();
            this.listBox_debug = new System.Windows.Forms.ListBox();
            this.nSelected = new System.Windows.Forms.Label();
            this.Copyright = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(481, 12);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(134, 54);
            this.Add_button.TabIndex = 4;
            this.Add_button.Text = "Add to selection";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // Remove_button
            // 
            this.Remove_button.Location = new System.Drawing.Point(481, 72);
            this.Remove_button.Name = "Remove_button";
            this.Remove_button.Size = new System.Drawing.Size(134, 54);
            this.Remove_button.TabIndex = 5;
            this.Remove_button.Text = "Remove from selection";
            this.Remove_button.UseVisualStyleBackColor = true;
            this.Remove_button.Click += new System.EventHandler(this.Remove_button_Click);
            // 
            // Clear_button
            // 
            this.Clear_button.Location = new System.Drawing.Point(481, 132);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(134, 54);
            this.Clear_button.TabIndex = 6;
            this.Clear_button.Text = "Clear selection";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.Location = new System.Drawing.Point(481, 326);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(134, 54);
            this.Close_Button.TabIndex = 7;
            this.Close_Button.Text = "Close";
            this.Close_Button.UseVisualStyleBackColor = true;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // layer_listBox
            // 
            this.layer_listBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.layer_listBox.FormattingEnabled = true;
            this.layer_listBox.Location = new System.Drawing.Point(12, 12);
            this.layer_listBox.Name = "layer_listBox";
            this.layer_listBox.Size = new System.Drawing.Size(463, 368);
            this.layer_listBox.Sorted = true;
            this.layer_listBox.TabIndex = 8;
            this.layer_listBox.DoubleClick += new System.EventHandler(this.Layer_listBox_DoubleClick);
            // 
            // listBox_debug
            // 
            this.listBox_debug.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBox_debug.FormattingEnabled = true;
            this.listBox_debug.Location = new System.Drawing.Point(12, 417);
            this.listBox_debug.Name = "listBox_debug";
            this.listBox_debug.Size = new System.Drawing.Size(600, 199);
            this.listBox_debug.TabIndex = 9;
            // 
            // nSelected
            // 
            this.nSelected.AutoSize = true;
            this.nSelected.Location = new System.Drawing.Point(12, 393);
            this.nSelected.Name = "nSelected";
            this.nSelected.Size = new System.Drawing.Size(35, 13);
            this.nSelected.TabIndex = 11;
            this.nSelected.Text = "label1";
            // 
            // Copyright
            // 
            this.Copyright.AutoSize = true;
            this.Copyright.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Copyright.Location = new System.Drawing.Point(381, 393);
            this.Copyright.Name = "Copyright";
            this.Copyright.Size = new System.Drawing.Size(231, 13);
            this.Copyright.TabIndex = 12;
            this.Copyright.Text = "SelectByLayer v0.1   Frans Nygaard, Oslo 2019";
            // 
            // LayerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(624, 629);
            this.Controls.Add(this.Copyright);
            this.Controls.Add(this.nSelected);
            this.Controls.Add(this.listBox_debug);
            this.Controls.Add(this.layer_listBox);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.Clear_button);
            this.Controls.Add(this.Remove_button);
            this.Controls.Add(this.Add_button);
            this.Name = "LayerSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectByLayer v0.1 for AutoCAD 2020";
            this.Load += new System.EventHandler(this.LayerSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.Button Remove_button;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.ListBox layer_listBox;
        private System.Windows.Forms.ListBox listBox_debug;
        private System.Windows.Forms.Label nSelected;
        private System.Windows.Forms.Label Copyright;
    }
}