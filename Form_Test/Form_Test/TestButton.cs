using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    // Buttonクラスを継承したTestButton
    internal class TestButton : Button
    {
        /// <summary>off時の色</summary>
        private Color _onColor = Color.LightBlue;
        /// <summary>on時の色</summary>
        private Color _offColor = Color.LightYellow;

        /// <summary>現在onかoffか</summary>
        private bool _enable;

        /// <summary>onとoffの設定</summary>
        /// <param name="on"></param>
        public void SetEnable(bool on)
        {
            _enable = on;
            if (on)
            {
                BackColor = _onColor;
            }
            else
            {
                BackColor = _offColor;
            }
        }


        public TestButton(Point position, Size size, string text)
        {
            // ボタンの位置を設定
            Location = position;
            // ボタンの大きさを設定
            Size = size;
            // ボタン内のテキストを設定
            Text = text;

            SetEnable(false);

            Click += ClickEvent;
        }

        // 自分で作成することも可能
        private void ClickEvent(object sender, EventArgs e)
        {
            SetEnable(!_enable);  // enableの否定
        }

    }
}
