using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawShapesWithInheritance
{
    public partial class Form1 : Form
    {
        Engine mEngine;
        public static Color color;
        public Form1()
        {
            mEngine = Engine.GetInstance();
            InitializeComponent();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                color = colorDlg.Color;
            }
        }

        private void squareCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (squareCheckBox.Checked == true)
            {
                triangleCheckBox.Checked = false;
                circleCheckBox.Checked = false;
            }
        }

        private void circleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (circleCheckBox.Checked == true)
            {
                triangleCheckBox.Checked = false;
                squareCheckBox.Checked = false;
            }
        }

        private void triangleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (triangleCheckBox.Checked == true)
            {
                squareCheckBox.Checked = false;
                circleCheckBox.Checked = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "serielazied";
            saveFileDialog.Filter = "TXT files|*.txt|All Files|*.*";
            saveFileDialog.Title = "Save as";
            this.saveFileDialog.ShowDialog();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int hight = (int)sizeUpDown.Value;
            int width = (int)sizeUpDown.Value;
            Point position = new Point(e.X, e.Y);
            if (circleCheckBox.Checked == true)
            {
                string type = "circle";
                mEngine.BaseShapes.Add(new Circle(type, (int)sizeUpDown.Value, color, filledCheckBox.Checked, new Point(e.X, e.Y)));
            }
            if (squareCheckBox.Checked == true)
            {
                string type = "square";
                mEngine.BaseShapes.Add(new Square(type, (int)sizeUpDown.Value, color, filledCheckBox.Checked, new Point(e.X, e.Y)));
            }
            if (triangleCheckBox.Checked == true)
            {
                string type = "triangle";
                mEngine.BaseShapes.Add(new Triangle(type, (int)sizeUpDown.Value, color, filledCheckBox.Checked, new Point(e.X, e.Y)));
            }

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            foreach (BaseShape shape in mEngine.BaseShapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {

            StringBuilder strBld = new StringBuilder();
            foreach (BaseShape shape in mEngine.BaseShapes)
            {
                strBld.AppendLine(shape.Serialize());
            }

            string stringOfShapes = strBld.ToString();
            string name = saveFileDialog.FileName;
            File.WriteAllText(name, stringOfShapes);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string name = openFileDialog.FileName;
            string[] lines = File.ReadAllLines(name);

            //foreach (string line in lines)
            //{
            //    BaseShape shape = null;
            //    Dictionary<string, string> valuesDict = mEngine.LineToDictionary(line);
            //    string valueStr;
            //    if (!valuesDict.TryGetValue("type", out valueStr))
            //    {
            //        continue;
            //    }

            //    switch (valueStr)
            //    {
            //        case "circle":
            //            shape = new Circle();
            //            break;
            //        case "triangle":
            //            shape = new Triangle();
            //            break;
            //        case "square":
            //            shape = new Square();
            //            break;
            //    }

            //    if (shape != null)
            //    {
            //        shape.Deserialize(valuesDict); // rewrite Deserialize to use Dictionary
            //        mEngine.BaseShapes.Add(shape);
            //    }
            //}

            foreach (string line in lines)
            {
                BaseShape shape = null;
                var nameValueList = mEngine.LineToList(line);
                foreach (NameValue curNameVal in nameValueList)
                {
                    if (curNameVal.Name == "type")
                    {
                        switch (curNameVal.Value)
                        {
                            case "circle":
                                shape = new Circle();
                                break;
                            case "triangle":
                                shape = new Triangle();
                                break;
                            case "square":
                                shape = new Square();
                                break;
                        }

                        if (shape != null)
                        {
                            shape.Deserialize(nameValueList);
                            mEngine.BaseShapes.Add(shape);
                        }
                    }
                }
            }

            Invalidate();

        }
    }
}
