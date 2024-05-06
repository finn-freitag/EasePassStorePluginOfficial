using EasePassExtensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EasePassStorePluginOfficial
{
    public class ExtensionSource : IExtensionSource
    {
        public string SourceName => "Official Ease Pass Store";
        public bool UseAsync => true;

        public (Uri Source, string Name)[] GetExtensionSources()
        {
            throw new NotImplementedException();
        }

        public async Task<(Uri Source, string Name)[]> GetExtensionSourcesAsync()
        {
            string url = "https://github.com/FrozenAssassine/EasePass/raw/master/Plugins/PluginList.txt";

            var result = await MakeRequest(url);
            if (!result.success)
                return new (Uri, string)[0];

            List<(Uri Source, string Name)> items = new();

            var entries = result.result.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pluginURL in entries)
            {
                var pluginData = pluginURL.Split("|");
                if (pluginData.Length < 2)
                    continue;

                items.Add((new Uri(pluginData[1]), pluginData[0]));
            }
            return items.ToArray();
        }

        public static async Task<(bool success, string result)> MakeRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return (true, result);
                    }
                }
                catch { }
                return (false, "");
            }
        }
    }
}
