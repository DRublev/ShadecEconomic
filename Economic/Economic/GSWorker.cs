using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Economic
{
	/// <summary>
	/// Working with Google Spreadsheets
	/// </summary>
	public class GSWorker
	{
		private static GSWorker instance = null;
		public static GSWorker Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new GSWorker();
				}

				return instance;
			}
		}

		private UserCredential credential;
		private static SheetsService sheetsService = null;

		private static string[] scopes = { SheetsService.Scope.Spreadsheets };
		private const string spreadheetId = "1K_mWlNjXGl_txJuW-XuCspVQ5yBm6zPOseU7BIZou5U";
		private const string sheetName = "test";

		public GSWorker()
		{
			FillCredential();

			sheetsService = new SheetsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = "ShadecEconomic"
			});
		}

		private void FillCredential()
		{
			using (var stream =
				new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
			{
				string credentialPath = "token.json";
				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					scopes,
					"shadec@shadececonomic-1535323001348.iam.gserviceaccount.com",
					CancellationToken.None,
					new FileDataStore(credentialPath, true)).Result;
			}
		}

		public List<List<object>> ReadDataFromSheet(string sheetName = sheetName, string rangeCols = "A:D")
		{
			List<List<object>> result = new List<List<object>>();

			string range = $"{sheetName}!{rangeCols}";
			SpreadsheetsResource.ValuesResource.GetRequest request =
				sheetsService.Spreadsheets.Values.Get(spreadheetId, range);

			try
			{
				ValueRange response = request.Execute();

				IList<IList<object>> values = response.Values;

				if (values != null && values.Count > 0)
				{
					foreach (var row in values)
					{
						result.Add((List<object>)row);
					}
				}
			}
			catch(Exception ex)
			{
				// TODO: Do a fucking Logger!

				Console.WriteLine(ex.Message);
			}

			return result;
		}

		public void InsertDataToSheet(List<object> data, string sheetName = sheetName, string rangeCols = "A:D")
		{
			var range = $"{sheetName}!{rangeCols}";
			var valueRange = new ValueRange();

			valueRange.Values = new List<IList<object>> { data };

			var appendRequest = sheetsService.Spreadsheets.Values.Append(valueRange, spreadheetId, range);
			appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
			var appendReponse = appendRequest.Execute();
		}

		public void UpdateDataInSheet(List<object> data, string sheetName = sheetName, string rangeCols = "A:D")
		{
			var range = $"{sheetName}!{rangeCols}";
			var valueRange = new ValueRange();

			valueRange.Values = new List<IList<object>> { data };

			var updateRequest = sheetsService.Spreadsheets.Values.Update(valueRange, spreadheetId, range);
			updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
			var appendReponse = updateRequest.Execute();
		}

		public void DeleteEntry(string sheetName = sheetName, string rangeCols = "A:D")
		{
			var range = $"{sheetName}!{rangeCols}";
			var requestBody = new ClearValuesRequest();

			var deleteRequest = sheetsService.Spreadsheets.Values.Clear(requestBody, spreadheetId, range);
			var deleteReponse = deleteRequest.Execute();
		}
	}
}
