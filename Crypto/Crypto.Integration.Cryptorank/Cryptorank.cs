using System.Text;
using Crypto.Common.Dto;
using Crypto.Common.Exchanges;
using HtmlAgilityPack;

namespace Crypto.Integration.Cryptorank
{
    public class Cryptorank
    {
        public ExchangeInfoDto GetVolume(string exchangeName)
        {
            var link = ExchangeLinks.Get(exchangeName);

            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
            HtmlDocument document = web.Load(link);

            try
            {
                ExchangeInfoDto exchangeInfoDto = new ExchangeInfoDto();
                int number = default;

                foreach (HtmlNode volume in document.DocumentNode.SelectNodes("//div[contains(@class, 'styled__VolumesBody-sc-1fkiprf-20 cCEvgE')]//div"))
                {
                    var splitVolume = volume.InnerText.Substring(2, volume.InnerText.Length - 2).Split(',');

                    string joinVolume = string.Empty;

                    foreach (var partVolume in splitVolume)
                        joinVolume += partVolume;

                    if (number == default)
                        exchangeInfoDto.VolumeUSD = Convert.ToDecimal(joinVolume);
                    else
                        exchangeInfoDto.VolumeBTC = Convert.ToDecimal(joinVolume);

                    number++;
                }
                return exchangeInfoDto;
            }
            catch (Exception ex) { throw new Exception("Failed to get data " + ex); }
        }
    }
}

