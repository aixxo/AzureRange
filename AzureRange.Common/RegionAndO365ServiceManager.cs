using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureRange.Website
{
    public class RegionAndO365ServiceManager
    {
        /// <summary>
        /// Detailed Azure Regions Descriptions
        /// </summary>
        private List<string> _regionsLocations = new List<string> {
            "uscentral,Central US,Iowa,42.0747,-93.49997,US",
            "useast,East US,Virginia,37.51282,-78.69794,US",
            "useast2,East US 2,Virginia,37.51282,-78.69794,US",
            "usgov1,US Gov Iowa,Iowa,42.0747,-93.49997,US Government",
            "usgov2,US Gov Virginia,Virginia,37.51282,-78.69794,US Government",
            "usnorth,North Central US,Illinois,40.11394,-89.15877,US",
            "ussouth,South Central US,Texas,31.46273,-99.33304,US",
            "uswest,West US,California,37.2551,-119.6175,US",
            "uswest2,West US 2,West US 2,37.2551,-119.6175,US",
            "uswestcentral,West Central US,West Central US,37.2551,-119.6175,US",
            "europenorth,North Europe,Ireland,53.183,-8.199,Europe",
            "europewest,West Europe,Netherlands,52.34226,5.528157,Europe",
            "asiaeast,East Asia,Hong Kong,22.27981,114.1618,Asia",
            "asiasoutheast,Southeast Asia,Singapore,1.321996,103.8205,Asia",
            "brazilsouth,Brazil South,Sao Paulo State,-22.26351,-48.73421,South America",
            "australiaeast,Australia East,New South Wales,-32.16693,147.0125,Autralia",
            "australiasoutheast,Australia Southeast,Victoria,-36.86425,144.3104,Autralia",
            "indiacentral,Central India,Pune,18.52522, 73.84863,India",
            "indiasouth,South India,Chennai,13.07983,80.27008,India",
            "indiawest,West India,Mumbai,18.9488,72.83056,India",
            "chinaeast,China East,Shanghai,31.16961,121.5168,China",
            "chinanorth,China North,Beijing,39.91257,116.389,China",
            "canadacentral,Canada Central,Toronto,43.65317,-79.3827,Canada",
            "canadaeast,Canada East,Quebec City,46.81332,-71.20937,Canada",
            "uksouth,United Kingdon South,London,51.500152,-1.126236,United Kingdom",
            "ukwest,United Kingdom West,Cardiff,51.481307,-3.180498,United Kingdom",
            "japaneast,Japan East,Tokyo,35.68993,139.6918,Japan",
            "japanwest,Japan West,Osaka,34.67752,135.5129,Japan",
            "koreasouth,Korea Central,Busan,35.10278,129.04028,South Korea",
            "koreacentral,Korea South,Seoul,37.566,126.9784,South Korea",
            "germanycentral,Germany Central,Frankfurt,50.11552,8.68417,Germany",
            "germanynortheast,Germany North East,Berlin,52.52437,13.41053,Germany"
            //"uscentraleuap,Central US,Iowa,42.0747,-93.49997,US Canarie",
            //"useast2euap,East US 2,Virginia,37.51282,-78.69794,US Canarie"
        };
        /// <summary>
        /// Detailed Service description
        /// </summary>
        private List<string> _o365Service = new List<string> {
            "EOP,Exchange Online Protection,Office 365",   //0
            "EXO,Exchange,Office 365",      //1
            "Identity,Identity Management,Office 365",  //2
            "LYO,Skype for Business Online,Office 365",    //3
            "o365,Office 365 Authentication Identity Portal and Shared Services,Office 365",  //4
            "OneNote,OneNote,Office 365",   //5
            "Planner,Planner,Office 365",    //6
            "ProPlus,Office ProPlus Download,Office 365",    //7
            "RCA,Remote Connectivity Analyzer,Office 365",    //8
            "SPO,SharePoint Online and OneDrive for Business,Office 365",   //9
            "Sway,Sway,Office 365",   //10
            "Teams,Microsoft Teams,Office 365",   //11
            "WAC,Office Online,Office 365",    //12
            "Yammer,Yammer,Office 365" //13
        };
        /*
          private List<string> _o365Service = new List<string> {
             "EOP,Exchange Online Protection,Office 365",   //0
             "EXO,Exchange Online,Office 365",      //1
             "Identity,Identity Management,Office 365",  //2
             "LYO,Skype for Business Online,Office 365",    //3
             "o365,Office 365 Authentication Identity Portal and Shared Services,Office 365",  //4
             "OneNote,OneNote,Office 365",   //5
             "Planner,Planner,Office 365",    //6
             "ProPlus,Office ProPlus Download,Office 365",    //7
             "RCA,Remote Connectivity Analyzer,Office 365",    //8
             "SPO,SharePoint Online and OneDrive for Business,Office 365",   //9
             "Sway,Sway,Office 365",   //10
             "Teams,Microsoft Teams,Office 365",   //11
             "WAC,Office Online,Office 365",    //12
             "Yammer,Yammer,Office 365" //13
         };
         */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regionList"> list of regions
        /// </param>
        /// <returns>
        /// function returns the list of regions objects along with detailed description (coordinates, etc.)
        /// </returns>
        public List<AzureRegion> GetAzureRegions(List<string> regionList)

        {
            List<AzureRegion> regions = new List<AzureRegion>();
            foreach(var regionName in regionList)
            {
                var line = _regionsLocations.FirstOrDefault(r => r.StartsWith(regionName));
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var splittedLine = line.Split(',');
                    regions.Add(new AzureRegion
                    {
                        Id = regionName,
                        Name = splittedLine[1],
                        Location = splittedLine[2],
                        Latitude = double.Parse(splittedLine[3]),
                        Longitude = double.Parse(splittedLine[4]),
                        Geography = splittedLine[5]
                    });
                }
            }
            return regions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o365serviceList"> list of o365 services, a string
        /// </param>
        /// <returns>
        /// function returns the list of o365 services along with detailed description (returns the objects)
        /// </returns>
        public List<O365Service> GetO365Services(List<string> o365serviceList)
        {
            List<O365Service> o365services = new List<O365Service>();
            foreach (var serviceName in o365serviceList)
            {
                var line = _o365Service.FirstOrDefault(r => r.StartsWith(serviceName));
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var splittedLine = line.Split(',');
                    o365services.Add(new O365Service
                    {
                        Id = serviceName,
                        Name = splittedLine[1]
                    });
                }
            }
            return o365services;
        }

    }
}