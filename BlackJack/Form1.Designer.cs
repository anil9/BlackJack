namespace BlackJack
{
    partial class GameWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.buttonActionHit = new System.Windows.Forms.Button();
            this.buttonActionStand = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDealerValue = new System.Windows.Forms.Label();
            this.labelDealerCards = new System.Windows.Forms.Label();
            this.labelPlayerValue = new System.Windows.Forms.Label();
            this.labelPlayerCards = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPreviousActions = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelPlayerMoney = new System.Windows.Forms.Label();
            this.buttonNextRound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonActionHit
            // 
            resources.ApplyResources(this.buttonActionHit, "buttonActionHit");
            this.buttonActionHit.Name = "buttonActionHit";
            this.buttonActionHit.UseVisualStyleBackColor = true;
            this.buttonActionHit.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonActionStand
            // 
            resources.ApplyResources(this.buttonActionStand, "buttonActionStand");
            this.buttonActionStand.Name = "buttonActionStand";
            this.buttonActionStand.UseVisualStyleBackColor = true;
            this.buttonActionStand.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // labelDealerValue
            // 
            resources.ApplyResources(this.labelDealerValue, "labelDealerValue");
            this.labelDealerValue.Name = "labelDealerValue";
            // 
            // labelDealerCards
            // 
            resources.ApplyResources(this.labelDealerCards, "labelDealerCards");
            this.labelDealerCards.Name = "labelDealerCards";
            // 
            // labelPlayerValue
            // 
            resources.ApplyResources(this.labelPlayerValue, "labelPlayerValue");
            this.labelPlayerValue.Name = "labelPlayerValue";
            // 
            // labelPlayerCards
            // 
            resources.ApplyResources(this.labelPlayerCards, "labelPlayerCards");
            this.labelPlayerCards.Name = "labelPlayerCards";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textBoxPreviousActions
            // 
            resources.ApplyResources(this.textBoxPreviousActions, "textBoxPreviousActions");
            this.textBoxPreviousActions.Name = "textBoxPreviousActions";
            this.textBoxPreviousActions.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // labelPlayerMoney
            // 
            resources.ApplyResources(this.labelPlayerMoney, "labelPlayerMoney");
            this.labelPlayerMoney.Name = "labelPlayerMoney";
            // 
            // buttonNextRound
            // 
            resources.ApplyResources(this.buttonNextRound, "buttonNextRound");
            this.buttonNextRound.Name = "buttonNextRound";
            this.buttonNextRound.UseVisualStyleBackColor = true;
            this.buttonNextRound.Click += new System.EventHandler(this.buttonNextRound_Click);
            // 
            // GameWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNextRound);
            this.Controls.Add(this.labelPlayerMoney);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPreviousActions);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelPlayerCards);
            this.Controls.Add(this.labelPlayerValue);
            this.Controls.Add(this.labelDealerCards);
            this.Controls.Add(this.labelDealerValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonActionStand);
            this.Controls.Add(this.buttonActionHit);
            this.Name = "GameWindow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonActionHit;
        private System.Windows.Forms.Button buttonActionStand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelDealerValue;
        private System.Windows.Forms.Label labelDealerCards;
        private System.Windows.Forms.Label labelPlayerValue;
        private System.Windows.Forms.Label labelPlayerCards;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPreviousActions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelPlayerMoney;
        private System.Windows.Forms.Button buttonNextRound;
    }
}

