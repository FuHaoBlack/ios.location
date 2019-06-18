using IOSLocation.Model;
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

namespace IOSLocation
{
    public partial class LocationByPhone : Form
    {
        public static LocationByPhone LocationByPhoneForm;
        /// <summary>
        /// 手机集合
        /// </summary>
        List<PhoneModel> PhoneList = null;

        /// <summary>
        /// 运行地址
        /// </summary>
        string basePath = string.Empty;


        #region action


        /// <summary>
        /// 加载手机
        /// </summary>
        private void PhoneCheck()
        {
            PhoneList = PhoneModel.PhoneCheck();
            this.cmbPhone.DataSource = PhoneList;
            this.cmbPhone.ValueMember = "PhoneId";
            this.cmbPhone.DisplayMember = "PhoneName";
            if (PhoneList.Count <= 0)
            {
                Log("暂无获取到手机数据，请插入数据线连接手机并点击信任");
            }
            else
            {
                Log("获取到" + PhoneList.Count + "台设备，请选择设备连接。");
            }
        }

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="str"></param>
        public void Log(string str)
        {
            if (TextLog.Text.Length >= 20000)
            {
                TextLog.Text = "";
            }
            TextLog.AppendText(DateTime.Now.ToString("HH:mm:ss ") + str + "\r\n\r\n");
        }

        /// <summary>
        /// 绑定分享位置
        /// </summary>
        public void BindShareLocation(List<LocationModel> ls = null)
        {
            if (ls == null || ls.Count <= 0)
            {
                ls = LocationModel.GetLocation();
            }
            string last = "";
            if (File.Exists(basePath + "lastLocation.txt"))
            {
                last = File.ReadAllText(basePath + "lastLocation.txt");
            }
            if (!string.IsNullOrWhiteSpace(last))
            {
                ls.Insert(0, new LocationModel()
                {
                    Alias = "最后位置",
                    Longitude = last.Split(',')[0],
                    Latitude = last.Split(',')[1],
                    LocationName = "最后定位位置"
                });
            };
            this.cmbLocation.DataSource = ls;
            this.cmbLocation.ValueMember = "Location";
            this.cmbLocation.DisplayMember = "Alias";
        }

        /// <summary>
        /// 定位
        /// </summary>
        private void PhoneLocation()
        {
            File.WriteAllText(basePath + "lastLocation.txt", this.TextLocation.Text);
            PhoneModel.PhoneLocation(this.TextLocation.Text, this.TextDeviation.Text);
        }

        /// <summary>
        /// 定位类型（偷懒才用中文枚举，其他开发同学别学我）
        /// </summary>
        public enum LocationType
        {
            /// <summary>
            /// 东
            /// </summary>
            East,
            
            /// <summary>
            /// 西
            /// </summary>
            West,

            /// <summary>
            /// 南
            /// </summary>
            South,

            /// <summary>
            /// 北
            /// </summary>
            North,

            /// <summary>
            /// 东南
            /// </summary>
            Southeast,

            /// <summary>
            /// 西南
            /// </summary>
            Southwest,

            /// <summary>
            /// 东北
            /// </summary>
            Northeast,

            /// <summary>
            /// 西北
            /// </summary>
            Northwest
        }

        private void LocationChangeByRun(LocationType ltype)
        {
            var split = this.TextLocation.Text.Split(',');
            switch (ltype)
            {
                case LocationType.East:
                    this.TextLocation.Text = (Convert.ToDouble(split[0]) + Convert.ToDouble(this.TextSpeed.Text)) + "," + Convert.ToDouble(split[1]);
                    break;
                case LocationType.West:
                    this.TextLocation.Text = (Convert.ToDouble(split[0]) - Convert.ToDouble(this.TextSpeed.Text)) + "," + Convert.ToDouble(split[1]);
                    break;
                case LocationType.South:
                    this.TextLocation.Text = split[0] + "," + (Convert.ToDouble(split[1]) - Convert.ToDouble(this.TextSpeed.Text));
                    break;
                case LocationType.North:
                    this.TextLocation.Text = split[0] + "," + (Convert.ToDouble(split[1]) + Convert.ToDouble(this.TextSpeed.Text));
                    break;
                case LocationType.Southeast:
                    this.TextLocation.Text = (Convert.ToDouble(split[0]) + Convert.ToDouble(this.TextSpeed.Text)) + "," + (Convert.ToDouble(split[1]) - Convert.ToDouble(this.TextSpeed.Text));
                    break;
                case LocationType.Southwest:
                    this.TextLocation.Text = (Convert.ToDouble(split[0]) - Convert.ToDouble(this.TextSpeed.Text)) + "," + (Convert.ToDouble(split[1]) - Convert.ToDouble(this.TextSpeed.Text));
                    break;
                case LocationType.Northeast:
                    this.TextLocation.Text = (Convert.ToDouble(split[0]) + Convert.ToDouble(this.TextSpeed.Text)) + "," + (Convert.ToDouble(split[1]) + Convert.ToDouble(this.TextSpeed.Text));
                    break;
                case LocationType.Northwest:
                    this.TextLocation.Text = (Convert.ToDouble(split[0]) - Convert.ToDouble(this.TextSpeed.Text)) + "," + (Convert.ToDouble(split[1]) + Convert.ToDouble(this.TextSpeed.Text));
                    break;
            }
            PhoneLocation();
        }
        #endregion

        public LocationByPhone()
        {
            LocationByPhoneForm = this;
            PhoneModel.PhoneInit();
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("chrome.exe", "https://github.com/FuHaoBlack/ios.location");
            }
            catch
            {
                try
                {
                    System.Diagnostics.Process.Start("360chrome.exe", "https://github.com/FuHaoBlack/ios.location");
                }
                catch
                {
                    try
                    {
                        System.Diagnostics.Process.Start("iexplore.exe", "https://github.com/FuHaoBlack/ios.location");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("浏览器都没有，自己上github搜 FuHaoBlack 找作者吧");
                    }
                }
            }


        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            PhoneLocation();
        }

        private void LocationByPhone_Load(object sender, EventArgs e)
        {
            basePath = AppDomain.CurrentDomain.BaseDirectory + "Other\\";
            PhoneCheck();
            BindShareLocation();
            if (PhoneList != null && PhoneList.Count > 0)
            {
                PhoneModel model = PhoneList.Where(o => o.PhoneId == cmbPhone.SelectedValue.ToString()).FirstOrDefault();
                PhoneModel.PhoneConn(model);
            }
        }

        private void btnCheckPhone_Click(object sender, EventArgs e)
        {
            PhoneCheck();
        }

        private void btnSelectPhone_Click(object sender, EventArgs e)
        {
            if (PhoneList != null && PhoneList.Count > 0)
            {
                PhoneModel model = PhoneList.Where(o => o.PhoneId == cmbPhone.SelectedValue.ToString()).FirstOrDefault();
                PhoneModel.PhoneConn(model);
            }
        }

        private void btnLocationReset_Click(object sender, EventArgs e)
        {
            PhoneModel.PhoneReset();
        }

        private void BtnMap_Click(object sender, EventArgs e)
        {
            LocationMap locationMap = new LocationMap();
            locationMap.ShowDialog();
        }

        private void btnLocationXB_Click(object sender, EventArgs e)
        {
            LocationChangeByRun(LocationType.Northwest);
        }

        private void btnLocationB_Click(object sender, EventArgs e)
        {
            LocationChangeByRun(LocationType.North);
        }

        private void btnLocationDB_Click(object sender, EventArgs e)
        {
            LocationChangeByRun(LocationType.Northeast);
        }

        private void btnLocationX_Click(object sender, EventArgs e)
        {
            LocationChangeByRun(LocationType.West);
        }

        private void btnLocationD_Click(object sender, EventArgs e)
        {
            LocationChangeByRun(LocationType.East);
        }

        private void btnLocationXN_Click(object sender, EventArgs e)
        {
            LocationChangeByRun(LocationType.Southwest);
        }

        private void btnLocationN_Click(object sender, EventArgs e)
        {
            LocationChangeByRun(LocationType.South);
        }

        private void btnLocationDN_Click(object sender, EventArgs e)
        {
            LocationChangeByRun(LocationType.Southeast);
        }

        private void cmbLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            this.TextLocation.Text = this.cmbLocation.SelectedValue?.ToString();
        }
    }
}
