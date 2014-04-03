namespace Cnt.API
{
	public struct Constants
	{
#if RELEASE
		public const string CNTAPI_BASEURL = "https://api.collegenannies.com";
#elif STAGING
		public const string CNTAPI_BASEURL = "http://api.collegenannies.winpreview.servers.dakotacloud.com";
#else
		public const string CNTAPI_BASEURL = "http://api.collegenannies.scott.dev.onsharp.com";
#endif
		public const string NTMOBILE_BASEURL = CNTAPI_BASEURL + "/nt-mobile";

		public const string NTMOBILE_APPLICATION_ID = "nt-mobile";
		public const string NTMOBILE_APPLICATION_KEY = "07052D3D-19EB-4E22-8650-828B02778663";
	}
}
