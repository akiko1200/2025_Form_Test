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
        // constをつけると初期化時にのみ値の変更が可能になる(定数)
        /// <summary>
        /// ボタンの横幅
        /// </summary>
        const int BUTTON_SIZE_X = 100;
        /// <summary>
        /// ボタンの縦幅
        /// </summary>
        const int BUTTON_SIZE_Y = 100;

        /// <summary>
        /// ボタンが横に何個並ぶか
        /// </summary>
        const int BOARD_SIZE_X = 3;
        /// <summary>
        /// ボタンが縦に何個並ぶか
        /// </summary>
        const int BOARD_SIZE_Y = 3;

        /// <summary>
        /// TestButtonの二次元配列
        /// </summary>
        private TestButton[,] _buttonArray;


        public Form1()
        {
            InitializeComponent();

            // _buttonArrayの初期化
            _buttonArray = new TestButton[BOARD_SIZE_Y, BOARD_SIZE_X];

            for (int i = 0; i < BOARD_SIZE_X; i++)
            {
                for (int j = 0; j < BOARD_SIZE_Y; j++)
                {
                    // インスタンスの作成
                    TestButton testButton =
                        new TestButton(
                            this,
                            i, j,
                            new Size(BUTTON_SIZE_X, BUTTON_SIZE_Y),
                            "",
                            BOARD_SIZE_X, BOARD_SIZE_Y);

                    // 配列にボタンの参照を追加
                    _buttonArray[j, i] = testButton;

                    // コントロールにボタンを追加
                    Controls.Add(testButton);
                }
            }

            // 初期盤面のランダム化
            StartRandom();
        }

        /// <summary>
        /// TestButtonを取得する関数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public TestButton GetTestButton(int x, int y)  // _buttonArrayだと配列外の数字のときエラーになる
        {
            // 配列外参照対策
            if (x < 0 || x >= BOARD_SIZE_X) return null;
            if (y < 0 || y >= BOARD_SIZE_Y) return null;

            return _buttonArray[y, x];
        }

        /// <summary>
        /// 盤面をランダム化する関数
        /// </summary>
        public void StartRandom()
        {
            Random random = new Random();
            int r = random.Next(2, BOARD_SIZE_X * BOARD_SIZE_Y);
            for (int i = 0; i < r; i++)
            {
                int random_x = random.Next(BOARD_SIZE_X);
                int random_y = random.Next(BOARD_SIZE_Y);
                GetTestButton(random_x, random_y).Toggle();
            }
        }

        // 自動生成
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C#の世界へようこそ！");
        }
    }
}
