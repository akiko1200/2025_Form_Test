using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 6; j++) {
                    // インスタンスの作成
                    TestButton testButton = new TestButton();

                    // ボタンの位置を設定
                    testButton.Location = new Point(50 * j, 50 * i);

                    // ボタンの大きさを設定
                    testButton.Size = new Size(50, 50);

                    // ボタン内のテキストを設定
                    testButton.Text = "";

                    // コントロールにボタンを追加
                    Controls.Add(testButton);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C#の世界へようこそ！");
        }
    }
}
