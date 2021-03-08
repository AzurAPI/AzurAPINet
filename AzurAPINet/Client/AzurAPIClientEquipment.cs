using System;
using Jan0660.AzurAPINet.Equipments;

namespace Jan0660.AzurAPINet.Client
{
    public class AzurAPIClientEquipment
    {
        private AzurAPIClient _client;

        public AzurAPIClientEquipment(AzurAPIClient client)
        {
            this._client = client;
        }

        public Equipment name(string name)
            => _client.getEquipmentByEnglishName(name)
               ?? _client.getEquipmentByJapaneseName(name)
               ?? _client.getEquipmentByChineseName(name)
               ?? _client.getEquipmentByKoreanName(name);

        /// <summary>
        /// gets an equipment by its english, japanese or chinese name only
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language">one of "english", "japanese" ,"korean", "chinese"</param>
        /// <returns></returns>
        public Equipment name(string name, string language)
            => language.ToLower() switch
            {
                "english" => _client.getEquipmentByEnglishName(name),
                "japanese" => _client.getEquipmentByJapaneseName(name),
                "chinese" => _client.getEquipmentByChineseName(name),
                "korean" => _client.getEquipmentByKoreanName(name),
                _ => throw new Exception("Invalid language.")
            };
    }
}