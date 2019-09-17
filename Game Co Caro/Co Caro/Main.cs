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
using System.Timers;
namespace Co_Caro
{
    public partial class Main : Form
    {
        // X = 1 ; O = 0
        string StopTime = "10";
        private bool isPlayerX = true;
        private string Chess = "X";
        private int ChessInArray = 1;
        private int[,] A = new int[100, 100];
        private int no = 0;
        private int PlayerXScore = 0;
        private int PlayerOScore = 0;
        private int recent = -1;
        //==========================================
        private int[,] B = new int[100, 100];
        private int botMark = -1;
        private bool BotMode = false;
        private int[,] C = new int[100, 100];
        int Atttack = 2;
        bool isWin = false;
        bool botFirst = false;
        bool QuickBot = false;
        public Main()
        {
            InitializeComponent();

        }

        DateTime start = DateTime.Now;
      
      
     

        private void initArray(int Wight)
        {
            for (int i = 0; i < Wight; i++)
                for (int j = 0; j < Wight; j++)
                {
                    A[i, j] = -1;
                }
        }

        void copy2()
        {
            for(int i=0; i<no; i++)
                for(int j =0; j<no; j++)
                {
                    C[i, j] = A[i, j];
                }
        }
        private void CreateChessTable(int Width)
        {
            flpBanCo.Enabled = true;
            flpBanCo.Controls.Clear();
            flpBanCo.Width = Width * 30 + Width + 2;
            flpBanCo.Height = Width * 30 + Width + 1;

            flpBanCo.Left = (this.Width - flpBanCo.Width) / 2;
            int y = (this.Height - flpBanCo.Height) / 2;
            if (y > pnButton.Bottom + 30)
                flpBanCo.Top = y;
            else
                flpBanCo.Top = pnButton.Bottom + 30;

            for (int i = 0; i < Width * Width; i++)
            {
                Button btn = new Button() { Height = 30, Width = 30 };
                btn.Name = i.ToString();
                btn.ForeColor = this.ForeColor;
                btn.Margin = new Padding(0, 0, 0, 0);
                btn.Click += btn_Click;
                flpBanCo.Controls.Add(btn);
            }




        }

        private void Mark(int Postion)
        {
            int p = 0;
            for (int i = 0; i < no; i++)
                for (int j = 0; j < no; j++)
                {

                    if (p == Postion)
                    {
                        A[i, j] = ChessInArray;
                        return;
                    }
                    p++;
                }

        }


        void btn_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender; //lấy button đang được click
            
            if (bt.Text.Equals(""))
            {
                click(bt.Name.ToString());
                //newTh();

                if (BotMode && !isWin)
                {
                  
                    Auto();
                    
                }
                start = DateTime.Now;
            }

           
        }


        private void click(string btName)
        {


            int Pos = Convert.ToInt16(btName.ToString());
            if (isPlayerX)
                flpBanCo.Controls[Pos].ForeColor = Color.Red;
            else
                flpBanCo.Controls[Pos].ForeColor = Color.Blue;
            flpBanCo.Controls[Pos].Text = Chess;
            Mark(Pos);
            int Winer = checkWin(Pos);
            if (Winer == 0)
            {
                flpBanCo.Enabled = false;
                PlayerOScore++;
                UpdateRANK();
                takeCorlorBack();
                MessageBox.Show("PLAYER O thắng");
                isWin = true;
                btnTiepTuc.Enabled = true;
                btnReload.Enabled = true;
                timer2.Enabled = false;
                btnPause.Enabled = false;
                //btnSave.Enabled = false;
                btnLose.Enabled = false;

                return;
            }
            if (Winer == 1)
            {
                flpBanCo.Enabled = false;
                PlayerXScore++;
                UpdateRANK();
                takeCorlorBack();
                MessageBox.Show("PLAYER X thắng");
                isWin = true;
                btnTiepTuc.Enabled = true;
                btnReload.Enabled = true;
                timer2.Enabled = false;

                btnPause.Enabled = false;
                //btnSave.Enabled = false;
                btnLose.Enabled = false;

                return;
            }
            //
            // Đổi màu btn Reccent và thu hồi lại màu cũ
            takeCorlorBack();
            takeColorGreen(Pos);
            recent = Convert.ToInt16(btName.ToString());

            // --- Copy trạng thái sang B để bắt đầu tiên đoán
            copy();
            copy2();
            // -----------
            if (chkX.Checked)
                chkX.CheckState = CheckState.Unchecked;
            else
                chkX.CheckState = CheckState.Checked;

           
        }


        private void takeCorlorBack()
        {
            if (recent != -1)
                flpBanCo.Controls[recent].BackColor = this.BackColor;
            return;

        }

        private void takeColorGreen(int now)
        {

            flpBanCo.Controls[now].BackColor = Color.Green;
            return;

        }

        private void UpdateRANK()
        {
            lbTiSo.Text = PlayerXScore.ToString() + ":" + PlayerOScore.ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            txtKhac.Enabled = false;
            btn10.Checked = true;
            pnButton.Visible = false;
            btnContinue.Visible = false;
            chkX.CheckState = CheckState.Checked;
            pnTySo.Visible = false;
            //
            btnTiepTuc.Enabled = false;
            btnReload.Enabled = false;

            btnPause.Enabled = true;
       //     //btnSave.Enabled = true;
            btnLose.Enabled = true;
            chkBotFirst.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btn10.Checked)
                no = 10;
            if (btn12.Checked)
                no = 12;
            if (btn15.Checked)
                no = 15;
            if (btnKhac.Checked)
                no = (Convert.ToInt16(txtKhac.Text));
            CreateChessTable(no);
            initArray(no);
            pnKichThuoc.Visible = false;
            pnButton.Visible = true;
            pnCheck.Enabled = false;
            pnTySo.Visible = true;

            if (botFirst)
            {
                int x = no * no / 2;
                click(x.ToString());
            }

            timer2.Enabled = true;
            start = DateTime.Now;
            
        }

        private void btnKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (btnKhac.Checked)
            {
                txtKhac.Enabled = true;
                txtKhac.Focus();
                txtKhac.ResetText();
            }
            else
            {
                txtKhac.Enabled = false;
                txtKhac.Text = "Khác";
            }
        }

        private void txtKhac_Leave(object sender, EventArgs e)
        {
            checkKhac();
        }

        private bool checkKhac() // check btn Khac
        {
            if (txtKhac.Text.Equals(""))
                return false;

            if (btnKhac.Checked)
            {
                try
                {
                    int w = Convert.ToInt16(txtKhac.Text);
                    if (w < 10)
                    {
                        MessageBox.Show("Kích thước tối thiểu là 10 x 10");
                        txtKhac.Focus();
                        txtKhac.ResetText();
                        return false;
                    }
                    if (w > 20)
                    {
                        MessageBox.Show("Kích thước tối đa là 20 x 20");
                        txtKhac.Focus();
                        txtKhac.ResetText();
                        return false;
                    }

                    return true;
                }
                catch
                {
                    DialogResult tl = MessageBox.Show("Phải là số nguyên!!! Nhập lại??? ", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (tl == DialogResult.Yes)
                    {
                        txtKhac.Focus();
                        txtKhac.ResetText();
                        return false;
                    }
                    else
                        btn10.Checked = true;
                    return false;
                }


            }
            return true;
        }
        private void btnLose_Click(object sender, EventArgs e)
        {

            DialogResult tl = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                PlayerOScore = PlayerXScore = 0;
                UpdateRANK();
                flpBanCo.Controls.Clear();

                btnReload.Enabled = false;
                btnReload.Enabled = false;

                btnPause.Enabled = true;
                //btnSave.Enabled = true;
                btnLose.Enabled = true;

                pnButton.Visible = false;
                pnKichThuoc.Visible = true;
                pnCheck.Enabled = true;
                pnTySo.Visible = false;







            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            btnContinue.Visible = false;
            btnPause.Visible = true;
            flpBanCo.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnContinue.Visible = true;
            btnPause.Visible = false;
            flpBanCo.Enabled = false;
        }

        private void chkX_CheckedChanged(object sender, EventArgs e)
        {
            if (chkX.Checked)
            {
                chkO.CheckState = CheckState.Unchecked;
                lbX.ForeColor = Color.Red;
                lbO.ForeColor = Color.Black;
                isPlayerX = true;
                Chess = "X";
                ChessInArray = 1;
              //  botMark = 0; 
            }
            else
            {
                chkO.CheckState = CheckState.Checked;
                lbX.ForeColor = Color.Black;
                lbO.ForeColor = Color.Red;
                isPlayerX = false;
                Chess = "O";
                ChessInArray = 0;
              //  botMark = 1; 
            }
        }



        private void chkO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkO.Checked)
            {
                chkX.CheckState = CheckState.Unchecked;
                lbX.ForeColor = Color.Black;
                lbO.ForeColor = Color.Red;
                isPlayerX = false;
                Chess = "O";
                ChessInArray = 0;
            //    botMark = 1; 

            }
            else
            {
                chkX.CheckState = CheckState.Checked;
                lbX.ForeColor = Color.Red;
                lbO.ForeColor = Color.Black;
                isPlayerX = true;
                Chess = "X";
                ChessInArray = 1;
               // botMark = 0; 
            }
        }

        // ----------------- Xu Ly Mang


        private bool IsWinIntCol(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về top
            // Mark là nước đang ở X hoặc Y
            int Mark = A[x, y];

            if (Mark == -1) return false;

            int Count = 1;
            for (int i = x; i > 0; i--)
                if (Mark == A[i - 1, y])
                    x = i - 1;
                else
                    break;

            for (int j = x; j < no - 1; j++)
                if (Mark == A[j + 1, y])
                    Count++;
                else
                    break;

            if (Count == 5)
            {
                return true;
            }

            return false;
        }

        private bool IsWinIntRow(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về left
            // Mark là nước đang ở X hoặc Y

            int Mark = A[x, y];
            if (Mark == -1) return false;
            int Count = 1;
            for (int i = y; i > 0; i--)
                if (A[x, i] == A[x, i - 1])
                    y--;
                else
                    break;
            for (int j = y; j < no - 1; j++)
                if (A[x, j] == A[x, j + 1])
                    Count++;
                else
                    break;
            if (Count == 5)
                return true;
            return false;
        }

        private bool IsWinInLTR(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU HUYỀN
        {
            // top-left
            int Mark = A[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;
            while (flag > 0 && top > 0 && A[top - 1, flag - 1] == Mark)
            {
                flag--;
                top--;
            }
            while (flag < no && top < no && A[top, flag] == Mark)
            {
                flag++;
                top++;
                count++;
            }
            if (count >= 5)
                return true;
            return false;
        }

        private bool IsWinInRTL(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU SẮC
        {
            // top-left
            int Mark = A[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;

            while (top > 0 && flag < no && A[top - 1, flag + 1] == Mark)
            {
                top--;
                flag++;
            }
            while (top < no && flag >= 0 && A[top, flag] == Mark)
            {
                top++;
                flag--;
                count++;
            }

            if (count >= 5)
                return true;
            return false;
        }




        //Kiểm tra thắng theo thứ tự
        private int checkWin(int p) // không ai thằng trả về -1 , X thắng trả về 1, O thắng trả về 0
        {
            int i, j;
            i = j = 0;
            int k = 0;
            for (i = 0; i < no; i++)
            {
                for (j = 0; j < no; j++)
                {
                    if (p == k)
                        break;
                    else
                        k++;
                }
                if (p == k)
                    break;
            }


            if (IsWinIntCol(i, j))
            {

                return A[i, j];

            }
            if (IsWinIntRow(i, j))
            {
                return A[i, j];
            }

            if (IsWinInLTR(i, j))
            {
                return A[i, j];
            }
            if (IsWinInRTL(i, j))
            {
                return A[i, j];
            }


            return -1;
        }

        // Kiểm tra thắng theo tọa độ
        private int checkWin(int i, int j)
        {
            if (IsWinIntCol(i, j))
            {

                return A[i, j];

            }
            if (IsWinIntRow(i, j))
            {
                return A[i, j];
            }

            if (IsWinInLTR(i, j))
            {
                return A[i, j];
            }
            if (IsWinInRTL(i, j))
            {
                return A[i, j];
            }


            return -1;
        }

        /*
         *   ĐẦU
         */

        private bool IsWinIntCol2(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về top
            // Mark là nước đang ở X hoặc Y
            int Mark = B[x, y];

            if (Mark == -1) return false;

            int Count = 1;
            for (int i = x; i > 0; i--)
                if (Mark == B[i - 1, y])
                    x = i - 1;
                else
                    break;

            for (int j = x; j < no - 1; j++)
                if (Mark == B[j + 1, y])
                    Count++;
                else
                    break;

            if (Count >= 3)
            {
                return true;
            }

            return false;
        }
        private bool IsWinIntCol21(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về top
            // Mark là nước đang ở X hoặc Y
            int Mark = B[x, y];

            if (Mark == -1) return false;

            int Count = 1;
            for (int i = x; i > 0; i--)
                if (Mark == B[i - 1, y])
                    x = i - 1;
                else
                {
                    if (B[i - 1, y] == -1)
                        Count++;
                    break;
                }
            for (int j = x; j < no - 1; j++)
                if (Mark == B[j + 1, y])
                    Count++;
                else
                {
                    if (B[j + 1, y] == -1)
                        Count++;
                    break;
                }
            if (Count >= 4)
            {
                return true;
            }

            return false;
        }
        private bool IsWinIntRow2(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về left
            // Mark là nước đang ở X hoặc Y

            int Mark = B[x, y];
            if (Mark == -1) return false;
            int Count = 1;
            for (int i = y; i > 0; i--)
                if (B[x, i] == B[x, i - 1])
                    y--;
                else
                    break;
            for (int j = y; j < no - 1; j++)
                if (B[x, j] == B[x, j + 1])
                    Count++;
                else
                    break;
            if (Count >= 3)
                return true;
            return false;
        }
        private bool IsWinIntRow21(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về left
            // Mark là nước đang ở X hoặc Y

            int Mark = B[x, y];
            if (Mark == -1) return false;
            int Count = 1;
            for (int i = y; i > 0; i--)
                if (B[x, i] == B[x, i - 1])
                    y--;
                else
                {
                    if (B[x, y - 1] == -1)
                        Count++;
                    break;
                }
            for (int j = y; j < no - 1; j++)
                if (B[x, j] == B[x, j + 1])
                    Count++;
                else
                {
                    if (B[x, j + 1] == -1)
                        Count++;
                    break;
                }
            if (Count >= 4)
                return true;
            return false;
        }

        private bool IsWinInLTR2(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU HUYỀN
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;
            while (flag > 0 && top > 0 && B[top - 1, flag - 1] == Mark)
            {
                flag--;
                top--;
            }
            while (flag < no && top < no && B[top, flag] == Mark)
            {
                flag++;
                top++;
                count++;
            }
            if (count >= 2)
                return true;
            return false;
        }

        private bool IsWinInRTL2(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU SẮC
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;

            while (top > 0 && flag < no && B[top - 1, flag + 1] == Mark)
            {
                top--;
                flag++;
            }
            while (top < no && flag >= 0 && B[top, flag] == Mark)
            {
                top++;
                flag--;
                count++;
            }

            if (count >=2)
                return true;
            return false;
        }




        //Kiểm tra thắng theo thứ tự
        private int checkWin2(int p) // không ai thằng trả về -1 , X thắng trả về 1, O thắng trả về 0
        {
            int i, j;
            i = j = 0;
            int k = 0;
            for (i = 0; i < no; i++)
            {
                for (j = 0; j < no; j++)
                {
                    if (p == k)
                        break;
                    else
                        k++;
                }
                if (p == k)
                    break;
            }


            if (IsWinIntCol2(i, j))
            {

                return B[i, j];

            }
            if (IsWinIntRow2(i, j))
            {
                return B[i, j];
            }
          
            
            //if (IsWinInLTR2(i, j))
            //{
            //    return B[i, j];
            //}
            //if (IsWinInRTL2(i, j))
            //{
            //    return B[i, j];
            //}


            return -1;
        }

        // Kiểm tra thắng theo tọa độ
        private int checkWin2(int i, int j)
        {
            if (IsWinIntCol2(i, j))
            {

                return B[i, j];

            }
         
            if (IsWinIntRow2(i, j))
            {
                return B[i, j];
            }

            if (IsWinInLTR2(i, j))
            {
                return B[i, j];
            }
            if (IsWinInRTL2(i, j))
            {
                return B[i, j];
            }
            //if (IsWinIntCol21(i, j))
            //{

            //    return B[i, j];

            //}
            //if (IsWinIntRow21(i, j))
            //{
            //    return B[i, j];
            //}

            return -1;
        }



        /*
         * CUỐI
         */
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            initArray(no);
            CreateChessTable(no);
            btnLose.Enabled = true;
            btnPause.Enabled = true;
            //btnSave.Enabled = true;
            btnTiepTuc.Enabled = false;
            btnReload.Enabled = false;
            isWin = false;
            initArray(no);
            chkX.CheckState = CheckState.Checked;
            if (botFirst)
                click((no * no / 2).ToString());
            timer2.Enabled = true;
            start = DateTime.Now;
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            initArray(no);
            CreateChessTable(no);
            PlayerOScore = PlayerXScore = 0;
            UpdateRANK();
            btnLose.Enabled = true;
            btnPause.Enabled = true;
            //btnSave.Enabled = true;
            btnTiepTuc.Enabled = false;
            btnReload.Enabled = false;
            isWin = false;
            initArray(no);
            chkX.CheckState = CheckState.Checked;
            if (botFirst)
                click((no * no / 2).ToString());
            timer2.Enabled = true;
            start = DateTime.Now;
        }

        private void txtKhac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkKhac())
                    btnStart_Click(null, null);
            }
        }
        // ============================================= Hàm AutoBot

        // Copy Mảng A sang B để làm temp thử:

        private void copy()
        {
            for (int i = 0; i < no; i++)
                for (int j = 0; j < no; j++)
                {
                    B[i, j] =A[i, j] ;
                }
        }

        // ƯU TIÊN 1: ĐÁNH VÀO CHỔ THẮNG
        //--------------- Tìm vị trí đặt thử tốt nhất cho quân của mình.
        //--------------- Mark = 1 sẽ đặt cờ và tìm tốt nhất cho X;
        private int putFlag(int Mark)
        {
            for (int i = 0; i < no; i++)
                for (int j = 0; j < no; j++)
                {
                    if (B[i, j] == -1) // Vị trị có thể đánh được
                    {
                        B[i, j] = Mark;
                        if (checkWin2(i, j) != -1)
                        {
                            return takePos(i,j); // trả về thứ tự
                        }
                        else
                        {
                            copy(); // Trả về trạng thái cũ
                        }
                    }
                }
            return -1;
        }


        //ƯU TIÊN 2: LỢI DỤNG ƯU TIÊN 1 ĐỂ PHÁT HIỆN NƯỚC ĐỊCH THẮNG. => ĐÁNH CHẶN
        // Hàm trên => Lặt mặt Mark


        //ƯU TIÊN 3: KIỂM TRA MÌNH CÓ ĐƯỜNG 3 2 ĐẦU NÀO KHÔNG?
        // CƠ HỘI THẮNG CAO

        private bool IsThreeIntCol(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về top
            // Mark là nước đang ở X hoặc Y
            int Mark = B[x, y];

            if (Mark == -1) return false;

            int Count = 1;
            for (int i = x; i > 0; i--)
                if (Mark == B[i - 1, y])
                    x = i - 1;
                else
                    break;
            if (x > 0 && B[x - 1, y] == -1)
                Count++;
            for (int j = x; j < no - 1; j++)
                if (Mark == B[j + 1, y])
                    Count++;
                else
                {
                    if (B[j + 1, y] == -1)
                        Count++;
                    break;
                }

            if (Count == 5)
            {
                return true;
            }

            return false;
        }

        private bool IsThreeIntRow(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về left
            // Mark là nước đang ở X hoặc Y

            int Mark = B[x, y];
            if (Mark == -1) return false;
            int Count = 1;
            for (int i = y; i > 0; i--)
                if (Mark == B[x, i - 1])
                    y--;
                else
                    break;
            if (y > 0 && B[x, y - 1] == -1)
                Count++;

            for (int j = y; j < no - 1; j++)
                if (Mark == B[x, j + 1])
                    Count++;
                else
                {
                    if (B[x, j + 1] == -1)
                        Count++;
                    break;
                }
            if (Count == 5)
                return true;
            return false;
        }

        private bool IsThreeInLTR(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU HUYỀN
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;
            while (flag > 0 && top > 0 && B[top - 1, flag - 1] == Mark)
            {
                flag--;
                top--;
            }
            if(flag>0 && top >0 && B[top-1,flag-1] == -1)
                count++;
            while (flag < no && top < no && B[top, flag] == Mark)
            {
                flag++;
                top++;
                count++;
            }
            if (flag < no && top < no && B[top, flag] == -1)
                count++;
            if (count > 5)
                return true;
            return false;
        }

        private bool IsThreeInRTL(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU SẮC
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;

            while (top > 0 && flag < no && B[top - 1, flag + 1] == Mark)
            {
                top--;
                flag++;
            }

            if (top > 0 && flag < no && B[top - 1, flag + 1] == -1)
                count++;
            while (top < no && flag >= 0 && B[top, flag] == Mark)
            {
                top++;
                flag--;
                count++;
            }
            if (top < no && flag >= 0 && B[top, flag] == -1)
                count++;

            if (count > 5)
                return true;
            return false;
        }


        // Bắt đầu hàm đặt thử và kiểm tra
        private int check3PosinLine(int Mark)
        {
            for (int i = 0; i < no; i++)
                for (int j = 0; j < no; j++)
                {
                    if (B[i, j] == -1)
                    {
                        B[i, j] = Mark;

                        // check Win
                        if (IsThreeIntRow(i, j))
                        {
                            return takePos(i,j);
                        }
                        if (IsThreeIntCol(i, j))
                        {
                            return takePos(i, j);
                        }
                        if (IsThreeInRTL(i, j))
                        {
                            return takePos(i, j);
                        }
                        if (IsThreeInLTR(i, j))
                        {
                            return takePos(i, j);
                        }
                    }
                    else
                    {
                        copy(); // Trả về mảng ban đầu;
                    }
                }
            return -1;
        }


        // ƯU TIÊN 4: KIỂM TRA HÀNG 3 KHÔNG CHẶN CỦA ĐỊCH ĐỂ ĂN
        // LỢI DỤNG ƯU TIÊN 3 ĐỂ KIỂM TRA ĐỊCH, LẬT MẶT FLAH


        // ƯU TIÊN 5: Đặt sao cho tạo thành 4:
        private bool IsFourIntCol(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về top
            // Mark là nước đang ở X hoặc Y
            int Mark = B[x, y];

            if (Mark == -1) return false;

            int Count = 1;
            for (int i = x; i > 0; i--)
                if (Mark == B[i - 1, y])
                    x = i - 1;
                else
                    break;
            x--; // Không quan tâm đằng sau là gì

            for (int j = x; j < no - 1; j++)
                if (Mark == B[j + 1, y])
                    Count++;
                else
                {
                    if (B[j + 1, y] == -1)
                        Count++;
                    break;
                }
            if (Count >= 5)
            {
                return true;
            }

            return false;
        }

        // Kiểm ở dòng
        private bool IsFourIntRow(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về left
            // Mark là nước đang ở X hoặc Y

            int Mark = B[x, y];
            if (Mark == -1) return false;
            int Count = 1;
            for (int i = y; i > 0; i--)
                if (B[x, i] == B[x, i - 1])
                    y--;
                else
                    break;
            if(y>0)
            y--;

            for (int j = y; j < no - 1; j++)
                if (B[x, j] == B[x, j + 1])
                    Count++;
                else
                {
                    if (B[x, j + 1] == -1)
                        Count++;
                    break;
                }
            if (Count >= 5)
                return true;
            return false;
        }

        // Top Left
        private bool IsFourInLTR(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU HUYỀN
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;
            while (flag > 0 && top > 0 && B[top - 1, flag - 1] == Mark)
            {
                flag--;
                top--;
            }
            // HÀM IF CHỈ KIỂM TRA THÊM ĐÚNG 1 LẦN
            //Lùi đại
            if (top != 0 && flag != 0)
            {
                flag--;
                top--;
            }
            while (flag < no && top < no && B[top, flag] == Mark)
            {
                flag++;
                top++;
                count++;
            }
            // HÀM IF CHỈ KIỂM TRA THÊM ĐÚNG 1 LẦN
            if (B[top, flag] == -1 && flag < no && top < no) /// Bổ tăng lên lùi về bằng -1;
            {
                flag++;
                top++;
                count++;
            }

            if (count >= 5)
                return true;
            return false;
        }

        // Top- Right
        private bool IsFourInRTL(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU SẮC
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;

            while (top > 0 && flag < no && B[top - 1, flag + 1] == Mark)
            {
                top--;
                flag++;
            }
            // HÀM IF CHỈ KIỂM TRA THÊM ĐÚNG 1 LẦN
            if (top != 0 && flag != no - 1)
            {
                top--;
                flag++;
            }

            while (top < no && flag >= 0 && B[top, flag] == Mark)
            {
                top++;
                flag--;
                count++;
            }

            // HÀM IF CHỈ KIỂM TRA THÊM ĐÚNG 1 LẦN
            if (top < no && flag >= 0 && B[top, flag] == -1)
            {
                top++;
                flag--;
                count++;
            }

            if (count >= 5)
                return true;
            return false;
        }

        // Bắt đầu hàm đặt thử và kiểm tra
        private int check4PosinLine(int Mark)
        {
            for (int i = 0; i < no; i++)
                for (int j = 0; j < no; j++)
                {
                    if (B[i, j] == -1)
                    {
                        B[i, j] = Mark;

                        // check Win
                        if (IsFourIntRow(i, j))
                        {
                            return takePos(i, j);
                        }
                        if (IsFourIntCol(i, j))
                        {
                            return takePos(i, j);
                        }
                        if (IsFourInRTL(i, j))
                        {
                            return takePos(i, j);
                        }
                        if (IsFourInLTR(i, j))
                        {
                            return takePos(i, j);
                        }
                    }
                    else
                    {
                        copy(); // Trả về mảng ban đầu;
                    }
                }
            return -1;
        }

        // ƯU TIÊN 6: Đặt sao cho tạo thành 3 không chặn

        private bool IsTwoIntCol(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về top
            // Mark là nước đang ở X hoặc Y
            int Mark = B[x, y];

            if (Mark == -1) return false;

            int Count = 1;
            for (int i = x; i > 0; i--)
                if (Mark == B[i - 1, y])
                    x = i - 1;
                else
                {
                    if (B[i - 1, y] == -1)
                        x = i - 1;
                    break;
                }
            for (int j = x; j < no - 1; j++)
                if (Mark == B[j + 1, y])
                    Count++;
                else
                {
                    if (B[j + 1, y] == -1)
                        Count++;
                    break;
                }
            if (Count >= 4)
            {
                return true;
            }

            return false;
        }

        // Kiểm ở dòng
        private bool IsTwoIntRow(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về left
            // Mark là nước đang ở X hoặc Y

            int Mark = B[x, y];
            if (Mark == -1) return false;
            int Count = 1;
            for (int i = y; i > 0; i--)
                if (B[x, i] == B[x, i - 1])
                    y--;
                else
                {
                    if (B[x, i - 1] == -1)
                        y--;
                    break;
                }
            for (int j = y; j < no - 1; j++)
                if (B[x, j] == B[x, j + 1])
                    Count++;
                else
                {
                    if (B[x, j + 1] == -1)
                        Count++;
                    break;
                }
            if (Count >= 4)
                return true;
            return false;
        }

        // Top Left
        private bool IsTwoInLTR(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU HUYỀN
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;
            while (flag > 0 && top > 0 && B[top - 1, flag - 1] == Mark)
            {
                flag--;
                top--;
            }
            // HÀM IF CHỈ KIỂM TRA THÊM ĐÚNG 1 LẦN
            if ( flag > 1 && top > 1 && B[top - 1, flag - 1] == -1 ) /// Bổ xung lùi về bằng -1;
            {
                flag--;
                top--;
            }

            while (flag < no && top < no && B[top, flag] == Mark)
            {
                flag++;
                top++;
                count++;
            }
            // HÀM IF CHỈ KIỂM TRA THÊM ĐÚNG 1 LẦN
            if (B[top, flag] == -1 && flag < no && top < no) /// Bổ tăng lên lùi về bằng -1;
            {
                flag++;
                top++;
                count++;
            }

            if (count >= 4)
                return true;
            return false;
        }

        // Top- Right
        private bool IsTwoInRTL(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU SẮC
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;

            while (top > 0 && flag < no && B[top - 1, flag + 1] == Mark)
            {
                top--;
                flag++;
            }
            // HÀM IF CHỈ KIỂM TRA THÊM ĐÚNG 1 LẦN
            if (top > 1 && flag < no-1 && B[top - 1, flag + 1] == -1)
            {
                top--;
                flag++;
            }

            while (top < no && flag >= 0 && B[top, flag] == Mark)
            {
                top++;
                flag--;
                count++;
            }

            // HÀM IF CHỈ KIỂM TRA THÊM ĐÚNG 1 LẦN
            if (top < no && flag >= 0 && B[top, flag] == -1)
            {
                top++;
                flag--;
                count++;
            }

            if (count >= 4)
                return true;
            return false;
        }

        // Bắt đầu hàm đặt thử và kiểm tra
        private int check2PosinLine(int Mark)
        {
            for (int i = 0; i < no; i++)
                for (int j = 0; j < no; j++)
                {
                    if (B[i, j] == -1)
                    {
                        B[i, j] = Mark;

                        // check Win
                        if (IsTwoIntRow(i, j))
                        {
                            return takePos(i, j);
                        }
                        if (IsTwoIntCol(i, j))
                        {
                            return takePos(i, j);
                        }
                        if (IsTwoInRTL(i, j))
                        {
                            return takePos(i, j);
                        }
                        if (IsTwoInLTR(i, j))
                        {
                            return takePos(i, j);
                        }
                    }
                    else
                    {
                        copy(); // Trả về mảng ban đầu;
                    }
                }
            return -1;
        }


        // ƯU TIÊN 7: LỢI DỤNG ƯU TIÊN 6 ĐỂ CHẶN ĐỊCH

        // DONE


        // ƯU TIÊN 8: LỢI DỤNG ƯU TIÊN 5 ĐỂ CHẶN ĐỊCH
        // DONE

        // ƯU TIÊN 9: ĐÁNH RANDOM
        private int Rand(int a, int b)
        {

            Random TenBienRanDom = new Random();
            return TenBienRanDom.Next(a, b);//Trả về giá trị kiểu int
        }

        int takePos(int a, int b)
        {
            int p=0;
           for(int i=0; i<no; i++)
               for(int j =0; j<no;j++)
               {
                   if (i == a && j == b)
                       return p;
                   p++;
               }
           return p;
        }
        private int RAND()
        {
            /*
             * Xác định độ rộng của mảng đánh
             * 
             */
            copy();
            int i, j;
            int Start = -1;
            for (i = 0; i < no; i++)
            {
                for (j = 0; j < no; j++)
                {
                    if (B[i, j] != -1)
                    {
                        Start = takePos(i,j);
                        break;
                    }

                }
                if (Start != -1)
                    break;
            }
            int End = -1;
            for (i = no - 1; i >= 0; i--)
            {
                for (j = no - 1; j >= 0; j--)
                {
                    if (B[i, j] != -1)
                    {
                        End = takePos(i,j);
                        break;
                    }
                }
                if (End != -1)
                    break;
            }

            if (End == Start)
            {
                if (Start != -1)
                {
                    if (Start >= 3)
                        Start = Start - 3;
                    if (End + 3 < no * no)
                        End = End + 3;
                }
                else
                {
                    Start = 0;
                    End = no * no;
                }
            }

            
            int r = Rand(Start, End);
            while(!flpBanCo.Controls[r].Text.Equals(""))
            {
                Thread.Sleep(10);
                r = Rand(Start, End);
            }
            return r;
            

        }

        int countSL()
        {
            int count = 0;
            for(int i=0; i<no; i++)
                for(int j =0; j<no; j++)
                {
                    if (A[i, j] != -1)
                        count++;
                }
            return count;
        }

        // AUTOBOT 

        int selection(int Mark)
        {

            //int [] count1 = new int[5];
            //count1[0] = count1[1] = count1[2]= count1[3] = 0;
            for(int i=0; i<no; i++)
                for(int j =0; j<no; j++)
                {
                    //DONG
                    if(j+4<no)
                    {
                        if(A[i,j] == -1 && A[i,j+1] == Mark && A[i,j+2] == Mark && A[i,j+3] == Mark && A[i,j+4] == -1 )
                        {
                            //MessageBox.Show("Row1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i, j + 4);
                        }
                    }

                    if(j+5<no)
                    {
                      
                        if(A[i,j] == -1 && A[i,j+1] == Mark && A[i,j+2] == -1 && A[i,j+3] == Mark && A[i,j+4] == Mark && A[i,j+5] == -1 )
                        {
                            //MessageBox.Show("Row2");
                            return takePos(i, j + 2);
                        }
                        if (A[i, j] == -1 && A[i, j + 1] == Mark && A[i, j + 2] == Mark && A[i, j + 3] == -1 && A[i, j + 4] == Mark && A[i, j + 5] == -1)
                        {
                            //MessageBox.Show("Row2");
                            return takePos(i, j + 3);
                        }
                    }
                    //
                    //COT
                    if (i+4<no)
                    {
                        if (A[i, j] == -1 && A[i+1, j ] == Mark && A[i+2, j ] == Mark && A[i+3, j ] == Mark && A[i+4, j] == -1)
                        {
                            //MessageBox.Show("Col1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i+4, j);
                        }
                    }

                    if (i + 5 < no)
                    {
                       
                        if (A[i, j] == -1 && A[i+1, j] == Mark && A[i+2, j ] == -1 && A[i+3, j ] == Mark && A[i+4, j] == Mark && A[i+5, j] == -1)
                        {
                            //MessageBox.Show("Col2");
                            return takePos(i+2, j);
                        }
                        if (A[i, j] == -1 && A[i + 1, j] == Mark && A[i + 2, j] == Mark && A[i + 3, j] == -1 && A[i + 4, j] == Mark && A[i + 5, j] == -1)
                        { 
                            //MessageBox.Show("Col2");
                            return takePos(i + 3, j);
                        }
                    }

                    // Sac

                    if(i+4<no && j-4>=0)
                    {

                        if(A[i,j] == -1 && A[i+1,j-1] == Mark && A[i+2, j-2]== Mark && A[i+3,j-3] == Mark && A[i+4,j-4]==-1)
                        {
                            //MessageBox.Show("Sac1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i+4, j-4);
                        }

                    }
                    if(i+5<no && j-5 >=0)
                    {

                        if (A[i, j] == -1 && A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == -1 && A[i + 3, j - 3] == Mark && A[i + 4, j - 4] == Mark && A[i + 5, j + 5] == -1)
                        {
                            //MessageBox.Show("sac2");
                            return takePos(i + 2, j - 2);
                        }
                        if (A[i, j] == -1 && A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == Mark && A[i + 3, j - 3] == -1 && A[i + 4, j - 4] == Mark && A[i + 5, j + 5] == -1)
                        {
                            //MessageBox.Show("sac2");
                            return takePos(i + 3, j - 3); 
                        }
                    }
                    // HUYEN

                    if (i + 4 < no && j + 4 <no)
                    {

                        if (A[i, j] == -1 && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == Mark && A[i + 3, j + 3] == Mark && A[i + 4, j + 4] == -1)
                        {
                            //MessageBox.Show("huyen1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i + 4, j + 4);
                        }

                    }
                    if (i + 5 < no && j + 5 <no)
                    {

                        if (A[i, j] == -1 && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == -1 && A[i + 3, j + 3] == Mark && A[i + 4, j + 4] == Mark && A[i + 5, j + 5] == -1)
                        {
                            //MessageBox.Show("Huyen2");
                            return takePos(i + 2, j + 2);
                        }
                        if (A[i, j] == -1 && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == Mark && A[i + 3, j + 3] == -1 && A[i + 4, j + 4] == Mark && A[i + 5, j + 5] == -1)
                        {
                            //MessageBox.Show("huyen2");
                            return takePos(i + 3, j + 3);
                        }
                    }


                }

            return -1;
        
        }

        int selectionAttack(int Mark)
        {

            //int [] count1 = new int[5];
            //count1[0] = count1[1] = count1[2]= count1[3] = 0;
            for (int i = 0; i < no; i++)
                for (int j = 0; j < no; j++)
                {
                  

                    //DONG
                    if (j + 4 < no)
                    {
                        if (A[i, j] == -1 && A[i, j + 1] == Mark && A[i, j + 2] == Mark && A[i, j + 3] == Mark && A[i, j + 4] == -1)
                        {
                            //MessageBox.Show("A Row1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i, j + 4);
                        }
                    }

                    if (j + 5 < no)
                    {

                        if (A[i, j] == -1 && A[i, j + 1] == Mark && A[i, j + 2] == -1 && A[i, j + 3] == Mark && A[i, j + 4] == Mark && A[i, j + 5] == -1)
                        {
                            //MessageBox.Show("A Row2");
                            return takePos(i, j + 2);
                        }
                        if (A[i, j] == -1 && A[i, j + 1] == Mark && A[i, j + 2] == Mark && A[i, j + 3] == -1 && A[i, j + 4] == Mark && A[i, j + 5] == -1)
                        {
                            //MessageBox.Show("A Row2");
                            return takePos(i, j + 3);
                        }
                    }
                    //
                    //COT
                    if (i + 4 < no)
                    {
                        if (A[i, j] == -1 && A[i + 1, j] == Mark && A[i + 2, j] == Mark && A[i + 3, j] == Mark && A[i + 4, j] == -1)
                        {
                            //MessageBox.Show("A Col1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i + 4, j);
                        }
                    }

                    if (i + 5 < no)
                    {

                        if (A[i, j] == -1 && A[i + 1, j] == Mark && A[i + 2, j] == -1 && A[i + 3, j] == Mark && A[i + 4, j] == Mark && A[i + 5, j] == -1)
                        {
                            //MessageBox.Show("A Col2");
                            return takePos(i + 2, j);
                        }
                        if (A[i, j] == -1 && A[i + 1, j] == Mark && A[i + 2, j] == Mark && A[i + 3, j] == -1 && A[i + 4, j] == Mark && A[i + 5, j] == -1)
                        {
                            //MessageBox.Show("A Col2");
                            return takePos(i + 3, j);
                        }
                    }

                    // Sac

                    if (i + 4 < no && j - 4 >= 0)
                    {

                        if (A[i, j] == -1 && A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == Mark && A[i + 3, j - 3] == Mark && A[i + 4, j - 4] == -1)
                        {
                            //MessageBox.Show("A Sac1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i + 4, j - 4);
                        }

                    }
                    if (i + 5 < no && j - 5 >= 0)
                    {

                        if (A[i, j] == -1 && A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == -1 && A[i + 3, j - 3] == Mark && A[i + 4, j - 4] == Mark && A[i + 5, j + 5] == -1)
                        {
                            //MessageBox.Show("A sac2");
                            return takePos(i + 2, j - 2);
                        }
                        if (A[i, j] == -1 && A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == Mark && A[i + 3, j - 3] == -1 && A[i + 4, j - 4] == Mark && A[i + 5, j + 5] == -1)
                        {
                            //MessageBox.Show("A sac2");
                            return takePos(i + 3, j - 3);
                        }
                    }
                    // HUYEN

                    if (i + 4 < no && j + 4 <no)
                    {

                        if (A[i, j] == -1 && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == Mark && A[i + 3, j + 3] == Mark && A[i + 4, j + 4] == -1)
                        {
                            //MessageBox.Show("A huyen1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i + 4, j + 4);
                        }

                    }
                    if (i + 5 < no && j + 5 <no)
                    {

                        if (A[i, j] == -1 && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == -1 && A[i + 3, j + 3] == Mark && A[i + 4, j + 4] == Mark && A[i + 5, j + 5] == -1)
                        {
                            //MessageBox.Show("A Huyen2");
                            return takePos(i + 2, j + 2);
                        }
                        if (A[i, j] == -1 && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == Mark && A[i + 3, j + 3] == -1 && A[i + 4, j + 4] == Mark && A[i + 5, j + 5] == -1)
                        {
                            //MessageBox.Show("A huyen2");
                            return takePos(i + 3, j + 3);
                        }
                    }


                    ///// attck
                    // HUYEN
                    if (i + 4 < no && j + 4<no)
                    {

                        if (A[i, j] == -1 && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == -1 && A[i + 3, j + 3] == Mark && A[i + 4, j + 4] == -1)
                        {
                            //MessageBox.Show("Attak hUYEN2");

                            return takePos(i + 2, j + 2);
                        }

                    }

                    if (i + 3 < no && j + 3 <no)
                    {
                        if (A[i, j] == -1 && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == Mark && A[i + 3, j + 3] == -1)
                        {
                            //MessageBox.Show("Attack Huyen1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i + 3, j + 3);
                        }
                    }
                    
                    
                    //SAC

                    if (i + 4 < no && j - 4 >= 0)
                    {

                        if (A[i, j] == -1 && A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == -1 && A[i + 3, j - 3] == Mark && A[i + 4, j - 4] == -1)
                        {
                            //MessageBox.Show("Attak Sac2");
                         
                            return takePos(i + 2, j - 2);
                        }

                    }

                    if(i+3<no && j-3>=0)
                    {
                        if (A[i, j] == -1 && A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == Mark && A[i + 3, j - 3] == -1)
                        {
                            //MessageBox.Show("Attack Sac1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i + 3, j-3);
                        }
                    }


                    //COL

                    if (i + 4 < no)
                    {
                        if (A[i, j] == -1 && A[i + 1, j] == Mark && A[i + 2, j] == -1 && A[i + 3, j] == Mark && A[i + 4, j] == -1)
                        {
                            //MessageBox.Show("Attack Col2");
                           
                            return takePos(i + 2, j);
                        }
                    }

                    if (i + 3 < no)
                    {

                        if (A[i, j] == -1 && A[i+1, j ] == Mark && A[i+2, j] == Mark && A[i+3, j] == -1)
                        {
                            //MessageBox.Show("Attack Col1");
                            if (DateTime.Now.Second % 2 == 0)
                                return takePos(i, j);
                            return takePos(i+3, j );
                        }
                    }

                    //ROW
                    if (j + 4 < no)
                    {
                        if (A[i, j] == -1 && A[i, j + 1] == Mark && A[i, j + 2] == -1 && A[i, j + 3] == Mark && A[i, j + 4] == -1)
                        {
                            //MessageBox.Show("Attack row2");
                            return takePos(i, j + 2);
                        }
                    }

                    
                    if(j+3<no)
                    {
                    
                        if(A[i,j] == -1 && A[i,j+1] == Mark && A[i,j+2] == Mark && A[i,j+3] == -1)
                        {
                            //MessageBox.Show("Attack row1");
                            if(DateTime.Now.Second %2==0)
                                return takePos(i,j);
                            return takePos(i,j+3);
                        }
                    }


                    //boxung

                    // SAC
                    if (i + 4 < no && j - 4 >= 0)
                    {

                        if ((A[i, j] == -1 || A[i+4,j-4] == -1) && A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == Mark && A[i + 3, j - 3] == Mark )
                        {
                            //MessageBox.Show("A sac12");
                            if (A[i, j] == -1)
                                return takePos(i, j);
                            else takePos(i+4, j -4);
                            
                        }
                   

                    }
                    if (i + 5 < no && j - 5 >= 0)
                    {

                        if ((A[i, j] == -1 || A[i+5,j-5] == -1)&& A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == -1 && A[i + 3, j - 3] == Mark && A[i + 4, j - 4] == Mark)
                        {
                            //MessageBox.Show("A sac21");
                            return takePos(i + 2, j - 2);
                        }
                        if ((A[i, j] == -1 || A[i + 5, j - 5] == -1) && A[i + 1, j - 1] == Mark && A[i + 2, j - 2] == Mark && A[i + 3, j - 3] == -1 && A[i + 4, j - 4] == Mark)
                        {
                            //MessageBox.Show("A sac22");
                            return takePos(i + 3, j - 3);
                        }
                    }

                    //HUYỀN
                    if (i + 4 < no && j + 4 <no)
                    {

                        if ((A[i, j] == -1 || A[i + 4, j + 4] == -1) && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == Mark && A[i + 3, j + 3] == Mark)
                        {
                            //MessageBox.Show("A hUYEN12");
                            if (A[i, j] == -1)
                                return takePos(i, j);
                            else takePos(i+4, j + 4);

                        }


                    }
                    if (i + 5 < no && j + 5<no )
                    {

                        if ((A[i, j] == -1 || A[i + 5, j + 5] == -1) && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == -1 && A[i + 3, j + 3] == Mark && A[i + 4, j + 4] == Mark)
                        {
                            //MessageBox.Show("A HUYEN21");
                            return takePos(i + 2, j + 2);
                        }
                        if ((A[i, j] == -1 || A[i + 5, j + 5] == -1) && A[i + 1, j + 1] == Mark && A[i + 2, j + 2] == Mark && A[i + 3, j + 3] == -1 && A[i + 4, j + 4] == Mark)
                        {
                            //MessageBox.Show("A HUEYN22");
                            return takePos(i + 3, j + 3);
                        }
                    }
                    // COL
                    if (i + 5 < no)
                    {
                        if ((A[i, j] == -1 || A[i+5,j] == -1) &&A[i+1, j] == Mark && A[i+2, j ] == Mark && A[i+3, j] == Mark && A[i+4, j ] == -1)
                        {
                            //MessageBox.Show("A COL12");

                            return takePos(i+4, j );
                        }
                        if ((A[i, j] == -1 || A[i + 5, j] == -1) && A[i, j] == Mark && A[i + 1, j] == Mark && A[i + 2, j] == Mark && A[i + 3, j] == -1&& A[i+4, j ] == -1)
                        {
                            //MessageBox.Show("A COL13");
                            //   if (DateTime.Now.Second % 2 == 0)
                            if (A[i, j] == -1)
                                return takePos(i, j);
                            else takePos(i+3, j );

                        }
                    }

                    if (i + 5 < no)
                    {

                        if ((A[i, j] == -1 || A[i+5,j] == -1) && A[i + 1, j] == Mark && A[i + 2, j] == -1 && A[i + 3, j] == Mark && A[i + 4, j] == Mark)
                        {
                            //MessageBox.Show("A COL21");
                            return takePos(i+2, j);
                        }

                        if ((A[i, j] == -1 || A[i+5,j] == -1) &&(A[i, j + 1] == Mark && A[i, j + 2] == Mark && A[i, j + 3] == -1 && A[i, j + 4] == Mark))
                        {
                            //MessageBox.Show("A COL22");
                            return takePos(i+3, j);
                        }

                    }

                    if (j + 5 < no)
                    {
                        if ((A[i, j] == -1 || A[i,j+5] == -1)&&A[i, j + 1] == Mark && A[i, j + 2] == Mark && A[i, j + 3] == Mark && A[i, j + 4] == -1)
                        {
                            //MessageBox.Show("A Row12");

                            return takePos(i, j + 4);
                        }
                        if ((A[i, j] == -1 || A[i, j + 5] == -1) && A[i, j] == -1 && A[i, j + 1] == Mark && A[i, j + 2] == Mark && A[i, j + 3] == Mark)
                        {
                            //MessageBox.Show("A Row13");
                            //   if (DateTime.Now.Second % 2 == 0)
                            if (A[i, j] == -1)
                                return takePos(i, j);
                            else takePos(i, j + 5);
                        }
                    }

                    if (j + 5 < no)
                    {

                        if ((A[i, j] == -1 || A[i, j + 5] == -1) && A[i, j + 1] == Mark && A[i, j + 2] == -1 && A[i, j + 3] == Mark && A[i, j + 4] == Mark)
                        {
                            //MessageBox.Show("A Row21");
                            return takePos(i, j + 2);
                        }

                        if ((A[i, j] == -1 || A[i, j + 5] == -1) && A[i, j + 1] == Mark && A[i, j + 2] == Mark && A[i, j + 3] == -1 && A[i, j + 4] == Mark)
                        {
                            //MessageBox.Show("A Row22");
                            return takePos(i, j + 3);
                        }

                    }

                   


                }

            return -1;

        }

        private int BOTChoice(int Mark)
        {
            int UnMark = -1;
            if (Mark == 1)
            {
                UnMark = 0;
            }
            else
            {
                UnMark = 1;
            }


            int kq = -1;

            // ƯU TIÊN 1
            kq = putFlag1(Mark);
            if (kq != -1)
            {
             //   //MessageBox.Show("ƯU TIÊN 1");
                return kq;
            }
            // ƯU TIÊN 2
            kq = putFlag(UnMark);
            int kq7 = beCareFulHuyen(UnMark);
            int kq3 = putFlag(Mark);
            int kq6 = beCareFulSac(UnMark);
            int kq2 = putFlag1(UnMark);
            int kq4 =    beCareFullLine2(UnMark);
            int kq5 = beCareFullRows2(UnMark);
            if (kq2 != -1 )
            {
              //  //MessageBox.Show("ƯU TIÊN 2");
                return kq2;

            }

            int kqS = selection(UnMark);
            if (kqS != -1)
                return kqS;

            int kqAttack = selectionAttack(Mark);
            if (kqAttack != -1)
                return kqAttack;

            if (kq4 != -1)
            {
                //  //MessageBox.Show("ƯU TIÊN 2 Line");
                return kq4;

            }
            if (kq5 != -1)
            {
                //  //MessageBox.Show("ƯU TIÊN 2 Row");
                return kq5;

            }
            if (kq6 != -1)
            {
                //  //MessageBox.Show("ƯU TIÊN 2");
                return kq6;

            }
            if (kq7 != -1)
            {
                //  //MessageBox.Show("ƯU TIÊN 2");
                return kq7;

            }
    

            if (kq != -1  )
            {
                ////MessageBox.Show("ƯU TIÊN 2 Defend");
                Atttack++;
                return kq;
             

            }
            else
            {
                if (kq3 != -1 && Atttack == 5)
                {
                //    //MessageBox.Show("ƯU TIÊN 2 Attack");
                    Atttack = 0;
                    return kq3;
                    

                }
            }
            // ƯU TIÊN 3
            if (countSL() >200)
            {
               

                // ƯU TIÊN 4:
                kq = check3PosinLine(UnMark);

                if (kq != -1)
                {
                    //MessageBox.Show("ƯU TIÊN 4");
                    return kq;
                }

                kq = check3PosinLine(Mark);
                if (kq != -1)
                {
                    //MessageBox.Show("ƯU TIÊN 3");
                    return kq;
                }

                // ƯU TIÊN 5:
                kq = check4PosinLine(Mark);
                if (kq != -1)
                {
                    //MessageBox.Show("ƯU TIÊN 5");
                    return kq;

                }

                // ƯU TIÊN 6:
                kq = check2PosinLine(Mark);
                if (kq != -1)
                {
                    //MessageBox.Show("ƯU TIÊN 6");
                    return kq;
                }

                // ƯU TIÊN 7:
                kq = check2PosinLine(UnMark);
                if (kq != -1)
                {
                    //MessageBox.Show("ƯU TIÊN 7");
                    return kq;
                }

                // ƯU TIÊN 8:
                kq = check4PosinLine(UnMark);
                if (kq != -1)
                {
                    //MessageBox.Show("ƯU TIÊN 8");
                    return kq;
                }
                // ƯU TIÊN 9:
            }
            kq = RAND();
           // //MessageBox.Show("ƯU TIÊN 9");
            return kq;

        }

        private void Auto()
        {
           
            int Pos = BOTChoice(botMark);
            click(Pos.ToString());
        }


        private void chkBot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBot.CheckState == CheckState.Checked)
            {
                BotMode = true;
                botMark = 0;
                if (chkO.Checked)
                {
                    botMark = 1;
                }
                chkBotFirst.Enabled = true;
                chkBotFirst.CheckState = CheckState.Checked;
              //  lbYou.Visible = true;
            }
            else
            {
                BotMode = false;
                chkBotFirst.Enabled = true;
                chkBotFirst.CheckState = CheckState.Unchecked;
             //   lbYou.Visible = false;
            }
        }

        private bool IsWinIntCol1(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về top
            // Mark là nước đang ở X hoặc Y
            int Mark = B[x, y];

            if (Mark == -1) return false;

            int Count = 1;
            for (int i = x; i > 0; i--)
                if (Mark == B[i - 1, y])
                    x = i - 1;
                else
                    break;

            for (int j = x; j < no - 1; j++)
                if (Mark == B[j + 1, y])
                    Count++;
                else
                    break;

            if (Count == 5)
            {
                return true;
            }

            return false;
        }

        private bool IsWinIntRow1(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột
        {
            // chạy ngược về left
            // Mark là nước đang ở X hoặc Y

            int Mark = B[x, y];
            if (Mark == -1) return false;
            int Count = 1;
            for (int i = y; i > 0; i--)
                if (B[x, i] == B[x, i - 1])
                    y--;
                else
                    break;
            for (int j = y; j < no - 1; j++)
                if (B[x, j] == B[x, j + 1])
                    Count++;
                else
                    break;
            if (Count == 5)
                return true;
            return false;
        }

        private bool IsWinInLTR1(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU HUYỀN
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;
            while (flag > 0 && top > 0 && B[top - 1, flag - 1] == Mark)
            {
                flag--;
                top--;
            }
            while (flag < no && top < no && B[top, flag] == Mark)
            {
                flag++;
                top++;
                count++;
            }
            if (count >= 5)
                return true;
            return false;
        }

        private bool IsWinInRTL1(int x, int y) // 0 hoặc 1 thắng ở đường thẳng, x là dòng, y là cột // DẤU SẮC
        {
            // top-left
            int Mark = B[x, y];
            if (Mark == -1) return false;
            int count = 0;
            int top = x;
            int flag = y;

            while (top > 0 && flag < no && B[top - 1, flag + 1] == Mark)
            {
                top--;
                flag++;
            }
            while (top < no && flag >= 0 && B[top, flag] == Mark)
            {
                top++;
                flag--;
                count++;
            }

            if (count >= 5)
                return true;
            return false;
        }




        //Kiểm tra thắng theo thứ tự
        private int checkWin1(int p) // không ai thằng trả về -1 , X thắng trả về 1, O thắng trả về 0
        {
            int i, j;
            i = j = 0;
            int k = 0;
            for (i = 0; i < no; i++)
            {
                for (j = 0; j < no; j++)
                {
                    if (p == k)
                        break;
                    else
                        k++;
                }
                if (p == k)
                    break;
            }


            if (IsWinIntCol1(i, j))
            {

                return B[i, j];

            }
            if (IsWinIntRow1(i, j))
            {
                return B[i, j];
            }

            if (IsWinInLTR1(i, j))
            {
                return B[i, j];
            }
            if (IsWinInRTL1(i, j))
            {
                return B[i, j];
            }


            return -1;
        }

        // Kiểm tra thắng theo tọa độ
        private int checkWin1(int i, int j)
        {
            if (IsWinIntCol1(i, j))
            {

                return B[i, j];

            }
            if (IsWinIntRow1(i, j))
            {
                return B[i, j];
            }

            if (IsWinInLTR1(i, j))
            {
                return B[i, j];
            }
            if (IsWinInRTL1(i, j))
            {
                return B[i, j];
            }


            return -1;
        }
        private int putFlag1(int Mark)
        {
            for (int i = 0; i < no; i++)
                for (int j = 0; j < no; j++)
                {
                    if (B[i, j] == -1) // Vị trị có thể đánh được
                    {
                        B[i, j] = Mark;
                        if (checkWin1(i, j) != -1)
                        {
                            return takePos(i, j); // trả về thứ tự
                        }
                        else
                        {
                            copy(); // Trả về trạng thái cũ
                        }
                    }
                }
            return -1;
        }


        /*
         * CUỐI
         */

        // KHACS
       private bool checkOther(int dong, int cot, int light, ref int k)
{
	if (light != -1)
	{
		int count = 0;
		//left-right
		int flag = cot;
		while (flag >= 0 && C[dong-1,flag-1] == light)
			flag--;
		while (flag < no && C[dong,flag] == light)
		{
			count++;
			flag++;
		}
        if (count >= 3)
        {
            return true;
            k = 2;
        }
        else count = 0;
		//up-down
		flag = dong;
		while (flag >= 0 && C[flag-1,cot-1] == light)
			flag--;
		while (flag < no && C[flag,cot] == light)
		{
			count++;
			flag++;
		}
        if (count >= 3)
        {
            return true;
            k = 1;
        }
		else count = 0;
		// top-left
		int top = dong;
		flag = cot;
		while (flag >= 0 && top >= 0 && C[top-1,flag-1] == light)
		{
			flag--;
			top--;
		}
		while (flag < no && top < no && C[top,flag] == light)
		{
			flag++;
			top++;
			count++;
		}
        if (count >= 3)
        {
            return true;
            k = 3;
        }
		else count = 0;

		flag = cot;
		top = dong;

		while (top >= 0 && flag < no && C[top-1,flag+1] == light)
		{
			top--;
			flag++;
		}
		while (top < no && flag >= 0 && C[top,flag] == light)
		{
			top++;
			flag--;
			count++;
		}

        if (count >= 3)
        {
            return true;
            k = 4;
        }
	}
	return false;
}

 

        int beCareFullLine(int Mark, int Line)
       {
           int Count = 0;
           for (int i = 0; i < no; i++)
           {
               if (A[i, Line] == -1) ;
               {
                   for(int  j = i+1; j<no-1; j++)
                   {
                       if(A[j,Line] == Mark)
                       {
                           Count++;
                       }
                       else
                       {
                           Count = 0;
                           break;
                       }

                       if (Count == 3)
                       {
                           if (A[j + 1, Line] == -1)
                               return takePos(j + 1, Line);
                       }
                   }
                  
               }
           
           }
           return -1;
       }


        int  beCareFullLine2(int Mark)
        {
            int temp =-1;
            for(int i=0; i<no;i++)
            {
                temp = beCareFullLine6(Mark, i);
                if (temp != -1)
                    return temp;
                temp = beCareFullLine5(Mark, i);
                if (temp != -1)
                    return temp;
                temp = beCareFullLine3(Mark, i);
                if (temp != -1)
                    return temp;
                temp =     beCareFullLine(Mark,i);
                if (temp != -1)
                    return temp;
                temp = beCareFullLine4(Mark, i);
                if (temp != -1)
                    return temp;
            }
            return temp;
        }

        int beCareFullRow(int Mark, int Row)
        {
            int Count = 0;
            for (int i = 0; i < no; i++)
            {
                if (A[Row,i] == -1)                 {
                    for (int j = i + 1; j < no - 1; j++)
                    {
                        
                        if (A[Row, j] == Mark)
                        {
                            Count++;
                        }
                        else
                        {
                            if(Count == 2 && A[Row, j+2] == Mark && A[Row,j+1] == -1)
                                return takePos(Row, j + 1);
                            Count = 0;
                            break;
                        }
                        if (Count == 3)
                        {
                            if (A[Row, j + 1] == -1)
                                return takePos(Row, j+1);
                        }
                    }

                }

            }
            return -1;
        }

        int beCareFullLine3(int Mark, int Line)
        {
            for (int i = 0; i < no - 4; i++)
            {

                if (A[i, Line] == -1)
                {

                    if (A[i+1, Line] == Mark && A[i+2, Line] == -1 && A[i+3, Line] == Mark && A[i+4, Line] == -1)
                       
                        return takePos(i+2, Line);
                    if (A[i+1, Line] == Mark && A[i+2, Line] == Mark && A[i+3, Line] == -1 && A[i+4, Line] == -1)
                        return takePos(i+3, Line);


                }
            }
            return -1;
        }

        int beCareFullLine5(int Mark, int Line)
        {
            for (int i = 0; i < no - 4; i++)
            {

                if (A[i, Line] == -1)
                {

                    if (A[i + 1, Line] == Mark && A[i + 2, Line] == Mark && A[i + 3, Line] == Mark && A[i + 4, Line] == -1)
                    {
                        if (DateTime.Now.Second % 2 == 0)
                            return takePos(i,Line);
                        return takePos(i+4,Line);
                    }

              


                }
            }
            return -1;
        }

        int beCareFullLine6(int Mark, int Line)
        {
            for (int i = 0; i < no - 4; i++)
            {

                if (A[i, Line] == -1)
                {

                    if (A[i + 1, Line] == Mark && A[i + 2, Line] == Mark && A[i + 3, Line] == -1 && A[i + 4, Line] == Mark && A[i+5,Line] == -1)
                    {
           //             //MessageBox.Show("Do It");
                        if (DateTime.Now.Second % 3 == 0)
                            return takePos(i, Line);
                        if(DateTime.Now.Second % 5 ==0)
                        return takePos(i + 5, Line);
                        return takePos(i + 3, Line);
                      
                    }

                    if (A[i + 1, Line] == Mark && A[i + 2, Line] == -1 && A[i + 3, Line] == Mark && A[i + 4, Line] == Mark && A[i + 5, Line] == -1)
                    {
                //        //MessageBox.Show("Do It");
                        if (DateTime.Now.Second % 3 == 0)
                            return takePos(i, Line);
                        if (DateTime.Now.Second % 5 == 0)
                            return takePos(i + 5, Line);
                        return takePos(i + 2, Line);
                      
                    }


                 
                   



                }
            }
            return -1;
        }

        int beCareFullLine4(int Mark, int Line)
        {
            for (int i = 0; i < no - 4; i++)
            {

                if (A[i, Line] == -1)
                {

                    if (A[i + 1, Line] == Mark && A[i + 2, Line] == Mark && A[i + 3, Line] == -1 && A[i + 4, Line] == -1)
                        return takePos(i + 3, Line);


                }
            }
            return -1;
        }

        int beCareFullRow3(int Mark, int Row)
        {
           
            for (int i = 0; i < no-4; i++)
            {
               
                if(A[Row, i] == -1)
                {

                    if(A[Row, i+1] == Mark && A[Row,i+2] == -1 && A[Row, i+3] == Mark && A[Row, i+4] == -1)
                        return takePos(Row,i+2);
                    
                   

                }
            }

            return -1;
        }
        int beCareFullRow4(int Mark, int Row)
        {

            for (int i = 0; i < no - 4; i++)
            {

                if (A[Row, i] == -1)
                {

                    if (A[Row, i + 1] == Mark && A[Row, i + 2] == Mark && A[Row, i + 3] == -1 && A[Row, i + 4] == -1)
                        return takePos(Row, i + 3);


                }
            }

            return -1;
        }

        int beCareFullRow5(int Mark, int Row)
        {

            for (int i = 0; i < no - 4; i++)
            {

                if (A[Row, i] == -1)
                {

                    if (A[Row, i + 1] == Mark && A[Row, i + 2] == Mark && A[Row, i + 3] == Mark && A[Row, i + 4] == -1)
                    {
                        if (DateTime.Now.Second % 2 == 0)
                            return takePos(Row, i);
                        return takePos(Row, i + 4);
                    }


                }
            }

            return -1;
        }

        int beCareFullRows2(int Mark)
        {
            int temp = -1;
            for (int i = 0; i < no; i++)
            {
                temp = beCareFullRow5(Mark, i);
                if (temp != -1)
                    return temp;
                temp = beCareFullRow3(Mark, i);
                if (temp != -1)
                    return temp;
                temp = beCareFullRow(Mark, i);
                if (temp != -1)
                    return temp;
                temp = beCareFullRow4(Mark, i);
                if (temp != -1)
                    return temp;
            }
            return temp;
        }

        private void txtKhac_TextChanged(object sender, EventArgs e)
        {

        }

        int isSac(int Mark, int x, int y)
        {
            if (x + 4 >= no || y - 4 < 0)
                return -1;

            if( A[x,y] == -1)
            {
               if(A[x+1,y-1] ==Mark && A[x+2,y-2] ==Mark && A[x+3, y -3] == Mark && A[x+4,y-4] == -1 )
               {
                   if(DateTime.Now.Second % 2 == 0 )
                   {
                       return takePos(x + 4, y - 4);
                   }
                   else
                   {
                       return takePos(x, y);
                   }
               }

              
                
              
            }
            return -1;
        }
        //if (A[x + 1, y - 1] == Mark && A[x + 2, y - 2] == Mark && A[x + 3, y - 3] == Mark && A[x + 4, y - 4] == Mark && A[x+5,y-5] == Mark)
               
        int isSac2(int Mark, int x, int y)
        {
            if (x + 5>= no || y - 5 < 0)
                return -1;

            if (A[x, y] == -1)
            {
                if (A[x + 1, y - 1] == Mark && A[x + 2, y - 2] == -1 && A[x + 3, y - 3] == Mark && A[x + 4, y - 4] == Mark && A[x + 5, y + 5] == Mark)
                {
                    return takePos(x + 2, y - 2);
                }

                if (A[x + 1, y - 1] == Mark && A[x + 2, y - 2] == Mark && A[x + 3, y - 3] == -1 && A[x + 4, y - 4] == Mark && A[x + 5, y + 5] == Mark)
                {
                    return takePos(x + 3, y - 3);
                }

               





            }
            return -1;
        }

        int isSac5(int Mark, int x, int y)
        {
            if (x - 4 <0 || y + 4 >= 0)
                return -1;

            if (A[x, y] == -1)
            {
               if(A[x-1,y+1] == Mark && A[x-2,y+2] == Mark && A[x-3, y+3] == Mark && A[x-4,y+4] ==-1)
               {
                   //MessageBox.Show("Do");
                   if (DateTime.Now.Second % 2 == 0)
                       return takePos(x, y);
                   return takePos(x - 4, y + 4);
               }





            }
            return -1;
        }


        int beCareFulSac(int Mark)
        {
            int temp;
            for(int i=0; i<no; i++)
                for(int j = 0; j<no; j++)
                {
                    temp = isSac5(Mark, i, j);
                    if (temp != -1)
                    {
                        return temp;
                    }
                    temp = isSac(Mark, i, j);
                    if (temp != -1)
                    {
                        return temp;
                    }
                    temp =isSac2(Mark, i, j);
                    if(temp!=-1)
                    {
                        return temp;
                    }
                    temp = isSac3(Mark, i, j);
                    if (temp != -1)
                    {
                        return temp;
                    }

                }
            return -1;
        }


        // Huyền
        int isHuyen(int Mark, int x, int y)
        {
            if (x + 4 >= no || y - 4 < 0)
                return -1;

            if (A[x, y] == -1)
            {
                if (A[x + 1, y + 1] == Mark && A[x + 2, y + 2] == Mark && A[x + 3, y + 3] == Mark && A[x + 4, y + 4] == -1)
                {
                    if (DateTime.Now.Second % 2 == 0)
                    {
                        return takePos(x + 4, y + 4);
                    }
                    else
                    {
                        return takePos(x, y);
                    }
                }




            }
            return -1;
        }
        //if (A[x + 1, y - 1] == Mark && A[x + 2, y - 2] == Mark && A[x + 3, y - 3] == Mark && A[x + 4, y - 4] == Mark && A[x+5,y-5] == Mark)

        int isHuyen2(int Mark, int x, int y)
        {
            if (x + 4 >= no || y + 4 < 0)
                return -1;

            if (A[x, y] == -1)
            {
                if (A[x + 1, y + 1] == Mark && A[x + 2, y + 2] == -1 && A[x + 3, y + 3] == Mark && A[x + 4, y + 4] == Mark && A[x + 5, y + 5] == -1)
                {
                    return takePos(x + 2, y + 2);
                }

                if (A[x + 1, y + 1] == Mark && A[x + 2, y + 2] == Mark && A[x + 3, y + 3] == -1 && A[x + 4, y + 4] == Mark && A[x + 5, y + 5] ==-1)
                {
                    return takePos(x + 3, y + 3);
                }

                if (A[x + 1, y + 1] == Mark && A[x + 2, y + 2] == Mark && A[x + 3, y + 3] == Mark && A[x + 4, y + 4] == -1 && A[x + 5, y + 5] == -1)
                {
                    return takePos(x + 4, y + 4);
                }





            }
            return -1;
        }
        int isSac3(int Mark, int x, int y)
        {
            if (x + 4 >= no || y - 4 < 0)
                return -1;

            if (A[x, y] == Mark)
            {
                if (A[x + 1, y - 1] == -1 && A[x + 2, y - 2] == Mark && A[x + 3, y - 3] == Mark && A[x + 4, y - 4] ==-1)
                    return takePos(x + 1, y - 1);
                if (A[x + 1, y - 1] == Mark && A[x + 2, y - 2] == -1 && A[x + 3, y - 3] == Mark && A[x + 4, y - 4] == -1)
                    return takePos(x + 2, y - 2);
                if (A[x + 1, y - 1] == Mark && A[x + 2, y - 2] == Mark && A[x + 3, y - 3] == -1 && A[x + 4, y - 4] == -1)
                    return takePos(x + 3, y - 3);




            }
            return -1;
        }

        int isHuyen3(int Mark, int x, int y)
        {
            if (x + 4 >= no || y + 4 < 0)
                return -1;

           if(A[x,y] == Mark )
            {
                if (A[x + 1, y + 1] == -1 && A[x + 2, y + 2] == Mark && A[x + 3, y + 3] == Mark && A[x + 4, y + 4] == -1)
                    return takePos(x + 1, y + 1);
                if (A[x + 1, y + 1] == Mark && A[x + 2, y + 2] == -1 && A[x + 3, y + 3] == Mark && A[x + 4, y + 4] == -1)
                    return takePos(x + 2, y + 2);
                if (A[x + 1, y + 1] == Mark && A[x + 2, y + 2] == Mark && A[x + 3, y + 3] == -1 && A[x + 4, y + 4] == -1)
                    return takePos(x + 3, y + 3);
             



            }
            return -1;
        }

        int beCareFulHuyen(int Mark)
        {
            int temp;
            for (int i = 0; i < no; i++)
                for (int j = 0; j < no; j++)
                {
                    
                    temp = isHuyen2(Mark, i, j);
                    if (temp != -1)
                    {
                        return temp;
                    }
                    temp = isHuyen(Mark, i, j);
                    if (temp != -1)
                    {
                        return temp;
                    }

                    temp = isHuyen3(Mark, i, j);
                    if (temp != -1)
                    {
                        return temp;
                    }
                    
                  
                }
            return -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void chkBotFirst_CheckedChanged(object sender, EventArgs e)
        {

            if (chkBotFirst.Checked)
            {
                botFirst = true;
                
            }
            else botFirst = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string a = (DateTime.Now - start).ToString();




            string kq = "";
            DateTime passTime = DateTime.Parse(a);
            string b =  passTime.ToLongTimeString().ToString();

            b = b.Substring(6, b.Length- 6);
            b = b.Substring(0, b.Length - 2);
            //while (b[b.Length -1] != ' ' && b.Length > 0)
            //{
            //    b = b.Substring(0, b.Length - 1);
            //}
            label9.Text = b;
            //if(b.Trim().Equals(StopTime))
            //{
            //    timer2.Enabled = false;
            //    MessageBox.Show("Người chơi thua");
            //    flpBanCo.Enabled = false;
            //}
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        


    }
}
