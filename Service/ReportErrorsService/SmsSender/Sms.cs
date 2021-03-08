using System;

namespace SmsSender
{
    public class Sms
    {
		private string _sender;
		private string _sendTo;

		public Sms(SmsParams smsParams)
        {
			_sender = smsParams.Sender;
			_sendTo = smsParams.SendTo;
        }
  //      public async Task SendSms(string sender, string sendTo, string message)
  //      {
		//	try
		//	{
		//		SMSApi.Api.IClient client = new SMSApi.Api.ClientOAuth("oTbPvveN7C9kelZ1SzYXsDpA5x33h6l61Mc5xjeg");

		//		var smsApi = new SMSApi.Api.SMSFactory(client);

		//		var result =
		//			smsApi.ActionSend()
		//				.SetText("test message")
		//				.SetTo("0000000000")
		//				.SetSender("Test") 
		//				.Execute();

		//		System.Console.WriteLine("Send: " + result.Count);

		//		string[] ids = new string[result.Count];

		//		for (int i = 0, l = 0; i < result.List.Count; i++)
		//		{
		//			if (!result.List[i].isError())
		//			{
		//				if (!result.List[i].isFinal())
		//				{
		//					ids[l] = result.List[i].ID;
		//					l++;
		//				}
		//			}
		//		}

		//		System.Console.WriteLine("Get:");
		//		result =
		//			smsApi.ActionGet()
		//				.Ids(ids)
		//				.Execute();

		//		foreach (var status in result.List)
		//		{
		//			System.Console.WriteLine("ID: " + status.ID + " NUmber: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
		//		}

		//		for (int i = 0, l = 0; i < result.List.Count; i++)
		//		{
		//			if (!result.List[i].isError())
		//			{
		//				var deleted =
		//					smsApi.ActionDelete()
		//						.Id(result.List[i].ID)
		//						.Execute();
		//				Console.WriteLine("Deleted: " + deleted.Count);
		//			}
		//		}
		//	}
		//	catch (SMSApi.Api.ActionException e)
		//	{
		//		Console.WriteLine(e.Message);
		//	}
		//	catch (SMSApi.Api.ClientException e)
		//	{
		//		Console.WriteLine(e.Message);
		//	}
		//	catch (SMSApi.Api.HostException e)
		//	{
		//		Console.WriteLine(e.Message);
		//	}
		//	catch (SMSApi.Api.ProxyException e)
		//	{
		//		Console.WriteLine(e.Message);
		//	}
		//}
    }
}
