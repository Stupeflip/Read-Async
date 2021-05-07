using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

class Download
{
    public static HttpClient Client { get; set; }

    public async Task<bool> DownloadFileAsync(Uri u, string fn, string dts)
    {
        try
        {
            var e = Path.GetExtension(u.AbsoluteUri);

            var ip = new DirectoryInfo(dts).FullName;

            using (Client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                byte[] c = await Client.GetAsync(u).Result.Content.ReadAsByteArrayAsync();

                var ms = new MemoryStream(c);

                if (ms.Length < 1) return false;

                var i = System.Drawing.Image.FromStream(ms);

                switch (e)
                {
                    case "gif":
                        i.Save($"{ip}\\{fn}{e}", System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "png":
                        i.Save($"{ip}\\{fn}{e}", System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case "jpg":
                        i.Save($"{ip}\\{fn}{e}", System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    default:
                        return false;
                }

                return true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
