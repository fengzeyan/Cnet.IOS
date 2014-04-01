using Cnt.API.Services.NTMobile;

namespace Cnt.API
{
	public class Client
	{
		public Client(string userName, string password)
		{
			this.UserName = userName;
			this.Password = password;

			ApplicationLoadService = new ApplicationLoadService(this);
			AuthenticateService = new AuthenticateService(this);
			AvailabilityService = new AvailabilityService(this);
			CurrentPayPeriodService = new CurrentPayPeriodService(this);
			MobileCarrierService = new MobileCarrierService(this);
			NotificationService = new NotificationService(this);
			OfficeService = new OfficeService(this);
			PlacementService = new PlacementService(this);
			TimesheetService = new TimesheetService(this);
			UserService = new UserService(this); 
		}
		
		public string UserName { get; set; }
		public string Password { get; set; }

		public ApplicationLoadService ApplicationLoadService { get; private set; }

		public AuthenticateService AuthenticateService { get; private set; }

		public AvailabilityService AvailabilityService { get; private set; }

		public CurrentPayPeriodService CurrentPayPeriodService { get; private set; }

		public MobileCarrierService MobileCarrierService { get; private set; }

		public NotificationService NotificationService { get; private set; }

		public OfficeService OfficeService { get; private set; }

		public PlacementService PlacementService { get; private set; }

		public TimesheetService TimesheetService { get; private set; }

		public UserService UserService { get; private set; }
	}
}
