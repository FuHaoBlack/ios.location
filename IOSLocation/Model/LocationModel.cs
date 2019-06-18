using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSLocation.Model
{
    public class LocationModel
    {
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// 位置名称
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 经纬度
        /// </summary>
        public string Location
        {
            get
            {
                return Longitude + "," + Latitude;
            }
        }

        /// <summary>
        /// 获取本地化坐标
        /// </summary>
        /// <returns></returns>
        public static List<LocationModel> GetLocation()
        {
            try
            {
                string location = File.ReadAllText("Other/ShareLocation.data", Encoding.UTF8);
                return JsonConvert.DeserializeObject<List<LocationModel>>(location);
            }
            catch (Exception ex)
            {
                return new List<LocationModel>();
            }
        }

        /// <summary>
        /// 添加新位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<LocationModel> AddLocation(LocationModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Alias) || string.IsNullOrWhiteSpace(model.Latitude) || string.IsNullOrWhiteSpace(model.Longitude))
            {
                System.Windows.Forms.MessageBox.Show("保存失败，数据异常");
            }
            List<LocationModel> ls;
            try
            {
                string location = File.ReadAllText("Other/ShareLocation.data", Encoding.UTF8);
                ls = JsonConvert.DeserializeObject<List<LocationModel>>(location);
            }
            catch (Exception ex)
            {
                ls = new List<LocationModel>();
            }
            ls.Insert(0, model);
            File.WriteAllText("Other/ShareLocation.data", JsonConvert.SerializeObject(ls), Encoding.UTF8);
            return ls;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<LocationModel> DelLocation(string Alias)
        {
            if (string.IsNullOrWhiteSpace(Alias))
            {
                System.Windows.Forms.MessageBox.Show("删除失败，数据异常");
            }
            List<LocationModel> ls;
            try
            {
                string location = File.ReadAllText("Other/ShareLocation.data", Encoding.UTF8);
                ls = JsonConvert.DeserializeObject<List<LocationModel>>(location);
            }
            catch (Exception ex)
            {
                ls = new List<LocationModel>();
            }
            ls.RemoveAll(o => o.Alias == Alias);
            File.WriteAllText("Other/ShareLocation.data", JsonConvert.SerializeObject(ls), Encoding.UTF8);
            return ls;
        }
    }
}
