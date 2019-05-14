using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jubeatsu
{
    public partial class Form1 : Form
    {
        string filePath = String.Empty;
        string fileName = String.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnPick_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = fileDialogOsu.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                tbOsuFile.Text = $"Selected: {fileDialogOsu.SafeFileName}";
                filePath = fileDialogOsu.FileName;
                fileName = fileDialogOsu.SafeFileName;
                progressBar.Value = 10;
                btnCreateStoryboard.Enabled = true;
            }
        }

        private void CreateOSB()
        {
            string[] osbText = new string[]
            {
                "[Events]",
                "Sample,-1400,0,\"SB\\READY.wav\",100",
                "Sample,-200,0,\"SB\\GO.wav\",100"
            };
            string osbPath = GetOsbName();
            bool proceed = CheckAndContinueOSB(osbPath);
            if (!proceed)
                return;
            lblProgress.Text = "Creating .osb file under Directory.";
            File.WriteAllLines(osbPath, osbText);
            progressBar.Value = 20;
        }
        private List<HitObject> GetHitObjects()
        {
            List<HitObject> hitObjects = new List<HitObject>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int hitObj = -1;
                int counter = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "[HitObjects]" && hitObj == -1)
                    {
                        counter++;
                        continue;
                    }
                    if (line == "[HitObjects]")
                    {
                        hitObj = counter;
                    }

                    if (counter > hitObj && line != Environment.NewLine)
                    {
                        HitObject hitObject = ParseHitObject(line);
                        if (hitObject == null)
                            throw new Exception(
                                $"Holy fuck! I couldn't parse the HitObjects.\nIs the Beatmap Hitcircles only? If not, report it to me.");
                        hitObjects.Add(hitObject);
                    }

                    counter++;
                }    
            }
            return hitObjects;
        }

        private void CreateStoryboard()
        {
            lblProgress.Text = "Creating Mask";
            progressBar.Value = 30;
            string[] mask = CreateMask();
            lblProgress.Text = "Creating Buttons";
            progressBar.Value = 40;
            string[] buttons = CreateButtons();
            lblProgress.Text = "Retrieving HitObjects";
            progressBar.Value = 50;
            List<HitObject> hitObjects = GetHitObjects();
            List<string[]> animations = new List<string[]>();
            lblProgress.Text = "Creating Animations";
            foreach (var hitObj in hitObjects)
            {
                animations.Add(CreateAnimation(hitObj));
            }

            lblProgress.Text = "Saving Events file as .txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                string directory = Path.GetDirectoryName(filePath);
                string newFileName = "Events_" + fileName + ".txt";
                string newFilePath = Path.Combine(directory, newFileName);

                using (StreamWriter sw = new StreamWriter(newFilePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        foreach (var str in mask)
                        {
                            sw.WriteLine(str);
                        }

                        foreach (var str in buttons)
                        {
                            sw.WriteLine(str);
                        }

                        foreach (var animation in animations)
                        {
                            foreach (var str in animation)
                            {
                                sw.WriteLine(str);
                            }
                        }
                        break;
                    }
                }
            }
            lblProgress.Text = "Done, your new File has been saved.";
            progressBar.Value = 100;
        }

        private string[] CreateMask()
        {
            string[] mask = new string[]
            {
                "Sprite,Foreground,Centre,\"sb\\copious.png\",320,240",
                " S,0,-4000,,1.152",
                " M,0,-4000,109494,559,251",
                "Sprite,Foreground,Centre,\"sb\\ready.png\",320,240",
                " S,0,-1400,,0.6919998",
                " M,0,-1400,-200,325,-10,323,251",
                "Sprite,Foreground,Centre,\"sb\\go.png\",320,240",
                " M,0,-200,,319,250",
                " S,0,-200,0,0.7920002,1.872",
                " S,0,0,50,1.872,1.728",
                " F,0,100,329,1,0",
                "Sprite,Foreground,Centre,\"sb\\mask.png\",320,240",
                " S,0,-4000,,0.8560004",
                " M,0,-4000,109494,331,240"
            };
            return mask;
        }
        private string[] CreateButtons()
        {
            string[] buttons = new string[]
            {
                "Sprite,Foreground,Centre,\"sb\\start.png\",320,240",
                " S,0,-4000,,0.704",
                " M,0,-1,-295,482,406",
                "Sprite,Foreground,Centre,\"sb\\jubeat.png\",320,240",
                " S,0,-4000,,0.8480002",
                " R,0,-4000,,1.568",
                " M,0,-4000,109494,575,325",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,165,95",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,269,95",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,373,95",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,477,95",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,373,199",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,269,199",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,165,199",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,477,199",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,373,303",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,269,303",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,165,303",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,477,303",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,373,407",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,269,407",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,165,407",
                "Sprite,Foreground,Centre,\"sb\\test_button_up.png\",320,240",
                " S,0,-4000,,0.536",
                " M,0,-4000,109494,477,407"
            };
            return buttons;
        }
        private string[] CreateAnimation(HitObject hitObject)
        {
            const int ANIM_LENGTH = 462;
            const int HORIZONTAL_OFFSET = 64;
            const int VERTICAL_OFFSET = 55;
            int timeOffset = hitObject.time - ANIM_LENGTH;
            int x = hitObject.x + HORIZONTAL_OFFSET;
            int y = hitObject.y + VERTICAL_OFFSET;
            string[] animation = new string[]
            {
                $"Animation,Foreground,Centre,\"marker\\marker_.png\",{x},{y},29,33,LoopOnce",
                $" L,{timeOffset},1",
                "  F,0,0,,1",
                "  S,0,957,,0.608"
            };
            return animation;
        }
        private HitObject ParseHitObject(string line)
        {
            var lines = line.Split(',');
            if (!int.TryParse(lines[0], out var x) || !int.TryParse(lines[1], out var y) ||
                !int.TryParse(lines[2], out var time))
            {
                Console.WriteLine($"{lines[0]}, {lines[1]}, {lines[2]}");
                return null;
            }
            Console.WriteLine($"{lines[0]}, {lines[1]}, {lines[2]}");
            return new HitObject() { x = x, y = y, time = time };
        }
        private bool CheckAndContinueOSB(string osbPath)
        {
            if (File.Exists(osbPath))
            {
                const string osbtext1 = "You already have an osb File in this Folder, it will be overwritten! Are you sure?";
                const string osbtext2 = "If you want to save your OSB, move it somewhere else, create the OSB and then merge it into yours!";
                bool proceed = CreateDialog($"{osbtext1}\n{osbtext2}", "Proceed?", MessageBoxButtons.YesNo);

                if (!proceed)
                {
                    progressBar.Value = 10;
                    return false;
                }
            }
            return true;
        }
        private bool CreateDialog(string text, string header, MessageBoxButtons buttonType)
        {
            DialogResult result = MessageBox.Show(text, header, buttonType);
            return result == DialogResult.Yes? true : false;
        }
        private void BtnCreateStoryboard_Click(object sender, EventArgs e)
        {
            CreateOSB();
            CreateStoryboard();
            MessageBox.Show(
                "An events text file has been created, please paste the text file inside your .osu file under your [Events]",
                "Last steps, now its up to you!");
        }

        private string GetOsbName()
        {
            lblProgress.Text = "Getting .osb Filename...";
            string directory = Path.GetDirectoryName(filePath);
            string osbFileName = String.Empty;
            foreach (var file in Directory.GetFiles(directory))
            {
                if (file.EndsWith(".osu"))
                {
                    // Need to remove ex. [Extreme].osu and replace with .osb to get Osb Path
                    osbFileName = file.Substring(0, file.LastIndexOf('['));
                    // There is still a space at the very end, so we need to get rid of that!
                    osbFileName = osbFileName.Substring(0, osbFileName.LastIndexOf(' '));
                    osbFileName += ".osb";
                    break;
                }
            }
            progressBar.Value = 15;
            return osbFileName;
        }
    }
}
