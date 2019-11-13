using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Diagnostics;

namespace SpeechtoTextFORM
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        
        public  Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
         
            Choices commands = new Choices();
            commands.Add(new string[] { "map", "grenade", "reload", "openchrome" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder); 
            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;

        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch(e.Result.Text)
            {
                case "map":
                    SendKeys.Send("m");

                    break;

                case "grenade":
                    SendKeys.Send("g");

                    break;
                case "reload":
                    SendKeys.Send("r");
                    break;
                
                case "openchrome":
                    Process.Start("chrome", "https://www.google.com");

                break;
                
            }

            textBox1.Text = "Kelime:" + e.Result.Text;

           
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnDisable.Enabled = true;
            btnEnable.Enabled = false;
            
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnDisable.Enabled = false;
            btnEnable.Enabled = true;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
