using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        House[] H;
        room[] R;
        string name;
        Address A;
        double sum = 0;
        int i = 0, j = 0;//i שייך לבתים,j שייך לחדרים

        public void name_address_off()
        {
            txt_city.Visible = false;
            txt_street.Visible = false;
            txt_numhouse.Visible = false;
            lbl_city.Visible = false;
            lbl_num.Visible = false;
            lbl_street.Visible = false;
            lbl_house_name.Visible = false;
            btn_nameaddress.Visible = false;
            txt_house.Visible = false;
        }
        public void option_off()
        {
            txt_printbigarea.Visible = false;
            txt_change.Visible = false;
            txt_erase.Visible = false;
            btn_change.Visible = false;
            btn_erase.Visible = false;
            btn_bigarea.Visible = false;
            btn_newdetails.Visible = false;
        }

        public void option_on()
        {
            txt_printbigarea.Visible = true;
            txt_change.Visible = true;
            txt_erase.Visible = true;
            btn_change.Visible = true;
            btn_erase.Visible = true;
            btn_bigarea.Visible = true;
            btn_newdetails.Visible = true;
        }

        public void name_address_on()
        {
            txt_city.Visible = true;
            txt_street.Visible = true;
            txt_numhouse.Visible = true;
            lbl_city.Visible = true;
            lbl_num.Visible = true;
            lbl_street.Visible = true;
            lbl_house_name.Visible = true;
            btn_nameaddress.Visible = true;
            txt_house.Visible = true;
        }
        public void name_address_clear()
        {
            txt_city.Clear();
            txt_street.Clear();
            txt_house.Clear();
            txt_numhouse.Clear();
        }
        public void manyroom_off()
        {
            txt_howR.Visible = false;
            lbl_rooms.Visible = false;
            btn_roomH.Visible = false;
        }
        public void manyroom_on()
        {
            lbl_house.Visible = false;
            txt_howR.Visible = true;
            lbl_rooms.Visible = true;
            btn_roomH.Visible = true;
        }
        public void room_off()
        {
            lbl_type.Visible = false;
            lbl_size.Visible = false;
            txt_type.Visible = false;
            txt_size.Visible = false;
            chk_shared.Visible = false;
            btn_room.Visible = false;
        }
        public void room_on()
        {
            lbl_type.Visible = true;
            lbl_size.Visible = true;
            txt_type.Visible = true;
            txt_size.Visible = true;
            chk_shared.Visible = true;
            btn_room.Visible = true;
        }
        public void after_add_house_on()
        {
            lbl_change.Visible = true;
            lbl_change.Text = "Which index do you want to change his details? 1 - " + H.Length;
            lbl_erase.Visible = true;
            lbl_erase.Text = "Which index of house do you want to erase? 1 - " + H.Length;
            lbl_bigarea.Visible = true;
            lbl_bigarea.Text = "print the house wuth big area";
        }

        private void btn_numH_Click(object sender, EventArgs e)
        {
            if (txt_numH.Text == "")
                MessageBox.Show("please enter How many houses");
            else
            {
                H = new House[int.Parse(txt_numH.Text)];
                name_address_on();
                lbl_house.Text = "Insert details for house " + (i + 1);
                txt_numH.Enabled = false;
                btn_numH.Enabled = false;
            }
        }

        private void btn_nameaddress_Click(object sender, EventArgs e)
        {
            if (txt_house.Text == "" || txt_city.Text == "" || txt_street.Text == "" || txt_numhouse.Text == "")
                MessageBox.Show("please insert details!");
            else
            {
                name = txt_house.Text;
                A = new Address(txt_city.Text, txt_street.Text, int.Parse(txt_numhouse.Text));
                manyroom_on();
                name_address_off();
                name_address_clear();
            }
        }

        private void btn_roomH_Click(object sender, EventArgs e)
        {
            if (txt_howR.Text == "")
                MessageBox.Show("please enter How many rooms");
            else
            {
                R = new room[int.Parse(txt_howR.Text)];
                room_on();
                lbl_roomnumber.Text = "Insert details of room number" + (i + 1);
                manyroom_off();
                txt_howR.Clear();
            }
        }

        private void btn_room_Click(object sender, EventArgs e)
        {
            if (txt_type.Text == "" || txt_size.Text == "")
                MessageBox.Show("please Insert  details");
            else
            {
                if (chk_shared.Checked)
                    R[j] = new room(txt_type.Text, double.Parse(txt_size.Text), true);
                else
                    R[j] = new room(txt_type.Text, double.Parse(txt_size.Text), false);
                sum += R[j++].Size;
                lbl_roomnumber.Text = "Insert room details " + (j + 1);
                room_on();
                txt_type.Clear();
                txt_size.Clear();
                chk_shared.Checked = false;
                if (j == R.Length)
                {
                    room_off();
                    lbl_roomnumber.Visible = false;
                    H[i++] = new House(name, R, sum, A);
                    j = 0;
                    sum = 0;
                    if (i < H.Length)
                    {
                        name_address_on();
                        lbl_house.Visible = true;
                        lbl_house.Text = "Insert details for house " + (i + 1);
                    }
                    else
                        option_on();

                }

            }
           
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (txt_change.Text == "")
                MessageBox.Show("please inset details!");
            else
            {
                name_address_on();
                name_address_clear();
                btn_newdetails.Visible = true;
            }
        }

        private void btn_newdetails_Click(object sender, EventArgs e)
        {
            if (txt_house.Text == "" || txt_city.Text == "" || txt_street.Text == "" || txt_numhouse.Text == "")
                MessageBox.Show("please inset details!");
            else
            {
                H[int.Parse(txt_change.Text) - 1].Name_house = txt_numhouse.Text;
                H[int.Parse(txt_change.Text) - 1].Add = new Address(txt_city.Text, txt_street.Text, int.Parse(txt_numhouse.Text));
            }
        }

        private void btn_erase_Click(object sender, EventArgs e)
        {
            for (int k = int.Parse(txt_erase.Text)-1; k < H.Length - 1; k++)
            {
                H[k] = H[k + 1];
            }
            txt_printbigarea.Text = "your house is delete!";
        }

        private void btn_bigarea_Click(object sender, EventArgs e)
        {
          
            House h1 = new House("", null, 0, null);
            foreach (House item in H)
                if (item.Sum_size > h1.Sum_size)
                    h1 = item;
            txt_printbigarea.Text = h1.ToString() + "\r\n";

        }

        public Form1()
        {
            InitializeComponent();
            name_address_off();
            manyroom_off();
            room_off();
            option_off();
        }

    }
}
