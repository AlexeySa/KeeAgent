namespace KeeAgent.UI
{
    partial class OptionsPanel
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsPanel));
            this.customListViewEx = new KeePass.UI.CustomListViewEx();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.modeLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.additionalAgentUsersLabel = new System.Windows.Forms.Label();
            this.additionalAgentUsersTextBox = new System.Windows.Forms.TextBox();
            this.additionalAgentUsersHelpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.socketPanel = new System.Windows.Forms.Panel();
            this.msysPathBrowseButton = new System.Windows.Forms.Button();
            this.wslSocketPathBrowseButton = new System.Windows.Forms.Button();
            this.cygwinPathBrowseButton = new System.Windows.Forms.Button();
            this.msysSocketPathTextBox = new System.Windows.Forms.TextBox();
            this.msysSocketPathLabel = new System.Windows.Forms.Label();
            this.wslSocketPathTextBox = new System.Windows.Forms.TextBox();
            this.cygwinSocketPathTextBox = new System.Windows.Forms.TextBox();
            this.wslSocketPathLabel = new System.Windows.Forms.Label();
            this.useMsysSocketCheckBox = new System.Windows.Forms.CheckBox();
            this.useWslSocketCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.useCygwinSocketCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.socketPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customListViewEx
            // 
            resources.ApplyResources(this.customListViewEx, "customListViewEx");
            this.customListViewEx.CheckBoxes = true;
            this.customListViewEx.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.customListViewEx.FullRowSelect = true;
            this.customListViewEx.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.customListViewEx.HideSelection = false;
            this.customListViewEx.Name = "customListViewEx";
            this.customListViewEx.ShowItemToolTips = true;
            this.customListViewEx.UseCompatibleStateImageBehavior = false;
            this.customListViewEx.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader
            // 
            resources.ApplyResources(this.columnHeader, "columnHeader");
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.modeComboBox, "modeComboBox");
            this.modeComboBox.Name = "modeComboBox";
            // 
            // modeLabel
            // 
            resources.ApplyResources(this.modeLabel, "modeLabel");
            this.modeLabel.Name = "modeLabel";
            // 
            // helpButton
            // 
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Image = global::KeeAgent.Properties.Resources.Help_png;
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // additionalAgentUsersLabel
            // 
            resources.ApplyResources(this.additionalAgentUsersLabel, "additionalAgentUsersLabel");
            this.additionalAgentUsersLabel.Name = "additionalAgentUsersLabel";
            // 
            // additionalAgentUsersTextBox
            // 
            resources.ApplyResources(this.additionalAgentUsersTextBox, "additionalAgentUsersTextBox");
            this.additionalAgentUsersTextBox.Name = "additionalAgentUsersTextBox";
            //
            // additionalAgentUsersHelpLinkLabel
            //
            resources.ApplyResources(this.additionalAgentUsersHelpLinkLabel, "additionalAgentUsersHelpLinkLabel");
            this.additionalAgentUsersHelpLinkLabel.AccessibleName = "Show agent access help";
            this.additionalAgentUsersHelpLinkLabel.Font = new System.Drawing.Font(this.additionalAgentUsersHelpLinkLabel.Font, System.Drawing.FontStyle.Bold);
            this.additionalAgentUsersHelpLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.additionalAgentUsersHelpLinkLabel.Name = "additionalAgentUsersHelpLinkLabel";
            this.additionalAgentUsersHelpLinkLabel.TabStop = true;
            this.additionalAgentUsersHelpLinkLabel.Text = "?";
            this.additionalAgentUsersHelpLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.additionalAgentUsersHelpLinkLabel_LinkClicked);
            //
            // socketPanel
            // 
            resources.ApplyResources(this.socketPanel, "socketPanel");
            this.socketPanel.BackColor = System.Drawing.Color.Transparent;
            this.socketPanel.Controls.Add(this.msysPathBrowseButton);
            this.socketPanel.Controls.Add(this.wslSocketPathBrowseButton);
            this.socketPanel.Controls.Add(this.cygwinPathBrowseButton);
            this.socketPanel.Controls.Add(this.msysSocketPathTextBox);
            this.socketPanel.Controls.Add(this.msysSocketPathLabel);
            this.socketPanel.Controls.Add(this.wslSocketPathTextBox);
            this.socketPanel.Controls.Add(this.cygwinSocketPathTextBox);
            this.socketPanel.Controls.Add(this.wslSocketPathLabel);
            this.socketPanel.Controls.Add(this.useMsysSocketCheckBox);
            this.socketPanel.Controls.Add(this.useWslSocketCheckBox);
            this.socketPanel.Controls.Add(this.label3);
            this.socketPanel.Controls.Add(this.useCygwinSocketCheckBox);
            this.socketPanel.Controls.Add(this.label1);
            this.socketPanel.Name = "socketPanel";
            // 
            // msysPathBrowseButton
            // 
            resources.ApplyResources(this.msysPathBrowseButton, "msysPathBrowseButton");
            this.msysPathBrowseButton.Name = "msysPathBrowseButton";
            this.msysPathBrowseButton.UseVisualStyleBackColor = true;
            this.msysPathBrowseButton.Click += new System.EventHandler(this.msysPathBrowseButton_Click);
            // 
            // wslSocketPathBrowseButton
            // 
            resources.ApplyResources(this.wslSocketPathBrowseButton, "wslSocketPathBrowseButton");
            this.wslSocketPathBrowseButton.Name = "wslSocketPathBrowseButton";
            this.wslSocketPathBrowseButton.UseVisualStyleBackColor = true;
            this.wslSocketPathBrowseButton.Click += new System.EventHandler(this.wslSocketPathBrowseButton_Click);
            // 
            // cygwinPathBrowseButton
            // 
            resources.ApplyResources(this.cygwinPathBrowseButton, "cygwinPathBrowseButton");
            this.cygwinPathBrowseButton.Name = "cygwinPathBrowseButton";
            this.cygwinPathBrowseButton.UseVisualStyleBackColor = true;
            this.cygwinPathBrowseButton.Click += new System.EventHandler(this.cygwinPathBrowseButton_Click);
            // 
            // msysSocketPathTextBox
            // 
            resources.ApplyResources(this.msysSocketPathTextBox, "msysSocketPathTextBox");
            this.msysSocketPathTextBox.Name = "msysSocketPathTextBox";
            // 
            // msysSocketPathLabel
            // 
            resources.ApplyResources(this.msysSocketPathLabel, "msysSocketPathLabel");
            this.msysSocketPathLabel.Name = "msysSocketPathLabel";
            // 
            // wslSocketPathTextBox
            // 
            resources.ApplyResources(this.wslSocketPathTextBox, "wslSocketPathTextBox");
            this.wslSocketPathTextBox.Name = "wslSocketPathTextBox";
            // 
            // cygwinSocketPathTextBox
            // 
            resources.ApplyResources(this.cygwinSocketPathTextBox, "cygwinSocketPathTextBox");
            this.cygwinSocketPathTextBox.Name = "cygwinSocketPathTextBox";
            // 
            // wslSocketPathLabel
            // 
            resources.ApplyResources(this.wslSocketPathLabel, "wslSocketPathLabel");
            this.wslSocketPathLabel.Name = "wslSocketPathLabel";
            // 
            // useMsysSocketCheckBox
            // 
            resources.ApplyResources(this.useMsysSocketCheckBox, "useMsysSocketCheckBox");
            this.useMsysSocketCheckBox.Name = "useMsysSocketCheckBox";
            this.useMsysSocketCheckBox.UseVisualStyleBackColor = true;
            this.useMsysSocketCheckBox.CheckedChanged += new System.EventHandler(this.useMsysSocketCheckBox_CheckedChanged);
            // 
            // useWslSocketCheckBox
            // 
            resources.ApplyResources(this.useWslSocketCheckBox, "useWslSocketCheckBox");
            this.useWslSocketCheckBox.Name = "useWslSocketCheckBox";
            this.useWslSocketCheckBox.UseVisualStyleBackColor = true;
            this.useWslSocketCheckBox.CheckedChanged += new System.EventHandler(this.useWslSocketCheckBox_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // useCygwinSocketCheckBox
            // 
            resources.ApplyResources(this.useCygwinSocketCheckBox, "useCygwinSocketCheckBox");
            this.useCygwinSocketCheckBox.Name = "useCygwinSocketCheckBox";
            this.useCygwinSocketCheckBox.UseVisualStyleBackColor = true;
            this.useCygwinSocketCheckBox.CheckedChanged += new System.EventHandler(this.useCygwinSocketCheckBox_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // OptionsPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.socketPanel);
            this.Controls.Add(this.additionalAgentUsersHelpLinkLabel);
            this.Controls.Add(this.additionalAgentUsersTextBox);
            this.Controls.Add(this.additionalAgentUsersLabel);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.modeComboBox);
            this.Controls.Add(this.customListViewEx);
            this.Name = "OptionsPanel";
            this.socketPanel.ResumeLayout(false);
            this.socketPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KeePass.UI.CustomListViewEx customListViewEx;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label additionalAgentUsersLabel;
        private System.Windows.Forms.TextBox additionalAgentUsersTextBox;
        private System.Windows.Forms.LinkLabel additionalAgentUsersHelpLinkLabel;
        private System.Windows.Forms.Panel socketPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox msysSocketPathTextBox;
        private System.Windows.Forms.Label msysSocketPathLabel;
        private System.Windows.Forms.TextBox cygwinSocketPathTextBox;
        private System.Windows.Forms.CheckBox useMsysSocketCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox useCygwinSocketCheckBox;
        private System.Windows.Forms.Button msysPathBrowseButton;
        private System.Windows.Forms.Button cygwinPathBrowseButton;
        private System.Windows.Forms.Button wslSocketPathBrowseButton;
        private System.Windows.Forms.TextBox wslSocketPathTextBox;
        private System.Windows.Forms.Label wslSocketPathLabel;
        private System.Windows.Forms.CheckBox useWslSocketCheckBox;
    }
}
