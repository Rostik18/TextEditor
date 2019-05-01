using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        int wordCount;
        public Form1()
        {
            InitializeComponent();
            wordCount = 0;
            timer1.Start();
            timer1.Tick += WordCouter;
        }

        //private async void WordCouterAsync(object sender, EventArgs e)  //Async?
        //{                                                         //No, because richTextBox1 blocked from main Thread.
        //    Task task = new Task(WordCouter);
        //    task.Start();
        //    WordsCountLabel.Text = wordCount.ToString();
        //}

        private void WordCouter(object sender, EventArgs e)
        {
            string[] words = richTextBox1.Text.Split(new char[] { ' ', ',', '.', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            wordCount = words.Length;
            WordsCountLabel.Text = wordCount.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;
            oldFont = richTextBox1.SelectionFont;
            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            richTextBox1.SelectionFont = newFont;
            richTextBox1.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;
            oldFont = richTextBox1.SelectionFont;
            if (oldFont.Underline)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);
            richTextBox1.SelectionFont = newFont;
            richTextBox1.Focus();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;
            oldFont = richTextBox1.SelectionFont;
            if (oldFont.Italic)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);
            richTextBox1.SelectionFont = newFont;
            richTextBox1.Focus();
        }

        private void toolStripButton4_Click(object sender, EventArgs e) //по лівому
        {
            if (this.richTextBox1.SelectionAlignment != HorizontalAlignment.Left)
                this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            this.richTextBox1.Focus();
        }

        private void toolStripButton5_Click(object sender, EventArgs e) //центр
        {
            if (this.richTextBox1.SelectionAlignment != HorizontalAlignment.Center)
                this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            this.richTextBox1.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e) //по правому
        {
            if (this.richTextBox1.SelectionAlignment != HorizontalAlignment.Right)
                this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            this.richTextBox1.Focus();
        }


        private void FontSizeNumeric_ValueChanged(object sender, EventArgs e)
        {
            float newSize = (float)FontSizeNumeric.Value;
            FontFamily currentFontFamily;
            Font newFont;
            currentFontFamily = this.richTextBox1.SelectionFont.FontFamily;
            newFont = new Font(currentFontFamily, newSize);
            this.richTextBox1.SelectionFont = newFont;
            this.richTextBox1.Focus();
        }
    }
}
