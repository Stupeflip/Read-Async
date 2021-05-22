using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

public class Read
{
     public static async Task<IEnumerable<string>> LoadAsListAsync(string path)
        {
            byte[] res;

            try
            {
                using FileStream fs = File.Open(path, FileMode.Open);

                res = new byte[fs.Length];

                await fs.ReadAsync(res.AsMemory(0, (int)fs.Length));

                return Encoding.UTF8.GetString(res).Split(' ', 
                    StringSplitOptions.RemoveEmptyEntries);
            }

            catch { return null; }
        }

}
