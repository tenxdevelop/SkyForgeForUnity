/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;
using UnityEngine;
using System.IO;
using System;

namespace SkyForge.Extention.GoogleImporter
{
    public abstract class GoogleSheetsImporter
    {
        private readonly string m_spreadSheetId;
        private readonly List<string> m_headers;
        private SheetsService m_sheetsService;

        public GoogleSheetsImporter(string spreadSheetId)
        {
            m_spreadSheetId = spreadSheetId;
            m_headers = new List<string>();
        }

        public GoogleSheetsImporter CreateWithCredentials(string credentialsPath)
        {
            GoogleCredential credential;
            try
            {
                using (var fileStream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(fileStream).CreateScoped(SheetsService.ScopeConstants.SpreadsheetsReadonly);

                }

                m_sheetsService = new SheetsService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential
                });

                return this;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error can't create GoogleSheetsImporter, error: {ex.Message}");
                return null;
            }
        }

        public async Task DownloadAndParseSheets(string sheetName)
        {
            Debug.Log($"Downloading sheet: {sheetName} ....");

            var range = $"{sheetName}!A1:Z";
            var request = m_sheetsService.Spreadsheets.Values.Get(m_spreadSheetId, range);

            ValueRange responce;
            try
            {
                responce = await request.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error retrieving Google Sheets data: {ex.Message}");
                return;
            }

            if (responce is not null && responce.Values is not null)
            {
                var tableList = responce.Values;
                Debug.Log($"Sheet downloaded successfully: {sheetName}");
                Debug.Log($"Parsing sheet: {sheetName} ...");

                var firstRow = tableList[0];
                foreach (var cell in firstRow)
                {
                    m_headers.Add(cell.ToString());
                }

                var rowsCount = tableList.Count;
                for (var rowIndex = 1; rowIndex < rowsCount; rowIndex++)
                {
                    var row = tableList[rowIndex];
                    var countElement = row.Count;

                    for (var elementIndex = 0; elementIndex < countElement; elementIndex++)
                    {
                        var element = row[elementIndex].ToString();

                        if (!string.IsNullOrEmpty(element))
                        {
                            var header = m_headers[elementIndex];
                            ParseCell(header, element);
                        }
                    }
                }

                Debug.Log($"Sheet parsed successfully: {sheetName}");
            }
            else
            {
                Debug.LogWarning($"No data found in Google Sheet: {sheetName}");
            }

        }

        protected abstract void ParseCell(string header, string cellData);
    }
}
