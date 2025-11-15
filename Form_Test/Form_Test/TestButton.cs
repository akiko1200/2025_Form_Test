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
    public class TestButton : Button
    {
        /// <summary>off時の色</summary>
        private Color _onColor = Color.LightBlue;
        /// <summary>on時の色</summary>
        private Color _offColor = Color.LightYellow;

        /// <summary>現在onかoffか</summary>
        private bool _enable;

        /// <summary>Form1の参照</summary>
        private Form1 _form1;

        /// <summary>横位置</summary>
        private int _x;

        /// <summary>縦位置</summary>
        private int _y;

        /// <summary>ボタンの列数</summary>
        private int _board_size_x;

        /// <summary>ボタンの行数</summary>
        private int _board_size_y;

        // コンストラクタ
        public TestButton(Form1 form1, int x, int y, Size size, string text, int board_size_x, int board_size_y)
        {
            // Form1の参照を保管
            _form1 = form1;

            // 横位置を保管
            _x = x;

            // 縦位置を保管
            _y = y;

            // ボタンの位置を設定
            Location = new Point(x * size.Width, y * size.Height);
            // ボタンの大きさを設定
            Size = size;
            // ボタン内のテキストを設定
            Text = text;

            // ボタンの列数を保管
            _board_size_x = board_size_x;

            // ボタンの行数を保管
            _board_size_y = board_size_y;

            SetEnable(false);

            Click += ClickEvent;
            
        }


        /// <summary>onとoffの設定</summary>
        /// <param name="on"></param>
        public void SetEnable(bool on)
        {
            _enable = on;
            if (on)       // onがtrueなら_onColor
            {
                BackColor = _onColor;
            }
            else
            {
                BackColor = _offColor;
            }
        }

        public void Toggle()
        {
            SetEnable(!_enable);
        }

        /// <summary>
        /// 各ボタンがクリックされたときに呼び出される関数
        /// クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickEvent(object sender, EventArgs e)
        {
            ToggleButtonAround();

            if (IsClear())
            {
                OnClear();
            }

        }

        /// <summary>
        /// ボタンがtrueかfalseか確認
        /// </summary>
        /// <returns></returns>
        private bool IsEnable()
        {
            return _enable;
        }

        /// <summary>
        /// 押されたボタンとその上下左右のボタンの色を変える
        /// </summary>
        private void ToggleButtonAround()
        {
            // 楽な書き方
            //_form1.GetTestButton(_x, _y)?.Toggle();
            //_form1.GetTestButton(_x + 1, _y)?.Toggle();
            //_form1.GetTestButton(_x - 1, _y)?.Toggle();
            //_form1.GetTestButton(_x, _y + 1)?.Toggle();
            //_form1.GetTestButton(_x, _y - 1)?.Toggle();

            // かっこいい書き方
            for (int i = 0; i < _toggleData.Length; i++)
            {
                var data = _toggleData[i];
                var button = _form1.GetTestButton(_x + data[0], _y + data[1]);

                if (button != null)
                {
                    button.Toggle();
                }
            }
        }

        // かっこいい書き方に使用
        private int[][] _toggleData =
        {
            new int[]{0, 0},
            new int[]{1, 0} ,
            new int[]{-1, 0},
            new int[]{0, 1 },
            new int[]{0, -1},
        };

        /// <summary>
        /// クリアしたかの判定
        /// </summary>
        /// <returns></returns>
        private bool IsClear()
        {
            int trueCnt = 0;
            for (int i = 0; i < _board_size_y; i++)
            {
                for (int j = 0; j < _board_size_x; j++)
                {
                    TestButton btn = _form1.GetTestButton(j, i);
                    if (btn != null)
                    {
                        if (btn.IsEnable() == true)
                        {
                            trueCnt++;
                        }
                    }
                }
            }

            return trueCnt == 0 || trueCnt == _board_size_x * _board_size_y;
        }

        /// <summary>
        /// クリア時の処理
        /// </summary>
        private void OnClear()
        {
            DialogResult result = MessageBox.Show("クリア！！！\r\n再チャレンジしますか？",
                                                      "おめでとうございます", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                _form1.StartRandom();  // はいを押されたら再ランダム化
            }
            else if (result == DialogResult.No)
            {
                _form1.Close();  // いいえを押されたらフォームを閉じる
            }
        }


    }
}
