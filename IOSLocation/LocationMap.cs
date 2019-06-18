using IOSLocation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOSLocation
{
    [ComVisible(true)]
    public partial class LocationMap : Form
    {
        public LocationMap()
        {
            InitializeComponent();
        }

        private void LocationMap_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            string str = File.ReadAllText("Other/map.html");
            if (!string.IsNullOrEmpty(LocationByPhone.LocationByPhoneForm.TextLocation.Text))
            {
                string[] array = LocationByPhone.LocationByPhoneForm.TextLocation.Text.Split(',');
                str = str + "evaluatepoint(" + array[0] + "," + array[1] + ");";
            }
            str += "</script>";
            webBrowser1.DocumentText = str;
            webBrowser1.ObjectForScripting = this;
            BindShareLocation();
        }

        /// <summary>
        /// 定位（webbrowser使用）
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="longitude">纬度</param>
        /// <param name="location">位置</param>
        public void position(string longitude, string latitude, string location)
        {
            label3.Text = latitude;
            label4.Text = longitude;
            label5.Text = location;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string text = comboBox1.SelectedValue?.ToString();
            if (!string.IsNullOrWhiteSpace(text) && text.IndexOf(",") > 0)
            {
                string[] array = text.Split(',');
                object[] args = new object[2]
                {
                    array[0],
                    array[1]
                };
                webBrowser1.Document.InvokeScript("evaluatepoint", args);
            }
        }

        /// <summary>
        /// 绑定分享位置
        /// </summary>
        private void BindShareLocation(List<LocationModel> ls = null)
        {
            if (ls == null || ls.Count <= 0)
            {
                ls = LocationModel.GetLocation();
            }
            this.comboBox1.DataSource = ls;
            this.comboBox1.ValueMember = "Location";
            this.comboBox1.DisplayMember = "Alias";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem == null)
            {
                MessageBox.Show("已经没有可以删除的坐标点了");
                return;
            }
            BindShareLocation(LocationModel.DelLocation(((LocationModel)this.comboBox1.SelectedItem).Alias));
            LocationByPhone.LocationByPhoneForm.BindShareLocation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindShareLocation(LocationModel.AddLocation(new LocationModel()
            {
                Alias = this.textBox1.Text,
                Latitude = label4.Text,
                Longitude = label3.Text,
                LocationName = label5.Text
            }));
            LocationByPhone.LocationByPhoneForm.BindShareLocation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LocationByPhone.LocationByPhoneForm.TextLocation.Text = label3.Text + "," + label4.Text;
            Close();
        }
    }
}
