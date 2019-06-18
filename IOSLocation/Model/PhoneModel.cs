using iMobileDevice;
using iMobileDevice.iDevice;
using iMobileDevice.Lockdown;
using iMobileDevice.Plist;
using iMobileDevice.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSLocation.Model
{
    public class PhoneModel
    {
        /// <summary>
        /// 手机ID
        /// </summary>
        public static string phoneId = "";
        public string PhoneId { get; set; }

        public string PhoneVersion { get; set; }

        public string PhoneName { get; set; }

        /// <summary>
        /// 初始化加载
        /// </summary>
        public static void PhoneInit()
        {
            NativeLibraries.Load();
        }

        /// <summary>
        /// 检测手机
        /// </summary>
        /// <returns></returns>
        public static List<PhoneModel> PhoneCheck()
        {
            List<PhoneModel> lp = new List<PhoneModel>();
            int count = 0;
            ReadOnlyCollection<string> udids;
            var idevice = LibiMobileDevice.Instance.iDevice;
            var lockdown = LibiMobileDevice.Instance.Lockdown;

            var ret = idevice.idevice_get_device_list(out udids, ref count);

            if (ret == iDeviceError.NoDevice)
            {
                // Not actually an error in our case
                return lp;
            }

            ret.ThrowOnError();

            // Get the device name
            foreach (var udid in udids)
            {
                iDeviceHandle deviceHandle;
                idevice.idevice_new(out deviceHandle, udid).ThrowOnError();

                LockdownClientHandle lockdownHandle;//Quamotion
                lockdown.lockdownd_client_new_with_handshake(deviceHandle, out lockdownHandle, "Quamotion").ThrowOnError();

                string deviceName;
                lockdown.lockdownd_get_device_name(lockdownHandle, out deviceName).ThrowOnError();


                string val = "";
                var handshake = lockdown.lockdownd_client_new_with_handshake(deviceHandle, out lockdownHandle, "");
                var getProductVersion = lockdown.lockdownd_get_value(lockdownHandle, null, "ProductVersion", out PlistHandle value);

                if (handshake == LockdownError.Success && getProductVersion == LockdownError.Success)
                {
                    LibiMobileDevice.Instance.Plist.plist_get_string_val(value, out val);
                }
                deviceHandle.Dispose();
                lockdownHandle.Dispose();
                if (string.IsNullOrWhiteSpace(val))
                {
                    val = "获取设备版本失败";
                }
                lp.Add(new PhoneModel()
                {
                    PhoneId = udid,
                    PhoneVersion = val,
                    PhoneName = deviceName
                });
            }
            return lp;
        }

        /// <summary>
        /// 链接手机
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static void PhoneConn(PhoneModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.PhoneId) || string.IsNullOrWhiteSpace(model.PhoneVersion))
            {
                LocationByPhone.LocationByPhoneForm.Log("无法连接手机，请重新检测设备");
            }
            
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "Other\\";
            string text = model.PhoneVersion.Split('.')[0] + "." + model.PhoneVersion.Split('.')[1];
            if (File.Exists(Path.Combine(basePath + "/drivers/" + text + "/", "inject.dmg")))
            {
                try
                {
                    string fileName = basePath + "injecttool.exe";
                    Process process = new Process();
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = false;
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.CreateNoWindow = true;
                    string arguments = ".\\drivers\\" + text + "\\inject.dmg";
                    process.StartInfo.Arguments = arguments;
                    process.Start();
                    process.WaitForExit();
                    LocationByPhone.LocationByPhoneForm.Log($"链接手机{model.PhoneName}成功，设备版本：{model.PhoneVersion}");
                    phoneId = model.PhoneId;
                }
                catch (Exception ex)
                {
                    LocationByPhone.LocationByPhoneForm.Log($"链接手机{model.PhoneName}失败，原因：{ex.Message}");
                }
            }
            else
            {
                LocationByPhone.LocationByPhoneForm.Log($"链接手机{model.PhoneName}失败，原因：无该版本drivers，请自己上网搜了下载，不然用不了");
            }

        }

        /// <summary>
        /// 发起定位修改
        /// </summary>
        /// <param name="location">定位</param>
        /// <param name="deviation">偏移量</param>
        public static void PhoneLocation(string location, string deviation)
        {
            try
            {
                string[] array = location.Split(',');
                string[] deviationArray = deviation.Split(',');
                if (array != null && array.Length == 2)
                {
                    string jingdu = array[0];
                    string weidu = array[1];
                    jingdu = (double.Parse(jingdu) - double.Parse(deviationArray[0])).ToString();
                    weidu = (double.Parse(weidu) - double.Parse(deviationArray[1])).ToString();
                    IiDeviceApi iDevice = LibiMobileDevice.Instance.iDevice;
                    ILockdownApi lockdown = LibiMobileDevice.Instance.Lockdown;
                    IServiceApi service = LibiMobileDevice.Instance.Service;
                    iDevice.idevice_set_debug_level(1);
                    if (iDevice.idevice_new(out iDeviceHandle device, phoneId) == iDeviceError.NoDevice)
                    {
                        //设备未连接
                        LocationByPhone.LocationByPhoneForm.Log("设备未连接");
                    }
                    else
                    {
                        LocationByPhone.LocationByPhoneForm.Log($"发起定位修改：经度{jingdu},纬度{weidu}");
                        var jailoutresult = lockdown.lockdownd_client_new_with_handshake(device, out LockdownClientHandle client, "com.alpha.jailout");
                        var bbb = lockdown.lockdownd_start_service(client, "com.apple.dt.simulatelocation", out LockdownServiceDescriptorHandle service2);
                        service.service_client_new(device, service2, out ServiceClientHandle client2);
                        uint sent = 0u;
                        byte[] bytes = BitConverter.GetBytes(0u);
                        if (BitConverter.IsLittleEndian)
                        {
                            Array.Reverse(bytes);
                        }
                        var zz = service.service_send(client2, bytes, (uint)bytes.Length, ref sent);
                        uint sent2 = 0u;
                        byte[] array2 = BitConverter.GetBytes((uint)weidu.Length);
                        if (BitConverter.IsLittleEndian)
                        {
                            Array.Reverse(array2);
                        }
                        byte[] array3 = Encoding.ASCII.GetBytes(weidu);
                        var bb = service.service_send(client2, array2, (uint)array2.Length, ref sent2);
                        if (service.service_send(client2, array3, (uint)array3.Length, ref sent2) != 0)
                        {
                            LocationByPhone.LocationByPhoneForm.Log("修改定位失败");
                        }
                        else
                        {
                            byte[] array4 = BitConverter.GetBytes((uint)jingdu.Length);
                            if (BitConverter.IsLittleEndian)
                            {
                                Array.Reverse(array4);
                            }
                            byte[] bytes2 = Encoding.ASCII.GetBytes(jingdu);
                            service.service_send(client2, array4, (uint)array4.Length, ref sent2);
                            if (service.service_send(client2, bytes2, (uint)bytes2.Length, ref sent2) != 0)
                            {
                                LocationByPhone.LocationByPhoneForm.Log("修改定位失败");
                            }
                            else
                            {
                                LocationByPhone.LocationByPhoneForm.Log("修改定位成功");
                            }
                        }
                    }
                }
                else
                {
                    LocationByPhone.LocationByPhoneForm.Log("输入坐标有误，请重新输入");
                }
            }
            catch (Exception ex)
            {
                LocationByPhone.LocationByPhoneForm.Log("修改定位失败,原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 复原位置
        /// </summary>
        public static void PhoneReset()
        {
            try
            {
                IiDeviceApi iDevice = LibiMobileDevice.Instance.iDevice;
                ILockdownApi lockdown = LibiMobileDevice.Instance.Lockdown;
                IServiceApi service = LibiMobileDevice.Instance.Service;
                iDevice.idevice_set_debug_level(1);
                if (iDevice.idevice_new(out iDeviceHandle device, phoneId) == iDeviceError.NoDevice)
                {
                    LocationByPhone.LocationByPhoneForm.Log("设备未连接");
                }
                else
                {
                    LocationByPhone.LocationByPhoneForm.Log("开始复原位置");
                    var jailoutresult = lockdown.lockdownd_client_new_with_handshake(device, out LockdownClientHandle client, "com.alpha.jailout");
                    var bbb = lockdown.lockdownd_start_service(client, "com.apple.dt.simulatelocation", out LockdownServiceDescriptorHandle service2);
                    service.service_client_new(device, service2, out ServiceClientHandle client2);
                    uint sent = 0u;
                    byte[] bytes = BitConverter.GetBytes(1u);
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(bytes);
                    }
                    if (service.service_send(client2, bytes, (uint)bytes.Length, ref sent) != 0)
                    {
                        LocationByPhone.LocationByPhoneForm.Log("复原位置失败");
                    }
                    else
                    {
                        IiDeviceApi iDevice2 = LibiMobileDevice.Instance.iDevice;
                        ILockdownApi lockdown2 = LibiMobileDevice.Instance.Lockdown;
                        IServiceApi service3 = LibiMobileDevice.Instance.Service;
                        iDevice2.idevice_set_debug_level(1);
                        if (iDevice2.idevice_new(out iDeviceHandle device2, null) != iDeviceError.NoDevice)
                        {

                            lockdown.lockdownd_client_new_with_handshake(device, out LockdownClientHandle client3, "com.alpha.jailout");
                            lockdown.lockdownd_start_service(client3, "com.apple.dt.simulatelocation", out LockdownServiceDescriptorHandle service4);
                            service3.service_client_new(device2, service4, out ServiceClientHandle client4);
                            uint sent2 = 0u;
                            byte[] bytes2 = BitConverter.GetBytes(1u);
                            if (BitConverter.IsLittleEndian)
                            {
                                Array.Reverse(bytes2);
                            }
                            service3.service_send(client4, bytes2, (uint)bytes2.Length, ref sent2);
                            LocationByPhone.LocationByPhoneForm.Log("复原位置成功");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LocationByPhone.LocationByPhoneForm.Log($"复原位置失败，原因：{ex.Message}");
            }
        }
    }
}
