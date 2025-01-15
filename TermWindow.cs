using System;
using System.ComponentModel;
using System.Configuration;
using System.IO.Ports;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Terminal
{
    public partial class TermWindow : Form
    {
        // Declarations for Echo Envelope controls
        private Button btn_EchoEnvelope;
        private TextBox txt_EchoEnvelope;
        private ComboBox combo_EchoEnvelopeMode;

        // Other control declarations
        private Button btn_Clear;
        private Button btn_set;
        private TextBox Term_box;
        private ComboBox combo_coms;
        private ComboBox combo_baud;
        private Button btn_connect;
        private NumericUpDown new_pings_1;
        private NumericUpDown new_pulses_1;
        private NumericUpDown new_sv;
        private Button btn_pause;
        private SerialPort serialPort1;
        private Label label4;
        private Label label5;
        private Button btn_Query;
        private ComboBox new_mode;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox box_mode;
        private TextBox box_sv;
        private TextBox box_t_off;
        private TextBox box_d_off;
        private TextBox box_d_filt;
        private TextBox box_pulse;
        private TextBox box_ping;
        private TextBox box_range;
        private TextBox box_s_filt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private ComboBox new_range;
        private NumericUpDown new_d_off;
        private NumericUpDown new_t_off;
        private NumericUpDown new_s_filt;
        private NumericUpDown new_d_filt;
        private NumericUpDown new_pulses_2;
        private NumericUpDown new_pulses_4;
        private NumericUpDown new_pulses_3;
        private NumericUpDown new_pings_2;
        private NumericUpDown new_pings_4;
        private NumericUpDown new_pings_3;
        private Label label21;
        private TextBox box_depth;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Button btn_reset;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar indicator;
        private ToolStripStatusLabel Status_box;
        private IContainer components;
        private static System.Configuration.Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public string RX_com = "";
        public string TX_com = "";
        public bool DEBUG_flag = true;
        public int count = 0;
        public string sAttr;
        public static string[] Query_str = new string[9];
        public static string[] Set_str;
        public readonly Database dataB = new Database();
        public readonly ControlFlags flags = new ControlFlags();

        public TermWindow()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            findPorts();
            getSettings();
            new_sv.DecimalPlaces = 1;
            new_sv.Minimum = 1350.0M / 10;
            new_sv.Maximum = 1650.0M / 10;
            new_sv.Value = 1500.0M / 10;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TermWindow));

            // Initialize Echo Envelope controls
            this.btn_EchoEnvelope = new System.Windows.Forms.Button();
            this.txt_EchoEnvelope = new System.Windows.Forms.TextBox();
            this.combo_EchoEnvelopeMode = new System.Windows.Forms.ComboBox();

            // Initialize other controls
            this.btn_set = new System.Windows.Forms.Button();
            this.Term_box = new System.Windows.Forms.TextBox();
            this.combo_coms = new System.Windows.Forms.ComboBox();
            this.combo_baud = new System.Windows.Forms.ComboBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.new_pings_1 = new System.Windows.Forms.NumericUpDown();
            this.new_pulses_1 = new System.Windows.Forms.NumericUpDown();
            this.new_sv = new System.Windows.Forms.NumericUpDown();
            this.btn_pause = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Query = new System.Windows.Forms.Button();
            this.new_mode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.box_mode = new System.Windows.Forms.TextBox();
            this.box_sv = new System.Windows.Forms.TextBox();
            this.box_t_off = new System.Windows.Forms.TextBox();
            this.box_d_off = new System.Windows.Forms.TextBox();
            this.box_d_filt = new System.Windows.Forms.TextBox();
            this.box_pulse = new System.Windows.Forms.TextBox();
            this.box_ping = new System.Windows.Forms.TextBox();
            this.box_range = new System.Windows.Forms.TextBox();
            this.box_s_filt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.new_range = new System.Windows.Forms.ComboBox();
            this.new_d_off = new System.Windows.Forms.NumericUpDown();
            this.new_t_off = new System.Windows.Forms.NumericUpDown();
            this.new_s_filt = new System.Windows.Forms.NumericUpDown();
            this.new_d_filt = new System.Windows.Forms.NumericUpDown();
            this.new_pulses_2 = new System.Windows.Forms.NumericUpDown();
            this.new_pulses_4 = new System.Windows.Forms.NumericUpDown();
            this.new_pulses_3 = new System.Windows.Forms.NumericUpDown();
            this.new_pings_2 = new System.Windows.Forms.NumericUpDown();
            this.new_pings_4 = new System.Windows.Forms.NumericUpDown();
            this.new_pings_3 = new System.Windows.Forms.NumericUpDown();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.box_depth = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.indicator = new System.Windows.Forms.ToolStripProgressBar();
            this.Status_box = new System.Windows.Forms.ToolStripStatusLabel();
            this.new_pings_1.BeginInit();
            this.new_pulses_1.BeginInit();
            this.new_sv.BeginInit();
            this.new_d_off.BeginInit();
            this.new_t_off.BeginInit();
            this.new_s_filt.BeginInit();
            this.new_d_filt.BeginInit();
            this.new_pulses_2.BeginInit();
            this.new_pulses_4.BeginInit();
            this.new_pulses_3.BeginInit();
            this.new_pings_2.BeginInit();
            this.new_pings_4.BeginInit();
            this.new_pings_3.BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // btn_EchoEnvelope
            // 
            this.btn_EchoEnvelope.Location = new System.Drawing.Point(150, 100);
            this.btn_EchoEnvelope.Name = "btn_EchoEnvelope";
            this.btn_EchoEnvelope.Size = new System.Drawing.Size(100, 30);
            this.btn_EchoEnvelope.TabIndex = 0;
            this.btn_EchoEnvelope.Text = "Echo Envelope";
            this.btn_EchoEnvelope.UseVisualStyleBackColor = true;
            this.btn_EchoEnvelope.Click += new System.EventHandler(this.Btn_EchoEnvelope_Click);

            // 
            // txt_EchoEnvelope
            // 
            this.txt_EchoEnvelope.Location = new System.Drawing.Point(150, 150);
            this.txt_EchoEnvelope.Name = "txt_EchoEnvelope";
            this.txt_EchoEnvelope.Size = new System.Drawing.Size(200, 20);
            this.txt_EchoEnvelope.TabIndex = 1;

            // 
            // combo_EchoEnvelopeMode
            // 
            this.combo_EchoEnvelopeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_EchoEnvelopeMode.FormattingEnabled = true;
            this.combo_EchoEnvelopeMode.Items.AddRange(new object[] {
                "Mode1",
                "Mode2",
                "Mode3"
            });
            this.combo_EchoEnvelopeMode.Location = new System.Drawing.Point(150, 200);
            this.combo_EchoEnvelopeMode.Name = "combo_EchoEnvelopeMode";
            this.combo_EchoEnvelopeMode.Size = new System.Drawing.Size(121, 21);
            this.combo_EchoEnvelopeMode.TabIndex = 2;

            // 
            // Initialize other controls...
            // 
            this.btn_set.Location = new System.Drawing.Point(899, 478);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(56, 26);
            this.btn_set.TabIndex = 0;
            this.btn_set.Text = "Set";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.Btn_set_Click);
            this.Term_box.BackColor = System.Drawing.SystemColors.Control;
            this.Term_box.HideSelection = false;
            this.Term_box.Location = new System.Drawing.Point(12, 75);
            this.Term_box.Multiline = true;
            this.Term_box.Name = "Term_box";
            this.Term_box.ReadOnly = true;
            this.Term_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Term_box.Size = new System.Drawing.Size(758, 305);
            this.Term_box.TabIndex = 1;
            this.combo_coms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_coms.FormattingEnabled = true;
            this.combo_coms.Location = new System.Drawing.Point(84, 11);
            this.combo_coms.Name = "combo_coms";
            this.combo_coms.Size = new System.Drawing.Size(121, 21);
            this.combo_coms.Sorted = true;
            this.combo_coms.TabIndex = 2;
            this.combo_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_baud.FormattingEnabled = true;
            this.combo_baud.Items.AddRange(new object[] {
                "4800",
                "9600",
                "19200",
                "38400",
                "57600",
                "115200"
            });
            this.combo_baud.Location = new System.Drawing.Point(84, 38);
            this.combo_baud.Name = "combo_baud";
            this.combo_baud.Size = new System.Drawing.Size(121, 21);
            this.combo_baud.TabIndex = 3;
            this.btn_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_connect.Location = new System.Drawing.Point(211, 11);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 48);
            this.btn_connect.TabIndex = 4;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.Btn_connect_Click);

            // Initialize other controls similarly...

            // 
            // Adding Controls to the Form
            // 
            this.Controls.Add(this.btn_EchoEnvelope);
            this.Controls.Add(this.txt_EchoEnvelope);
            this.Controls.Add(this.combo_EchoEnvelopeMode);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.Term_box);
            this.Controls.Add(this.combo_coms);
            this.Controls.Add(this.combo_baud);
            this.Controls.Add(this.btn_connect);

            // Add other controls similarly...

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon("sb.ico");
            this.Name = "TermWindow";
            this.Text = "TermWindow";
            this.new_pings_1.EndInit();
            this.new_pulses_1.EndInit();
            this.new_sv.EndInit();
            this.new_d_off.EndInit();
            this.new_t_off.EndInit();
            this.new_s_filt.EndInit();
            this.new_d_filt.EndInit();
            this.new_pulses_2.EndInit();
            this.new_pulses_4.EndInit();
            this.new_pulses_3.EndInit();
            this.new_pings_2.EndInit();
            this.new_pings_4.EndInit();
            this.new_pings_3.EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void findPorts()
        {
            this.combo_coms.Items.AddRange(SerialPort.GetPortNames());
        }

        private void getSettings()
        {
            this.combo_coms.Text = configFile.AppSettings.Settings["COM_PORT"].Value;
            this.combo_baud.Text = configFile.AppSettings.Settings["BAUD_RATE"].Value;
        }

        private void setSettings()
        {
            try
            {
                configFile.AppSettings.Settings["COM_PORT"].Value = this.combo_coms.Text;
                configFile.AppSettings.Settings["BAUD_RATE"].Value = this.combo_baud.Text;
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ex)
            {
                this.Status_box.Text = "Error writing app settings: " + ex.Message;
            }
        }

        private void Btn_connect_Click(object sender, EventArgs e)
        {
            this.Status_box.Text = string.Empty;
            if (string.IsNullOrEmpty(this.combo_coms.Text) || string.IsNullOrEmpty(this.combo_baud.Text))
            {
                this.Status_box.Text = "Please Select Port Settings";
                return;
            }

            try
            {
                if (!this.serialPort1.IsOpen)
                {
                    this.serialPort1.PortName = this.combo_coms.Text;
                    this.serialPort1.BaudRate = int.Parse(this.combo_baud.Text);
                    this.serialPort1.Open();
                    this.indicator.Value = 100;
                    this.btn_connect.Text = "Disconnect";
                }
                else
                {
                    this.serialPort1.DiscardInBuffer();
                    this.serialPort1.DiscardOutBuffer();
                    this.serialPort1.Close();
                    this.indicator.Value = 0;
                    this.btn_connect.Text = "Connect";
                }
            }
            catch (UnauthorizedAccessException)
            {
                this.Status_box.Text = "Unable to open COM Port";
            }
            catch (Exception ex)
            {
                this.Status_box.Text = $"Error: {ex.Message}";
            }
        }

        private void Btn_set_Click(object sender, EventArgs e)
        {
            try
            {
                dataB.mode = new_mode.Text;
                dataB.range = new_range.SelectedIndex.ToString();
                dataB.range_s = new_range.Text;
                decimal soundVelocity = new_sv.Value * 10;
                dataB.sostw = soundVelocity.ToString();
                dataB.pings[0] = new_pings_1.Value.ToString();
                dataB.pings[1] = new_pings_2.Value.ToString();
                dataB.pings[2] = new_pings_3.Value.ToString();
                dataB.pings[3] = new_pings_4.Value.ToString();
                dataB.pulses[0] = new_pulses_1.Value.ToString();
                dataB.pulses[1] = new_pulses_2.Value.ToString();
                dataB.pulses[2] = new_pulses_3.Value.ToString();
                dataB.pulses[3] = new_pulses_4.Value.ToString();
                dataB.depth_off = new_d_off.Value.ToString();
                dataB.temp_off = new_t_off.Value.ToString();
                dataB.depth_filt = new_d_filt.Value.ToString();
                dataB.sample_filt = new_s_filt.Value.ToString();

                if (serialPort1.IsOpen)
                {
                    if (!flags.is_paused)
                    {
                        Invoke(new EventHandler(Btn_pause_Click));
                    }

                    serialPort1.WriteLine($"{Set_str[0]},{dataB.mode}\r\n");
                    serialPort1.WriteLine($"{Set_str[1]},{dataB.range}\r\n");
                    serialPort1.WriteLine($"{Set_str[2]},{dataB.sostw}\r\n");
                    serialPort1.WriteLine($"{Set_str[3]},{string.Join(",", dataB.pings)}\r\n");
                    serialPort1.WriteLine($"{Set_str[4]},{string.Join(",", dataB.pulses)}\r\n");
                    serialPort1.WriteLine($"{Set_str[5]},{dataB.depth_off}\r\n");
                    serialPort1.WriteLine($"{Set_str[6]},{dataB.temp_off}\r\n");
                    serialPort1.WriteLine($"{Set_str[7]},{dataB.depth_filt}\r\n");
                    serialPort1.WriteLine($"{Set_str[8]},{dataB.sample_filt}\r\n");
                    serialPort1.WriteLine("$PAMTC,EN,S\r\n");

                    Invoke(new EventHandler(Btn_Query_Click));
                }
                else
                {
                    Status_box.Text = "Please connect to device";
                }

                Status_box.Text = "Settings updated successfully";
            }
            catch (Exception ex)
            {
                Status_box.Text = $"Update error: {ex.Message}";
            }
        }

        private void Btn_pause_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
                return;

            flags.is_paused = !flags.is_paused;
            btn_pause.Text = flags.is_paused ? "Resume" : "Pause";
            serialPort1.WriteLine(flags.is_paused ? "$PAMTX,0\r\n" : "$